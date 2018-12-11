using System.ComponentModel.DataAnnotations;

namespace ExamManagement.Core.Entities
{
    public class Course
    {
        public Course(int id, string title, int studyYear, int semester)
        {
            this.id = id;
            this.title = title;
            this.studyYear = studyYear;
            this.semester = semester;
        }
        [Key]
        public int id { set; get; }
        public string title { set; get; }
        public int studyYear { set; get; }
        public int semester { set; get; }
    }
}