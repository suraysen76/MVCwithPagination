namespace MVCwithPagination.Models
{
    public class PagingModel
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }
}