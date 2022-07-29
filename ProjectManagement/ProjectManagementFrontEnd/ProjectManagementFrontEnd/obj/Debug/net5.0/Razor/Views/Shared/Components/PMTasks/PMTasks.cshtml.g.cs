#pragma checksum "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23675e9d373d1e35a183cf23e5462a0635bbb748"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_PMTasks_PMTasks), @"mvc.1.0.view", @"/Views/Shared/Components/PMTasks/PMTasks.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\_ViewImports.cshtml"
using ProjectManagementFrontEnd;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\_ViewImports.cshtml"
using ProjectManagementFrontEnd.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\_ViewImports.cshtml"
using ProjectManagementFrontEnd.ViewComponents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
using ProjectManagementFrontEnd.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23675e9d373d1e35a183cf23e5462a0635bbb748", @"/Views/Shared/Components/PMTasks/PMTasks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdbb83cf6f711b15a58702e2bb8df776fc8009e2", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_PMTasks_PMTasks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PMTaskInfo>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"table-responsive\">\r\n");
#nullable restore
#line 5 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
  
    if(@Model.Count==0){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3 class=\"text-success\">No Pending Tasks are there!!!</h3>\r\n");
#nullable restore
#line 8 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
    }else{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table table-striped"">
            <thead>
                <tr>
                    <th>Sr</th>
                    <th>Title</th>
                    <th>Description</th>
                    <th>Deadline</th>
                    <th>Username</th>
                    <th>Current Status</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 22 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
              
                var index = 0;
                foreach (var userTask in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 27 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
                       Write(index);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 28 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
                       Write(userTask.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 29 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
                       Write(userTask.description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 30 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
                       Write(userTask.deadlineDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 31 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
                       Write(userTask.assignedUsername);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 32 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
                         if (userTask.status == false)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"bg-danger text-light\">Not Completed</td>\r\n");
#nullable restore
#line 35 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"bg-success text-light\"> Completed</td>\r\n");
#nullable restore
#line 39 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td><button class=\"btn btn-warning w-75\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1466, "\"", 1504, 3);
            WriteAttributeValue("", 1476, "UpdatePMTask(\'", 1476, 14, true);
#nullable restore
#line 40 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
WriteAttributeValue("", 1490, userTask.id, 1490, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1502, "\')", 1502, 2, true);
            EndWriteAttribute();
            WriteLiteral("> Update </button> </td>\r\n                    </tr>\r\n");
#nullable restore
#line 42 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
                    {index++;}
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 47 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\PMTasks\PMTasks.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PMTaskInfo>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591