#pragma checksum "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0a36b0001596874b3b4799cea2c70391ecbd7cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Hoadon), @"mvc.1.0.view", @"/Views/Home/Hoadon.cshtml")]
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
#line 1 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\_ViewImports.cshtml"
using ASP_Foody_Ordering;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\_ViewImports.cshtml"
using ASP_Foody_Ordering.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0a36b0001596874b3b4799cea2c70391ecbd7cc", @"/Views/Home/Hoadon.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5e92849046d3e483da754aeea385ef386d73321", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Hoadon : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ASP_Foody_Ordering.Models.Hoadon>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Chitiethoadon", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<div class=""container-fluid px-4"">
    <div class=""card mb-4"">
        <div class=""card-header"">
            <h1 class=""mt-4"">Danh sách hóa đơn</h1>
        </div>
        <div class=""card-body"">
            <table class=""table"">
                <thead>
                    <tr>
                        <th>
                            ");
#nullable restore
#line 13 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml"
                       Write(Html.DisplayNameFor(model => model.Ngay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 16 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml"
                       Write(Html.DisplayNameFor(model => model.TongTien));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 19 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml"
                       Write(Html.DisplayNameFor(model => model.MaTkNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th> \r\n                            ");
#nullable restore
#line 22 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml"
                       Write(Html.DisplayNameFor(model => model.TrangThai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th></th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 28 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 32 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Ngay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 35 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml"
                           Write(item.TongTien.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 38 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml"
                           Write(Html.DisplayFor(modelItem => item.MaTkNavigation.Ten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n");
#nullable restore
#line 40 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml"
                             if (item.TrangThai==0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>Đã tạo đơn hàng</td>\r\n");
#nullable restore
#line 43 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml"
                            }
                            else if (item.TrangThai==1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>Đã giao hàng</td>\r\n");
#nullable restore
#line 47 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>Đã hủy đơn hàng</td>\r\n");
#nullable restore
#line 51 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0a36b0001596874b3b4799cea2c70391ecbd7cc8841", async() => {
                WriteLiteral("Chi tiết");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml"
                                                                WriteLiteral(item.MaHd);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 56 "C:\Users\Home\Documents\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Hoadon.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ASP_Foody_Ordering.Models.Hoadon>> Html { get; private set; }
    }
}
#pragma warning restore 1591
