#pragma checksum "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Admin\Student.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f3d205759e36ddb16ca339b3d1fbdb951e46e8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Student), @"mvc.1.0.view", @"/Views/Admin/Student.cshtml")]
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
#line 1 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Admin\Student.cshtml"
using NonFactors.Mvc.Grid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Admin\Student.cshtml"
using HesProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f3d205759e36ddb16ca339b3d1fbdb951e46e8a", @"/Views/Admin/Student.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84285228a7c17681ac586e794b627ff7b4dc6737", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Student : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IGrid<ProlizData>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Gate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Konfides", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Student", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-primary bg-hover-state-primary card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StudentRiskless", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-success bg-hover-state-success card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StudentRisky", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-danger bg-hover-state-danger card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StudentError", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-warning bg-hover-state-warning card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Admin\Student.cshtml"
  
    Layout = "~/Views/Admin/_AdminStudentLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"modal fade\" id=\"modalDetail\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myLargeModalLabel\" aria-hidden=\"true\">\r\n    <div class=\"modal-dialog modal-lg\" style=\"margin-top: 125px\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f3d205759e36ddb16ca339b3d1fbdb951e46e8a8161", async() => {
                WriteLiteral(@"
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Bilgiler</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <i aria-hidden=""true"" class=""ki ki-close""></i>
                    </button>
                </div>

                <div class=""modal-body"">
                    <table class=""table table-bordered"">
                        <tbody>

                            <tr>
                                <th style=""width:50%"" scope=""col"">Ad</th>
                                <td id=""name""></td>

                            </tr>
                            <tr>
                                <th scope=""col"">Soyad</th>
                                <td id=""surname""></td>

                            </tr>
                            <tr>
                                <th scope=""col"">Fakülte</th>
                                <t");
                WriteLiteral(@"d id=""faculty""></td>

                            </tr>
                            <tr>
                                <th scope=""col"">Bölüm</th>
                                <td id=""program""></td>

                            </tr>

                        </tbody>
                    </table>

                    <table class=""table table-bordered"">
                        <tbody>
                            <tr>
                                <th style=""width:50%"" scope=""col"">Hes Kodu</th>
                                <td id=""hesCode""></td>

                            </tr>
                            <tr>
                                <th style=""width:50%"" scope=""col"">Risk Durumu</th>
                                <td id=""healty""></td>

                            </tr>
                            <tr>
                                <th scope=""col"">Aşılı Durumu</th>
                                <td id=""vaccine""></td>

                            </tr>
       ");
                WriteLiteral(@"                     <tr>
                                <th scope=""col"">Geçirilmiş Hastalık</th>
                                <td id=""immune""></td>
                            </tr>
                            <tr>
                                <th scope=""col"">Son 48 Saat Negatif Test</th>
                                <td id=""pcr""></td>
                            </tr>

                        </tbody>
                    </table>
                    <table class=""table table-bordered"">
                        <thead>
                            <tr>
                                <th style=""font-weight:bold"" scope=""col"">Kart Kilitli Mi?</th>
                                <th style=""font-weight:bold"" scope=""col"">Açıklama</th>

                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td id=""cardStatus""></td>
                                <td id=""cardDescription""></td");
                WriteLiteral(@">
                            </tr>

                        </tbody>
                    </table>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Kapat</button>
                </div>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n<div class=\"modal fade\" id=\"modalGrup\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myLargeModalLabel\" aria-hidden=\"true\">\r\n    <div class=\"modal-dialog modal-s\" style=\"margin-top: 125px\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f3d205759e36ddb16ca339b3d1fbdb951e46e8a13636", async() => {
                WriteLiteral(@"
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Bilgiler</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <i aria-hidden=""true"" class=""ki ki-close""></i>
                    </button>
                </div>

                <div class=""modal-body"">
                    <input type=""hidden"" class=""form-control"" name=""action"" value=""Student"">
                    <input type=""hidden"" class=""form-control"" name=""id"" id=""Id"">
                    <div class=""form-group row"">
                        <label class=""col-2 col-form-label"">Hes</label>
                        <div class=""col-8"">
                            <input type=""text"" class=""form-control"" name=""Hes"" id=""Hes"">
                        </div>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""submit"" class");
                WriteLiteral("=\"btn btn-primary\">Kaydet</button>\r\n                    <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Kapat</button>\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n<div class=\"modal fade\" id=\"modalGate\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myLargeModalLabel\" aria-hidden=\"true\">\r\n    <div class=\"modal-dialog modal-s\" style=\"margin-top: 125px\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f3d205759e36ddb16ca339b3d1fbdb951e46e8a16837", async() => {
                WriteLiteral(@"
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Kart Durumu</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <i aria-hidden=""true"" class=""ki ki-close""></i>
                    </button>
                </div>

                <div class=""modal-body row"">

                    <input type=""hidden"" class=""form-control"" name=""action"" value=""Student"">
                    <input type=""hidden"" class=""form-control"" name=""controller"" value=""Admin"">
                    <input type=""hidden"" name=""tc"" id=""TcGate""><input type=""hidden"" name=""GateId"" id=""GateId"">
                    <input type=""hidden"" name=""result"" id=""IsBlocked"">
                    <div class=""form-group row"">
                        <div class=""col-12"">
                            <p>Kişi kart bilgilerini güncelleştirmek istediğinizden emin misiniz?</p>
                        </d");
                WriteLiteral(@"iv>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""submit"" class=""btn btn-primary"" id=""btnSubmit""></button>
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Kapat</button>
                </div>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
</div>

<div class=""d-flex flex-column-fluid"">
    <!--begin::Container-->
    <div class=""container"" style=""max-width: 100%"">
        <!--end::Notice-->


        <div class=""card card-custom mb-10"">
            <div class=""card-body"">

                <div class=""row"">
                    <div class=""col-xl-3"">

                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f3d205759e36ddb16ca339b3d1fbdb951e46e8a20531", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fa fa-user"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;"">
                                        <h1>");
#nullable restore
#line 185 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Admin\Student.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f3d205759e36ddb16ca339b3d1fbdb951e46e8a22999", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fas fa-heart"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;"">
                                        <h1>");
#nullable restore
#line 203 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Admin\Student.cshtml"
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
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f3d205759e36ddb16ca339b3d1fbdb951e46e8a25486", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-danger font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fa fa-exclamation-triangle"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;""> <h1>");
#nullable restore
#line 220 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Admin\Student.cshtml"
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f3d205759e36ddb16ca339b3d1fbdb951e46e8a27981", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-primary font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fas fa-times-circle"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;""><h1>");
#nullable restore
#line 236 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Admin\Student.cshtml"
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                </div>


            </div>
        </div>
        <!--begin::Card-->
        <div class=""card card-custom"">
            <div class=""card-header flex-wrap border-0 pt-6 pb-0"">
                <div class=""card-title"">
                    <h3 class=""card-label"">
                        Tüm Öğrenciler
                    </h3>
                </div>
");
            WriteLiteral(@"            </div>
            <div class=""card-body"">

                <!--begin: Search Form-->
                <!--begin::Search Form-->
                <!--end::Search Form-->
                <!--end: Search Form-->
                <!--begin: Datatable-->
                ");
#nullable restore
#line 269 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Admin\Student.cshtml"
            Write(new HtmlGrid<ProlizData>
   (Html, Model)
    .Build(columns =>
    {

    })
    .Using(GridFilterMode.Header)
    .Empty("No data found")
    .Filterable()
    .Sortable()
    .Pageable()
    .Attributed(new {id="StudentTable" })

    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <!--end: Datatable-->\r\n            </div>\r\n        </div>\r\n        <!--end::Card-->\r\n    </div>\r\n    <!--end::Container-->\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"


    <script>

        var rowData;
        $(""#StudentTable"").on(""click"", ""a.detay"", function (e) {

            var ID = e.currentTarget.dataset[""aday""];
            $.ajax({
                async: false,
                method: ""GET"",
                dataType: ""json"",
                url: ""hes/admin/getData"",
                data: { ID: ID }
            }).done(function (resp) {
                rowData = resp;
                console.log(rowData);
                document.getElementById(""Id"").value = rowData.id; document.getElementById(""GateId"").value = rowData.id;
                document.getElementById(""TcGate"").value = rowData.tckimlikno;
                document.getElementById(""Hes"").value = rowData.heskod;
                document.getElementById(""IsBlocked"").value = rowData.isBlocked;

                if (rowData.isBlocked == true) {
                    document.getElementById(""btnSubmit"").innerHTML = ""Kilidi Kaldır"";
                }
                else {
              ");
                WriteLiteral(@"      document.getElementById(""btnSubmit"").innerHTML = ""Kilitle"";
                }

                document.getElementById(""name"").innerHTML = rowData.ad;
                document.getElementById(""surname"").innerHTML = rowData.soyad;
                document.getElementById(""faculty"").innerHTML = rowData.fakulte;
                document.getElementById(""program"").innerHTML = rowData.bolum;
                document.getElementById(""hesCode"").innerHTML = rowData.heskod;
                if (rowData.current_health_status == ""RISKLESS"") {
                    document.getElementById(""healty"").innerHTML = ""RİSKLİ DEĞİL"";
                }
                else if (rowData.current_health_status == ""RISKY"") {
                    document.getElementById(""healty"").innerHTML = ""RİSKLİ"";
                }
                else {
                    document.getElementById(""healty"").innerHTML = ""Bilgi Bulunamadı"";
                }

                if (rowData.is_vaccinated == true) {
                    do");
                WriteLiteral(@"cument.getElementById(""vaccine"").innerHTML = ""Aşıları Tamamlanmıştır"";
                }
                else if (rowData.is_vaccinated == false) {
                    document.getElementById(""vaccine"").innerHTML = ""Aşıları Tamamlanmamıştır"";
                }
                else {
                    document.getElementById(""vaccine"").innerHTML = ""Bilgi Bulunamadı"";
                }

                if (rowData.is_immune == true) {
                    document.getElementById(""immune"").innerHTML = ""Hastalık Geçirmiştir"";
                }
                else if (rowData.is_immune == false) {
                    document.getElementById(""immune"").innerHTML = ""Hastalık Geçirmemiştir"";
                }
                else {
                    document.getElementById(""immune"").innerHTML = ""Bilgi Bulunamadı"";
                }

                if (rowData.last_negative_test_date != null) {
                    document.getElementById(""pcr"").innerHTML = rowData.last_negative_test_date;
    ");
                WriteLiteral(@"            }
                else {
                    document.getElementById(""pcr"").innerHTML = ""Bilgi Bulunamadı"";
                }
                if (rowData.isBlocked == true) {
                    document.getElementById(""cardStatus"").innerHTML = ""Kilitli"";
                }
                else if (rowData.isBlocked == false) {
                    document.getElementById(""cardStatus"").innerHTML = ""Kilitli Değil"";
                }
                else {
                    document.getElementById(""cardStatus"").innerHTML = ""Bilinmiyor"";
                }

                if (rowData.description != null) {
                    document.getElementById(""cardDescription"").innerHTML = rowData.description;
                }
                else {
                    document.getElementById(""cardDescription"").innerHTML = ""Bilinmiyor"";
                }
            })
        });


    </script>

");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IGrid<ProlizData>> Html { get; private set; }
    }
}
#pragma warning restore 1591
