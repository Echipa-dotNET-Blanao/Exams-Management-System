namespace ExamManagement.Web.Requests
{
    public class MarkPresenceRequest
    {
        public string StudentId { get; set; }
        public int ExamId { get; set; }
        public string Token { get; set; }
    }
}