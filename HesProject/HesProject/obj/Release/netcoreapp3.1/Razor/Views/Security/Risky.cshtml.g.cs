#pragma checksum "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Risky.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb3e490f94920ffad57ebe725e2779f0a42b970e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Security_Risky), @"mvc.1.0.view", @"/Views/Security/Risky.cshtml")]
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
#line 1 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Risky.cshtml"
using NonFactors.Mvc.Grid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Risky.cshtml"
using HesProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb3e490f94920ffad57ebe725e2779f0a42b970e", @"/Views/Security/Risky.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84285228a7c17681ac586e794b627ff7b4dc6737", @"/Views/_ViewImports.cshtml")]
    public class Views_Security_Risky : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IGrid<ProlizData>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Employee", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-success bg-hover-state-success card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EmployeeRiskless", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EmployeeRisky", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-danger bg-hover-state-danger card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EmployeeError", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-primary bg-hover-state-primary card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Student", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StudentRiskless", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StudentRisky", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StudentError", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 6 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Risky.cshtml"
  
    Layout = "~/Views/Shared/_SecurityLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""modal fade"" id=""modalGrup"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" style=""margin-top: 125px"">

        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Bilgiler</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <i aria-hidden=""true"" class=""ki ki-close""></i>
                </button>
            </div>

            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb3e490f94920ffad57ebe725e2779f0a42b970e8783", async() => {
                WriteLiteral(@"
                    <input type=""hidden"" class=""form-control"" name=""action"" value=""Employee"">

                    <div class=""form-group row"">
                        <label class=""col-2 col-form-label"">Tc</label>
                        <div class=""col-4"">
                            <input type=""text"" class=""form-control"" name=""Tc"" id=""Tc"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-2 col-form-label"">Hes</label>
                        <div class=""col-4"">
                            <input type=""text"" class=""form-control"" name=""Hes"" id=""Hes"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-2 col-form-label"">Status</label>
                        <div class=""col-4"">
                            <input type=""text"" class=""form-control"" name=""Status"" id=""Status"">
                        <");
                WriteLiteral(@"/div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-2 col-form-label"">Durum</label>
                        <div class=""col-4"">
                            <input type=""text"" class=""form-control"" name=""Durum"" id=""Durum"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-4"">
                            <button type=""submit"" class=""btn btn-secondary"">Kaydet</button>
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
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Kapat</button>
            </div>
        </div>

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
                        Riskli Kişiler Listesi
                    </h3>
                </div>
");
            WriteLiteral("            </div>\r\n            <div class=\"card-body\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-xl-3\">\r\n                        <!--begin::Stats Widget 15-->\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb3e490f94920ffad57ebe725e2779f0a42b970e13142", async() => {
                WriteLiteral(@"
                            <!--begin::Body-->
                            <div class=""card-body"">
                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">PERSONEL SAYISI</div>
                                <div class=""font-weight-bold text-inverse-success font-size-sm"">");
#nullable restore
#line 88 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Risky.cshtml"
                                                                                           Write(ViewBag.Person);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                            </div>\r\n                            <!--end::Body-->\r\n                        ");
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
            WriteLiteral("\r\n                        <!--end::Stats Widget 15-->\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        <!--begin::Stats Widget 15-->\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb3e490f94920ffad57ebe725e2779f0a42b970e15362", async() => {
                WriteLiteral(@"
                            <!--begin::Body-->
                            <div class=""card-body"">
                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">SAĞLIKLI PERSONEL SAYISI</div>
                                <div class=""font-weight-bold text-inverse-success font-size-sm"">");
#nullable restore
#line 100 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Risky.cshtml"
                                                                                           Write(ViewBag.PersonRiskless);

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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <!--end::Stats Widget 15-->\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        <!--begin::Stats Widget 13-->\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb3e490f94920ffad57ebe725e2779f0a42b970e17600", async() => {
                WriteLiteral(@"
                            <!--begin::Body-->
                            <div class=""card-body"">
                                <div class=""text-inverse-danger font-weight-bolder font-size-h5 mb-2 mt-5"">RİSKLİ PERSONEL SAYISI</div>
                                <div class=""font-weight-bold text-inverse-danger font-size-sm"">");
#nullable restore
#line 112 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Risky.cshtml"
                                                                                          Write(ViewBag.PersonRisky);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                            </div>\r\n                            <!--end::Body-->\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <!--end::Stats Widget 13-->\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        <!--begin::Stats Widget 14-->\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb3e490f94920ffad57ebe725e2779f0a42b970e19830", async() => {
                WriteLiteral(@"
                            <!--begin::Body-->
                            <div class=""card-body"">
                                <div class=""text-inverse-primary font-weight-bolder font-size-h5 mb-2 mt-5"">KOD HATALI OLAN PERSONEL SAYISI</div>
                                <div class=""font-weight-bold text-inverse-primary font-size-sm"">");
#nullable restore
#line 124 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Risky.cshtml"
                                                                                           Write(ViewBag.PersonError);

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
            WriteLiteral(@"
                        <!--end::Stats Widget 14-->
                    </div>
                </div>

                <div class=""row"">
                    <div class=""col-xl-3"">
                        <!--begin::Stats Widget 15-->
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb3e490f94920ffad57ebe725e2779f0a42b970e22126", async() => {
                WriteLiteral(@"
                            <!--begin::Body-->
                            <div class=""card-body"">
                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">ÖĞRENCİ SAYISI</div>
                                <div class=""font-weight-bold text-inverse-success font-size-sm"">");
#nullable restore
#line 139 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Risky.cshtml"
                                                                                           Write(ViewBag.Student);

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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <!--end::Stats Widget 15-->\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        <!--begin::Stats Widget 15-->\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb3e490f94920ffad57ebe725e2779f0a42b970e24347", async() => {
                WriteLiteral(@"
                            <!--begin::Body-->
                            <div class=""card-body"">
                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">SAĞLIKLI ÖĞRENCİ SAYISI</div>
                                <div class=""font-weight-bold text-inverse-success font-size-sm"">");
#nullable restore
#line 151 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Risky.cshtml"
                                                                                           Write(ViewBag.StudentRiskless);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                            </div>\r\n                            <!--end::Body-->\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <!--end::Stats Widget 15-->\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        <!--begin::Stats Widget 13-->\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb3e490f94920ffad57ebe725e2779f0a42b970e26587", async() => {
                WriteLiteral(@"
                            <!--begin::Body-->
                            <div class=""card-body"">
                                <div class=""text-inverse-danger font-weight-bolder font-size-h5 mb-2 mt-5"">RİSKLİ ÖĞRENCİ SAYISI</div>
                                <div class=""font-weight-bold text-inverse-danger font-size-sm"">");
#nullable restore
#line 163 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Risky.cshtml"
                                                                                          Write(ViewBag.StudentRisky);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                            </div>\r\n                            <!--end::Body-->\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <!--end::Stats Widget 13-->\r\n                    </div>\r\n                    <div class=\"col-xl-3\">\r\n                        <!--begin::Stats Widget 14-->\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb3e490f94920ffad57ebe725e2779f0a42b970e28819", async() => {
                WriteLiteral(@"
                            <!--begin::Body-->
                            <div class=""card-body"">
                                <div class=""text-inverse-primary font-weight-bolder font-size-h5 mb-2 mt-5"">KOD HATALI OLAN ÖĞRENCİ SAYISI</div>
                                <div class=""font-weight-bold text-inverse-primary font-size-sm"">");
#nullable restore
#line 175 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Risky.cshtml"
                                                                                           Write(ViewBag.StudentError);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                            </div>\r\n                            <!--end::Body-->\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
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
                <!--begin: Search Form-->
                <!--begin::Search Form-->
                <!--end::Search Form-->
                <!--end: Search Form-->
                <!--begin: Datatable-->
                ");
#nullable restore
#line 187 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Security\Risky.cshtml"
            Write(new HtmlGrid<ProlizData>
   (Html, Model)
    .Build(columns =>
    {

    })
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
                url: ""hes/security/getData"",
                data: { ID: ID }
            }).done(function (resp) {
                rowData = resp;
                console.log(rowData);
                
                document.getElementById(""name"").innerHTML = rowData.ad;
                document.getElementById(""surname"").innerHTML = rowData.soyad;
                document.getElementById(""employeeType"").innerHTML = rowData.tip;
                document.getElementById(""title"").innerHTML = rowData.departman; document.getElementById(""phoneNumber"").innerHTML = rowData.phone; document.getElementById(""emailAddress"").innerHTML = rowData.email;
                if (rowData.current_health_status == ""RISKLESS"") {
            ");
                WriteLiteral(@"        document.getElementById(""healty"").innerHTML = ""RİSKLİ DEĞİL"";
                }
                else if (rowData.current_health_status == ""RISKY"") {
                    document.getElementById(""healty"").innerHTML = ""RİSKLİ"";
                }
                else {
                    document.getElementById(""healty"").innerHTML = ""Bilgi Bulunamadı"";
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
 ");
                WriteLiteral(@"               else if (rowData.is_immune == false) {
                    document.getElementById(""immune"").innerHTML = ""Hastalık Geçirmemiştir"";
                }
                else {
                    document.getElementById(""immune"").innerHTML = ""Bilgi Bulunamadı"";
                }

                if (rowData.last_negative_test_date != null) {
                    document.getElementById(""pcr"").innerHTML = rowData.last_negative_test_date;
                }
                else {
                    document.getElementById(""pcr"").innerHTML = ""Bilgi Bulunamadı"";
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