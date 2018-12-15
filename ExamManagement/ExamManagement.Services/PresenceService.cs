using ExamManagement.Core.Interfaces.Services;
using ExamManagement.Core.Interfaces.Repositories;

namespace ExamManagement.Services
{
    public class PresenceService : IPresenceService
    {
        private IGradeRepository _gradeRepository;
        private IExamRepository _examRepository;

        public PresenceService(IGradeRepository gradeRepository, IExamRepository examRepository)
        {
            _examRepository = examRepository;
            _gradeRepository = gradeRepository;
        }
        public void MarkStudentPresent(string studentId, int examId, string token)
        {
            //Temporary until we make the repository great again
            var examToken = "";
            //var examToken = (from exam in _dbContext.Exams
            //                 where exam.id == examId
            //                 select exam.token).FirstOrDefault();
            if (examToken == token)
            {
                var studentGrade = new GradeService(_gradeRepository).GetGradeByStudentId(studentId, examId);
                studentGrade.present = true;
                _gradeRepository.Update(studentGrade.id, studentGrade);
            }
        }
    }
}