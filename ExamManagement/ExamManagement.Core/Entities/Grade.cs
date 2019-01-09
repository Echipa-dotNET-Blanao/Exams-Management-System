using System.ComponentModel.DataAnnotations;
using ExamManagement.Core.SharedKernel;

namespace ExamManagement.Core.Entities
{
    public class Grade : BaseEntity
    {
        public Grade(string studentId, int examId, float grade, int pages)
        {
            StudentId = studentId;
            ExamId = examId;
            GradeValue = grade;
            Pages = pages;
        }

        [Key] public int Id { set; get; }

        public string StudentId { set; get; }
        public int ExamId { set; get; }
        public float GradeValue { set; get; }
        public bool ReevaluationClosed { set; get; }
        public bool Final { set; get; }
        public bool ReevaluationRequested { set; get; }
        public int Pages { set; get; }
        public bool Present { set; get; }
    }
}