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
            _dbContext.Set<Exam>().Add(exam);
            _dbContext.SaveChanges();
        }

        public void StartExam(int examID)
        {
            throw new System.NotImplementedException();
        }

        public void CloseExam(int examID)
        {
            throw new System.NotImplementedException();
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