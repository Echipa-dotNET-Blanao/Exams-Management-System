using System.Collections.Generic;
using System.Linq;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Repositories;

namespace ExamManagement.Infrastructure.Data
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _dbContext;

        public ExamRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Exam exam)
        {
            _dbContext.Add(exam);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var exam = GetById(id);
            _dbContext.Remove(exam);
            _dbContext.SaveChanges();
        }

        public List<Exam> GetAll()
        {
            IEnumerable<Exam> examQuery = from exam in _dbContext.Exams
                select exam;
            return examQuery.ToList();
        }

        public Exam GetById(int id)
        {
            IEnumerable<Exam> examQuery = from exam in _dbContext.Exams
                where exam.Id == id
                select exam;

            return examQuery.FirstOrDefault();
        }

        public void Update(int id, Exam exam)
        {
            var originalExam = GetById(id);
            originalExam.Id = exam.Id;
            originalExam.CourseId = exam.CourseId;
            originalExam.ExamDate = exam.ExamDate;
            originalExam.Room = exam.Room;
            originalExam.StartTime = exam.StartTime;
            originalExam.EndTime = exam.EndTime;
            originalExam.ReevaluationEndDate = exam.ReevaluationEndDate;
            originalExam.Type = exam.Type;
            originalExam.Started = exam.Started;
            originalExam.Token = exam.Token;
            originalExam.Finished = exam.Finished;
            originalExam.CorrectionScorePublished = exam.CorrectionScorePublished;
            originalExam.GradesPublished = exam.GradesPublished;
            _dbContext.SaveChanges();
        }
    }
}