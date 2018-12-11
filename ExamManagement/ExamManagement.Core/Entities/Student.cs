using System.ComponentModel.DataAnnotations;

namespace ExamManagement.Core.Entities
{
    public class Student
    {
        public Student(string id, string email, string fullName, int studyYear, string studyGroup)
        {
            this.id = id;
            this.email = email;
            this.fullName = fullName;
            this.studyYear = studyYear;
            this.studyGroup = studyGroup;
        }
        [Key]
        public string id { set; get; }
        public string email { set; get; }
        public string passwordBase { set; get; }
        public string passwordHash { set; get; }
        public string fullName { set; get; }
        public int studyYear { set; get; }
        public string studyGroup { set; get; }
    }
}