#pragma checksum "D:\ProjectWord\Cosmetic-Store\TECH\WEBSITE\Areas\Admin\Views\Acount\ViewRegistration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7da9f7685db247a138fcb4b001aff80d13958ccd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Acount_ViewRegistration), @"mvc.1.0.view", @"/Areas/Admin/Views/Acount/ViewRegistration.cshtml")]
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
#line 1 "D:\ProjectWord\Cosmetic-Store\TECH\WEBSITE\Areas\Admin\Views\_ViewImports.cshtml"
using WEBSITE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ProjectWord\Cosmetic-Store\TECH\WEBSITE\Areas\Admin\Views\_ViewImports.cshtml"
using WEBSITE.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\ProjectWord\Cosmetic-Store\TECH\WEBSITE\Areas\Admin\Views\Acount\ViewRegistration.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ProjectWord\Cosmetic-Store\TECH\WEBSITE\Areas\Admin\Views\Acount\ViewRegistration.cshtml"
using WEBSITE.Data.DatabaseEntity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7da9f7685db247a138fcb4b001aff80d13958ccd", @"/Areas/Admin/Views/Acount/ViewRegistration.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"566e11193e06d5b16c73522a53c4e952c0238a84", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Acount_ViewRegistration : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("registration"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hold-transition register-page"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "D:\ProjectWord\Cosmetic-Store\TECH\WEBSITE\Areas\Admin\Views\Acount\ViewRegistration.cshtml"
  
    ViewData["Title"] = "Home Page";
 Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7da9f7685db247a138fcb4b001aff80d13958ccd5359", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <title>Đăng ký</title>

    <!-- Google Font: Source Sans Pro -->
    <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback"">
    <!-- Font Awesome -->
    <link rel=""stylesheet"" href=""/admin/plugins/fontawesome-free/css/all.min.css"">
    <!-- icheck bootstrap -->
");
                WriteLiteral("    <!-- Theme style -->\r\n    <link rel=\"stylesheet\" href=\"/admin/dist/css/adminlte.min.css\">\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7da9f7685db247a138fcb4b001aff80d13958ccd6919", async() => {
                WriteLiteral(@"
    <style type=""text/css"">
        input.error {
            border-color: #f00 !important;
        }

        label.error {
            clear: both;
            color: #f00;
            display: block;
            /* padding: 10px; */
            text-align: left;
            margin: unset;
            padding: unset;
            font-size: 13px;
            font-weight: unset !important;
            background: unset;
        }
    </style>
    <div class=""register-box"">
");
#nullable restore
#line 48 "D:\ProjectWord\Cosmetic-Store\TECH\WEBSITE\Areas\Admin\Views\Acount\ViewRegistration.cshtml"
         if (!SignInManager.IsSignedIn(User))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <p>Bạn chưa đăng nhập </p>\r\n");
#nullable restore
#line 51 "D:\ProjectWord\Cosmetic-Store\TECH\WEBSITE\Areas\Admin\Views\Acount\ViewRegistration.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <div class=\"card\">\r\n                <div class=\"card-body register-card-body\">\r\n                    <p class=\"login-box-msg\">Register a new membership ");
#nullable restore
#line 55 "D:\ProjectWord\Cosmetic-Store\TECH\WEBSITE\Areas\Admin\Views\Acount\ViewRegistration.cshtml"
                                                                  Write(UserManager.GetUserName(User));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7da9f7685db247a138fcb4b001aff80d13958ccd8739", async() => {
                    WriteLiteral(@"
                        <div class=""mb-3"" style=""position:relative"">
                            <input type=""text"" class=""form-control"" name=""txtFullName"" placeholder=""Full Name"">
                            <span class=""fas fa-user"" style=""position:absolute;right:10px;top:10px;""></span>
                        </div>
                        <div class=""mb-3"" style=""position:relative"">
                            <input type=""text"" class=""form-control"" name=""txtUserName"" placeholder=""User Name"">
                            <span class=""fas fa-user"" style=""position:absolute;right:10px;top:10px;""></span>
                        </div>
                        <div class=""mb-3"" style=""position:relative"">
                            <input type=""text"" class=""form-control"" name=""txtPhone"" placeholder=""Phone"">
                            <span class=""fas fa-envelope"" style=""position:absolute;right:10px;top:10px;""></span>
");
                    WriteLiteral("                        </div>\r\n                        <div class=\"mb-3\" style=\"position:relative\">\r\n");
                    WriteLiteral(@"                            <input type=""email"" class=""form-control"" name=""txtEmail"" placeholder=""Email"">
                            <span class=""fas fa-envelope"" style=""position:absolute;right:10px;top:10px;""></span>
                        </div>
                        <div class=""mb-3"" style=""position:relative"">
                            <input type=""password"" class=""form-control"" name=""txtPassword"" placeholder=""Password"" id=""txtPassword"">
                            <span class=""fas fa-lock"" style=""position:absolute;right:10px;top:10px;""></span>
");
                    WriteLiteral(@"                        </div>
                        <div class=""mb-3"" style=""position:relative"">
                            <input type=""password"" class=""form-control"" name=""txtRetypePassword"" placeholder=""Retype password"">
                            <span class=""fas fa-lock"" style=""position:absolute;right:10px;top:10px;""></span>
");
                    WriteLiteral(@"                        </div>
                        <div class=""row"">
                            <div class=""col-8"">
                                <div class=""icheck-primary"">
                                    <input type=""checkbox"" id=""agreeTerms"" name=""terms"" value=""agree"">
                                    <label for=""agreeTerms"">
                                        I agree to the <a href=""#"">terms</a>
                                    </label>
                                </div>
                            </div>
                            <!-- /.col -->
                            <div class=""col-4"">
                                <button type=""submit"" class=""btn btn-primary btn-block"">Register</button>
                            </div>
                            <!-- /.col -->
                        </div>
                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

                    <div class=""social-auth-links text-center"">
                        <p>- OR -</p>
                        <a href=""#"" class=""btn btn-block btn-primary"">
                            <i class=""fab fa-facebook mr-2""></i>
                            Sign up using Facebook
                        </a>
                        <a href=""#"" class=""btn btn-block btn-danger"">
                            <i class=""fab fa-google-plus mr-2""></i>
                            Sign up using Google+
                        </a>
                    </div>

                    <a href=""login.html"" class=""text-center"">I already have a membership</a>
                </div>
                <!-- /.form-box -->
            </div><!-- /.card -->
        </div>
    <!-- /.register-box -->
    <!-- jQuery -->
    <script src=""/admin/plugins/jquery/jquery.min.js""></script>
    <!-- Bootstrap 4 -->
    <script src=""/admin/plugins/bootstrap/js/bootstrap.bundle.min.js""></script>
    <!-- AdminLTE");
                WriteLiteral(@" App -->
    <script src=""/admin/dist/js/adminlte.min.js""></script>
    <script src=""/admin/plugins/jquery-validation/jquery.validate.min.js""></script>
    <script>
        $(document).ready(function () {

            $('#registration').validate({
                rules: {
                    txtFullName: {
                        required: true,
                    },
                    txtUserName: {
                        required: true,
                    },
                    txtPhone: {
                        required: true,
                    },
                    txtPassword: {
                        required: true,
                    },
                    txtRetypePassword: {
                        required: true,
                        equalTo: ""#txtPassword""
                    },
                    txtEmail: {
                        required: true,
                    }
                },
                messages: {
                    txtUserName: {
    ");
                WriteLiteral(@"                    required: ""Bạn phải User Name"",
                    },
                    txtFullName: {
                        required: ""Bạn phải nhập tên"",
                    },
                    txtPhone: {
                        required: ""Bạn chưa nhập số điện thoại"",
                    },
                    txtEmail: {
                        required: ""Bạn chưa nhập email"",
                    },
                    txtPassword: {
                        required: ""Bạn chưa nhập password"",
                    },
                    txtRetypePassword: {
                        required: ""Vui lòng nhập lại password"",
                        equalTo: ""Password nhập lại không đúng.""
                    }
                },
                submitHandler: function () {
                    $.ajax({
                        url: '/Admin/Acount/CreateRegistration',
                        type: 'POST',
                        data: {
                            user: {
     ");
                WriteLiteral(@"                           UserName: $(""input[name=txtUserName]"").val(),
                                Name: $(""input[name=txtFullName]"").val(),
                                Email: $(""input[name=txtEmail]"").val(),
                                PhoneNumber: $(""input[name=txtPhone]"").val()
                            },
                            password: $(""input[name=txtPassword]"").val()

                        },                        
                        dataType: 'json',
                        beforeSend: function () {

                        },
                        success: function (response) {
                            console.log(response);
                            //if (response.status) {
                            //    var data = response.data;
                            //    var html = '';
                            //    var template = $('#data-template').html();
                            //    $.each(data, function (i, item) {
                    ");
                WriteLiteral(@"        //        html += Mustache.render(template, {
                            //            ID: item.ID,
                            //            Name: item.Name,
                            //            Salary: item.Salary,
                            //            Status: item.Status == true ? ""<span class=\""label label-success\"">Actived</span>"" : ""<span class=\""label label-danger\"">Locked</span>""
                            //        });

                            //    });
                            //    $('#tblData').html(html);
                            //    homeController.paging(response.total, function () {
                            //        homeController.loadData();
                            //    }, changePageSize);
                            //    homeController.registerEvent();
                            //}
                        }
                    })
                }
            });


        });

    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<Staff> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<Staff> SignInManager { get; private set; }
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
