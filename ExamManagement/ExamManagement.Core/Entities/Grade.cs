using ExamManagement.Core.SharedKernel;

namespace ExamManagement.Core.Entities
{
    public class Grade : BaseEntity
    {

        public Grade(string studentId, int examId, int grade, int pages)
        {
            this.studentId = studentId;
            this.examId = examId;
            this.grade = grade;
            this.pages = pages;
        }
        
        public string studentId { set; get; }
        public int examId { set; get; }
        public int grade { set; get; }
        public bool reevaluationClosed { set; get; }
        public bool final { set; get; }
        public bool reevaluationRequested { set; get; }
        public int pages { set; get; }
    }
}