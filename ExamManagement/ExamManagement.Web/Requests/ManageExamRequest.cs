namespace ExamManagement.Web.Requests
{

    public class ManageExamRequest
    {
        public int ExamID { get; set; }
        public Core.Interfaces.Enums.ManageExamTask Task { get; set; }
        //enum
    }
}
