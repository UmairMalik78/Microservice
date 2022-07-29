using System;

namespace Play.Users.Service
{
    public record UserDto(Guid Id, string Username, string Password, string Email);
    public record CreateUserDto(string Username, string Password, string Email);
    public record UpdateUserDto(string Username, string Password, string Email);

}