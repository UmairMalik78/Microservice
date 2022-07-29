using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementFrontEnd.Models;
using ProjectManagementFrontEnd.ViewModels;

namespace ProjectManagementFrontEnd.ViewComponents
{
    public class UpdatePMTaskViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(UpdatePMTaskViewModel taskToUpdate)
        {
            return View("UpdatePMTask", taskToUpdate);
        }
    }
}
