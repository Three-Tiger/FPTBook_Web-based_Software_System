#pragma checksum "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb146e9117edcdeffedbb76530fcfebd1e3c8bec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Owners_Views_Statistic_Index), @"mvc.1.0.view", @"/Areas/Owners/Views/Statistic/Index.cshtml")]
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
#line 1 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\_ViewImports.cshtml"
using FPTBookWebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\_ViewImports.cshtml"
using FPTBookWebClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb146e9117edcdeffedbb76530fcfebd1e3c8bec", @"/Areas/Owners/Views/Statistic/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9df26dc013fcd8f29fe11b47c1e876fbdb36450e", @"/Areas/Owners/Views/_ViewImports.cshtml")]
    public class Areas_Owners_Views_Statistic_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("category/delete/31?_method=DELETE"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return deleteConfirm()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("category/delete/30?_method=DELETE"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
  
    ViewData["Title"] = "Data Statistics";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""pt-2 mb-2"">
    <h1 class=""text-center"">Data Statistics</h1>
    <table id=""tablecategory"" class=""table table-striped table-bordered mb-5""cellspacing=""0""
           width=""100%"">
        <thead class=""justify-content-md-between justify-content-sm-center align-content-center border-bottom border-2 my-2 bg-dark text-light p-3 rounded-3"">
            <tr class=""text-center"">
                <th colspan=""5"">
                    <strong>Who purchase the most</strong>
                </th>
            </tr>
        </thead>

        <tbody class=""justify-content-md-between justify-content-sm-center border-bottom border-2 my-2 bg-light p-2 rounded-3"">
            <tr>
                <td class=""text-center align-middle"" id=""category31"">
                    <a href=""/shop?cid=31&page=1"" style=""text-decoration: none;"">1</a>
                </td>
                <td class=""text-center align-middle"">Harry Potter</td>
                <td class=""align-middle"">Harry Potter Product</td>
      ");
            WriteLiteral("          <td class=\"text-center align-middle\">\r\n                    <a href=\"category/show/31\"><i class=\"bi bi-pen-fill\" style=\"color: black;\"></i></a>\r\n                </td>\r\n                <td class=\"text-center align-middle\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb146e9117edcdeffedbb76530fcfebd1e3c8bec6658", async() => {
                WriteLiteral("\r\n                        <button type=\"submit\" style=\"border: none; cursor: pointer;\">\r\n                            <i class=\"bi bi-trash-fill\" style=\"color: red;\"></i>\r\n                        </button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </td>
            </tr>
            <tr>
                <td class=""text-center align-middle"" id=""category30"">
                    <a href=""/shop?cid=30&page=1"" style=""text-decoration: none;"">2</a>
                </td>
                <td class=""text-center align-middle"">Winx 2</td>
                <td class=""align-middle"">Winx 2 Product</td>
                <td class=""text-center align-middle"">
                    <a href=""category/show/30""><i class=""bi bi-pen-fill"" style=""color: black;""></i></a>
                </td>
                <td class=""text-center align-middle"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb146e9117edcdeffedbb76530fcfebd1e3c8bec9142", async() => {
                WriteLiteral("\r\n                        <button type=\"submit\" style=\"border: none; cursor: pointer;\">\r\n                            <i class=\"bi bi-trash-fill\" style=\"color: red;\"></i>\r\n                        </button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </td>
            </tr>
        </tbody>
    </table>

    <table id=""tablecategory"" class=""table table-striped table-bordered mb-5"" cellspacing=""0""
           width=""100%"">
        <thead class=""justify-content-md-between justify-content-sm-center align-content-center border-bottom border-2 my-2 bg-dark text-light p-3 rounded-3"">
            <tr class=""text-center"">
                <th colspan=""5"">
                    <strong>Total income for the month</strong>
                </th>    
            </tr>
        </thead>

        <tbody class=""justify-content-md-between justify-content-sm-center border-bottom border-2 my-2 bg-light p-2 rounded-3"">
            <tr>
                <td class=""text-center align-middle"" id=""category31"">
                    <a href=""/shop?cid=31&page=1"" style=""text-decoration: none;"">1</a>
                </td>
                <td class=""text-center align-middle"">Harry Potter</td>
                <td class=""align-middle"">Harry Potter Product");
            WriteLiteral(@"</td>
                <td class=""text-center align-middle"">
                    <a href=""category/show/31""><i class=""bi bi-pen-fill"" style=""color: black;""></i></a>
                </td>
                <td class=""text-center align-middle"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb146e9117edcdeffedbb76530fcfebd1e3c8bec12333", async() => {
                WriteLiteral("\r\n                        <button type=\"submit\" style=\"border: none; cursor: pointer;\">\r\n                            <i class=\"bi bi-trash-fill\" style=\"color: red;\"></i>\r\n                        </button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </td>
            </tr>
            <tr>
                <td class=""text-center align-middle"" id=""category30"">
                    <a href=""/shop?cid=30&page=1"" style=""text-decoration: none;"">2</a>
                </td>
                <td class=""text-center align-middle"">Winx 2</td>
                <td class=""align-middle"">Winx 2 Product</td>
                <td class=""text-center align-middle"">
                    <a href=""category/show/30""><i class=""bi bi-pen-fill"" style=""color: black;""></i></a>
                </td>
                <td class=""text-center align-middle"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb146e9117edcdeffedbb76530fcfebd1e3c8bec14818", async() => {
                WriteLiteral("\r\n                        <button type=\"submit\" style=\"border: none; cursor: pointer;\">\r\n                            <i class=\"bi bi-trash-fill\" style=\"color: red;\"></i>\r\n                        </button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </td>
            </tr>
        </tbody>
    </table>

    <table id=""tablecategory"" class=""table table-striped table-bordered mb-5"" cellspacing=""0""
           width=""100%"">
        <thead class=""justify-content-md-between justify-content-sm-center align-content-center border-bottom border-2 my-2 bg-dark text-light p-3 rounded-3"">
            <tr class=""text-center"">
                <th colspan=""5"">
                    <strong>Which books are purchased the most?</strong>
                </th>
            </tr>
        </thead>

        <tbody class=""justify-content-md-between justify-content-sm-center border-bottom border-2 my-2 bg-light p-2 rounded-3"">
            <tr>
                <td class=""text-center align-middle"" id=""category31"">
                    <a href=""/shop?cid=31&page=1"" style=""text-decoration: none;"">1</a>
                </td>
                <td class=""text-center align-middle"">Harry Potter</td>
                <td class=""align-middle"">Harry Potter Pr");
            WriteLiteral(@"oduct</td>
                <td class=""text-center align-middle"">
                    <a href=""category/show/31""><i class=""bi bi-pen-fill"" style=""color: black;""></i></a>
                </td>
                <td class=""text-center align-middle"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb146e9117edcdeffedbb76530fcfebd1e3c8bec18015", async() => {
                WriteLiteral("\r\n                        <button type=\"submit\" style=\"border: none; cursor: pointer;\">\r\n                            <i class=\"bi bi-trash-fill\" style=\"color: red;\"></i>\r\n                        </button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </td>
            </tr>
            <tr>
                <td class=""text-center align-middle"" id=""category30"">
                    <a href=""/shop?cid=30&page=1"" style=""text-decoration: none;"">2</a>
                </td>
                <td class=""text-center align-middle"">Winx 2</td>
                <td class=""align-middle"">Winx 2 Product</td>
                <td class=""text-center align-middle"">
                    <a href=""category/show/30""><i class=""bi bi-pen-fill"" style=""color: black;""></i></a>
                </td>
                <td class=""text-center align-middle"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb146e9117edcdeffedbb76530fcfebd1e3c8bec20500", async() => {
                WriteLiteral("\r\n                        <button type=\"submit\" style=\"border: none; cursor: pointer;\">\r\n                            <i class=\"bi bi-trash-fill\" style=\"color: red;\"></i>\r\n                        </button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
