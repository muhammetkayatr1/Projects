#pragma checksum "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Infirmary\StudentRisky.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0d1eca4c38f1b178a71db968a6c4705cfe1795e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Infirmary_StudentRisky), @"mvc.1.0.view", @"/Views/Infirmary/StudentRisky.cshtml")]
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
#line 1 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Infirmary\StudentRisky.cshtml"
using NonFactors.Mvc.Grid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Infirmary\StudentRisky.cshtml"
using HesProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0d1eca4c38f1b178a71db968a6c4705cfe1795e", @"/Views/Infirmary/StudentRisky.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84285228a7c17681ac586e794b627ff7b4dc6737", @"/Views/_ViewImports.cshtml")]
    public class Views_Infirmary_StudentRisky : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IGrid<ProlizData>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Student", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-primary bg-hover-state-primary card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StudentRiskless", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-success bg-hover-state-success card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StudentRisky", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-danger bg-hover-state-danger card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StudentError", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card card-custom bg-warning bg-hover-state-warning card-stretch gutter-b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ExcelStudent", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color: #3699ff; border-color: #3699ff;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info font-weight-bolder font-size-sm mr-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Excel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 6 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Infirmary\StudentRisky.cshtml"
  
    Layout = "~/Views/Infirmary/_InfirmaryStudentLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"modal fade\" id=\"modalDetail\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myLargeModalLabel\" aria-hidden=\"true\">\r\n    <div class=\"modal-dialog modal-lg\" style=\"margin-top: 125px\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0d1eca4c38f1b178a71db968a6c4705cfe1795e9018", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0d1eca4c38f1b178a71db968a6c4705cfe1795e13920", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fa fa-user"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;"">
                                        <h1>");
#nullable restore
#line 104 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Infirmary\StudentRisky.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0d1eca4c38f1b178a71db968a6c4705cfe1795e16397", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-success font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fas fa-heart"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;"">
                                        <h1>");
#nullable restore
#line 122 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Infirmary\StudentRisky.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0d1eca4c38f1b178a71db968a6c4705cfe1795e18893", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-danger font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fa fa-exclamation-triangle"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;""> <h1>");
#nullable restore
#line 139 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Infirmary\StudentRisky.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0d1eca4c38f1b178a71db968a6c4705cfe1795e21397", async() => {
                WriteLiteral(@"

                            <div class=""card-body"">

                                <div class=""text-inverse-primary font-weight-bolder font-size-h5 mb-2 mt-5"">
                                    <i class=""fas fa-times-circle"" aria-hidden=""true"" style=""color: white !important;font-size: 30px;""></i>
                                    <div style=""text-align: end; display: inline-block; float: right; font-size: 30px;""><h1>");
#nullable restore
#line 155 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Infirmary\StudentRisky.cshtml"
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
                        Riskli Öğrenciler
                    </h3>
                </div>
                <div class=""card-toolbar"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0d1eca4c38f1b178a71db968a6c4705cfe1795e24279", async() => {
                WriteLiteral("Öğrenci  Listesi (Excel)");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0d1eca4c38f1b178a71db968a6c4705cfe1795e25643", async() => {
                WriteLiteral("Personel  Listesi (Excel)");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_13.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
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
            <div class=""card-body"">
                <!--begin: Search Form-->
                <!--begin::Search Form-->
                <!--end::Search Form-->
                <!--end: Search Form-->
                <!--begin: Datatable-->
                ");
#nullable restore
#line 188 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Infirmary\StudentRisky.cshtml"
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
                url: ""hes/Infirmary/getData"",
                data: { ID: ID }
            }).done(function (resp) {
                rowData = resp;
                console.log(rowData);
                
                document.getElementById(""name"").innerHTML = rowData.ad;
                document.getElementById(""surname"").innerHTML = rowData.soyad;
                document.getElementById(""faculty"").innerHTML = rowData.fakulte;
                document.getElementById(""program"").innerHTML = rowData.bolum;
                document.getElementById(""hesCode"").innerHTML = rowData.heskod;
                if (rowData.current_health_status == ""RISKLESS"") {
                    document.getElementById(""healty"").innerHTML = """);
                WriteLiteral(@"RİSKLİ DEĞİL"";
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
                else if (rowData.is_immune == false) {
");
                WriteLiteral(@"                    document.getElementById(""immune"").innerHTML = ""Hastalık Geçirmemiştir"";
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
