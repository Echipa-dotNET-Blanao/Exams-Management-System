using System;
using ExamManagement.Core.Interfaces.Repositories;
using ExamManagement.Core.Interfaces.Services;

namespace ExamManagement.Services
{
    public class PresenceService : IPresenceService
    {
        private readonly IExamRepository _examRepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly IGradeService _gradeService;

        public PresenceService(IGradeRepository gradeRepository, IExamRepository examRepository, IGradeService gradeService)
        {
            _examRepository = examRepository;
            _gradeRepository = gradeRepository;
            _gradeService = gradeService;
        }

        public void MarkStudentPresent(string studentId, int examId, string token)
        {
            if (studentId == null || examId <= 0 || token == null || _examRepository.GetById(examId) == null)
                throw new ArgumentNullException(nameof(studentId));

            var examToken = _examRepository.GetById(examId).Token;

            if (examToken == token)
            {
                var studentGrade = _gradeService.GetGradeByStudentId(studentId, examId);
                studentGrade.Present = true;
                _gradeRepository.Update(studentGrade.Id, studentGrade);
            }
        }
    }
}