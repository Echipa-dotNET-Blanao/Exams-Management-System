using System.Collections.Generic;

namespace ExamManagement.Core.SharedKernel
{
    public abstract class BaseEntity
    {
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}