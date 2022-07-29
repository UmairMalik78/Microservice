using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementFrontEnd.Models;

namespace ProjectManagementFrontEnd.ViewComponents
{
    public class PMTasksViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<PMTaskInfo> allPMTasks)
        {
            return View("PMTasks", allPMTasks);
        }
    }
}
