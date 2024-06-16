using System.Collections.Generic;

namespace MVCwithPagination.Models
{
    public class MasterModel
    {
        public PagingModel Paging { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}