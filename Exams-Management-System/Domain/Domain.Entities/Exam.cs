using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.Entities
{
    public class Exam
    {
        public Exam()
        {
        }

        public Exam(int examId, int courseId, DateTime date, string room, double gradesAverage, DateTime startTime,
            DateTime endTime)
        {
            ExamId = examId;
            CourseId = courseId;
            Date = date;
            Room = room;
            GradesAverage = gradesAverage;
            StartTime = startTime;
            EndTime = endTime;
        }

        public int ExamId { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public String Room { get; set; }
        public Double GradesAverage { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}