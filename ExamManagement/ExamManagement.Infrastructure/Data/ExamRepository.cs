using System.Linq;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces;
using ExamManagement.Core.Services;
using System;
using System.Linq;

namespace ExamManagement.Infrastructure.Data
{
    public class ExamRepository : IExamRepository

    {
        private readonly AppDbContext _dbContext;

        public ExamRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void CreateExam(Exam exam)
        {

            int index = 0;
            
            _dbContext.Set<Exam>().Add(exam);

            var assignedStudents = (from students in _dbContext.Students
                join courses in _dbContext.Courses on students.studyYear equals courses.studyYear
                select students);


            foreach (var student in assignedStudents)
            {
                Grade grade = new Grade(student.id, exam.courseId, 0, 0);
                _dbContext.Add(grade);
            }
            
            
            _dbContext.SaveChanges();
            
        }

        public void StartExam(int examId)
        {
            Exam exams = (from exam in _dbContext.Exams
                where exam.id == examId
                select exam).SingleOrDefault();

            exams.started = true;

            _dbContext.SaveChanges();

        }

        public void CloseExam(int examId)
        {
            Exam exams = (from exam in _dbContext.Exams
                where exam.id == examId
                select exam).SingleOrDefault();

            exams.finished = true;

            _dbContext.SaveChanges();
        }

        public void PublishGrades(int examID)
        {
            var selectedExam = from exam in _dbContext.Exams
                               where exam.id == examID
                               select exam;
            selectedExam.FirstOrDefault().gradesPublished = true;
            var eligibleStudents = (from student in _dbContext.Students
                                    join course in _dbContext.Courses on student.studyYear equals course.studyYear
                                    join exam in _dbContext.Exams on course.id equals exam.courseId
                                    join grade in _dbContext.Grades on exam.id equals grade.examId
                                    where student.studyYear == course.studyYear && course.id == exam.courseId && exam.id == grade.examId
                                    && student.id == grade.studentId && exam.id == examID
                                    select new { student, grade, course }).Distinct();
            foreach (var tuple in eligibleStudents)
            {
                MailService.SendEmail(tuple.student.email, $"Your grade on {tuple.course.title}",
                    $"Your paper has been graded with {tuple.grade.grade} points!");
            }
            _dbContext.SaveChanges();
        }
    }
}