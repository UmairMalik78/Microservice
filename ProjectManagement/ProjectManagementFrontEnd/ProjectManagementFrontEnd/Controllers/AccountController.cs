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
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagementFrontEnd.Controllers
{
    public class AccountController : Controller
    {
        HttpClient client;
        string ApiUrl;
        string adminEmail, adminPass;

        public AccountController(IConfiguration Configuration)
        {
            ApiUrl = Configuration.GetValue<string>("baseurlForUsers");
            client = new HttpClient();
            client.BaseAddress = new Uri(ApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            adminEmail = Configuration.GetValue<string>("adminEmail");
            adminPass = Configuration.GetValue<string>("adminPass");

        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            string response = (await client.GetAsync(ApiUrl)).Content.ReadAsStringAsync().Result;
            ViewData["error-msg"] = TempData["error-msg"];
            return View(new DisplayUserInfoViewModel());
        }
        [HttpPost]
        public IActionResult Login(DisplayUserInfoViewModel user)
        {
            if (user.userInfo.email.Equals(adminEmail) && user.userInfo.password.Equals(adminPass))
            {
                return RedirectToAction("PMViewTasks", "Manager");
            }
            else
            {
                return RedirectToAction("Login", "Developer");
            }
        }
        // [HttpPost]
        // public async Task<IActionResult> Login(DisplayUserInfoViewModel user)
        // {
        //     // string jsno1 = JsonSerializer.Serialize<UserInfo>(new UserInfo { id = Guid.NewGuid(), Username = "sfads", Password = "dfssd", Email = "adsasdfasf" });
        //     // string jsno2 = JsonSerializer.Serialize<UserInfo>(new UserInfo { Id = Guid.NewGuid(), Username = "sfads", Password = "dfssd", Email = "adsasdfasf" });
        //     // UserInfo a = JsonSerializer.Deserialize<UserInfo>(jsno1);
        //     // List<UserInfo> allJsnos = new List<UserInfo>();
        //     // allJsnos.Add(JsonSerializer.Deserialize<UserInfo>(jsno1));
        //     // allJsnos.Add(JsonSerializer.Deserialize<UserInfo>(jsno2));
        //     string repsonse = (await client.GetAsync(ApiUrl + "/users")).Content.ReadAsStringAsync().Result;
        //     List<UserInfo> allUsers = JsonSerializer.Deserialize<List<UserInfo>>(repsonse);
        //     //            string yes = JsonSerializer.Serialize(allJsnos);
        //     if (allUsers.FindIndex(item => item.password == user.userInfo.password && item.email == user.userInfo.email) >= 0)
        //     {
        //         return RedirectToAction("UpdateProfile", "Developer");
        //     }
        //     else
        //     {
        //         ViewData["error-msg"] = "Incorrect Username or Password";
        //         return View();
        //     }
        // }
    }
}
