#pragma checksum "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13de9f21a92ee72f823c815ed7ac52661d4e4eee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hoadons_Details), @"mvc.1.0.view", @"/Views/Hoadons/Details.cshtml")]
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
#line 1 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\_ViewImports.cshtml"
using ASP_Foody_Ordering;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\_ViewImports.cshtml"
using ASP_Foody_Ordering.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13de9f21a92ee72f823c815ed7ac52661d4e4eee", @"/Views/Hoadons/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5e92849046d3e483da754aeea385ef386d73321", @"/Views/_ViewImports.cshtml")]
    public class Views_Hoadons_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ASP_Foody_Ordering.Models.Hoadon>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<section class=""py-3"">
    <div class=""container"">
        <div class=""row justify-content-center"">
            <div class=""col-md-6"">
                <div class=""card shadow"">
                    <div class=""card-header bg-info text-white text-center"">
                        <h3>Thông tin đơn hàng</h3>
                    </div>
                    <div class=""card-body"">
                        <ul class=""list-group list-group-flush"">
                            <li class=""list-group-item""><strong>");
#nullable restore
#line 19 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml"
                                                           Write(Html.DisplayNameFor(model => model.Ngay));

#line default
#line hidden
#nullable disable
            WriteLiteral(": </strong>");
#nullable restore
#line 19 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml"
                                                                                                               Write(Html.DisplayFor(model => model.Ngay));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            <li class=\"list-group-item\"><strong>");
#nullable restore
#line 20 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml"
                                                           Write(Html.DisplayNameFor(model => model.TongTien));

#line default
#line hidden
#nullable disable
            WriteLiteral(": </strong>");
#nullable restore
#line 20 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml"
                                                                                                                   Write(Model.TongTien.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            <li class=\"list-group-item\"><strong>");
#nullable restore
#line 21 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml"
                                                           Write(Html.DisplayNameFor(model => model.MaTkNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral(": </strong>");
#nullable restore
#line 21 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml"
                                                                                                                         Write(Html.DisplayFor(model => model.MaTkNavigation.Ten));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 22 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml"
                             if (Model.TrangThai == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"list-group-item\"><strong>");
#nullable restore
#line 24 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml"
                                                               Write(Html.DisplayNameFor(model => model.TrangThai));

#line default
#line hidden
#nullable disable
            WriteLiteral(": </strong>Đã tạo đơn hàng</li>\r\n");
#nullable restore
#line 25 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml"
                            }
                            else if(Model.TrangThai == 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"list-group-item\"><strong>");
#nullable restore
#line 28 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml"
                                                               Write(Html.DisplayNameFor(model => model.TrangThai));

#line default
#line hidden
#nullable disable
            WriteLiteral(": </strong>Đơn hàng đã giao</li>\r\n");
#nullable restore
#line 29 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"list-group-item\"><strong>");
#nullable restore
#line 32 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml"
                                                               Write(Html.DisplayNameFor(model => model.TrangThai));

#line default
#line hidden
#nullable disable
            WriteLiteral(": </strong>Đã hủy đơn hàng</li>\r\n");
#nullable restore
#line 33 "D:\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Hoadons\Details.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ul>\r\n                    </div>\r\n                    <div class=\"card-footer text-center\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13de9f21a92ee72f823c815ed7ac52661d4e4eee9421", async() => {
                WriteLiteral("Quay về");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ASP_Foody_Ordering.Models.Hoadon> Html { get; private set; }
    }
}
#pragma warning restore 1591
