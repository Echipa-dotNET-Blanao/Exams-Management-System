using System;
using System.Security.Cryptography;

namespace ExamManagement.Core.Entities
{
    public class Exam
    {

        public Exam(int courseId, DateTime examDate, string room, DateTime startTime, DateTime endTime,
            string type, int correctionScorePublished)
        {
            //this.id = id;
            id = 50;
            this.courseId = courseId;
            this.examDate = examDate;
            this.room = room;
            this.startTime = startTime;
            this.endTime = endTime;
            this.type = type;
            Random random = new Random();
            this.token = random.Next(11111111, 99999999);
            this.correctionScorePublished = correctionScorePublished;
        }
        
        public int id { set; get; }
        public int courseId { set; get; }
        public DateTime examDate { set; get; }
        public string room { set; get; }
        public DateTime startTime { set; get; }
        public DateTime endTime { set; get; }
        public string type { set; get; }
        public int token { set; get; }
        public int finished { set; get; }
        public int correctionScorePublished { set; get; }
        public int gradesPublished { set; get; }
    }
}