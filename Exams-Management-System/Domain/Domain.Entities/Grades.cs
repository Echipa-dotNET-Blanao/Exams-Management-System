namespace Domain.Domain.Entities
{
    public class Grades
    {
        
        public Grades(){}

        public Grades(char studentId, int examId, int grade, bool reevaluationClosed, bool final,
            bool reevaluationRequested, int pages)
        {
            this.studentId = studentId;
            this.examId = examId;
            this.grade = grade;
            this.reevaluationClosed = reevaluationClosed;
            this.final = final;
            this.reevaluationRequested = reevaluationRequested;
            this.pages = pages;
        }
        
        public char studentId { set; get; }
        public int examId { set; get; }
        public int grade { set; get; }
        public bool reevaluationClosed { set; get; }
        public bool final { set; get; }
        public bool reevaluationRequested { set; get; }
        public int pages { set; get; }
        
    }
}