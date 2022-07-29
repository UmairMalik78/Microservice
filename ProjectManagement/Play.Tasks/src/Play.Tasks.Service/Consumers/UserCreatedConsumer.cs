using System.Threading.Tasks;
using MassTransit;
using Play.Common;
using Play.Tasks.Service.Entities;
using Play.Users.Contracts;

namespace Play.Tasks.Service.Consumers
{
    public class UserCreatedConsumer : IConsumer<UserItemCreated>
    {
        private readonly IRepository<UserInfo> repository;

        public UserCreatedConsumer(IRepository<UserInfo> repository)
        {
            this.repository = repository;
        }
        public async Task Consume(ConsumeContext<UserItemCreated> context)
        {
            var message = context.Message;
            var item = await repository.GetAsync(message.UserId);
            if (item != null)
            {
                return;
            }
            item = new UserInfo
            {
                Id = message.UserId,
                Username = message.Username,
                Email = message.Email
            };
            await repository.CreateAsync(item);
        }
    }
}