using ExamManagement.Core.Interfaces.Services;
using ExamManagement.Web.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        
        [HttpGet]
        public JsonResult GetTeacherInformation([FromQuery] GetTeacherInformationRequest getTeacherInformationRequest)
        {
            return Json(_teacherService.GetTeacherInformation(_teacherService.GetTeacherById(getTeacherInformationRequest.TeacherID)));
        }
    }
}