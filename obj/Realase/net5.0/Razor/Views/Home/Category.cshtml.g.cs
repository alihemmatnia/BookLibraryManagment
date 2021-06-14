#pragma checksum "C:\Users\ali2004h\projects\Book\Views\Home\Category.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70af4c822c38c95d200fb37844b869bb17d19378"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Category), @"mvc.1.0.view", @"/Views/Home/Category.cshtml")]
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
#line 2 "C:\Users\ali2004h\projects\Book\Views\Home\Category.cshtml"
using Book.DateConvert;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70af4c822c38c95d200fb37844b869bb17d19378", @"/Views/Home/Category.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b252a8f427cf8f6a5987d720e148396be09107fc", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Category : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Book.Data.Category>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\ali2004h\projects\Book\Views\Home\Category.cshtml"
  
    ViewData["Title"] = "صفحه اصلی";

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
#line 14 "C:\Users\ali2004h\projects\Book\Views\Home\Category.cshtml"
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
                 ");
            WriteLiteral(@"       <h3>44</h3>

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

<div class=""row mt-3 mr-5"">
    <div class=""col-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h3 class=""card-title"">");
            WriteLiteral(@"دسته بندی ها</h3>
            </div>
            <div class=""card-body table-responsive p-0"">
                <table class=""table table-hover"">
                    <tr>
                        <th>شماره</th>
                        <th>عنوان</th>
                        <th>حذف</th>
                    </tr>
");
#nullable restore
#line 83 "C:\Users\ali2004h\projects\Book\Views\Home\Category.cshtml"
                     foreach (var i in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 86 "C:\Users\ali2004h\projects\Book\Views\Home\Category.cshtml"
                           Write(i.CategoryId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 87 "C:\Users\ali2004h\projects\Book\Views\Home\Category.cshtml"
                           Write(i.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td><a");
            BeginWriteAttribute("href", " href=\"", 3012, "\"", 3048, 2);
            WriteAttributeValue("", 3019, "/CategoryDel?Id=", 3019, 16, true);
#nullable restore
#line 88 "C:\Users\ali2004h\projects\Book\Views\Home\Category.cshtml"
WriteAttributeValue("", 3035, i.CategoryId, 3035, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><button class=\"btn btn-sm btn-danger\">حذف</button></a></td>\r\n                        </tr>\r\n");
#nullable restore
#line 90 "C:\Users\ali2004h\projects\Book\Views\Home\Category.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Book.Data.Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591
