#pragma checksum "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Cliente\Lista.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5fe42fb04edf1081f92bd15539f58ba572eb9539"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cliente_Lista), @"mvc.1.0.view", @"/Views/Cliente/Lista.cshtml")]
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
#line 1 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\_ViewImports.cshtml"
using ProgaWeb3TP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\_ViewImports.cshtml"
using ProgaWeb3TP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fe42fb04edf1081f92bd15539f58ba572eb9539", @"/Views/Cliente/Lista.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e0e3af05d7e5ab492c239619c3718d0788963dd", @"/Views/_ViewImports.cshtml")]
    public class Views_Cliente_Lista : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<div class=""container"">

    <div class=""row justify-content-center align-items-center"">
        <div class=""col-md-12"">

                <button  role=""link""  onclick=""window.location='/Cliente/Crear'"" class=""btn btn-primary float-right mt-2 mb-2""> Nuevo Cliente  </button>
            
        </div>
    </div>
    <div class=""row justify-content-center align-items-center"">
        <div class=""col-md-4"">
            <div class=""form-group"">
                <label for=""exampleFormControlSelect1"">Nombre Cliente:</label>
                <select class=""custom-select"" id=""exampleFormControlSelect1"">
");
#nullable restore
#line 19 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Cliente\Lista.cshtml"
                     for (int i = 0; i < 6; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5fe42fb04edf1081f92bd15539f58ba572eb95393995", async() => {
                WriteLiteral("Cliente ");
#nullable restore
#line 21 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Cliente\Lista.cshtml"
                                   Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 22 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Cliente\Lista.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </select>
            </div>
        </div>
        <div class=""col-md-4"">
            <div class=""form-group"">
                <label for=""exampleFormControlSelect1"">Numero:</label>
                <select class=""custom-select"" id=""exampleFormControlSelect1"">

                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5fe42fb04edf1081f92bd15539f58ba572eb95395672", async() => {
                WriteLiteral("1");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5fe42fb04edf1081f92bd15539f58ba572eb95396645", async() => {
                WriteLiteral("2");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5fe42fb04edf1081f92bd15539f58ba572eb95397618", async() => {
                WriteLiteral("3");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
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
        <div class=""col-md-4"">
          
            <div class=""form-check mt-3"">
                <input type=""checkbox"" class=""form-check-input"" id=""exampleCheck1"">
                <label class=""form-check-label"" for=""exampleCheck1"">Excluir Eliminados</label>
            </div>
        </div>

    </div>
    <div class=""row justify-content-center align-items-center"">
        <div class=""col-md-12"">
            <table class=""table  table-bordered"">
                <thead class=""thead-light"">
                    <tr>
                        <th class=""text-center""  scope=""col"">Nombre</th>
                        <th class=""text-center"" scope=""col"">Numero</th>
                        <th class=""text-center"" scope=""col"">Telefono</th>
                        <th class=""text-center"" scope=""col"">Ver</th>
                    </tr>
                </thead>
                <tbody>

");
#nullable restore
#line 60 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Cliente\Lista.cshtml"
                     for (int i = 0; i < 6; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <th class=\"text-center\" scope=\"row\">Nombre ");
#nullable restore
#line 63 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Cliente\Lista.cshtml"
                                                                  Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <td class=\"text-center\">estado  ");
#nullable restore
#line 64 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Cliente\Lista.cshtml"
                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                            <td class=""text-center"">--</td>
                            <td class=""text-center""><button  role=""link""  onclick=""window.location='/Cliente/Editar'"" type=""button"" class=""btn btn-info"">Ver</button></td>
                        </tr>
");
#nullable restore
#line 68 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Cliente\Lista.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"



                </tbody>
            </table>


        </div>
    </div>
    <div class=""row justify-content-center align-items-center"">
        <div class=""col-md-12 text-center"">
            <nav aria-label=""Page navigation example  "">

                <ul class=""pagination  justify-content-center"">
                    <li class=""page-item""><a class=""page-link"" href=""#""><i class=""bi bi-arrow-left""></i>Anterior</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">1</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">2</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">3</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">Siguiente<i class=""bi bi-arrow-right""></i></a></li>
                </ul>
            </nav>
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
