using System.Runtime.ConstrainedExecution;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using System.Transactions;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Play.Users.Service.Entities;
using MassTransit;
using Play.Users.Contracts;
using Play.Common;

namespace Play.Users.Service.Controller
{

    //  https://localhost:5001/items/
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {

        private readonly IRepository<User> usersRepository;
        private readonly IPublishEndpoint publishEndpoint;
        public UsersController(IRepository<User> usersRepository, IPublishEndpoint publishEndPoint)
        {
            this.usersRepository = usersRepository;
            this.publishEndpoint = publishEndPoint;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAsync()
        {
            var items = (await usersRepository.GetAllAsync())
                        .Select(user => user.AsDto());
            return Ok(items);
        }
        // GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetByIdAsync(Guid id)
        {
            var item = (await usersRepository.GetAsync(id)).AsDto();
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> PostAsync(CreateUserDto createUserDto)
        {

            var allUsers = await usersRepository.GetAllAsync();
            if (allUsers.FirstOrDefault(user => user.Username == createUserDto.Username) != null)
            {
                return StatusCode(409);
            }
            var user = new User { Id = Guid.NewGuid(), Username = createUserDto.Username, Password = createUserDto.Password, Email = createUserDto.Email };

            await usersRepository.CreateAsync(user);

            await publishEndpoint.Publish(new UserItemCreated(user.Id, user.Username, user.Email));
            return CreatedAtAction(nameof(GetByIdAsync), new { id = user.Id }, user.AsDto());
        }
        //PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsycn(Guid id, UpdateUserDto updateUserDto)
        {
            var existingUser = await usersRepository.GetAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.Username = updateUserDto.Username;
            existingUser.Password = updateUserDto.Password;
            existingUser.Email = updateUserDto.Email;

            await usersRepository.UpdateAsync(existingUser);
            await publishEndpoint.Publish(new UserItemUpdated(existingUser.Id, existingUser.Username, existingUser.Email));

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existingItem = await usersRepository.GetAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            await usersRepository.RemoveAsync(id);

            await publishEndpoint.Publish(new UserItemDeleted(existingItem.Id));
            return NoContent();
        }
    }
}