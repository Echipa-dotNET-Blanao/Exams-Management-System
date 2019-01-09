using System.ComponentModel.DataAnnotations;

namespace ExamManagement.Core.Entities
{
    public class Course
    {
        public Course(int id, string title, int studyYear, int semester)
        {
            Id = id;
            Title = title;
            StudyYear = studyYear;
            Semester = semester;
        }

        [Key] public int Id { set; get; }

        public string Title { set; get; }
        public int StudyYear { set; get; }
        public int Semester { set; get; }
    }
}