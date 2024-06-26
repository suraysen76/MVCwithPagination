﻿using System;
using System.Collections.Generic;

namespace MVCwithPagination.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<EnrollmentModel> Enrollments { get; set; }
    }
}