#pragma checksum "C:\AbhishekDadhichCodes\DotNet\dotnet\Core\BethanysPieShop\BethanysPieShop\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21c1bee02ea778f0830d0bf327cb2088154bbb06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21c1bee02ea778f0830d0bf327cb2088154bbb06", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BethanysPieShop.ViewModels.HomeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 3 "C:\AbhishekDadhichCodes\DotNet\dotnet\Core\BethanysPieShop\BethanysPieShop\Views\Home\Index.cshtml"
Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n");
#nullable restore
#line 5 "C:\AbhishekDadhichCodes\DotNet\dotnet\Core\BethanysPieShop\BethanysPieShop\Views\Home\Index.cshtml"
 foreach (var pie in Model.Pies)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-sm-4 col-lg-4 col-md-4\">\r\n        <div class=\"img-thumbnail\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 212, "\"", 240, 1);
#nullable restore
#line 9 "C:\AbhishekDadhichCodes\DotNet\dotnet\Core\BethanysPieShop\BethanysPieShop\Views\Home\Index.cshtml"
WriteAttributeValue("", 218, pie.ImageThumbnailUrl, 218, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 241, "\"", 247, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n            <div class=\"figure-caption\">\r\n                <h3 class=\"text-right\">");
#nullable restore
#line 11 "C:\AbhishekDadhichCodes\DotNet\dotnet\Core\BethanysPieShop\BethanysPieShop\Views\Home\Index.cshtml"
                                  Write(pie.Price.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <h3>");
#nullable restore
#line 12 "C:\AbhishekDadhichCodes\DotNet\dotnet\Core\BethanysPieShop\BethanysPieShop\Views\Home\Index.cshtml"
               Write(pie.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <p>");
#nullable restore
#line 13 "C:\AbhishekDadhichCodes\DotNet\dotnet\Core\BethanysPieShop\BethanysPieShop\Views\Home\Index.cshtml"
              Write(pie.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 17 "C:\AbhishekDadhichCodes\DotNet\dotnet\Core\BethanysPieShop\BethanysPieShop\Views\Home\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BethanysPieShop.ViewModels.HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591