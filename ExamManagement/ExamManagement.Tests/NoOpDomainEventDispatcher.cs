using ExamManagement.Core.Interfaces;
using ExamManagement.Core.SharedKernel;

namespace ExamManagement.Tests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public void Dispatch(BaseDomainEvent domainEvent) { }
    }
}
