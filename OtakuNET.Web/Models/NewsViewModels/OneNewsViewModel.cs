namespace OtakuNET.Web.Models.NewsViewModels
{
    public class OneNewsViewModel : OneNewsBaseViewModel
    {
        public string Text { get; set; }

        public OneNewsViewModel()
            => Tag = Tag.News;
    }
}
