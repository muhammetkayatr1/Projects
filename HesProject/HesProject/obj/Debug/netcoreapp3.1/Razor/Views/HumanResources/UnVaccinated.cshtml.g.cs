#pragma checksum "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\UnVaccinated.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9e4e94b09d8187e2c21ca8c4075a7d7aa140cad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HumanResources_UnVaccinated), @"mvc.1.0.view", @"/Views/HumanResources/UnVaccinated.cshtml")]
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
#line 1 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\UnVaccinated.cshtml"
using NonFactors.Mvc.Grid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\UnVaccinated.cshtml"
using HesProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9e4e94b09d8187e2c21ca8c4075a7d7aa140cad", @"/Views/HumanResources/UnVaccinated.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84285228a7c17681ac586e794b627ff7b4dc6737", @"/Views/_ViewImports.cshtml")]
    public class Views_HumanResources_UnVaccinated : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IGrid<ProlizData>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Gate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Konfides", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Employee", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-success bg-hover-state-success card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EmployeeRiskless", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EmployeeRisky", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-danger bg-hover-state-danger card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EmployeeError", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-primary bg-hover-state-primary card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 6 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\UnVaccinated.cshtml"
  
    Layout = "~/Views/HumanResources/_HumanResourcesEmployeeLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"modal fade\" id=\"modalDetail\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myLargeModalLabel\" aria-hidden=\"true\">\r\n    <div class=\"modal-dialog modal-lg\" style=\"margin-top: 125px\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9e4e94b09d8187e2c21ca8c4075a7d7aa140cad7883", async() => {
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
                                <th scope=""col"">Çalışan Türü</th>
                             ");
                WriteLiteral(@"   <td id=""employeeType""></td>

                            </tr>
                            <tr>
                                <th scope=""col"">Unvanı</th>
                                <td id=""title""></td>

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

                            </tr>");
                WriteLiteral(@"
                            <tr>
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
                                <td id=""cardDescri");
                WriteLiteral(@"ption""></td>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9e4e94b09d8187e2c21ca8c4075a7d7aa140cad13371", async() => {
                WriteLiteral(@"
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Bilgiler</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <i aria-hidden=""true"" class=""ki ki-close""></i>
                    </button>
                </div>

                <div class=""modal-body"">
                    <input type=""hidden"" class=""form-control"" name=""action"" value=""UnVaccinated"">
                    <input type=""hidden"" class=""form-control"" name=""id"" id=""Id"">
                    <div class=""form-group row"">
                        <label class=""col-2 col-form-label"">Hes</label>
                        <div class=""col-8"">
                            <input type=""text"" class=""form-control"" name=""Hes"" id=""Hes"">
                        </div>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""submit"" ");
                WriteLiteral("class=\"btn btn-primary\">Kaydet</button>\r\n                    <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Kapat</button>\r\n                </div>\r\n            </div>\r\n        ");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9e4e94b09d8187e2c21ca8c4075a7d7aa140cad16577", async() => {
                WriteLiteral(@"
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Kart Durumu</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <i aria-hidden=""true"" class=""ki ki-close""></i>
                    </button>
                </div>

                <div class=""modal-body row"">

                    <input type=""hidden"" class=""form-control"" name=""action"" value=""UnVaccinated"">
                    <input type=""hidden"" name=""tc"" id=""TcGate""><input type=""hidden"" name=""GateId"" id=""GateId"">
                    <input type=""hidden"" name=""result"" id=""IsBlocked"">
                    <div class=""form-group row"">
                        <div class=""col-12"">
                            <p>Kişi kart bilgilerini güncelleştirmek istediğinizden emin misiniz?</p>
                        </div>
                    </div>
                </div>
                <div class=""modal-");
                WriteLiteral(@"footer"">
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
        <!--begin::Card-->
        <div class=""card card-custom"">
            <div class=""card-header flex-wrap border-0 pt-6 pb-0"">
                <div class=""card-title"">
                    <h3 class=""card-label"">
                        Genel Bilgiler
                    </h3>
                </div>
");
            WriteLiteral("            </div>\r\n            <div class=\"card-body\">\r\n\r\n                <div class=\"row\">\r\n                    <div class=\"col-xl-3\">\r\n                        <!--begin::Stats Widget 15-->\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9e4e94b09d8187e2c21ca8c4075a7d7aa140cad20558", async() => {
                WriteLiteral(@"
                            <!--begin::Body-->
                            <div class=""card-body"">
                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">PERSONEL SAYISI</div>
                                <div class=""font-weight-bold text-inverse-success font-size-sm"">");
#nullable restore
#line 192 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\UnVaccinated.cshtml"
                                                                                           Write(ViewBag.Person);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                            </div>\r\n                            <!--end::Body-->\r\n                        ");
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
            WriteLiteral("\r\n                        <!--end::Stats Widget 15-->\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        <!--begin::Stats Widget 15-->\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9e4e94b09d8187e2c21ca8c4075a7d7aa140cad22792", async() => {
                WriteLiteral(@"
                            <!--begin::Body-->
                            <div class=""card-body"">
                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">SAĞLIKLI PERSONEL SAYISI</div>
                                <div class=""font-weight-bold text-inverse-success font-size-sm"">");
#nullable restore
#line 204 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\UnVaccinated.cshtml"
                                                                                           Write(ViewBag.PersonRiskless);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                            </div>\r\n                            <!--end::Body-->\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <!--end::Stats Widget 15-->\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        <!--begin::Stats Widget 13-->\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9e4e94b09d8187e2c21ca8c4075a7d7aa140cad25043", async() => {
                WriteLiteral(@"
                            <!--begin::Body-->
                            <div class=""card-body"">
                                <div class=""text-inverse-danger font-weight-bolder font-size-h5 mb-2 mt-5"">RİSKLİ PERSONEL SAYISI</div>
                                <div class=""font-weight-bold text-inverse-danger font-size-sm"">");
#nullable restore
#line 216 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\UnVaccinated.cshtml"
                                                                                          Write(ViewBag.PersonRisky);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                            </div>\r\n                            <!--end::Body-->\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <!--end::Stats Widget 13-->\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        <!--begin::Stats Widget 14-->\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9e4e94b09d8187e2c21ca8c4075a7d7aa140cad27286", async() => {
                WriteLiteral(@"
                            <!--begin::Body-->
                            <div class=""card-body"">
                                <div class=""text-inverse-primary font-weight-bolder font-size-h5 mb-2 mt-5"">KOD HATALI OLAN PERSONEL SAYISI</div>
                                <div class=""font-weight-bold text-inverse-primary font-size-sm"">");
#nullable restore
#line 228 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\UnVaccinated.cshtml"
                                                                                           Write(ViewBag.PersonError);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                            </div>\r\n                            <!--end::Body-->\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        <!--end::Stats Widget 14-->
                    </div>
                </div>
                <!--<div class=""row"">
                    <div class=""col-xl-3"">-->
                        <!--begin::Stats Widget 15-->
                        <!--<a asp-action=""Vaccinated"" class=""card card-custom bg-success bg-hover-state-success card-stretch gutter-b"">-->
                            <!--begin::Body-->
                            <!--<div class=""card-body"">
                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">AŞILARINI TAMAMLAYANLAR</div>
                                <div class=""font-weight-bold text-inverse-success font-size-sm"">");
#nullable restore
#line 242 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\UnVaccinated.cshtml"
                                                                                           Write(ViewBag.Vaccinated);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>-->
                            <!--end::Body-->
                        <!--</a>-->
                        <!--end::Stats Widget 15-->
                    <!--</div>
                    <div class=""col-xl-3"">-->
                        <!--begin::Stats Widget 15-->
                        <!--<a asp-action=""UnVaccinated"" class=""card card-custom bg-success bg-hover-state-success card-stretch gutter-b"">-->
                            <!--begin::Body-->
                            <!--<div class=""card-body"">
                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">AŞILARINI TAMAMLAMAYANLAR</div>
                                <div class=""font-weight-bold text-inverse-success font-size-sm"">");
#nullable restore
#line 254 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\UnVaccinated.cshtml"
                                                                                           Write(ViewBag.UnVaccinated);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>-->
                            <!--end::Body-->
                        <!--</a>-->
                        <!--end::Stats Widget 15-->
                    <!--</div>
                    <div class=""col-xl-3"">-->
                        <!--begin::Stats Widget 13-->
                        <!--<a asp-action=""PcrTested"" class=""card card-custom bg-danger bg-hover-state-danger card-stretch gutter-b"">-->
                            <!--begin::Body-->
                            <!--<div class=""card-body"">
                                <div class=""text-inverse-danger font-weight-bolder font-size-h5 mb-2 mt-5"">AŞILARINI TAMAMLAMAYIP PCR TESTİ YAPTIRANLAR</div>
                                <div class=""font-weight-bold text-inverse-danger font-size-sm"">");
#nullable restore
#line 266 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\UnVaccinated.cshtml"
                                                                                          Write(ViewBag.PcrTested);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>-->
                            <!--end::Body-->
                        <!--</a>-->
                        <!--end::Stats Widget 13-->
                    <!--</div>
                    <div class=""col-xl-3"">-->
                        <!--begin::Stats Widget 14-->
                        <!--<a asp-action=""UnPcrTested"" class=""card card-custom bg-primary bg-hover-state-primary card-stretch gutter-b"">-->
                            <!--begin::Body-->
                            <!--<div class=""card-body"">
                                <div class=""text-inverse-primary font-weight-bolder font-size-h5 mb-2 mt-5"">AŞILARINI TAMAMLAMAYIP PCR TESTİ YAPTIRMAYANLAR</div>
                                <div class=""font-weight-bold text-inverse-primary font-size-sm"">");
#nullable restore
#line 278 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\UnVaccinated.cshtml"
                                                                                           Write(ViewBag.UnPcrTested);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>-->
                            <!--end::Body-->
                        <!--</a>-->
                        <!--end::Stats Widget 14-->
                    <!--</div>
                </div>-->
                <!--begin: Search Form-->
                <!--begin::Search Form-->
                <!--end::Search Form-->
                <!--end: Search Form-->
                <!--begin: Datatable-->
                ");
#nullable restore
#line 290 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\UnVaccinated.cshtml"
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
            WriteLiteral("\r\n                <!--end: Datatable-->\r\n            </div>\r\n        </div>\r\n        <!--end::Card-->\r\n    </div>\r\n    <!--end::Container-->\r\n</div>\r\n\r\n\r\n");
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
                url: ""hes/humanresources/getData"",
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
                WriteLiteral(@"               document.getElementById(""btnSubmit"").innerHTML = ""Kilitle"";
                }

                document.getElementById(""name"").innerHTML = rowData.ad;
                document.getElementById(""surname"").innerHTML = rowData.soyad;
                document.getElementById(""employeeType"").innerHTML = rowData.tip;
                document.getElementById(""title"").innerHTML = rowData.departman; document.getElementById(""phoneNumber"").innerHTML = rowData.phone; document.getElementById(""emailAddress"").innerHTML = rowData.email;
                document.getElementById(""hesCode"").innerHTML = rowData.heskod;
                if (rowData.current_health_status == ""RISKLESS"") {
                    document.getElementById(""healty"").innerHTML = ""RİSKLİ DEĞİL"";
                }
                else if (rowData.current_health_status == ""RISKY"") {
                    document.getElementById(""healty"").innerHTML = ""RİSKLİ"";
                }
                else {
                    document.getElement");
                WriteLiteral(@"ById(""healty"").innerHTML = ""Bilgi Bulunamadı"";
                }

                if (rowData.is_vaccinated == true) {
                    document.getElementById(""vaccine"").innerHTML = ""Aşıları Tamamlanmıştır"";
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

                if (");
                WriteLiteral(@"rowData.last_negative_test_date != null) {
                    document.getElementById(""pcr"").innerHTML = rowData.last_negative_test_date;
                }
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
   ");
                WriteLiteral("             }\r\n\r\n            })\r\n        });\r\n\r\n\r\n    </script>\r\n\r\n");
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