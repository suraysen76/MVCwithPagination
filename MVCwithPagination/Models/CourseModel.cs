using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCwithPagination.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        [DisplayName("Course Id")]
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<EnrollmentModel> Grades { get; set; }
    }
}