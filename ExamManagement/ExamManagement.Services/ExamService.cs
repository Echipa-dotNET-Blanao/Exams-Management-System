using System;
using System.Collections.Generic;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Enums;
using ExamManagement.Core.Interfaces.Repositories;
using ExamManagement.Core.Interfaces.Services;

namespace ExamManagement.Services
{
    public class ExamService : IExamService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IExamRepository _examRepository;
        private readonly IGradeRepository _gradeRepostory;
        private readonly IMailService _mailService;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IDidacticRepository _didacticRepository;

        public ExamService(IExamRepository examRepository, IGradeRepository gradeRepository,
            ICourseRepository courseRepository, IStudentRepository studentRepository,
            IMailService mailService, ITeacherRepository teacherRepository, IDidacticRepository didacticRepository)
        {
            _examRepository = examRepository;
            _gradeRepostory = gradeRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _didacticRepository = didacticRepository;
            _mailService = mailService;
        }

        public void CreateExam(Exam exam)
        {
            if (_examRepository.GetById(exam.Id) != null) throw new ArgumentOutOfRangeException();
            _examRepository.Add(exam);

            foreach (var stud in _studentRepository.GetAll())
                foreach (var course in _courseRepository.GetAll())
                    if (stud.StudyYear == course.StudyYear && course.Id == exam.CourseId)
                    {
                        var grade = new Grade(stud.Id, exam.Id, 0, 0);
                        _gradeRepostory.Add(grade);
                    }
        }

        public void StartExam(int examId)
        {
            var exam = _examRepository.GetById(examId);

            if (exam == null) throw new ArgumentOutOfRangeException();
            if (exam.Started) throw new ArgumentOutOfRangeException();

            var token = "";
            var r = new Random();
            for (var i = 0; i < 8; i++)
            {
                char c;
                var character = r.Next(0, 61);
                if (character <= 25)
                    c = (char)(65 + character);
                else if (character <= 51)
                    c = (char)(97 + character - 26);
                else
                    c = (char)(48 + character - 52);
                token += c;
            }

            exam.Started = true;
            exam.Token = token;
            _examRepository.Update(exam.Id, exam);
        }

        public void CloseExam(int examId)
        {
            var exam = _examRepository.GetById(examId);

            if (exam == null) throw new ArgumentOutOfRangeException();
            if (!exam.Started) throw new ArgumentOutOfRangeException();
            if (exam.Finished) throw new ArgumentOutOfRangeException();

            exam.Finished = true;
            _examRepository.Update(exam.Id, exam);
        }


        public void PublishGrades(int examId)
        {
            var selectedExam = _examRepository.GetById(examId);

            if (selectedExam == null) throw new ArgumentOutOfRangeException();
            if (!selectedExam.Started) throw new ArgumentOutOfRangeException();
            if (!selectedExam.Finished) throw new ArgumentOutOfRangeException();

            selectedExam.GradesPublished = true;
            foreach (var student in _studentRepository.GetAll())
                foreach (var course in _courseRepository.GetAll())
                {
                    if (student.StudyYear != course.StudyYear) continue;
                    foreach (var exam in _examRepository.GetAll())
                    {
                        if (exam.CourseId != course.Id || exam.Id != examId) continue;
                        foreach (var grade in _gradeRepostory.GetAll())
                        {
                            if (grade.ExamId != exam.Id || grade.StudentId != student.Id) continue;
                            _mailService.SendEmail(student.Email, $"Your grade on {course.Title}",
                                $"Your paper has been graded with {grade.GradeValue} points!");
                        }
                    }
                }
        }

        public void ManageExam(int examId, ManageExamTask task)
        {
            if (_examRepository.GetById(examId) == null) throw new ArgumentOutOfRangeException();

            switch (task)
            {
                case ManageExamTask.Start:
                    StartExam(examId);
                    break;
                case ManageExamTask.End:
                    CloseExam(examId);
                    break;
                case ManageExamTask.PublishGrades:
                    PublishGrades(examId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(task), task, null);
            }
        }

        public List<StudentExam> GetAllStudentExams(string studentId)
        {
            var studentExams = new List<StudentExam>();
            var student = _studentRepository.GetById(studentId);
            var grades = _gradeRepostory.GetAll();
            var studentGrades = new List<Grade>();
            foreach (var grade in grades)
            {
                if (grade.StudentId == studentId)
                {
                    var studentExam = new StudentExam();
                    var exam = _examRepository.GetById(grade.ExamId);
                    studentExam.Id = exam.Id;
                    studentExam.StudentGrade = grade.GradeValue;
                    studentExam.StartTime = exam.StartTime;
                    studentExam.EndTime = exam.EndTime;
                    studentExam.ReevaluationEndTime = exam.ReevaluationEndDate;
                    studentExam.Started = exam.Started;
                    studentExam.Finished = exam.Finished;
                    studentExam.CorrectionScorePublished = exam.CorrectionScorePublished;
                    studentExam.CorrectionScoreLink = "www.google.com"; //TODO in db
                    studentExam.GradesPublished = exam.GradesPublished;
                    studentExam.StudentGrade = grade.GradeValue;
                    studentExam.MedianGrade = 0f; //TODO
                    studentExam.Room = exam.Room;
                    studentExam.Present = grade.Present;
                    studentExam.ReevaluationClosed = grade.ReevaluationClosed;

                    foreach (var course in _courseRepository.GetAll())
                    {
                        if (course.Id == exam.CourseId)
                        {
                            studentExam.CourseId = course.Id;
                            studentExam.CourseName = course.Title;
                            break;
                        }
                    }

                    foreach (var teacher in _teacherRepository.GetAll())
                    {
                        foreach (var didactic in _didacticRepository.GetAll())
                        {
                            if (teacher.Id == didactic.TeacherId && didactic.CourseId == studentExam.CourseId)
                            {
                                studentExam.TeacherID = teacher.Id;
                                studentExam.TeacherName = teacher.FullName;
                                break;
                            }
                        }
                    }

                    studentExams.Add(studentExam);
                }

            }
            return studentExams;
        }
    }
}