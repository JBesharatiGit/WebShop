#pragma checksum "C:\Users\Maryam.A.maryam_ahadi\source\repos\WebShopIdentity_20210702\WebShopIdentity\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9a07f284824b348512dae22b48185fc59423e45"
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
#nullable restore
#line 1 "C:\Users\Maryam.A.maryam_ahadi\source\repos\WebShopIdentity_20210702\WebShopIdentity\Views\_ViewImports.cshtml"
using WebShopIdentity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Maryam.A.maryam_ahadi\source\repos\WebShopIdentity_20210702\WebShopIdentity\Views\_ViewImports.cshtml"
using WebShopIdentity.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Maryam.A.maryam_ahadi\source\repos\WebShopIdentity_20210702\WebShopIdentity\Views\_ViewImports.cshtml"
using WebShopIdentity.Models.Stores;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Maryam.A.maryam_ahadi\source\repos\WebShopIdentity_20210702\WebShopIdentity\Views\_ViewImports.cshtml"
using WebShopIdentity.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9a07f284824b348512dae22b48185fc59423e45", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6caaff04f47867f2a53d34f892a7afffb3c98f37", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Maryam.A.maryam_ahadi\source\repos\WebShopIdentity_20210702\WebShopIdentity\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Info Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9a07f284824b348512dae22b48185fc59423e453858", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css\">\r\n");
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
            WriteLiteral(@"

<div class=""container"">
    <div class=""jumbotron"">
        <div class=""text-center"">
            <h1 class=""display-4"">Welcome to Group 5 Webshop solution.</h1>
            <br />
            <p class=""display-6"">
                All items in this webshop are fictitious and cannot be delivered.
                This is only a webshop project using MVC 5.0 Core, Entity Framework on top of Identity.
                As you can see, the contact information is also fake.
            </p>
        </div>

        <br />
        <br />

        <div class=""row justify-content-evenly "">
            <div class=""col-sm-4"">
                <div class=""container-sm"">
                    <h4>WebShop address:</h4>
                    <br />
                    <h6>QuakRoad 99</h6>
                    <h6>Disneyland</h6>
                    <h6>555-99 Florida</h6>
                    <h6>USA</h6>
                </div>
            </div>

            <div class=""col-sm-4"">
                <div");
            WriteLiteral(@" class=""container-sm"">
                    <h4>WebShop contact:</h4>
                    <br />
                    <h6>Email: donald@duck.com</h6>
                    <h6>Phone: 555-1234231</h6>
                    <h6>Mobile: 555-1324321</h6>
                    <h6>Fax: 555-654321</h6>
                </div>
            </div>
        </div>
        <div class=""text-center"">
            <br />
            <h1 class=""display-4"">Please try it out...</h1>
        </div>
    </div>
</div>

");
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
