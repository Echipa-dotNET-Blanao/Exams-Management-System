using System.Linq;
using ExamManagement.Core.Entities;
using ExamManagement.Core.Interfaces;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using Org.BouncyCastle.Asn1.X9;

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
        }
    }
}