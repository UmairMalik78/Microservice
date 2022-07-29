using System.Collections.Generic;
using ProjectManagementFrontEnd.Models;

namespace ProjectManagementFrontEnd.ViewModels
{
    public class UpdatePMTaskViewModel
    {
        public List<UserInfo> allUsers { get; set; }
        public PMTaskInfo taskToUpdate { get; set; }
    }
}