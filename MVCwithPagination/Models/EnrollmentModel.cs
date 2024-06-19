using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCwithPagination.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class EnrollmentModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual CourseModel Course { get; set; }
        public virtual StudentModel Student { get; set; }
    }
}