using System;
using System.Collections.Generic;
using System.Text;

namespace ExamManagement.Core.Requests
{
    public class CreateExamRequest
    {
        public int CourseId { get; set; }
        public DateTime ExamDate { get; set; }
        public string Room { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Type { get; set; }
        public string CorrectionScore { get; set}
    }
}
