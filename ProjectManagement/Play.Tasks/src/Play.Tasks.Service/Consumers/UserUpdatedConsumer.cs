using System.Threading.Tasks;
using MassTransit;
using Play.Users.Contracts;
using Play.Common;
using Play.Tasks.Service.Entities;

namespace Play.Tasks.Service.Consumers
{
    public class UserUpdatedConsumer : IConsumer<UserItemUpdated>
    {
        private readonly IRepository<UserInfo> repository;

        public UserUpdatedConsumer(IRepository<UserInfo> repository)
        {
            this.repository = repository;
        }
        public async Task Consume(ConsumeContext<UserItemUpdated> context)
        {
            var message = context.Message;
            var item = await repository.GetAsync(message.UserId);
            if (item == null)
            {
                UserInfo user = new UserInfo
                {
                    Id = message.UserId,
                    Username = message.Username,
                    Email = message.Email
                };
                await repository.CreateAsync(user);
                return;
            }
            item.Id = message.UserId;
            item.Username = message.Username;
            item.Email = message.Email;
            await repository.UpdateAsync(item);
        }
    }

}