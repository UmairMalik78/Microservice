using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementFrontEnd.Models;

namespace ProjectManagementFrontEnd.ViewComponents
{
    public class UserTasksVC : ViewComponent
    {
        public IViewComponentResult Invoke(List<TaskInfo> allUserTasks)
        {
            return View("UserTasks", allUserTasks);
        }
    }
}