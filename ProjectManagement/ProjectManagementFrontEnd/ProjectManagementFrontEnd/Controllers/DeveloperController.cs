using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
    public class DeveloperController : Controller
    {
        HttpClient client;
        string ApiUrl;
        // private UserInfo currentLoggedInUser = new UserInfo();
        // private Guid currentLoggedInUserId;
        private static List<UserInfo> allUsers = new List<UserInfo>();
        public DeveloperController(IConfiguration Configuration)
        {
            ApiUrl = Configuration.GetValue<string>("baseurlForUsers");
            client = new HttpClient();
            client.BaseAddress = new Uri(ApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet]
        public IActionResult UpdateProfile()
        {
            Guid currentUserId = Guid.Parse(HttpContext.Session.GetString("userId"));
            UserInfo currentUser = allUsers.Find(user => user.id == currentUserId);
            return View("UpdateProfile", new DisplayUserInfoViewModel() { userInfo = currentUser });
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(DisplayUserInfoViewModel user)
        {
            if (HttpContext.Session.Keys.Contains("userId"))
            {
                Guid currentUserId = Guid.Parse(HttpContext.Session.GetString("userId"));
                HttpResponseMessage response = await client.PutAsJsonAsync(ApiUrl + $"/users/{currentUserId}", new UserInfo { username = user.userInfo.username, password = user.userInfo.password, email = user.userInfo.email });
                response.EnsureSuccessStatusCode();
                bool isRefreshed = await RefreshUsersData();
                return View(new DisplayUserInfoViewModel { userInfo = allUsers.Find(user => user.id == currentUserId) });
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(DisplayUserInfoViewModel user)
        {
            bool isRefreshed = await RefreshUsersData();
            int index = allUsers.FindIndex(item => item.password == user.userInfo.password && item.email == user.userInfo.email);
            if (index >= 0)
            {
                HttpContext.Session.SetString("userId", (allUsers[index].id.ToString()));
                return UpdateProfile();
            }
            else
            {
                TempData["error-msg"] = "Incorrect Username or Password";
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public IActionResult UserTasks()
        {
            if (HttpContext.Session.Keys.Contains("userId"))
            {
                DisplayUserTasksViewModel userTasksViewModel = new DisplayUserTasksViewModel();
                return View(userTasksViewModel);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public async Task<IActionResult> UserTasksVC()
        {
            if (HttpContext.Session.Keys.Contains("userId"))
            {
                Guid currentUserId = Guid.Parse(HttpContext.Session.Get("userId").ToString());
                string response = (await client.GetAsync(ApiUrl + $"/{currentUserId}")).Content.ReadAsStringAsync().Result;
                return ViewComponent("UserTasks", JsonSerializer.Deserialize<List<TaskInfo>>(response));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpGet]
        public async Task<IActionResult> UserInfoVC()
        {
            if (HttpContext.Session.Keys.Contains("userId"))
            {
                string response = (await client.GetAsync(ApiUrl)).Content.ReadAsStringAsync().Result;
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
        private async Task<bool> RefreshUsersData()
        {
            string response = (await client.GetAsync(ApiUrl + "/users")).Content.ReadAsStringAsync().Result;
            allUsers = JsonSerializer.Deserialize<List<UserInfo>>(response);
            return true;
        }
    }
}
