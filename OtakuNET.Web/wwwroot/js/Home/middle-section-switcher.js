var AppState = Backbone.Model.extend({
    default: {
        state: ""
    }
});

var Controller = Backbone.Router.extend({
    routes: {
        "!/": "anime",
        "!/anime": "anime",
        "!/manga": "manga"
    },
    anime: function () {
        appState.set({ state: "anime" });
    },
    manga: function () {
        appState.set({ state: "manga" });
    }
});

var View = Backbone.View.extend({
    el: $("#middle-section__container"),
    templates: {
        "anime": _.template($("#anime-template").html()),
        "manga": _.template($("#manga-template").html())
    },
    initialize: function () {
        this.model.on("change:state", this.render, this);
    },
    render: function () {
        $(this.el).html(this.templates[this.model.get("state")]);
    }
});

var appState = new AppState();
var controller = new Controller();
var view = new View({ model: appState });
 
appState.set({ state: "anime" });
Backbone.history.start();  
