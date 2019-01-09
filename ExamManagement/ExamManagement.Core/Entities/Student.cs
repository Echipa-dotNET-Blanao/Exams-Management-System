using System.ComponentModel.DataAnnotations;

namespace ExamManagement.Core.Entities
{
    public class Student
    {
        public Student(string id, string email, string fullName, int studyYear, string studyGroup)
        {
            Id = id;
            Email = email;
            FullName = fullName;
            StudyYear = studyYear;
            StudyGroup = studyGroup;
        }

        [Key] public string Id { set; get; }

        public string Email { set; get; }
        public string PasswordBase { set; get; }
        public string PasswordHash { set; get; }
        public string FullName { set; get; }
        public int StudyYear { set; get; }
        public string StudyGroup { set; get; }
    }
}