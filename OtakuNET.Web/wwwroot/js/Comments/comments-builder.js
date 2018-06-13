var Comment = Backbone.Model.extend({
    defaults: {
        login: '',
        avatarSrc: '/images/missing-square.jpg',
        timestamp: '',
        text: ''
    }
});

var CommentList = Backbone.Collection.extend({
    model: Comment
});

var AppModel = Backbone.Model.extend({
    initialize: function () {
        this.comments = new CommentList();
    }
})

var AppController = Backbone.Router.extend({
    initialize: function () {
        this.model = new AppModel();
        this.view = new CommentsContainerView({ model: this.model });
        this.view.setup();
        this.updateModel();
        window._controller = this;
        setInterval(function () {
            window._controller.updateModel();
        }, 1000);
    },
    addComment: function (text, contentType, contentKey) {
        $.getJSON('/api/comments/send/' + contentType + '/' + contentKey + '/' + text, this._addComment);
    },
    _addComment: function (comment) {
        window._controller.model.comments.add(comment);
    },
    updateModel: function () {
        $.getJSON('/api/comments/get/' + getContentType() + '/' + getContentKey(), this._updateModel);
    },
    _updateModel: function (comments) {
        window._controller.model.comments.reset(comments);
    }
});

function getContentType() {
    var el = $('#contentType');
    var val = el.val();
    return val;
};
function getContentKey() {
    return $('#contentKey').val();
}

var CommentsContainerView = Backbone.View.extend({
    initialize: function () {
        this.model.comments.on('add', this.add, this);
        this.model.comments.on('reset', this.reset, this);
        window._view = this;
    },
    add: function (comment) {
        var view = new CommentView({ model: comment });
        $(this.el).append(view.render().el);
    },
    reset: function (comments) {
        this.setup();
        comments.forEach(function (comment) {
            window._view.add(comment);
        })
    },
    setup: function () {
        this.el = $('#comments__container');
        this.el.html('');
        return this;
    }
});

var CommentView = Backbone.View.extend({
    template: {
        'comment': _.template($('#comment-template').html())
    },
    render: function () {
        $(this.el).html(this.template['comment'](this.model.toJSON()));
        return this;
    }
});
