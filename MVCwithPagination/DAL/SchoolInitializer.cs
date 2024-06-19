using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCwithPagination.Models;

namespace MVCwithPagination.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<StudentModel>
            {
            new StudentModel{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new StudentModel{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new StudentModel{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new StudentModel{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new StudentModel{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new StudentModel{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new StudentModel{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new StudentModel{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
            var courses = new List<CourseModel>
            {
            new CourseModel{CourseId=1050,CourseTitle="Chemistry",Credits=3,},
            new CourseModel{CourseId=4022,CourseTitle="Microeconomics",Credits=3,},
            new CourseModel{CourseId=4041,CourseTitle="Macroeconomics",Credits=3,},
            new CourseModel{CourseId=1045,CourseTitle="Calculus",Credits=4,},
            new CourseModel{CourseId=3141,CourseTitle="Trigonometry",Credits=4,},
            new CourseModel{CourseId=2021,CourseTitle="Composition",Credits=3,},
            new CourseModel{CourseId=2042,CourseTitle="Literature",Credits=4,}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            var enrollments = new List<EnrollmentModel>
            {
            new EnrollmentModel{StudentID=1,CourseId=1050,Grade=Grade.A},
            new EnrollmentModel{StudentID=1,CourseId=4022,Grade=Grade.C},
            new EnrollmentModel{StudentID=1,CourseId=4041,Grade=Grade.B},
            new EnrollmentModel{StudentID=2,CourseId=1045,Grade=Grade.B},
            new EnrollmentModel{StudentID=2,CourseId=3141,Grade=Grade.F},
            new EnrollmentModel{StudentID=2,CourseId=2021,Grade=Grade.F},
            new EnrollmentModel{StudentID=3,CourseId=1050},
            new EnrollmentModel{StudentID=4,CourseId=1050,},
            new EnrollmentModel{StudentID=4,Id=4022,Grade=Grade.F},
            new EnrollmentModel{StudentID=5,Id=4041,Grade=Grade.C},
            new EnrollmentModel{StudentID=6,Id=1045},
            new EnrollmentModel{StudentID=7,Id=3141,Grade=Grade.A},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}