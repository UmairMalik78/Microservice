using Play.Tasks.Service.Entities;

namespace Play.Tasks.Service
{
    public static class Extensions
    {
        public static PMTaskItemDto AsDto(this TaskItem taskItem, string username)
        {
            return new PMTaskItemDto(taskItem.Id, taskItem.Title, taskItem.Description, taskItem.TaskDeadline, taskItem.AssignedUserId, username, taskItem.Status);
        }
        public static TaskItemDto AsDto(this TaskItem taskItem)
        {
            return new TaskItemDto(taskItem.Id, taskItem.Title, taskItem.Description, taskItem.TaskDeadline, taskItem.AssignedUserId, taskItem.Status);
        }
    }
}