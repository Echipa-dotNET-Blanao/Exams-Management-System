using ExamManagement.Core.Entities;

namespace ExamManagement.Core.Interfaces
{
    public interface IStudentRepository
    {

        void MarkPresenceById(char id);
    }
}