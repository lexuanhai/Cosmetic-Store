#pragma checksum "C:\hoc-tap\ban-mu-bao-hiem\TECH\WEBSITE\Areas\Admin\Views\Colors\_Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7a47f4684c64d82807ac9415ffe7749a34036bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Colors__Search), @"mvc.1.0.view", @"/Areas/Admin/Views/Colors/_Search.cshtml")]
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
#line 1 "C:\hoc-tap\ban-mu-bao-hiem\TECH\WEBSITE\Areas\Admin\Views\_ViewImports.cshtml"
using WEBSITE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\hoc-tap\ban-mu-bao-hiem\TECH\WEBSITE\Areas\Admin\Views\_ViewImports.cshtml"
using WEBSITE.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7a47f4684c64d82807ac9415ffe7749a34036bb", @"/Areas/Admin/Views/Colors/_Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"566e11193e06d5b16c73522a53c4e952c0238a84", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Colors__Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<style>
    .customcollapse{
        overflow-y:hidden;
    }
    .customcollapse, .customcollapse .body-search {
        width: 100%;
    }
    .box-footer-search .box-content{
        float:right;
    }
</style>
<div class=""collapse customcollapse"" id=""boxSearch"">
    <div class=""card card-body body-search"">
        <div class=""row"">
            <div class=""col-6"">
                <label>Tên màu</label>
                <div class=""form-group"">
                    <input type=""text"" class=""form-control name-search"" placeholder=""tên màu"" autocomplete=""off"">                    
                </div>
            </div>
            <div class=""col-6"">
                <label>Mã màu</label>
                <div class=""form-group"">
                    <input type=""text"" class=""form-control code-search"" placeholder=""mã màu"" autocomplete=""off"">                    
                </div>
            </div>
        </div>
        <div class=""form-group box-footer-search"">
            <div c");
            WriteLiteral(@"lass=""box-content"">
                <button type=""button"" class=""btn btn-danger btn-cancel-search"" data-toggle=""collapse"" data-target=""#boxSearch"" aria-expanded=""false"" aria-controls=""collapseExample"">Hủy</button>
                <button type=""button"" class=""btn btn-primary btn-submit-search"">Tìm kiếm</button>
            </div>
            
        </div>  
    </div>
    
</div>");
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
