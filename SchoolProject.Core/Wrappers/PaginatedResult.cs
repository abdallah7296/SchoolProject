namespace SchoolProject.Core.Wrappers
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(List<T> data)
        {
            Data = data;

        }
        public List<T> Data { get; set; }

        internal PaginatedResult(bool succeeded, List<T> data = default, List<string> message = null, int count = 0, int page = 1, int pageSize = 10)
        {
            Data = data;
            CurrentPage = page;
            Succeeded = succeeded;
            PageSize = pageSize;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
        }
        public static PaginatedResult<T> Success(List<T> data, int count, int page, int pagesize)
        {
            return new(true, data, null, page, pagesize);
        }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPage;
        public List<string> Massages { get; set; }
        public bool Succeeded { get; set; }
        public object meta { get; set; }

    }
}
