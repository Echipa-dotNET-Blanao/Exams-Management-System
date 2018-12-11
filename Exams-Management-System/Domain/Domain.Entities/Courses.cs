using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.Entities
{
    public class Courses
    {
        public Courses(int id, string title, int studyYear, int semester)
        {
            Id = id;
            Title = title;
            StudyYear = studyYear;
            Semester = semester;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int StudyYear { get; set; }
        public int Semester { get; set; }
    }
}
