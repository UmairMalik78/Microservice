using System;

namespace ProjectManagementFrontEnd.Models
{
    public class PMTaskInfo
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string assignedUsername { get; set; }
        public DateTimeOffset deadlineDate { get; set; }
        public bool status { get; set; } = false;
        public Guid assignedUserId { get; set; }
        //it refers to the Id of Developer to whoom this task is assigned
    }
}