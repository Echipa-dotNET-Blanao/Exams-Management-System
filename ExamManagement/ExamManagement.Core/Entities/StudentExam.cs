using System;

namespace ExamManagement.Core.Entities
{
    public class StudentExam
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ReevaluationEndTime { get; set; }
        public bool Started { get; set; }
        public bool Finished { get; set; }
        public bool CorrectionScorePublished { get; set; }
        public string CorrectionScoreLink { get; set; }
        public bool GradesPublished { get; set; }
        public float StudentGrade { get; set; }
        public float MedianGrade { get; set; }
        public string TeacherName { get; set; }
        public int TeacherID { get; set; }
        public string Room { get; set; }
        public bool Present { get; set; }
        public bool ReevaluationClosed { get; set; }
    }
}