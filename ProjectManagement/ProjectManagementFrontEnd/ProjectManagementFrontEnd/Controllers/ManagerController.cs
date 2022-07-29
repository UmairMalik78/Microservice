using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProjectManagementFrontEnd.Models;
using ProjectManagementFrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagementFrontEnd.Controllers
{
    public class ManagerController : Controller
    {
        HttpClient client;
        string ApiUrlForUser;
        string ApiUrlForTasks;
        private static List<UserInfo> allUsers = new List<UserInfo>();
        string adminEmail, adminPass;

        public ManagerController(IConfiguration Configuration)
        {
            ApiUrlForTasks = Configuration.GetValue<string>("baseurlForTasks");
            ApiUrlForUser = Configuration.GetValue<string>("baseurlForUsers");
            client = new HttpClient();
            client.BaseAddress = new Uri(ApiUrlForTasks);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            adminEmail = Configuration.GetValue<string>("adminEmail");
            adminPass = Configuration.GetValue<string>("adminPass");
        }

        // [HttpPost]
        // public async Task<IActionResult> PMViewTasks(DisplayUserInfoViewModel user)
        // {

        //     bool isRefreshed = await RefreshUsersData();
        //     Guid adminId = allUsers.Find(user => user.email.Equals(user.email)).id;
        //     HttpContext.Session.SetString("userId", adminId.ToString());
        //     if (HttpContext.Session.Keys.Contains("userId"))
        //     {
        //         DisplayPMTasksViewModel pmTasks = new DisplayPMTasksViewModel();
        //         pmTasks.allUsers = allUsers;
        //         return View(pmTasks);
        //     }
        //     else
        //     {
        //         return RedirectToAction("Login", "Account");
        //     }
        // }
        [HttpGet]
        public async Task<IActionResult> PMViewTasks()
        {
            bool isRefreshed = await RefreshUsersData();
            Guid adminId = allUsers.Find(user => user.email.Equals(adminEmail) && user.password.Equals(adminPass)).id;
            HttpContext.Session.SetString("userId", adminId.ToString());
            if (HttpContext.Session.Keys.Contains("userId"))
            {
                isRefreshed = await RefreshUsersData();
                DisplayPMTasksViewModel pmTasks = new DisplayPMTasksViewModel();
                pmTasks.allUsers = allUsers;
                return View(pmTasks);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public async void AddNewTask(TaskInfo task)
        {
            if (HttpContext.Session.Keys.Contains("userId"))
            {
                HttpResponseMessage response = await client.PostAsJsonAsync<TaskInfo>(client.BaseAddress + "tasks", task);
                if (response.StatusCode.Equals("Ok"))
                {
                    ViewData["success-msg"] = "Task Assigned Successfully!";
                }
                else
                {
                    ViewData["error-msg"] = "Some Problem occurrred, Try Again Later!";
                }
            }
        }

        //View Component to show Project Manager Tasks View
        public async Task<IActionResult> PMTasksVC()
        {
            if (HttpContext.Session.Keys.Contains("userId"))
            {
                string response = (await client.GetAsync(client.BaseAddress + $"tasks")).Content.ReadAsStringAsync().Result;
                return ViewComponent("PMTasks", JsonSerializer.Deserialize<List<PMTaskInfo>>(response));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        //View Component to show User Information
        [HttpGet]
        public async Task<IActionResult> UserInfoVC()
        {
            if (HttpContext.Session.Keys.Contains("userId"))
            {
                bool isRefreshed = await RefreshUsersData();
                Guid currentUserId = Guid.Parse(HttpContext.Session.GetString("userId"));

                var index = allUsers.FindIndex(user => user.id == currentUserId);
                if (index < 0)
                {
                    return RedirectToAction("Login", "Account");
                }
                return ViewComponent("UserInfo", allUsers[index]);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }



        [HttpGet]
        public async Task<IActionResult> UpdateTaskVC(string taskId)
        {
            if (HttpContext.Session.Keys.Contains("userId"))
            {
                bool isRefreshed = await RefreshUsersData();
                Guid currentUserId = Guid.Parse(HttpContext.Session.GetString("userId"));
                string response = (await client.GetAsync(client.BaseAddress + $"tasks/{taskId}")).Content.ReadAsStringAsync().Result;
                var pmtask = new PMTaskInfo();
                var jsonVal = JsonSerializer.Serialize(pmtask);
                var taskInfo = JsonSerializer.Deserialize<PMTaskInfo>(response);
                UpdatePMTaskViewModel updatePMTaskViewModel = new UpdatePMTaskViewModel
                {
                    allUsers = allUsers,
                    taskToUpdate = taskInfo
                };
                return ViewComponent("UpdatePMTask", updatePMTaskViewModel);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }


        private async Task<bool> RefreshUsersData()
        {
            string response = (await client.GetAsync(ApiUrlForUser + "/users")).Content.ReadAsStringAsync().Result;
            allUsers = JsonSerializer.Deserialize<List<UserInfo>>(response);
            return true;
        }

    }
}
