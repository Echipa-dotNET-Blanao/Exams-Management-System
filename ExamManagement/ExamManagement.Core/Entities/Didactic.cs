using System.ComponentModel.DataAnnotations;

namespace ExamManagement.Core.Entities
{
    public class Didactic
    {
        [Key]
        public int id { get; set; }
        public int teacherId { set; get; }
        public int courseId { set; get; }
    }
}