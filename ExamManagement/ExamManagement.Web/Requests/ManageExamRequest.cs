using ExamManagement.Core.Interfaces.Repositories;

namespace ExamManagement.Web.Requests
{

    public class ManageExamRequest
    {
        public int ExamID { get; set; }
        public ManageExamTask Task { get; set; }
        //enum
    }
}
