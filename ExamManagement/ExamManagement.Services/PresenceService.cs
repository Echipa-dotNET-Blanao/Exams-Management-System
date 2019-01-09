using System;
using ExamManagement.Core.Interfaces.Repositories;
using ExamManagement.Core.Interfaces.Services;

namespace ExamManagement.Services
{
    public class PresenceService : IPresenceService
    {
        private readonly IExamRepository _examRepository;
        private readonly IGradeRepository _gradeRepository;

        public PresenceService(IGradeRepository gradeRepository, IExamRepository examRepository)
        {
            _examRepository = examRepository;
            _gradeRepository = gradeRepository;
        }

        public void MarkStudentPresent(string studentId, int examId, string token)
        {
            if (studentId == null || examId <= 0 || token == null || _examRepository.GetById(examId) == null)
                throw new ArgumentNullException(nameof(studentId));

            var examToken = _examRepository.GetById(examId).Token;

            if (examToken == token)
            {
                var studentGrade = new GradeService(_gradeRepository).GetGradeByStudentId(studentId, examId);
                studentGrade.Present = true;
                _gradeRepository.Update(studentGrade.Id, studentGrade);
            }
        }
    }
}