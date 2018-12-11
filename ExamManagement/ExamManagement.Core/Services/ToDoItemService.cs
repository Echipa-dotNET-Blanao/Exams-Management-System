using ExamManagement.Core.Events;
using ExamManagement.Core.Interfaces;
using Ardalis.GuardClauses;

namespace ExamManagement.Core.Services
{
    public class ToDoItemService : IHandle<ToDoItemCompletedEvent>
    {
        public void Handle(ToDoItemCompletedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

        }
    }
}