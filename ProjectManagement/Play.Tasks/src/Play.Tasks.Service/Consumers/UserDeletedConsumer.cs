using System.Threading.Tasks;
using MassTransit;

using Play.Common;
using Play.Tasks.Service.Entities;
using Play.Users.Contracts;

namespace Play.Tasks.Service.Consumers
{
    public class UserDeletedConsumer : IConsumer<UserItemDeleted>
    {
        private readonly IRepository<UserInfo> repository;

        public UserDeletedConsumer(IRepository<UserInfo> repository)
        {
            this.repository = repository;
        }
        public async Task Consume(ConsumeContext<UserItemDeleted> context)
        {
            var message = context.Message;
            var item = await repository.GetAsync(message.UserId);
            if (item == null)
            {
                return;
            }
            await repository.RemoveAsync(message.UserId);
        }
    }
}