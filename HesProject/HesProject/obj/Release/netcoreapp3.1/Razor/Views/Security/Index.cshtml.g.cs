#pragma checksum "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9355f6549e0a9cec57b99f64335dda9096baa6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Security_Index), @"mvc.1.0.view", @"/Views/Security/Index.cshtml")]
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
#line 1 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\_ViewImports.cshtml"
using HesProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Index.cshtml"
using NonFactors.Mvc.Grid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Index.cshtml"
using HesProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9355f6549e0a9cec57b99f64335dda9096baa6a", @"/Views/Security/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84285228a7c17681ac586e794b627ff7b4dc6737", @"/Views/_ViewImports.cshtml")]
    public class Views_Security_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Student", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-primary bg-hover-state-primary card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StudentRiskless", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-success bg-hover-state-success card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StudentRisky", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-danger bg-hover-state-danger card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StudentError", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-warning bg-hover-state-warning card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Employee", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EmployeeRiskless", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EmployeeRisky", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EmployeeError", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Index.cshtml"
  
    Layout = "~/Views/Security/_SecurityLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""d-flex flex-column-fluid"">
    <!--begin::Container-->
    <div class=""container"" style=""max-width: 100%"">
        <!--end::Notice-->
        <!--begin::Card-->
        <div class=""card card-custom mb-10"">
            <div class=""card-body"">

                <div class=""row"">
                    <div class=""col-xl-3"">

                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9355f6549e0a9cec57b99f64335dda9096baa6a8035", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fa fa-user"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;"">
                                        <h1>");
#nullable restore
#line 26 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Index.cshtml"
                                       Write(ViewBag.Student);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n                                    </div>\r\n                                </div>\r\n                                <div class=\"font-weight-bold text-inverse-success font-size-sm\">\r\n                                    Öğrenciler\r\n");
                WriteLiteral("                                </div>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9355f6549e0a9cec57b99f64335dda9096baa6a10502", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fas fa-heart"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;"">
                                        <h1>");
#nullable restore
#line 44 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Index.cshtml"
                                       Write(ViewBag.StudentRiskless);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n                                    </div>\r\n                                </div>\r\n                                <div class=\"font-weight-bold text-inverse-success font-size-sm\">\r\n                                    Sağlıklı Öğrenciler\r\n");
                WriteLiteral("                                </div>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9355f6549e0a9cec57b99f64335dda9096baa6a12989", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-danger font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fa fa-exclamation-triangle"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;""> <h1>");
#nullable restore
#line 61 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Index.cshtml"
                                                                                                                        Write(ViewBag.StudentRisky);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1> </div>\r\n                                </div>\r\n                                <div class=\"font-weight-bold text-inverse-danger font-size-sm\">\r\n                                    Riskli Öğrenciler\r\n");
                WriteLiteral("                                </div>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9355f6549e0a9cec57b99f64335dda9096baa6a15484", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-primary font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fas fa-times-circle"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;""><h1>");
#nullable restore
#line 77 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Index.cshtml"
                                                                                                                       Write(ViewBag.StudentError);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1> </div>\r\n                                </div>\r\n                                <div class=\"font-weight-bold text-inverse-primary font-size-sm\">\r\n                                    Kod Sorunlu Öğrenciler\r\n");
                WriteLiteral("                                </div>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n\r\n\r\n                <div class=\"row\">\r\n                    <div class=\"col-xl-3\">\r\n\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9355f6549e0a9cec57b99f64335dda9096baa6a18054", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fa fa-user"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;"">
                                        <h1>");
#nullable restore
#line 99 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Index.cshtml"
                                       Write(ViewBag.Person);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n                                    </div>\r\n                                </div>\r\n                                <div class=\"font-weight-bold text-inverse-success font-size-sm\">\r\n                                    Personeller\r\n");
                WriteLiteral("                                </div>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9355f6549e0a9cec57b99f64335dda9096baa6a20522", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fas fa-heart"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;"">
                                        <h1>");
#nullable restore
#line 117 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Index.cshtml"
                                       Write(ViewBag.PersonRiskless);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n                                    </div>\r\n                                </div>\r\n                                <div class=\"font-weight-bold text-inverse-success font-size-sm\">\r\n                                    Sağlıklı Personeller\r\n");
                WriteLiteral("                                </div>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9355f6549e0a9cec57b99f64335dda9096baa6a23010", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-danger font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fa fa-exclamation-triangle"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;""> <h1>");
#nullable restore
#line 134 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Index.cshtml"
                                                                                                                        Write(ViewBag.PersonRisky);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1> </div>\r\n                                </div>\r\n                                <div class=\"font-weight-bold text-inverse-danger font-size-sm\">\r\n                                    Riskli Personeller\r\n");
                WriteLiteral("                                </div>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9355f6549e0a9cec57b99f64335dda9096baa6a25508", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-primary font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fas fa-times-circle"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;""><h1>");
#nullable restore
#line 150 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Index.cshtml"
                                                                                                                       Write(ViewBag.PersonError);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1> </div>\r\n                                </div>\r\n                                <div class=\"font-weight-bold text-inverse-primary font-size-sm\">\r\n                                    Kod Sorunlu Personeller\r\n");
                WriteLiteral("                                </div>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n\r\n\r\n            </div>\r\n        </div>\r\n        <!--end::Card-->\r\n    </div>\r\n    <!--end::Container-->\r\n</div>");
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
