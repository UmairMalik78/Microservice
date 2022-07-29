using System;
namespace Play.Tasks.Service
{
    public record TaskItemDto(Guid Id, string Title, string Description, DateTimeOffset DeadlineDate, Guid AssignedUserId, bool Status);
    public record PMTaskItemDto(Guid Id, string Title, string Description, DateTimeOffset DeadlineDate, Guid AssignedUserId, string AssignedUsername, bool status);
    public record CreateTaskItemDto(string Title, string Description, DateTimeOffset TaskDeadline, bool Status, Guid AssignedUserId);
    public record UpdateTaskItemDto(string Title, string Description, DateTimeOffset TaskDeadline, bool Status, Guid AssignedUserId);

    public record UserInfoDto(Guid Id, string Username, string Email);

}