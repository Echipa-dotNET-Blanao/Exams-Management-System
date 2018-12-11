using ExamManagement.Core.SharedKernel;

namespace ExamManagement.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}