using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Play.Common;
using Play.Tasks.Service.Entities;

namespace Play.Tasks.Service.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TaskController : ControllerBase
    {
        private readonly IRepository<TaskItem> tasksRepository;
        private readonly IRepository<UserInfo> usersRepository;
        public TaskController(IRepository<TaskItem> tasksRepository, IRepository<UserInfo> usersRepository)
        {
            this.tasksRepository = tasksRepository;
            this.usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetAsync()
        {
            var taskItems = (await tasksRepository.GetAllAsync());
            var userIds = taskItems.Select(task => task.AssignedUserId);

            var usersEntities = await usersRepository.GetAllAsync(user => userIds.Contains(user.Id));

            var taskItemDtos = taskItems.Select(task =>
            {
                var userInfo = usersEntities.Single(user => user.Id == task.AssignedUserId);
                return task.AsDto(userInfo.Username);

            });
            return Ok(taskItemDtos);
        }
        // GET /tasks/{id}
        [Route("userId/{userId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetByUserIdAsync(Guid userId)
        {
            var allUserTasks = (await tasksRepository.GetAllAsync(task => task.AssignedUserId == userId))
                                                    .Select(task => task.AsDto());
            if (allUserTasks == null)
            {
                return NotFound();
            }
            return Ok(allUserTasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PMTaskItemDto>> GetByIdAsync(Guid id)
        {
            var taskItem = (await tasksRepository.GetAsync(task => task.Id == id));
            var assignedUser = await usersRepository.GetAsync(user => user.Id == taskItem.AssignedUserId);

            if (taskItem == null)
            {
                return NotFound();
            }
            return Ok(taskItem.AsDto(assignedUser.Username));
        }


        [HttpPost]
        public async Task<ActionResult<TaskItemDto>> PostAsync(CreateTaskItemDto createTaskDto)
        {
            var taskItem = new TaskItem { Id = Guid.NewGuid(), Title = createTaskDto.Title, Description = createTaskDto.Description, TaskDeadline = createTaskDto.TaskDeadline, AssignedUserId = createTaskDto.AssignedUserId, Status = createTaskDto.Status };

            await tasksRepository.CreateAsync(taskItem);
            //await publishEndpoint.Publish(new CatalogItemCreated(item.Id, item.Name, item.Description));

            return Ok();
        }

        //PUT /tasks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsycn(Guid id, UpdateTaskItemDto updateTaskDto)
        {
            var existingTask = await tasksRepository.GetAsync(id);
            if (existingTask == null)
            {
                return NotFound();
            }
            existingTask.Title = updateTaskDto.Title;
            existingTask.Description = updateTaskDto.Description;
            existingTask.TaskDeadline = updateTaskDto.TaskDeadline;
            existingTask.AssignedUserId = updateTaskDto.AssignedUserId;
            existingTask.Status = updateTaskDto.Status;
            await tasksRepository.UpdateAsync(existingTask);
            return NoContent();
        }
        // To mark a task as done by the User i.e., this option will be available to the AssignedUser to 
        // mark an assigned task as done.

        [Route("[action]/{TaskId}")]
        [HttpPut]
        public async Task<IActionResult> MarkAsDone(Guid TaskId)
        {
            var existingTask = await tasksRepository.GetAsync(TaskId);
            if (existingTask == null)
            {
                return NotFound();
            }
            existingTask.Status = true;
            await tasksRepository.UpdateAsync(existingTask);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existingItem = await tasksRepository.GetAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            await tasksRepository.RemoveAsync(id);
            return NoContent();
        }
    }
}