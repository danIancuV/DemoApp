#pragma checksum "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4c6cee7c8d28f0ca1ca3f049379ea39fd54e0a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SerializedFile_Index), @"mvc.1.0.view", @"/Views/SerializedFile/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SerializedFile/Index.cshtml", typeof(AspNetCore.Views_SerializedFile_Index))]
namespace AspNetCore
{
    #line hidden
#line 1 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
using System;

#line default
#line hidden
#line 2 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
using System.Collections.Generic;

#line default
#line hidden
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
#line 4 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
using Microsoft.AspNetCore.Mvc.Rendering;

#line default
#line hidden
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\_ViewImports.cshtml"
using WebApplicationTextFileDemoApp;

#line default
#line hidden
#line 2 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\_ViewImports.cshtml"
using WebApplicationTextFileDemoApp.Models;

#line default
#line hidden
#line 3 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
using FileClassLibrary.FileServiceModel;

#line default
#line hidden
#line 5 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4c6cee7c8d28f0ca1ca3f049379ea39fd54e0a0", @"/Views/SerializedFile/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16865a29ca7ce7e5abe582e1bda594cdd6a10ff6", @"/Views/_ViewImports.cshtml")]
    public class Views_SerializedFile_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FileClassLibrary.SerializedFileDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CheckDelete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(254, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
  
    ViewData["Title"] = "File list";

#line default
#line hidden
            BeginContext(301, 29, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(330, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2f5881fde874440f94a4c09de8751b1f", async() => {
                BeginContext(353, 11, true);
                WriteLiteral("Create file");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(368, 8, true);
            WriteLiteral("\r\n</p>\r\n");
            EndContext();
#line 17 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
 using (Html.BeginForm("CheckDelete", "SerializedFile", FormMethod.Post))
{

#line default
#line hidden
            BeginContext(454, 184, true);
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    <p>Select</p>\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(639, 40, false);
#line 26 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(679, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(747, 45, false);
#line 29 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Extension));

#line default
#line hidden
            EndContext();
            BeginContext(792, 276, true);
            WriteLiteral(@"
                </th>
                <th>
                    <p>Actions</p>
                </th>
                <th>
                    <p>Download format</p>
                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 41 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(1125, 114, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <input type=\"checkbox\" name=\"ids\" id=\"ids\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1239, "\"", 1255, 1);
#line 45 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
WriteAttributeValue("", 1247, item.Id, 1247, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1256, 80, true);
            WriteLiteral(">\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1337, 39, false);
#line 48 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1376, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1456, 44, false);
#line 51 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Extension));

#line default
#line hidden
            EndContext();
            BeginContext(1500, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1579, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3dc936e1d43e45c5bb5556b36f504943", async() => {
                BeginContext(1624, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 54 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
                                               WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1632, 28, true);
            WriteLiteral(" |\r\n                        ");
            EndContext();
            BeginContext(1660, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e26d015b0da4ebcab882c2e7abe4af1", async() => {
                BeginContext(1708, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 55 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
                                                  WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1719, 28, true);
            WriteLiteral(" |\r\n                        ");
            EndContext();
            BeginContext(1747, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "592933d4c8844af3a37fa5575a192e45", async() => {
                BeginContext(1794, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 56 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
                                                 WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1804, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1884, 173, false);
#line 59 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
                   Write(Html.DropDownList("Download extension",
         new SelectList(Enum.GetValues(enumType: typeof(FileExtEnum))), "ext",
                    new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(2057, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 64 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(2124, 36, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n    ");
            EndContext();
            BeginContext(2160, 141, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c7b65da36b84becbca4541c8647ae3a", async() => {
                BeginContext(2191, 103, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"CheckDelete\" name =\"submitButton\" class=\"btn btn-danger\" />\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2301, 6, true);
            WriteLiteral("<br>\r\n");
            EndContext();
            BeginContext(2309, 62, true);
            WriteLiteral("<!--<input type=\"submit\" value=\"Delete selected files\" />-->\r\n");
            EndContext();
#line 72 "D:\APP\TextFileDemoApp\WebApplicationTextFileDemoApp\Views\SerializedFile\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2374, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FileClassLibrary.SerializedFileDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
