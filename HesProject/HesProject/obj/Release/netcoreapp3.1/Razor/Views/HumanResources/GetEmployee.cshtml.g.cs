#pragma checksum "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d22044ee0b7a83f26c70c09b8d2010b3fc3a905e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HumanResources_GetEmployee), @"mvc.1.0.view", @"/Views/HumanResources/GetEmployee.cshtml")]
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
#line 2 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\_ViewImports.cshtml"
using HesProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d22044ee0b7a83f26c70c09b8d2010b3fc3a905e", @"/Views/HumanResources/GetEmployee.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84285228a7c17681ac586e794b627ff7b4dc6737", @"/Views/_ViewImports.cshtml")]
    public class Views_HumanResources_GetEmployee : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HesProject.Models.ViewModels.EmployeeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
  
    Layout = "~/Views/HumanResources/_HumanResourcesLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""d-flex flex-column-fluid"" style=""display:block !important"">

    <!--begin::Entry-->
    <!--begin::Hero-->
 

    <!--end::Hero-->
    <!--begin::Section-->
    <div class=""container py-8"">
        <div class=""row"">
            <div class=""col-lg-10 mb-4"" style=""margin:auto"">
                <!--begin::Callout-->
                <div class=""card card-custom wave wave-animate-slow wave-success mb-8 mb-lg-0"" style=""background-color: white !important; height: 100%"">
                    <div class=""card-body""");
            BeginWriteAttribute("style", " style=\"", 675, "\"", 683, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                        <h3 style=""text-align: center;"">
                            Personel Sorgulama
                        </h3>
                        <div class=""d-flex align-items-center p-6"" style=""padding: 2rem 2.25rem !important;"">
                            <!--begin::Icon-->

                            <div class=""d-flex flex-column col-lg-6"" style=""margin:auto"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d22044ee0b7a83f26c70c09b8d2010b3fc3a905e5084", async() => {
                WriteLiteral(@"
                                    <div class=""input-group"">
                                        <input type=""text"" class=""form-control"" name=""tc"" autocomplete=""off"" maxlength=""11"" placeholder=""TC Kimlik Numarası"">
                                        <div class=""input-group-append"">
                                            <button class=""btn btn-primary"" type=""submit"">Sorgula</button>
                                        </div>
                                    </div>
                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 30 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
AddHtmlAttributeValue("", 1122, Url.Action("GetEmployee", "HumanResources"), 1122, 44, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n\r\n                            <!--end::Content-->\r\n                        </div>\r\n                        <h3 style=\"text-align:center\">");
#nullable restore
#line 42 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                                 Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 43 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                         if (Model != null)
                        {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                         if (Model.ProlizData != null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"text-center mb-10\">\r\n                            <div class=\"symbol symbol-60 symbol-circle symbol-xl-90\">\r\n");
#nullable restore
#line 49 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                 if(Model.ProlizData.Picture != null)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"symbol-label\"");
            BeginWriteAttribute("style", " style=\"", 2385, "\"", 2472, 7);
            WriteAttributeValue("", 2393, "background-image:", 2393, 17, true);
            WriteAttributeValue(" ", 2410, "url(\'", 2411, 6, true);
#nullable restore
#line 51 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
WriteAttributeValue("", 2416, Model.ProlizData.Picture, 2416, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2441, "\');width:", 2441, 9, true);
            WriteAttributeValue(" ", 2450, "100px;", 2451, 7, true);
            WriteAttributeValue(" ", 2457, "height:", 2458, 8, true);
            WriteAttributeValue(" ", 2465, "100px;", 2466, 7, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n");
#nullable restore
#line 52 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                    }
                                    else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"symbol-label\" style=\"background-image: url(\'../hes/avatar.jpg\'); width: 100px; height: 100px;\"></div>\r\n");
#nullable restore
#line 56 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                \r\n                            </div>\r\n                            <h4 class=\"font-weight-bold my-2\">");
#nullable restore
#line 59 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                                         Write(Model.ProlizData.Ad);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 59 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                                                              Write(Model.ProlizData.Soyad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                            <div class=\"text-muted mb-2\">");
#nullable restore
#line 60 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                                    Write(Model.ProlizData.Departman);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n");
#nullable restore
#line 62 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 66 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                         if (Model != null)
                        {
                            if (Model.ProlizData != null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <table class=""table table-bordered"" style=""margin: auto; margin-bottom: 20px;"">

                            <tbody>
                                <tr>
                                    <th style=""width:50%"" scope=""col"">Hes Kodu</th>
");
#nullable restore
#line 75 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                     if (Model.ProlizData.HESKOD != null)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color: green\">");
#nullable restore
#line 77 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                                        Write(Model.ProlizData.HESKOD);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 78 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }

                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:red\">");
#nullable restore
#line 82 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                                     Write(Model.ProlizData.durum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 83 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </tr>\r\n                                <tr>\r\n                                    <th scope=\"col\" style=\"width:50%\">Risk Durumu</th>\r\n");
#nullable restore
#line 88 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                     if (Model.ProlizData.current_health_status == "RISKLESS")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color: green\">Riskli Değil</td>\r\n");
#nullable restore
#line 91 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }
                                            else if (Model.ProlizData.current_health_status == "RISKY")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:red\">Riskli</td>\r\n");
#nullable restore
#line 95 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td style=\"color:red\">");
#nullable restore
#line 98 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                                 Write(Model.ProlizData.durum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 99 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </tr>\r\n                                <tr>\r\n                                    <th scope=\"col\">Aşılı Durumu</th>\r\n");
#nullable restore
#line 104 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                     if (Model.ProlizData.is_vaccinated == true)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:green\">Tüm aşıları tamamlanmıştır.</td>\r\n");
#nullable restore
#line 107 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }
                                            else if (Model.ProlizData.is_vaccinated == false)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:red\">Aşıları tamamlanmamıştır.</td>\r\n");
#nullable restore
#line 111 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }
                                            else if (Model.ProlizData.current_health_status != null)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:red\">HES Uygulamasından bilgilerinin paylaşılmasına izin verilmemeiştir.</td>\r\n");
#nullable restore
#line 115 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:red\">Aşı bilgisi bulunamadı.</td>\r\n");
#nullable restore
#line 119 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"

                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </tr>\r\n                                <tr>\r\n                                    <th scope=\"col\">Geçirilmiş Hastalık</th>\r\n");
#nullable restore
#line 125 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                     if (Model.ProlizData.is_immune == true)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:green\">Son 6 ayda Covid geçirmiştir.</td>\r\n");
#nullable restore
#line 128 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }
                                            else if (Model.ProlizData.is_immune == false)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:red\">Son 6 ayda Covid geçirmemiştir.</td>\r\n");
#nullable restore
#line 132 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }
                                            else if (Model.ProlizData.current_health_status != null)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:red\">HES uygulamasından bilgilerinin paylaşılmasına izin verilmemeiştir.</td>\r\n");
#nullable restore
#line 136 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:red\">Hastalık bilgisi bulunamadı.</td>\r\n");
#nullable restore
#line 140 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tr>\r\n                                <tr>\r\n                                    <th scope=\"col\">Son 48 Saat Negatif Test</th>\r\n");
#nullable restore
#line 144 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                     if (Model.ProlizData.last_negative_test_date != null)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:green\">");
#nullable restore
#line 146 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                                       Write(Model.ProlizData.last_negative_test_date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 147 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }
                                            else if (Model.ProlizData.current_health_status != null)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:red\">Son 2 günde PCR testi yaptırmamıştır.</td>\r\n");
#nullable restore
#line 151 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:red\">PCR testi bilgisi bulunamadı.</td>\r\n");
#nullable restore
#line 155 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tr>\r\n\r\n                            </tbody>\r\n                        </table>\r\n");
#nullable restore
#line 160 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"

                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 164 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                         if (Model != null)
                        {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 166 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                         if (Model.KimlikKarti != null && Model.KimlikKarti.Count > 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <table class=""table table-bordered"" style=""margin: auto; margin-bottom: 20px;"">
                            <thead>
                                <tr>
                                    <th style=""font-weight:bold"" scope=""col"">Kart ID</th>
                                    <th style=""font-weight:bold"" scope=""col"">Kart Tipi</th>
                                    <th style=""font-weight:bold"" scope=""col"">Kart Durumu</th>

                                </tr>
                            </thead>
                            <tbody>

");
#nullable restore
#line 179 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                 if (Model.KimlikKarti.Count > 0)
                                        {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 181 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                 foreach (var item in Model.KimlikKarti)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 184 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                   Write(item.KartNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 185 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                   Write(item.KartTipi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 186 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                     if (item.Durum != "")
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:red\">");
#nullable restore
#line 188 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                                     Write(item.Durum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 189 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td style=\"color:green\">Geçiş Yapabilir</td>\r\n");
#nullable restore
#line 193 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </tr>\r\n");
#nullable restore
#line 196 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 196 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                             
                                        }
                                        else
                                        {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <tr>
                                    <td style=""color:red"">Kişiye ait kart bilgisi bulunamaıştır.</td>
                                    <td style=""color:red"">Kişiye ait kart bilgisi bulunamaıştır.</td>
                                </tr>
");
#nullable restore
#line 205 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n                            </tbody>\r\n                        </table>\r\n");
#nullable restore
#line 212 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 212 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\HumanResources\GetEmployee.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n                <!--end::Callout-->\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n    <!--end::Section-->\r\n    <!--begin::Section-->\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HesProject.Models.ViewModels.EmployeeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591