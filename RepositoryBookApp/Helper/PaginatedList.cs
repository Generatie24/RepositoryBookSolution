namespace RepositoryBookApp.Helper
{
    public class PaginatedList<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
        }

        public bool HasPreviousPage => PageIndex > 1; 
        public bool HasNextPage => PageIndex < TotalPages;
    }
}
