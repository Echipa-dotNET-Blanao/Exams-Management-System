using ExamManagement.Core.SharedKernel;

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
        
        public string studentId { set; get; }
        public int examId { set; get; }
        public float grade { set; get; }
        public int reevaluationClosed { set; get; }
        public int final { set; get; }
        public int reevaluationRequested { set; get; }
        public int pages { set; get; }
        public int present { set; get; }
    }
}