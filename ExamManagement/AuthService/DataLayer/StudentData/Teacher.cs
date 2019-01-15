using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Teacher
    {
        public Teacher(int id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }

        [Key] public int Id { set; get; }

        public string FullName { set; get; }
        public string Email { set; get; }
        public string PasswordBase { set; get; }
        public string PasswordHash { set; get; }
    }
}