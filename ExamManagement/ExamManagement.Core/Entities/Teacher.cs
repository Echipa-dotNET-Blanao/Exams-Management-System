using System.ComponentModel.DataAnnotations;

namespace ExamManagement.Core.Entities
{
    public class Teacher
    {
        public Teacher(int id, string fullName, string email)
        {
            this.id = id;
            this.fullName = fullName;
            this.email = email;
        }
        [Key]
        public int id { set; get; }
        public string fullName { set; get; }
        public string email { set; get; }
        public string passwordBase { set; get; }
        public string passwordHash { set; get; }
        
    }
}