﻿namespace ExamManagement.Core.Requests
{
    public class MarkPresenceRequest
    {
        public string StudentID { get; set; }
        public int ExamID { get; set; }
        public int Token { get; set; }
    }
}