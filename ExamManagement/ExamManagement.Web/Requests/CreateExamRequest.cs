using System;

namespace ExamManagement.Web.Requests
{
    public class CreateExamRequest
    {
        public int CourseId { get; set; }
        public DateTime ExamDate { get; set; }
        public string Room { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CorrectionScorePostDate { get; set; }
        public char Type { get; set; }
        public bool CorrectionScore { get; set; }
    }
}