#pragma checksum "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb1355b1e03981e764770f9fe8ae9e0a275462b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(StackOverflow.Pages.Pages_SearchOutput), @"mvc.1.0.razor-page", @"/Pages/SearchOutput.cshtml")]
namespace StackOverflow.Pages
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
#line 1 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\_ViewImports.cshtml"
using StackOverflow;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\_ViewImports.cshtml"
using StackOverflow.Utilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\_ViewImports.cshtml"
using Newtonsoft.Json.Linq;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb1355b1e03981e764770f9fe8ae9e0a275462b4", @"/Pages/SearchOutput.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4bdf47fca722e7030d2cf88cfc6aae0edbfcb8f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_SearchOutput : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<h3 style=\"padding:12px;\">Top Questions</h3>\r\n<hr style=\"border-block-width:7px;color:black\" />\r\n");
#nullable restore
#line 6 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
 if (Model.questions.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>Answers for your search: ");
#nullable restore
#line 8 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                             Write(Model.searchText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 9 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
 for (int i = 0; i < Model.questions.Count; i++)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\" style=\"width: inherit\">\r\n        <div class=\"card-body\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 403, "\"", 445, 2);
            WriteAttributeValue("", 410, "/Question?id=", 410, 13, true);
#nullable restore
#line 13 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
WriteAttributeValue("", 423, Model.questions[i].ID, 423, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 13 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                                                      Write(Model.questions[i].Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n            <a style=\"float:right;font-size:12px;background-color:transparent;color:cornflowerblue;border:none;outline:none;\" class=\"btn btn-primary\" data-toggle=\"collapse\"");
            BeginWriteAttribute("href", " href=\"", 651, "\"", 663, 2);
            WriteAttributeValue("", 658, "#Q_", 658, 3, true);
#nullable restore
#line 14 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
WriteAttributeValue("", 661, i, 661, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"button\" aria-expanded=\"false\"");
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 700, "\"", 720, 2);
            WriteAttributeValue("", 716, "Q_", 716, 2, true);
#nullable restore
#line 14 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
WriteAttributeValue("", 718, i, 718, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                Show complete question\r\n            </a>\r\n            <div class=\"collapse\"");
            BeginWriteAttribute("id", " id=\"", 815, "\"", 824, 2);
            WriteAttributeValue("", 820, "Q_", 820, 2, true);
#nullable restore
#line 17 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
WriteAttributeValue("", 822, i, 822, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                &emsp;\r\n                ");
#nullable restore
#line 19 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
           Write(Html.Raw(Model.questions[i].Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <br />\r\n            <div class=\"row\">\r\n                <p class=\"QuestionTag\"> ");
#nullable restore
#line 23 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                                   Write(Model.questions[i].Tag1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>&nbsp;\r\n");
#nullable restore
#line 24 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                 if (Model.questions[i].Tag2 != "")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p class=\"QuestionTag\"> ");
#nullable restore
#line 26 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                                       Write(Model.questions[i].Tag2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 27 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                &nbsp;\r\n");
#nullable restore
#line 29 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                 if (Model.questions[i].Tag3 != "")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p class=\"QuestionTag\"> ");
#nullable restore
#line 31 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                                       Write(Model.questions[i].Tag3);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 32 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                &nbsp;\r\n");
#nullable restore
#line 34 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                 if (Model.questions[i].Tag4 != "")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p class=\"QuestionTag\"> ");
#nullable restore
#line 36 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                                       Write(Model.questions[i].Tag4);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 37 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                &nbsp;\r\n");
#nullable restore
#line 39 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                 if (Model.questions[i].Tag5 != "")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p class=\"QuestionTag\"> ");
#nullable restore
#line 41 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                                       Write(Model.questions[i].Tag5);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 42 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
            WriteLiteral(@"        </div>
        <div class=""card-footer"" style=""padding-top:7px;font-size:12px;"">
            <button class=""like bi bi-hand-thumbs-up-fill"" style=""background-color: transparent; border: transparent; outline: none; font-size: 21px;"" disabled>
            </button>23&nbsp;
            <button class=""dislike bi bi-hand-thumbs-down-fill"" style=""background-color: transparent; border: transparent; outline: none; font-size: 21px;"" disabled>
            </button>12&nbsp;
            <p style=""float:right;padding-top:4px;"">by&nbsp;");
#nullable restore
#line 52 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
                                                       Write(Model.questions[i].EmployeeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>&nbsp;\r\n            <p style=\"float:right;padding-top:4px;\">\r\n                ");
#nullable restore
#line 54 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
           Write(Model.questions[i].DateTimePosted);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>&nbsp;\r\n        </div>\r\n\r\n    </div>\r\n    <hr style=\"border-block-width:3px\" />\r\n");
#nullable restore
#line 60 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"

}

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
 
}
else { 

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>No questions found for your search. Please add more key words to your search....</div>\r\n");
#nullable restore
#line 65 "C:\Users\pvemuluri\source\repos\StackOverflow\StackOverflow\Pages\SearchOutput.cshtml"
}

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cb1355b1e03981e764770f9fe8ae9e0a275462b413403", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StackOverflow.Pages.HomePage.SearchOutputModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<StackOverflow.Pages.HomePage.SearchOutputModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<StackOverflow.Pages.HomePage.SearchOutputModel>)PageContext?.ViewData;
        public StackOverflow.Pages.HomePage.SearchOutputModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
