using ExamManagement.Core.SharedKernel;

namespace ExamManagement.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}