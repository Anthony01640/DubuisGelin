#pragma checksum "C:\Dev\ProjetSpe\DubuisGelin\Views\Home\IndexTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4cae870e80298eb6055e7c4ec0eeba7c0ef346b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_IndexTable), @"mvc.1.0.view", @"/Views/Home/IndexTable.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/IndexTable.cshtml", typeof(AspNetCore.Views_Home_IndexTable))]
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
#line 1 "C:\Dev\ProjetSpe\DubuisGelin\Views\_ViewImports.cshtml"
using DubuisGelin;

#line default
#line hidden
#line 2 "C:\Dev\ProjetSpe\DubuisGelin\Views\_ViewImports.cshtml"
using DubuisGelin.Models;

#line default
#line hidden
#line 2 "C:\Dev\ProjetSpe\DubuisGelin\Views\Home\IndexTable.cshtml"
using DubuisGelin.Controllers;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4cae870e80298eb6055e7c4ec0eeba7c0ef346b", @"/Views/Home/IndexTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7eff8724f65b21614be669ba77b8539fcd8693f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_IndexTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DubuisGelin.Models.HomeController.IndexTableViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(94, 25, true);
            WriteLiteral("\r\n<h2>IndexTable</h2>\r\n\r\n");
            EndContext();
            BeginContext(120, 83, false);
#line 6 "C:\Dev\ProjetSpe\DubuisGelin\Views\Home\IndexTable.cshtml"
Write(Html.ActionLink("Créer un champs", nameof(HomeController.AddChampsToTable), "Home"));

#line default
#line hidden
            EndContext();
            BeginContext(203, 23, true);
            WriteLiteral("\r\n\r\n<table>\r\n    <tr>\r\n");
            EndContext();
#line 10 "C:\Dev\ProjetSpe\DubuisGelin\Views\Home\IndexTable.cshtml"
         foreach (var champ in Model.ListeChamps)
        {

#line default
#line hidden
            BeginContext(288, 16, true);
            WriteLiteral("            <th>");
            EndContext();
            BeginContext(305, 9, false);
#line 12 "C:\Dev\ProjetSpe\DubuisGelin\Views\Home\IndexTable.cshtml"
           Write(champ.Nom);

#line default
#line hidden
            EndContext();
            BeginContext(314, 7, true);
            WriteLiteral("</th>\r\n");
            EndContext();
#line 13 "C:\Dev\ProjetSpe\DubuisGelin\Views\Home\IndexTable.cshtml"
        }

#line default
#line hidden
            BeginContext(332, 11, true);
            WriteLiteral("    </tr>\r\n");
            EndContext();
#line 15 "C:\Dev\ProjetSpe\DubuisGelin\Views\Home\IndexTable.cshtml"
     foreach (var liaison in Model.ListeLiaison)
    {

#line default
#line hidden
            BeginContext(400, 14, true);
            WriteLiteral("        <tr>\r\n");
            EndContext();
#line 18 "C:\Dev\ProjetSpe\DubuisGelin\Views\Home\IndexTable.cshtml"
             foreach (var item in liaison.ListeValue)
            {

#line default
#line hidden
            BeginContext(484, 20, true);
            WriteLiteral("                <td>");
            EndContext();
            BeginContext(505, 8, false);
#line 20 "C:\Dev\ProjetSpe\DubuisGelin\Views\Home\IndexTable.cshtml"
               Write(item.Nom);

#line default
#line hidden
            EndContext();
            BeginContext(513, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 21 "C:\Dev\ProjetSpe\DubuisGelin\Views\Home\IndexTable.cshtml"
            }

#line default
#line hidden
            BeginContext(535, 15, true);
            WriteLiteral("        </tr>\r\n");
            EndContext();
#line 23 "C:\Dev\ProjetSpe\DubuisGelin\Views\Home\IndexTable.cshtml"

    }

#line default
#line hidden
            BeginContext(559, 12, true);
            WriteLiteral("\r\n</table>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DubuisGelin.Models.HomeController.IndexTableViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
