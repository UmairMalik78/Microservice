using System;
using System.Security.AccessControl;
using Play.Common;

namespace Play.Tasks.Service.Entities
{
    public class TaskItem : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset TaskDeadline { get; set; }
        public bool Status { get; set; } = false;
        public Guid AssignedUserId { get; set; }//it refers to the Id of Developer to whoom this task is assigned

    }
}