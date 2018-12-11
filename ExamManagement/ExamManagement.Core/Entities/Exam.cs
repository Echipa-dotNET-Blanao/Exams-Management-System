using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ExamManagement.Core.Entities
{
    public class Exam
    {

        public Exam(int courseId, DateTime examDate, string room, DateTime startTime, DateTime endTime,
            char type, bool correctionScorePublished)
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
            this.token = random.Next(11111111, 99999999).ToString();
            this.correctionScorePublished = correctionScorePublished;
        }
        [Key]
        public int id { set; get; }
        public int courseId { set; get; }
        public DateTime examDate { set; get; }
        public string room { set; get; }
        public DateTime startTime { set; get; }
        public DateTime endTime { set; get; }
        public char type { set; get; }
        public string token { set; get; }
        public bool finished { set; get; }
        public bool correctionScorePublished { set; get; }
        public bool gradesPublished { set; get; }
    }
}