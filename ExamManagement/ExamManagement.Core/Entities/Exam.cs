using System;

namespace ExamManagement.Core.Entities
{
    public class Exam
    {

        public Exam(int id, int courseId, DateTime examDate, string room, DateTime startTime, DateTime endTime,
            string type)
        {
            this.id = id;
            this.courseId = courseId;
            this.examDate = examDate;
            this.room = room;
            this.startTime = startTime;
            this.endTime = endTime;
            this.type = type;
        }
        
        public int id { set; get; }
        public int courseId { set; get; }
        public DateTime examDate { set; get; }
        public string room { set; get; }
        public DateTime startTime { set; get; }
        public DateTime endTime { set; get; }
        public string type { set; get; }
        public string token { set; get; }
        public bool finished { set; get; }
        public bool correctionScorePublished { set; get; }
        public bool gradesPublished { set; get; }
    }
}