#pragma checksum "C:\Users\ali2004h\projects\Book\Views\Home\ReceivershipList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d406c2d24aafef9f9a086e01822be28574f4e899"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ReceivershipList), @"mvc.1.0.view", @"/Views/Home/ReceivershipList.cshtml")]
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
#line 1 "C:\Users\ali2004h\projects\Book\Views\_ViewImports.cshtml"
using Book;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ali2004h\projects\Book\Views\_ViewImports.cshtml"
using Book.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ali2004h\projects\Book\Views\Home\ReceivershipList.cshtml"
using Book.DateConvert;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d406c2d24aafef9f9a086e01822be28574f4e899", @"/Views/Home/ReceivershipList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b252a8f427cf8f6a5987d720e148396be09107fc", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ReceivershipList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Book.Data.Books>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("80"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\ali2004h\projects\Book\Views\Home\ReceivershipList.cshtml"
  
    ViewData["Title"] = "امانت کتابی";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!--<section class=""content mr-5"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-3 col-6"">-->
                <!-- small box -->
                <!--<div class=""small-box bg-info"">
                    <div class=""inner"">
                        <h3>");
#nullable restore
#line 14 "C:\Users\ali2004h\projects\Book\Views\Home\ReceivershipList.cshtml"
                       Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                        <p>مجموع کتاب ها</p>
                    </div>
                    <div class=""icon"">
                        <i class=""ion ion-ios-bookmarks""></i>
                    </div>
                </div>
            </div>-->
            <!-- ./col -->
            <!--<div class=""col-lg-3 col-6"">-->
                <!-- small box -->
                <!--<div class=""small-box bg-success"">
                    <div class=""inner"">
                        <h3>12<sup style=""font-size: 20px""></sup></h3>

                        <p>کل دانشجو ها</p>
                    </div>
                    <div class=""icon"">
                        <i class=""ion ion-person-stalker""></i>
                    </div>
                </div>
            </div>-->
            <!-- ./col -->
            <!--<div class=""col-lg-3 col-6"">-->
                <!-- small box -->
                <!--<div class=""small-box bg-warning"">
                    <div class=""inner"">
                 ");
            WriteLiteral("       <h3>");
#nullable restore
#line 42 "C:\Users\ali2004h\projects\Book\Views\Home\ReceivershipList.cshtml"
                       Write(Model.Where(p => p.Status == true).Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                        <p>کتاب های در امانت</p>
                    </div>
                    <div class=""icon"">
                        <i class=""ion ion-arrow-left-a""></i>
                    </div>
                </div>
            </div>-->
            <!-- ./col -->
            <!--<div class=""col-lg-3 col-6"">-->
                <!-- small box -->
                <!--<div class=""small-box bg-danger"">
                    <div class=""inner"">
                        <h3>");
#nullable restore
#line 56 "C:\Users\ali2004h\projects\Book\Views\Home\ReceivershipList.cshtml"
                       Write(Model.Where(p => p.Status == false).Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                        <p>کتاب های موجود برای امانت</p>
                    </div>
                    <div class=""icon"">
                        <i class=""ion ion-ios-albums""></i>
                    </div>
                </div>
            </div>-->
            <!-- ./col -->
        <!--</div>
    </div>
</section>-->

<div class=""row mt-3 mr-5"">
    <div class=""col-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h3 class=""card-title"">کتاب های در امانت</h3>
            </div>
            <div class=""card-body table-responsive p-0"">
                <table class=""table table-hover"">
                    <tr>
                        <th>شماره</th>
                        <th>تصویر</th>
                        <th>عنوان</th>
                        <th>تاریخ</th>
                        <th>تاریخ برگشت</th>
                        <th>دانشجو</th>
                    </tr>
");
#nullable restore
#line 86 "C:\Users\ali2004h\projects\Book\Views\Home\ReceivershipList.cshtml"
                     foreach (var i in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 89 "C:\Users\ali2004h\projects\Book\Views\Home\ReceivershipList.cshtml"
                   Write(i.BookId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d406c2d24aafef9f9a086e01822be28574f4e8998292", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3161, "~/Images/", 3161, 9, true);
#nullable restore
#line 90 "C:\Users\ali2004h\projects\Book\Views\Home\ReceivershipList.cshtml"
AddHtmlAttributeValue("", 3170, i.Image, 3170, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 91 "C:\Users\ali2004h\projects\Book\Views\Home\ReceivershipList.cshtml"
                   Write(i.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                    <td>");
#nullable restore
#line 93 "C:\Users\ali2004h\projects\Book\Views\Home\ReceivershipList.cshtml"
                   Write(i.CreateDate.ToShamsi().ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 94 "C:\Users\ali2004h\projects\Book\Views\Home\ReceivershipList.cshtml"
                   Write(i.DateBe.ToShamsi().ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    \r\n                    <td>");
#nullable restore
#line 96 "C:\Users\ali2004h\projects\Book\Views\Home\ReceivershipList.cshtml"
                   Write(i.StudentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 98 "C:\Users\ali2004h\projects\Book\Views\Home\ReceivershipList.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </table>\r\n            </div>\r\n            <!-- /.card-body -->\r\n        </div>\r\n        <!-- /.card -->\r\n    </div>\r\n</div><!-- /.row -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Book.Data.Books>> Html { get; private set; }
    }
}
#pragma warning restore 1591