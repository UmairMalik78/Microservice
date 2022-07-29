using Play.Users.Service.Entities;

namespace Play.Users.Service
{
    public static class Extensions
    {
        public static UserDto AsDto(this User user)
        {
            if (user == null)
            {
                return null;
            }
            return new UserDto(user.Id, user.Username, user.Password, user.Email);
        }

    }
}