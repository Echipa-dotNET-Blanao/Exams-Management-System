using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Repositories;
using ExamManagement.Core.Interfaces.Services;
using ExamManagement.Core.Interfaces.Enums;
using System;
namespace ExamManagement.Services
{
    public class ExamService : Core.Interfaces.Services.IExamService
    {
        private IExamRepository _examRepository;
        private IGradeRepository _gradeRepostory;
        private ICourseRepository _courseRepository;
        private IStudentRepository _studentRepository;
        private IMailService _mailService;

        public ExamService(IExamRepository examRepository, IGradeRepository gradeRepository,
            ICourseRepository courseRepository, IStudentRepository studentRepository,
            IMailService mailService)
        {
            _examRepository = examRepository;
            _gradeRepostory = gradeRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _mailService = mailService;
        }
        public void CreateExam(Exam exam)
        {
            if (_examRepository.GetById(exam.id) != null) throw new ArgumentOutOfRangeException();
            _examRepository.Add(exam);

            foreach (var stud in _studentRepository.GetAll())
            {
                foreach (var course in _courseRepository.GetAll())
                {
                    if (stud.studyYear == course.studyYear && course.id == exam.id)
                    {
                        Grade grade = new Grade(stud.id, exam.courseId, 0, 0);
                        _gradeRepostory.Add(grade);
                        continue;
                    }
                }
            }
        }

        public void StartExam(int examId)
        {
            Exam exam = _examRepository.GetById(examId);

            if (exam == null) throw new ArgumentOutOfRangeException();
            if (exam.started) throw new ArgumentOutOfRangeException();

            string token = "";
            System.Random r = new System.Random();
            for (int i = 0; i < 8; i++)
            {
                char c = ' ';
                int character = r.Next(0, 61);
                if (character <= 25)
                {
                    c = (char)(65 + character);
                }
                else if (character <= 51)
                {
                    c = (char)(97 + character - 26);
                }
                else
                {
                    c = (char)(48 + character - 52);
                }
                token += c;
            }
            exam.started = true;
            exam.token = token;
            _examRepository.Update(exam.id, exam);
        }

        public void CloseExam(int examId)
        {
            Exam exam = _examRepository.GetById(examId);

            if (exam == null) throw new ArgumentOutOfRangeException();
            if (!exam.started) throw new ArgumentOutOfRangeException();
            if (exam.finished) throw new ArgumentOutOfRangeException();

            exam.finished = true;
            _examRepository.Update(exam.id, exam);
        }


        public void PublishGrades(int examID)
        {
            Exam selectedExam = _examRepository.GetById(examID);

            if (selectedExam == null) throw new ArgumentOutOfRangeException();
            if (!selectedExam.started) throw new ArgumentOutOfRangeException();
            if (!selectedExam.finished) throw new ArgumentOutOfRangeException();

            selectedExam.gradesPublished = true;
            foreach (var student in _studentRepository.GetAll())
            {
                foreach (var course in _courseRepository.GetAll())
                {
                    if (student.studyYear != course.studyYear) continue;
                    foreach (var exam in _examRepository.GetAll())
                    {
                        if (exam.courseId != course.id || exam.id != examID) continue;
                        foreach (var grade in _gradeRepostory.GetAll())
                        {
                            if (grade.examId != exam.id || grade.studentId != student.id) continue;
                            _mailService.SendEmail(student.email, $"Your grade on {course.title}",
                            $"Your paper has been graded with {grade.grade} points!");
                        }
                    }
                }
            }
        }
        // Eliminate the separate functionality of Start/Close Exam/Publish Grades 
        public void ManageExam(int examId, ManageExamTask task)
        {
            if (_examRepository.GetById(examId) == null) throw new ArgumentOutOfRangeException();
            if (!(task == ManageExamTask.Start || task == ManageExamTask.End || task == ManageExamTask.PublishGrades))
                throw new ArgumentOutOfRangeException();
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
            }
        }
    }
}