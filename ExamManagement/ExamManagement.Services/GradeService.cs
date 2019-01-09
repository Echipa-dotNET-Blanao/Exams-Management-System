using System;
using System.Collections.Generic;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Repositories;
using ExamManagement.Core.Interfaces.Services;

namespace ExamManagement.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        // Defensive coding -> move logic from controller to service

        public Grade GetGradeByStudentId(string studentId, int examId)
        {
            if (studentId == null) throw new ArgumentNullException(nameof(studentId));
            if (examId <= 0) throw new ArgumentOutOfRangeException(nameof(examId));

            var allGrades = _gradeRepository.GetAll();

            foreach (var grade in allGrades)
                if (grade.StudentId == studentId && grade.ExamId == examId)
                    return grade;
            throw new KeyNotFoundException();
        }

        public void CreateGrade(Grade grade)
        {
            _gradeRepository.Add(grade);
        }

        public void SetGrade(int gradeId, float value)
        {
            if (gradeId <= 0) throw new ArgumentOutOfRangeException(nameof(gradeId));
            if (value <= 0.0) throw new ArgumentOutOfRangeException(nameof(gradeId));

            var newGrade = _gradeRepository.GetById(gradeId);
            newGrade.GradeValue = value;
            _gradeRepository.Update(newGrade.Id, newGrade);
        }

        public Grade GetGradeByGradeId(int gradeId)
        {
            return _gradeRepository.GetById(gradeId);
        }
    }
}