#pragma checksum "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\UserInfo\UserInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05a39cc8595551e8fa860430eb92be9a4da9798c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_UserInfo_UserInfo), @"mvc.1.0.view", @"/Views/Shared/Components/UserInfo/UserInfo.cshtml")]
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
#line 3 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\_ViewImports.cshtml"
using ProjectManagementFrontEnd.ViewModels;

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
#line 1 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\UserInfo\UserInfo.cshtml"
using ProjectManagementFrontEnd.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05a39cc8595551e8fa860430eb92be9a4da9798c", @"/Views/Shared/Components/UserInfo/UserInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdbb83cf6f711b15a58702e2bb8df776fc8009e2", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_UserInfo_UserInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserInfo>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""text-center p-md-5 bg-transparent box-shadow border-rounded"">
    <h1>User Information</h1>
    <div class=""w-50 mx-auto p-3 "">
        <table class=""table table-light border-0 fw-bold"">
            <tr>
                <td>Username</td>
                <td><i>");
#nullable restore
#line 9 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\UserInfo\UserInfo.cshtml"
                  Write(Model.username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i></td>\r\n            </tr>\r\n            <tr>\r\n                <td>Email</td>\r\n                <td><i><a href=\"mailto:s@Model.email\">");
#nullable restore
#line 13 "C:\Users\umair\Desktop\MyProjects\ProjectManagement\ProjectManagementFrontEnd\ProjectManagementFrontEnd\Views\Shared\Components\UserInfo\UserInfo.cshtml"
                                                 Write(Model.email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></i></td>\r\n            </tr>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserInfo> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591