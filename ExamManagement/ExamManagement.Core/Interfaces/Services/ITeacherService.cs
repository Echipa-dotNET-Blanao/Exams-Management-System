using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces.Services
{
    public interface ITeacherService
    {
        Teacher GetTeacherById(int teacherId);
        TeacherInformation GetTeacherInformation(Teacher teacher);
    }
}