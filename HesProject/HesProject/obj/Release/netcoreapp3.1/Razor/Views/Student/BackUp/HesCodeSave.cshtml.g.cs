#pragma checksum "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b13eb1575c07ec83c72ee53a185cd240fd33ca3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_BackUp_HesCodeSave), @"mvc.1.0.view", @"/Views/Student/BackUp/HesCodeSave.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b13eb1575c07ec83c72ee53a185cd240fd33ca3", @"/Views/Student/BackUp/HesCodeSave.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84285228a7c17681ac586e794b627ff7b4dc6737", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_BackUp_HesCodeSave : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Student>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    string[] mail = @Model[0].EPOSTA1.Split('@');

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""d-flex flex-column-fluid"">
    <!--begin::Container-->
    <div class=""container"">
        <div class=""card card-custom"">
            <div class=""card-body p-0"">
                <!--begin: Wizard-->
                <div class=""wizard wizard-2"" id=""kt_wizard"" data-wizard-state=""first"" data-wizard-clickable=""false"">
                    <!--begin: Wizard Nav-->
                    <div class=""wizard-nav border-right py-8 px-8 py-lg-20 px-lg-10"" style=""padding:0px !important"">
                        <div class=""card-body"">
                            <!--end::Toolbar-->
                            <!--begin::User-->
                            <div class=""d-flex align-items-center"">
                                <div class=""symbol symbol-60 symbol-xxl-100 mr-5 align-self-start align-self-xxl-center"">
                                    <div class=""symbol-label""");
            BeginWriteAttribute("style", " style=\"", 1029, "\"", 1079, 4);
            WriteAttributeValue("", 1037, "background-image:", 1037, 17, true);
            WriteAttributeValue(" ", 1054, "url(\'", 1055, 6, true);
#nullable restore
#line 22 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
WriteAttributeValue("", 1060, Model[0].PICTURE, 1060, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1077, "\')", 1077, 2, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n                                </div>\r\n                                <div>\r\n                                    <h1 class=\"font-weight-bolder font-size-h5 text-dark-75 text-hover-primary\">");
#nullable restore
#line 25 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
                                                                                                           Write(Model[0].OGR_ADI);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 25 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
                                                                                                                             Write(Model[0].OGR_SOYAD);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                                    <div class=\"text-muted\"> ");
#nullable restore
#line 26 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
                                                        Write(mail[0].Substring(0, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("*****");
#nullable restore
#line 26 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
                                                                                     Write(mail[0].Substring(mail[0].Length - 2, 2));

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
                                                                                                                              Write(Model[0].EPOSTA1.Substring(mail[0].Length, 1));

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
                                                                                                                                                                            Write(mail[1].Substring(0, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("*****");
#nullable restore
#line 26 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
                                                                                                                                                                                                         Write(mail[1].Substring(mail[1].Length - 2, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n                                    <div class=\"text-muted\">");
#nullable restore
#line 28 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
                                                       Write(Model[0].EPOSTA2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                    <div class=\"mt-2\">\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 1764, "\"", 1802, 1);
#nullable restore
#line 30 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
WriteAttributeValue("", 1771, Url.Action("Close", "Student"), 1771, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-sm btn-danger font-weight-bold py-2 px-3 px-xxl-5 my-1"">Çıkış</a>
                                    </div>
                                </div>
                            </div>
                            <div class=""py-9"">

                                <div class=""pb-3"" style=""background: #3699ff; padding-left: 10px; padding-top: 10px;"">
                                    <div class=""d-flex align-items-center justify-content-between"">
                                        <span class=""font-weight-bold mr-2"" style=""font-weight: bold !important; color:white"">Eğitim Bilgileri</span>
                                    </div>
                                </div>
                                <div style=""box-shadow: 0px 0px 30px 0px rgb(82 63 105 / 10%);"">
                                    <table class=""table table-bordered"">
                                        <thead>
                                            <tr>
                                            ");
            WriteLiteral(@"    <th scope=""col"">Fakülte</th>
                                                <th scope=""col"">Bölüm</th>
                                            </tr>
                                        </thead>
                                        <tbody>
");
#nullable restore
#line 50 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
                                             foreach (var item in Model)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>");
#nullable restore
#line 53 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
                                                   Write(item.FAKULTE_AD);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 54 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
                                                   Write(item.BOLUM_AD);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                </tr>\r\n");
#nullable restore
#line 56 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


                                        </tbody>
                                    </table>
                                </div>



                            </div>
                            <div class=""navi navi-bold navi-hover navi-active navi-link-rounded"">
                                <div class=""navi-item mb-2"">
                                    <a");
            BeginWriteAttribute("href", " href=\"", 3903, "\"", 3947, 1);
#nullable restore
#line 69 "C:\Users\muhammetkaya\source\repos\HesProject\HesProject\Views\Student\BackUp\HesCodeSave.cshtml"
WriteAttributeValue("", 3910, Url.Action("StudentInfo", "Student"), 3910, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""navi-link py-4 active"">
                                        <span class=""navi-icon mr-2"">
                                            <span class=""svg-icon"">
                                                <!--begin::Svg Icon | path:/metronic/theme/html/demo2/dist/assets/media/svg/icons/Design/Layers.svg-->
                                                <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                                    <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                                        <polygon points=""0 0 24 0 24 24 0 24""></polygon>
                                                        <path d=""M12.9336061,16.072447 L19.36,10.9564761 L19.5181585,10.8312381 C20.1676248,10.3169571 20.2772143,9.3735535 19.7629333,8.72408713 C19.6917232,8.63415859 19.6104327,8.55269514 19.5206557,8.48129411 L12.9336854,3.2425");
            WriteLiteral(@"7445 C12.3871201,2.80788259 11.6128799,2.80788259 11.0663146,3.24257445 L4.47482784,8.48488609 C3.82645598,9.00054628 3.71887192,9.94418071 4.23453211,10.5925526 C4.30500305,10.6811601 4.38527899,10.7615046 4.47382636,10.8320511 L4.63,10.9564761 L11.0659024,16.0730648 C11.6126744,16.5077525 12.3871218,16.5074963 12.9336061,16.072447 Z"" fill=""#000000"" fill-rule=""nonzero""></path>
                                                        <path d=""M11.0563554,18.6706981 L5.33593024,14.122919 C4.94553994,13.8125559 4.37746707,13.8774308 4.06710397,14.2678211 C4.06471678,14.2708238 4.06234874,14.2738418 4.06,14.2768747 L4.06,14.2768747 C3.75257288,14.6738539 3.82516916,15.244888 4.22214834,15.5523151 C4.22358765,15.5534297 4.2250303,15.55454 4.22647627,15.555646 L11.0872776,20.8031356 C11.6250734,21.2144692 12.371757,21.2145375 12.909628,20.8033023 L19.7677785,15.559828 C20.1693192,15.2528257 20.2459576,14.6784381 19.9389553,14.2768974 C19.9376429,14.2751809 19.9363245,14.2734691 19.935,14.2717619 L19.935,14.2717619");
            WriteLiteral(@" C19.6266937,13.8743807 19.0546209,13.8021712 18.6572397,14.1104775 C18.654352,14.112718 18.6514778,14.1149757 18.6486172,14.1172508 L12.9235044,18.6705218 C12.377022,19.1051477 11.6029199,19.1052208 11.0563554,18.6706981 Z"" fill=""#000000"" opacity=""0.3""></path>
                                                    </g>
                                                </svg>
                                                <!--end::Svg Icon-->
                                            </span>
                                        </span>
                                        <span class=""navi-text font-size-lg"">Hes Kodu Kaydı</span>
                                    </a>
                                </div>
                            </div>
                            <!--end::Nav-->
                        </div>

                    </div>
                    <!--end: Wizard Nav-->
                    <!--begin: Wizard Body-->
                    <div class=""wizard-body py-8 px-8 py-lg");
            WriteLiteral(@"-20 px-lg-10"" style=""margin:auto"">
                        <!--begin: Wizard Form-->
                        <div class=""row"">
                            <div class=""offset-xxl-2 col-xxl-8"" style=""text-align:center"">
                                <i class=""far fa-check-circle"" style=""color:green; font-size:50px""></i>
                                <h1 style=""font-size: 2em; color:green; text-align:center"">Başarı ile kaydedildi.</h1>
                            </div>
                            <!--end: Wizard-->
                        </div>
                        <!--end: Wizard Form-->
                    </div>
                    <!--end: Wizard Body-->
                </div>
                <!--end: Wizard-->
            </div>
        </div>
    </div>
    <!--end::Container-->
</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Student>> Html { get; private set; }
    }
}
#pragma warning restore 1591
