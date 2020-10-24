using KavkazHub.Remont.Core.Entities;
using KavkazHub.Remont.SharedKernel;

namespace KavkazHub.Remont.Core.Events
{
    public class ToDoItemCompletedEvent : BaseDomainEvent
    {
        public ToDoItem CompletedItem { get; set; }

        public ToDoItemCompletedEvent(ToDoItem completedItem)
        {
            CompletedItem = completedItem;
        }
    }
}