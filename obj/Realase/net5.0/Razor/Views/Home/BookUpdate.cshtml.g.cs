#pragma checksum "C:\Users\ali2004h\projects\Book\Views\Home\BookUpdate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff1f9184bd43f6ed28c49bc98da7539ce382b53d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_BookUpdate), @"mvc.1.0.view", @"/Views/Home/BookUpdate.cshtml")]
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
#line 5 "C:\Users\ali2004h\projects\Book\Views\Home\BookUpdate.cshtml"
using Book.DateConvert;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff1f9184bd43f6ed28c49bc98da7539ce382b53d", @"/Views/Home/BookUpdate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b252a8f427cf8f6a5987d720e148396be09107fc", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_BookUpdate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Book.Data.Books>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ali2004h\projects\Book\Views\Home\BookUpdate.cshtml"
  
    ViewData["Title"] = "کتاب ها";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!--<section class=\"content  \">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-3 col-6\">-->\r\n<!-- small box -->\r\n<!--<div class=\"small-box bg-info\">\r\n        <div class=\"inner\">\r\n            <h3>");
#nullable restore
#line 13 "C:\Users\ali2004h\projects\Book\Views\Home\BookUpdate.cshtml"
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
            <h3>53<sup style=""font-size: 20px""></sup></h3>

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
            <h3>44</h3>

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
        <div class=""inn");
            WriteLiteral(@"er"">
            <h3>65</h3>

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

<div class=""row mt-3  "">
    <div class=""col-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h3 class=""card-title"">کتاب  ها</h3>
            </div>
            <div class=""card-body table-responsive p-0"">
                <table class=""table table-hover"">
                    <tr>
                        <th>شماره</th>
                        <th>عنوان</th>
                        <th>تاریخ</th>
                        <th>نویسنده</th>
                        <th>ویرایش</th>

                    </tr>
");
#nullable restore
#line 85 "C:\Users\ali2004h\projects\Book\Views\Home\BookUpdate.cshtml"
                     foreach (var i in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <th>");
#nullable restore
#line 88 "C:\Users\ali2004h\projects\Book\Views\Home\BookUpdate.cshtml"
                           Write(i.BookId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <td>");
#nullable restore
#line 89 "C:\Users\ali2004h\projects\Book\Views\Home\BookUpdate.cshtml"
                           Write(i.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 90 "C:\Users\ali2004h\projects\Book\Views\Home\BookUpdate.cshtml"
                           Write(i.CreateDate.ToShamsi());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 91 "C:\Users\ali2004h\projects\Book\Views\Home\BookUpdate.cshtml"
                           Write(i.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td><a");
            BeginWriteAttribute("href", " href=\"", 2544, "\"", 2576, 2);
            WriteAttributeValue("", 2551, "/BookUpdatee?Id=", 2551, 16, true);
#nullable restore
#line 92 "C:\Users\ali2004h\projects\Book\Views\Home\BookUpdate.cshtml"
WriteAttributeValue("", 2567, i.BookId, 2567, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><button class=\"btn btn-sm btn-primary\">ویرایش</button></a></td>\r\n                        </tr>\r\n");
#nullable restore
#line 94 "C:\Users\ali2004h\projects\Book\Views\Home\BookUpdate.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </table>\r\n            </div>\r\n            <!-- /.card-body -->\r\n        </div>\r\n        <!-- /.card -->\r\n    </div>\r\n</div><!-- /.row -->");
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
