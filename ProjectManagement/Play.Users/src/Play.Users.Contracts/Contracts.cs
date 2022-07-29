using System;

namespace Play.Users.Contracts
{
    public record UserItemCreated(Guid UserId, string Username, string Email);
    public record UserItemUpdated(Guid UserId, string Username, string Email);
    public record UserItemDeleted(Guid UserId);
}