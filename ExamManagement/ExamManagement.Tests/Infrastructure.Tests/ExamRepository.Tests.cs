using System;
using ExamManagement.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamManagement.Tests.Infrastructure.Tests
{
    [TestClass]
    public class ExamRepositoryTests
    {

        private Exam Sut()
        {
            return new Exam(3, DateTime.Now, "C112", new DateTime(2018, 05, 12, 10, 0, 0), new DateTime(2018, 05, 12, 12, 0, 0), DateTime.Today, 'R', false);
        }
        
    }
}