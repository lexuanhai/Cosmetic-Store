#pragma checksum "E:\c#\Website\Cosmetic Store\TECH\WEBSITE\Areas\Admin\Views\Product\_AddUpdate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a1c5c6edf6987523d77d6e62dc3d8ec15569453f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product__AddUpdate), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/_AddUpdate.cshtml")]
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
#line 1 "E:\c#\Website\Cosmetic Store\TECH\WEBSITE\Areas\Admin\Views\_ViewImports.cshtml"
using WEBSITE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\c#\Website\Cosmetic Store\TECH\WEBSITE\Areas\Admin\Views\_ViewImports.cshtml"
using WEBSITE.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1c5c6edf6987523d77d6e62dc3d8ec15569453f", @"/Areas/Admin/Views/Product/_AddUpdate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"566e11193e06d5b16c73522a53c4e952c0238a84", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Product__AddUpdate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "#", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formSubmitAdd"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"box-group-content\">\r\n    <div class=\"box-content\" style=\"background:#fff;\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a1c5c6edf6987523d77d6e62dc3d8ec15569453f4814", async() => {
                WriteLiteral(@"
            <div class=""container"">
                <h3 class=""txt-title text-center"">Thêm mới sản phẩm</h3>
                <div class=""row"">
                    <div class=""col-sm-6"">
                        <div class=""form-group"">
                            <label>Tên sản phẩm:</label>
                            <input type=""text"" class=""form-control product-name"" name=""name"" autocomplete=""off""/>
                        </div>
                        <div class=""row"">
                            <div class=""form-group col-sm-6"">
                                <label>Danh mục:</label>
                                <select class=""form-control categoryid"" name=""categoryid"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a1c5c6edf6987523d77d6e62dc3d8ec15569453f5834", async() => {
                    WriteLiteral("text");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                </select>
                            </div>
                            <div class=""form-group col-sm-6"">
                                <label>Thương hiệu:</label>
                                <select class=""form-control brandsid"">
                                </select>
                            </div>
                        </div>

                        <div class=""row"">
                            <div class=""form-group col-sm-6"">
                                <label>Ngày sản xuất:</label>
                                <input type=""text"" name=""manufacturingdate""");
                BeginWriteAttribute("value", " value=\"", 1547, "\"", 1555, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control customdate manufacturingdate"" autocomplete=""off""/>
                            </div>
                            <div class=""form-group col-sm-6"">
                                <label>Hạn sử dụng:</label>
                                <input type=""text"" name=""expirydate""");
                BeginWriteAttribute("value", " value=\"", 1857, "\"", 1865, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control customdate expirydate"" autocomplete=""off""/>
                            </div>
                        </div>

                    </div>
                    <div class=""col-sm-6"">
                        <div class=""row"">
                            <div class=""form-group col-sm-6"">
                                <label>Giá:</label>
                                <input type=""text"" class=""form-control price"" name=""price""");
                BeginWriteAttribute("value", "  value=\"", 2323, "\"", 2332, 0);
                EndWriteAttribute();
                WriteLiteral(@" autocomplete=""off""/>
                            </div>
                            <div class=""form-group col-sm-6"">
                                <label>Giá giảm:</label>
                                <input type=""text"" class=""form-control reduced-price""");
                BeginWriteAttribute("value", "  value=\"", 2598, "\"", 2607, 0);
                EndWriteAttribute();
                WriteLiteral(@" autocomplete=""off""/>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""form-group col-sm-6"">
                                <label>Tổng số sản phẩm:</label>
                                <input type=""text"" class=""form-control total""");
                BeginWriteAttribute("value", "  value=\"", 2948, "\"", 2957, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""total"" autocomplete=""off""/>
                            </div>
                            <div class=""form-group col-sm-6"">
                                <label>Màu:</label>
                                <select class=""form-control colorsid"">                                    
                                </select>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""form-group col-sm-6"">
                                <label>Trạng thái:</label>
                                <select class=""form-control selectstatus"" name=""selectstatus"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a1c5c6edf6987523d77d6e62dc3d8ec15569453f10604", async() => {
                    WriteLiteral("text");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                </select>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""form-group"">
                    <label>Ảnh sản phẩm: <a href=""javascript:void(0)"" class=""add-image"">Thêm ảnh</a></label>
                    <div class=""box-images"">
                        <input id=""file-input"" class=""filesImages"" type=""file"" multiple/>
                        <div class=""image-upload item-image image-default"">
                        </div>
                    </div>
                </div>

                <div class=""form-group"" style=""display:inline-block;width:100%;"">
                    <label>Mô tả ngắn:</label>
                    <textarea id=""txtsubContent"" rows=""6"" class=""form-control"" name=""subdecription""></textarea>
                </div>
                <div class=""form-group"">
                    <div class=""form-group"" style=""display:inline-block;width:100%;"">
          ");
                WriteLiteral(@"              <label>Mô tả chi tiết:</label>
                        <textarea id=""txtContentdetail"" rows=""6"" class=""form-control"" name=""decription""></textarea>
                    </div>
                </div>
                <div class=""form-group text-center"">
                    <button type=""button"" class=""btn btn-danger btn-cancel"" style=""width: 100px"">Hủy</button>
                    <button type=""submit"" class=""btn btn-primary"" style=""width: 100px"">Lưu</button>
                </div>
            </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
