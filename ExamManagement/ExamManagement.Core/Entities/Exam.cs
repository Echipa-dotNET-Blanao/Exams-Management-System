using System;
using System.ComponentModel.DataAnnotations;

namespace ExamManagement.Core.Entities
{
    public class Exam
    {
        public Exam(int courseId, DateTime examDate, string room, DateTime startTime, DateTime endTime,
            DateTime reevaluationEndDate,
            char type, bool correctionScorePublished)
        {
            Id = Id;
            CourseId = courseId;
            ExamDate = examDate;
            Room = room;
            StartTime = startTime;
            EndTime = endTime;
            Type = type;
            CorrectionScorePublished = correctionScorePublished;
            ReevaluationEndDate = reevaluationEndDate;
        }

        [Key] public int Id { set; get; }

        public int CourseId { set; get; }
        public DateTime ExamDate { set; get; }
        public string Room { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
        public DateTime ReevaluationEndDate { set; get; }
        public char Type { set; get; }
        public bool Started { set; get; }
        public string Token { set; get; }
        public bool Finished { set; get; }
        public bool CorrectionScorePublished { set; get; }
        public bool GradesPublished { set; get; }
    }
}