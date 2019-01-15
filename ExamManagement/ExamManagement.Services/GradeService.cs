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
        private readonly IExamRepository _examRepository;
        private readonly IStudentRepository _studentRepository;

        public GradeService(IGradeRepository gradeRepository, IExamRepository examRepository,
            IStudentRepository studentRepository)
        {
            _gradeRepository = gradeRepository;
            _examRepository = examRepository;
            _studentRepository = studentRepository;
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

        public List<TeacherGrade> GetAllExamGrades(int examId)
        {
            var teacherGrades = new List<TeacherGrade>();
            var exam = _examRepository.GetById(examId);
            foreach (var grade in _gradeRepository.GetAll())
            {
                if (grade.ExamId == exam.Id)
                {
                    foreach (var student in _studentRepository.GetAll())
                    {
                        if (student.Id == grade.StudentId)
                        {
                            var teacherGrade = new TeacherGrade();
                            teacherGrade.StudentId = student.Id;
                            teacherGrade.GradeValue = grade.GradeValue;
                            teacherGrade.StudentName = student.FullName;
                            teacherGrades.Add(teacherGrade);
                            break;
                        }
                    }
                }
            }
            return teacherGrades;
        }
    }
}