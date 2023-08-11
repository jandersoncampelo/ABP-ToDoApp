using System;
using Volo.Abp.Domain.Entities;

namespace ToDoApp.Entities
{
    public class ToDoItem : BasicAggregateRoot<Guid>
    {
        public string Text { get; set; }
    }
}
