using System.Collections.Generic;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Services;
using ExamManagement.Core.Interfaces.Repositories;

namespace ExamManagement.Services
{
    public class GradeService : IGradeService
    {
        private IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public Grade GetGradeByStudentId(string studentId, int examId)
        {
            List<Grade> allGrades = _gradeRepository.GetAll();
            foreach (var grade in allGrades)
            {
                if (grade.studentId == studentId && grade.examId == examId)
                {
                    return grade;
                }
            }
            throw new KeyNotFoundException();
        }

        public void CreateGrade(Grade grade)
        {
            _gradeRepository.Add(grade);
        }

        public void SetGrade(int gradeId, float value)
        {
            Grade newGrade = _gradeRepository.GetById(gradeId);
            newGrade.grade = value;
            _gradeRepository.Update(newGrade.id, newGrade);
        }

        public Grade GetGradeByGradeId(int gradeId)
        {
            return _gradeRepository.GetById(gradeId);
        }
    }
}