using ExamManagement.Core.Interfaces.Enums;

namespace ExamManagement.Web.Requests
{
    public class ManageExamRequest
    {
        public int ExamId { get; set; }

        public ManageExamTask Task { get; set; }
    }
}