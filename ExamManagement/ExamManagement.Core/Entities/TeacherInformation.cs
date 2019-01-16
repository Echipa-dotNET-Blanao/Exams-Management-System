using ExamManagement.Core.Entities;
using System.Collections.Generic;

namespace ExamManagement.Core.Entities
{
    public class TeacherInformation
    {
        public string FullName { get; set; }
        public List<Course> Courses { get; set; }
    }
    public class TeacherGrade
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public int GradeId { get; set; }
        public float GradeValue { get; set; }
    }
}