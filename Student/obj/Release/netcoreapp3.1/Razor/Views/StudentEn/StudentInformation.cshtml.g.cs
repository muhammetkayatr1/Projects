#pragma checksum "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4563dfa8182c7d833dad86ca6f9de2216d7eab9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StudentEn_StudentInformation), @"mvc.1.0.view", @"/Views/StudentEn/StudentInformation.cshtml")]
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
#line 1 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\_ViewImports.cshtml"
using SelfServisUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4563dfa8182c7d833dad86ca6f9de2216d7eab9f", @"/Views/StudentEn/StudentInformation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3045b5b636a3c1f71c8ae83913265152b64e4a5", @"/Views/_ViewImports.cshtml")]
    public class Views_StudentEn_StudentInformation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StudentInfo>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
  
    Layout = "~/Views/Shared/_LayoutEn.cshtml";
string charData = "@";
    var Image = ViewBag.Image;
   string data="";
string[] mail = new string[2];
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
     foreach (var item in Model.data)
    {
         if(item.ogrencI_STATU.IndexOf("Aktif") >= 0)
         {
           data = item.gsM1.Substring(0, 6);
            if(item.epostA2 != null && item.epostA2 != "")
            {
            mail = item.epostA2.Split('@');
            } 
        }
     }

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
                            <!--begin::User--><div class=""d-flex align-items-center"">
                                <div class=""symbol symbol-60 symbol-xxl-100 mr-5 align-self-start align-self-xxl-center"">
");
#nullable restore
#line 35 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                     foreach (var item in Model.data)
                                        {
                                             if(item.ogrencI_STATU.IndexOf("Aktif") >= 0)
                                             {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"symbol-label\"");
            BeginWriteAttribute("style", " style=\"", 1623, "\"", 1678, 4);
            WriteAttributeValue("", 1631, "background-image:", 1631, 17, true);
            WriteAttributeValue(" ", 1648, "url(\'", 1649, 6, true);
#nullable restore
#line 39 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
WriteAttributeValue("", 1654, Model.data[0].picture, 1654, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1676, "\')", 1676, 2, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n");
#nullable restore
#line 40 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                                break;
                                            }
                                         }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                                <div>\r\n");
#nullable restore
#line 46 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                     foreach (var item in Model.data)
                                        {
                                             if(item.ogrencI_STATU.IndexOf("Aktif") >= 0)
                                             {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <h1 class=\"font-weight-bolder font-size-h5 text-dark-75 text-hover-primary\">");
#nullable restore
#line 50 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                                                                                           Write(item.ogR_ADI);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 50 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                                                                                                         Write(item.ogR_SOYAD);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 51 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                    if(item.epostA2 != "")
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"text-muted\"> ");
#nullable restore
#line 53 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                                        Write(mail[0].Substring(0, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("*****");
#nullable restore
#line 53 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                                                                     Write(mail[0].Substring(mail[0].Length - 2, 2));

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                                                                                                              Write(charData);

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                                                                                                                       Write(mail[1]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 54 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                    }
                                   break;
                                            }
                                         }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"mt-2\">\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 2843, "\"", 2881, 1);
#nullable restore
#line 59 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
WriteAttributeValue("", 2850, Url.Action("Close", "Student"), 2850, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-danger font-weight-bold py-2 px-3 px-xxl-5 my-1\">Log Out</a>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                            <div>\r\n\r\n");
#nullable restore
#line 65 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                 foreach (var item in Model.data)
                                        {
                                             if(item.ogrencI_STATU.IndexOf("Aktif") >= 0)
                                             {

                                    if (item.epostA1 == "" || item.epostA1.IndexOf("ogr.halic.edu.tr") < 0)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""pb-3"" style=""padding-left: 10px; padding-top: 10px;"">
                                    <div class=""d-flex align-items-center justify-content-between"">
                                        <span class=""font-weight-bold mr-2"" style=""font-weight: bold !important; color:red"">Email : Contact to Student Affairs.</span>
                                    </div>
                                </div>
");
#nullable restore
#line 77 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""pb-3"" style=""padding-left: 10px; padding-top: 10px;"">
                                    <div class=""d-flex align-items-center justify-content-between"">
                                        <span class=""font-weight-bold mr-2"" style=""font-weight: bold !important; color:green"">Email : ");
#nullable restore
#line 82 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                                                                                                                 Write(item.epostA1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 85 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                    }
                                                break;
                                            }
                                         }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </div>
                            <div class=""pb-9"">

                                <div class=""pb-3"" style=""background: #3699ff; padding-left: 10px; padding-top: 10px;"">
                                    <div class=""d-flex align-items-center justify-content-between"">
                                        <span class=""font-weight-bold mr-2"" style=""font-weight: bold !important; color:white"">Education Information</span>
                                    </div>
                                </div>
                                <div style=""box-shadow: 0px 0px 30px 0px rgb(82 63 105 / 10%);"">
                                    <table class=""table table-bordered"">
                                        <thead>
                                            <tr>
                                                <th scope=""col"">Student Number</th>
                                                <th scope=""col"">Faculty/Program</th>
                                   ");
            WriteLiteral("         </tr>\r\n                                        </thead>\r\n                                        <tbody>\r\n");
#nullable restore
#line 106 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                             foreach (var item in Model.data)
                                        {
                                           if(item.ogrencI_STATU.IndexOf("Aktif") >= 0)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>");
#nullable restore
#line 111 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                               Write(item.ogR_NO);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 112 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                               Write(item.fakultE_AD);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 112 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                                                  Write(item.boluM_AD);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n");
#nullable restore
#line 114 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
                                            }
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
            BeginWriteAttribute("href", " href=\"", 6853, "\"", 6906, 1);
#nullable restore
#line 127 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
WriteAttributeValue("", 6860, Url.Action("StudentInformation", "StudentEn"), 6860, 46, false);

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
                                        <span class=""navi-text font-size-lg"">User Guide</span>
                                    </a>
                                </div>
                                <div class=""navi-item mb-2"">
                                    <a");
            BeginWriteAttribute("href", " href=\"", 9782, "\"", 9830, 1);
#nullable restore
#line 145 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
WriteAttributeValue("", 9789, Url.Action("ADStudentInfo", "StudentEn"), 9789, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""navi-link py-4"">
                                        <span class=""navi-icon mr-2"">
                                            <span class=""svg-icon"">
                                                <!--begin::Svg Icon | path:/metronic/theme/html/demo2/dist/assets/media/svg/icons/Communication/Shield-user.svg-->
                                                <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                                    <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                                        <rect x=""0"" y=""0"" width=""24"" height=""24""></rect>
                                                        <path d=""M4,4 L11.6314229,2.5691082 C11.8750185,2.52343403 12.1249815,2.52343403 12.3685771,2.5691082 L20,4 L20,13.2830094 C20,16.2173861 18.4883464,18.9447835 16,20.5 L12.5299989,22.6687507 C12.2057287,22.8714196 11.7");
            WriteLiteral(@"942713,22.8714196 11.4700011,22.6687507 L8,20.5 C5.51165358,18.9447835 4,16.2173861 4,13.2830094 L4,4 Z"" fill=""#000000"" opacity=""0.3""></path>
                                                        <path d=""M12,11 C10.8954305,11 10,10.1045695 10,9 C10,7.8954305 10.8954305,7 12,7 C13.1045695,7 14,7.8954305 14,9 C14,10.1045695 13.1045695,11 12,11 Z"" fill=""#000000"" opacity=""0.3""></path>
                                                        <path d=""M7.00036205,16.4995035 C7.21569918,13.5165724 9.36772908,12 11.9907452,12 C14.6506758,12 16.8360465,13.4332455 16.9988413,16.5 C17.0053266,16.6221713 16.9988413,17 16.5815,17 C14.5228466,17 11.463736,17 7.4041679,17 C7.26484009,17 6.98863236,16.6619875 7.00036205,16.4995035 Z"" fill=""#000000"" opacity=""0.3""></path>
                                                    </g>
                                                </svg>
                                                <!--end::Svg Icon-->
                                            </span>
                 ");
            WriteLiteral(@"                       </span>
                                        <span class=""navi-text font-size-lg"">Change Password</span>
                                    </a>
                                </div>
                            </div>
                            <!--end::Nav-->
                        </div>

                    </div>
                    <!--end: Wizard Nav-->
                    <!--begin: Wizard Body-->
                    <div class=""wizard-body py-8 px-8 py-lg-20 px-lg-10"" style=""margin:auto"">
                        <!--begin: Wizard Form-->
                        <div class=""row"">
                            <div class=""offset-xxl-2 col-xxl-8"">

                                <div class=""timeline timeline-5"">
                                    <div class=""timeline-items"">
                                        <div class=""timeline-item"">
                                            <!--begin::Icon-->
                                            <div cla");
            WriteLiteral(@"ss=""timeline-media bg-light-danger"">
                                                <span class=""svg-icon-danger svg-icon-md"">
                                                    1
                                                </span>
                                            </div>
                                            <!--end::Icon-->
                                            <!--begin::Info-->
                                            <div class=""timeline-desc timeline-desc-light-danger"">
                                                <span class=""font-weight-bolder text-danger"">Beginning</span>
                                                <p class=""font-weight-normal text-dark-50 pt-1"">
                                                    If you want to create a new password, you have to click Change Password from the menu.
                                                </p>
                                            </div>
                                            <!--e");
            WriteLiteral(@"nd::Info-->
                                        </div>
                                        <!--begin::Item-->
                                        <!--end::Item-->
                                        <!--begin::Item-->
                                        <div class=""timeline-item"">
                                            <!--begin::Icon-->
                                            <div class=""timeline-media bg-light-warning"">
                                                <span class=""svg-icon-warning svg-icon-md"">
                                                    2
                                                </span>
                                            </div>
                                            <!--end::Icon-->
                                            <!--begin::Info-->
                                            <div class=""timeline-desc timeline-desc-light-warning"">
                                                <span class=""font-weight-bold");
            WriteLiteral(@"er text-warning"">Phone Verification</span>
                                                <p class=""font-weight-normal text-dark-50 pt-1 pb-2"">
                                                    In this step, you have to write the last four digits of your phone number registered in Student Affairs. After that, you will click Continue button.
                                                </p>
                                            </div>
                                            <!--end::Info-->
                                        </div>
                                        <!--end::Item-->
                                        <!--begin::Item-->
                                        <div class=""timeline-item"">
                                            <!--begin::Icon-->
                                            <div class=""timeline-media bg-light-success"">
                                                <span class=""svg-icon-success svg-icon-md"">
                        ");
            WriteLiteral(@"                            3
                                                </span>
                                            </div>
                                            <!--end::Icon-->
                                            <!--begin::Info-->
                                            <div class=""timeline-desc timeline-desc-light-success"">
                                                <span class=""font-weight-bolder text-success"">Get Password</span>
                                                <p class=""font-weight-normal text-dark-50 pt-1 pb-2"">
                                                    If you complete the application fields correctly, your new password will be sent to your phone number as an SMS. In addition, information e-mail will be sent to your personal e-mail address.
                                                </p>
                                            </div>
                                            <!--end::Info-->
                           ");
            WriteLiteral(@"             </div>
                                        <!--end::Item-->
                                        <!--begin::Item-->
                                        <!--end::Item-->
                                    </div>
                                </div>


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
#nullable restore
#line 255 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
 if (ViewBag.Error == "ADError")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""modal fade"" id=""exampleModalScrollable"" tabindex=""-1"" role=""dialog"" aria-labelledby=""staticBackdrop"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-scrollable"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Attention</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <i aria-hidden=""true"" class=""ki ki-close""></i>
                </button>
            </div>
            <div class=""modal-body"" style=""height: 100px;"">
                Your registered information could not be found in our system. Please contact the IT Department.

            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-primary font-weight-bold"" data-dismiss=""modal"">Ok</button>
            </div>
        </div>
    </div>
</div>
<script src=""https://ajax.googleapis.com/ajax/li");
            WriteLiteral("bs/jquery/3.6.0/jquery.min.js\"></script>\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\"#exampleModalScrollable\").modal(\'show\');\r\n    });\r\n</script>\r\n");
#nullable restore
#line 282 "C:\Users\muhammetkaya\Desktop\Projeler\Student\Views\StudentEn\StudentInformation.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StudentInfo> Html { get; private set; }
    }
}
#pragma warning restore 1591
