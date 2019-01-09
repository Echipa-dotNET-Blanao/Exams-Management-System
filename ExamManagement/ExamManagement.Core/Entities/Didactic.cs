using System.ComponentModel.DataAnnotations;

namespace ExamManagement.Core.Entities
{
    public class Didactic
    {
        [Key] public int Id { get; set; }

        public int TeacherId { set; get; }
        public int CourseId { set; get; }
    }
}