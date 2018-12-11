using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces;

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
            throw new System.NotImplementedException();
        }

        public void StartExam(Exam exam)
        {
            throw new System.NotImplementedException();
        }

        public void CloseExam(Exam exam)
        {
            throw new System.NotImplementedException();
        }
    }
}