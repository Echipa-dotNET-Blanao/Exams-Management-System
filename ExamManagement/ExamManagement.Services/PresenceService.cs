using ExamManagement.Core.Interfaces.Services;
using ExamManagement.Core.Interfaces.Repositories;

namespace ExamManagement.Services
{
    public class PresenceService : IPresenceService
    {
        private IGradeRepository _gradeRepository;
        private readonly IExamRepository _examRepository;

        public PresenceService(IGradeRepository gradeRepository, IExamRepository examRepository)
        {
            _examRepository = examRepository;
            _gradeRepository = gradeRepository;
        }

        public void MarkStudentPresent(string studentId, int examId, string token)
        {
            if (studentId == null || examId <= 0 || token == null || _examRepository.GetById(examId) == null)
            {
                throw new System.ArgumentNullException(nameof(studentId));
            }

            var examToken = _examRepository.GetById(examId).token;

            if (examToken == token)
            {
                var studentGrade = new GradeService(_gradeRepository).GetGradeByStudentId(studentId, examId);
                studentGrade.present = true;
                _gradeRepository.Update(studentGrade.id, studentGrade);
            }
        }
    }
}