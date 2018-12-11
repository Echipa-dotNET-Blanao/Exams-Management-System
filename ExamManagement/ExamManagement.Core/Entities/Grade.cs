using ExamManagement.Core.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace ExamManagement.Core.Entities
{
    public class Grade : BaseEntity
    {

        public Grade(string studentId, int examId, float grade, int pages)
        {
            this.studentId = studentId;
            this.examId = examId;
            this.grade = grade;
            this.pages = pages;
        }
        [Key]
        public int id { set; get; }
        public string studentId { set; get; }
        public int examId { set; get; }
        public float grade { set; get; }
        public bool reevaluationClosed { set; get; }
        public bool final { set; get; }
        public bool reevaluationRequested { set; get; }
        public int pages { set; get; }
        public bool present { set; get; }
    }
}