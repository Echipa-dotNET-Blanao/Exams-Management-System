using System.Linq;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces.Repositories;
using System.Collections.Generic;

namespace ExamManagement.Infrastructure.Data
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _dbContext;

        public ExamRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(Exam exam)
        {
            _dbContext.Add(exam);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Exam exam = GetById(id);
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
                                          where exam.id == id
                                          select exam;

            return examQuery.FirstOrDefault();
        }

        public void Update(int id, Exam exam)
        {
            Exam originalExam = GetById(id);
            originalExam.id = exam.id;
            originalExam.courseId = exam.courseId;
            originalExam.examDate = exam.examDate;
            originalExam.room = exam.room;
            originalExam.startTime = exam.startTime;
            originalExam.endTime = exam.endTime;
            originalExam.reevaluationEndDate = exam.reevaluationEndDate;
            originalExam.type = exam.type;
            originalExam.started = exam.started;
            originalExam.token = exam.token;
            originalExam.finished = exam.finished;
            originalExam.correctionScorePublished = exam.correctionScorePublished;
            originalExam.gradesPublished = exam.gradesPublished;
            _dbContext.SaveChanges();
        }
    }
}