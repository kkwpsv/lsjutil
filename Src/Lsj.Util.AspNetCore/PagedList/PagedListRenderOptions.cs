namespace Lsj.Util.AspNetCore.PagedList
{
    /// <summary>
    /// RenderMode
    /// </summary>
    public enum RenderMode
    {
        /// <summary>
        /// Always render.
        /// </summary>
        Always,

        /// <summary>
        /// Never render.
        /// </summary>
        Never,

        /// <summary>
        /// Render if needed
        /// </summary>
        IfNeeded
    }

    /// <summary>
    /// PagedListRenderOptions
    /// </summary>
    public class PagedListRenderOptions
    {
        /// <summary>
        /// Max Page Count
        /// </summary>
        public int MaxPageCount { get; set; } = 10;

        /// <summary>
        /// Render First Page
        /// </summary>
        public RenderMode RenderFirstPage { get; set; } = RenderMode.Always;

        /// <summary>
        /// Render Last Page
        /// </summary>
        public RenderMode RenderLastPage { get; set; } = RenderMode.Always;

        /// <summary>
        /// Link To First Page Text
        /// </summary>
        public string LinkToFirstPageText { get; set; } = "««";

        /// <summary>
        /// Link To Previous Page Text
        /// </summary>
        public string LinkToPreviousPageText { get; set; } = "«";

        /// <summary>
        /// Link To Next Page Text
        /// </summary>
        public string LinkToNextPageText { get; set; } = "»";

        /// <summary>
        /// Link To Last Page Text
        /// </summary>
        public string LinkToLastPageText { get; set; } = "»»";

        /// <summary>
        /// Ul Css Classes
        /// </summary>
        public string[] UlClasses { get; set; } = new[] { "pagination" };

        /// <summary>
        /// Li Css Classes
        /// </summary>
        public string[] LiClasses { get; set; } = new[] { "page-item" };

        /// <summary>
        /// A Css Classes
        /// </summary>
        public string[] AClasses { get; set; } = new[] { "page-link" };
    }
}