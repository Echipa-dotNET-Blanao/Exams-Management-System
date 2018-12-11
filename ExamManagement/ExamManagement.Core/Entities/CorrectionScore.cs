using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace ExamManagement.Core.Entities
{
    public class CorrectionScore
    {
        [Key]
        public int id { set; get; }
        public Byte binaryData { set; get; }
        
    }
}