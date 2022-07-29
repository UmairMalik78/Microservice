using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementFrontEnd.Models;

namespace ProjectManagementFrontEnd.ViewComponents
{
    public class UserInfoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(UserInfo user)
        {
            return View("UserInfo", user);
        }
    }
}
