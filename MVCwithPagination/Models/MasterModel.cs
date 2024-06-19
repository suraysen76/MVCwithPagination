using System.Collections.Generic;

namespace MVCwithPagination.Models
{
    public class MasterModel
    {
        public PagingModel Paging { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
    }
}