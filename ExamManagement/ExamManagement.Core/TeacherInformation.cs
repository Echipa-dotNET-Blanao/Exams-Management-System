using ExamManagement.Core.Entities;
using System.Collections.Generic;

namespace ExamManagement.Core
{
    public class TeacherInformation
    {
        public string FullName { get; set; }
        public List<Course> Courses { get; set; }
    }
}