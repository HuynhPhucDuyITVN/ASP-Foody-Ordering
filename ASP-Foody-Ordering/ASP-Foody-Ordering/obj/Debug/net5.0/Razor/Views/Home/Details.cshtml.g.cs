#pragma checksum "C:\Users\Home\Documents\ASPTEST\Fix UI and some little thing\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84776f8ccccdd436d7573493ece76a14d0633743"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
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
#line 1 "C:\Users\Home\Documents\ASPTEST\Fix UI and some little thing\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\_ViewImports.cshtml"
using ASP_Foody_Ordering;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Home\Documents\ASPTEST\Fix UI and some little thing\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\_ViewImports.cshtml"
using ASP_Foody_Ordering.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84776f8ccccdd436d7573493ece76a14d0633743", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5e92849046d3e483da754aeea385ef386d73321", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ASP_Foody_Ordering.Models.Monan>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-thumbnail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:400px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Home\Documents\ASPTEST\Fix UI and some little thing\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<section>\r\n    <div class=\"container\">\r\n        <div class=\"card\">\r\n            <div class=\"card-body\">\r\n                <h3 class=\"text-center font-weight-bold text-success\">");
#nullable restore
#line 12 "C:\Users\Home\Documents\ASPTEST\Fix UI and some little thing\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Details.cshtml"
                                                                 Write(Html.DisplayFor(model => model.Ten));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <div class=\"row\">\r\n                    <div class=\"col-lg-5 col-md-5 col-sm-6\">\r\n                        <div class=\"white-box text-center\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "84776f8ccccdd436d7573493ece76a14d06337436195", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 546, "~/images/MonAn/", 546, 15, true);
#nullable restore
#line 16 "C:\Users\Home\Documents\ASPTEST\Fix UI and some little thing\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Details.cshtml"
AddHtmlAttributeValue("", 561, Html.DisplayFor(model => model.HinhAnh), 561, 40, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-lg-7 col-md-7 col-sm-6\">\r\n                        <h4 class=\"box-title mt-5\">Mô tả</h4>\r\n                        <p>");
#nullable restore
#line 21 "C:\Users\Home\Documents\ASPTEST\Fix UI and some little thing\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Details.cshtml"
                      Write(Html.DisplayFor(model => model.MoTa));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <h2 class=\"mt-5\">\r\n");
#nullable restore
#line 23 "C:\Users\Home\Documents\ASPTEST\Fix UI and some little thing\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Details.cshtml"
                              
                                var culture = new System.Globalization.CultureInfo("vi-VN");
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
#nullable restore
#line 26 "C:\Users\Home\Documents\ASPTEST\Fix UI and some little thing\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Details.cshtml"
                       Write(String.Format(culture, "{0:C0}", Model.GiaBan));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n");
#nullable restore
#line 27 "C:\Users\Home\Documents\ASPTEST\Fix UI and some little thing\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Details.cshtml"
                             if (Model.GiaBan != Model.GiaGoc)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <small class=\"text-danger\" style=\"text-decoration: line-through;\">");
#nullable restore
#line 29 "C:\Users\Home\Documents\ASPTEST\Fix UI and some little thing\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Details.cshtml"
                                                                                             Write(String.Format(culture, "{0:C0}", Model.GiaGoc));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n");
#nullable restore
#line 30 "C:\Users\Home\Documents\ASPTEST\Fix UI and some little thing\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Details.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </h2>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84776f8ccccdd436d7573493ece76a14d063374310533", async() => {
                WriteLiteral("\r\n                            <i class=\"fa fa-shopping-cart\"></i>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\Users\Home\Documents\ASPTEST\Fix UI and some little thing\ASP-Foody-Ordering\ASP-Foody-Ordering\ASP-Foody-Ordering\Views\Home\Details.cshtml"
                                                                                                  WriteLiteral(Model.MaMa);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ASP_Foody_Ordering.Models.Monan> Html { get; private set; }
    }
}
#pragma warning restore 1591
