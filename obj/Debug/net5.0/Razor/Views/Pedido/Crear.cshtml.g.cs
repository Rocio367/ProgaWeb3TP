#pragma checksum "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Pedido\Crear.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e9cf09118ac68c44d7887992dfc74634af9c0cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pedido_Crear), @"mvc.1.0.view", @"/Views/Pedido/Crear.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e9cf09118ac68c44d7887992dfc74634af9c0cf", @"/Views/Pedido/Crear.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e0e3af05d7e5ab492c239619c3718d0788963dd", @"/Views/_ViewImports.cshtml")]
    public class Views_Pedido_Crear : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"<div class=""container"">
    <div id=""crear-row"" class=""row justify-content-center align-items-center"">
        <div id=""crear-column"" class=""col-md-10"">
          
              
                        <h4 class=""card-title mb-4 mt-1 "">Nuevo Pedido</h4>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2e9cf09118ac68c44d7887992dfc74634af9c0cf3648", async() => {
                WriteLiteral(@"
                            <div class=""form-row"">
                                <div class=""form-group col-md-6"">
                                    <label for=""exampleFormControlSelect1"">Cliente:</label>
                                    <select class=""custom-select"" id=""exampleFormControlSelect1"">
");
#nullable restore
#line 15 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Pedido\Crear.cshtml"
                                         for (int i = 0; i < 6; i++)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2e9cf09118ac68c44d7887992dfc74634af9c0cf4567", async() => {
                    WriteLiteral("Cliente ");
#nullable restore
#line 17 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Pedido\Crear.cshtml"
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
#line 18 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Pedido\Crear.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    </select>
                                </div> <!-- form-group// -->
                            </div>
                            <div class=""form-row"">
                                <div class=""form-group col-md-4"">
                                    <label for=""exampleFormControlSelect1"">Descripcion o codigo:</label>
                                    <select class=""custom-select"" id=""exampleFormControlSelect1"">
                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2e9cf09118ac68c44d7887992dfc74634af9c0cf6545", async() => {
                    WriteLiteral("??");
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
                                </div> <!-- form-group// -->
                                <div class=""form-group col-md-4"">
                                    <label>Cantidad:</label>
                                    <input type=""number"" class=""form-control"" placeholder=""2"">
                                </div> <!-- form-group// -->
                                <div class=""form-group col-md-4 "">

                                    <button class=""btn btn-primary "" id=""add-btn""> Agregar</button>

                                </div> <!-- form-group// -->
                            </div>
                            <div class=""form-row"">
                                <table class=""table  table-bordered"">
                                    <thead class=""thead-light"">
                                        <tr>
                                            <th scope=""col"">Descripcion</th>
                                           ");
                WriteLiteral(@" <th scope=""col"">Codigo</th>
                                            <th scope=""col"">Cantidad</th>
                                            <th scope=""col"">Ver</th>
                                        </tr>
                                    </thead>
                                    <tbody>

");
#nullable restore
#line 51 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Pedido\Crear.cshtml"
                                         for (int i = 0; i < 2; i++)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <tr>\r\n                                                <th>Decripcion ");
#nullable restore
#line 54 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Pedido\Crear.cshtml"
                                                          Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                                                <td>  ");
#nullable restore
#line 55 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Pedido\Crear.cshtml"
                                                 Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td>  ");
#nullable restore
#line 56 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Pedido\Crear.cshtml"
                                                 Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td> <a class=\"text-center\"");
                BeginWriteAttribute("href", " href=\"", 3145, "\"", 3170, 2);
                WriteAttributeValue("", 3152, "/Pedido/Detalle/", 3152, 16, true);
#nullable restore
#line 57 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Pedido\Crear.cshtml"
WriteAttributeValue("", 3168, i, 3168, 2, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Ver</a></td>\r\n                                            </tr>\r\n");
#nullable restore
#line 59 "C:\Users\Usuario\source\repos\ProgaWeb3TP\Views\Pedido\Crear.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"



                                    </tbody>
                                </table>
                            </div>
                            <div class=""form-group"">
                                <label for=""exampleFormControlTextarea1"">Comentario:</label>
                                <textarea class=""form-control"" id=""exampleFormControlTextarea1"" rows=""3""></textarea>
                            </div>
                           
                           

                       
                            <div class=""form-group "">
                                <button class=""btn btn-primary"">Guardar  </button>
                                <button class=""btn btn-primary "">Guardar y Crear Otro  </button>
                                <button class=""btn btn-secondary "">Cancelar  </button>

                            </div> <!-- form-group// -->

                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            \r\n        </div>\r\n    </div>\r\n</div>");
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
