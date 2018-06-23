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
        public int MaxPageNumber { get; set; } = 10;
        public RenderMode RenderFirstPage { get; set; } = RenderMode.Always;
        public RenderMode RenderLastPage { get; set; } = RenderMode.Always;
        public string LinkToFirstPageText { get; set; } = "««";
        public string LinkToPreviousPageText { get; set; } = "«";
        public string LinkToNextPageText { get; set; } = "»";
        public string LinkToLastPageText { get; set; } = "»»";
        public string[] UlClasses { get; set; } = new[] { "pagination" };
    }
}