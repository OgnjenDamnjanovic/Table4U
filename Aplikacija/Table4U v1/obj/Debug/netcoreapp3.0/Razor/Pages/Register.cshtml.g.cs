#pragma checksum "E:\Bitbucket\si.20.09.table4u\Aplikacija\Table4U v1\Pages\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a6edf9d7aee3414b19e90bb618c4f011d0d1021"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Table4U.Pages.Pages_Register), @"mvc.1.0.razor-page", @"/Pages/Register.cshtml")]
namespace Table4U.Pages
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
#line 1 "E:\Bitbucket\si.20.09.table4u\Aplikacija\Table4U v1\Pages\_ViewImports.cshtml"
using Table4U;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a6edf9d7aee3414b19e90bb618c4f011d0d1021", @"/Pages/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"437a0f754b7e44e517ed0728dd7819dada6fbd8e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Register : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("firstname"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "firstname", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("lastname"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "lastname", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("email"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "email", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "password", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("password"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "password", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("confirm_password"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "confirm_password", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("signupForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a6edf9d7aee3414b19e90bb618c4f011d0d10218081", async() => {
                WriteLiteral("\r\n    <title>Table4U | Register</title>\r\n\r\n\t<script src=\"js/jquery.js\"></script>\r\n\r\n");
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
            WriteLiteral("\r\n\r\n<div class=\"content\">\r\n\t<div class=\"main\">\r\n\t   <div class=\"container\">\r\n\t\t  <div class=\"register\">\r\n\t\t  \t  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a6edf9d7aee3414b19e90bb618c4f011d0d10219275", async() => {
                WriteLiteral(" \r\n\t\t\t\t <div class=\"register-top-grid\">\r\n\t\t\t\t\t<h3>PERSONAL INFORMATION</h3>\r\n\t\t\t\t\t <div class=\"wow fadeInLeft\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t<span>First Name<label>*</label></span>\r\n\t\t\t\t\t\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6a6edf9d7aee3414b19e90bb618c4f011d0d10219759", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 22 "E:\Bitbucket\si.20.09.table4u\Aplikacija\Table4U v1\Pages\Register.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.firstname);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t\t\t\t\t\t<label class=\"error\" style=\"visibility: hidden;\">This field is required.</label>\r\n\t\t\t\t\t </div>\r\n\t\t\t\t\t <div class=\"wow fadeInRight\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t<span>Last Name<label>*</label></span>\r\n\t\t\t\t\t\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6a6edf9d7aee3414b19e90bb618c4f011d0d102112009", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 27 "E:\Bitbucket\si.20.09.table4u\Aplikacija\Table4U v1\Pages\Register.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.lastname);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
							<label class=""error"" style=""visibility: hidden;"">This field is required.</label>
					 </div>
				    
					 <div class=""wow fadeInRight"" id=""register-form-email-c"" data-wow-delay=""0.4s"">
						 <span>Email Address<label>*</label></span>
						 ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6a6edf9d7aee3414b19e90bb618c4f011d0d102114268", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 33 "E:\Bitbucket\si.20.09.table4u\Aplikacija\Table4U v1\Pages\Register.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.email);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" \r\n\t\t\t\t\t\t \t<label class=\"error error-hidden\" style=\"visibility: hidden;\">This field is required.</label>\r\n\t\t\t\t\t\t <label id=\"adressTaken\">");
#nullable restore
#line 35 "E:\Bitbucket\si.20.09.table4u\Aplikacija\Table4U v1\Pages\Register.cshtml"
                                            Write(Model.ErrorMessage);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</label>
					 </div>



					 <div class=""clearfix""> </div>
					   <a class=""Business"" href=""#"">
						   <script src=""js/validateEmail.js""></script>
						  <script>
							  window.onload=()=>
							  {			let errmsg=document.querySelector(""#register-form-email-c"").querySelectorAll(""label"")[2];
							 		
								  if(errmsg.innerHTML==""This email address is already used"")
								  {
									document.querySelector(""#email"").onfocus=()=>{ errmsg.innerHTML="""";}
								  }
							  }
							  function isNullOrWhitespace( input ) {

    						if (typeof input === 'undefined' || input == null) return true;
							let p=input.replace(/\s/g, '').length < 1;
	
	
   							 return p;
							}
							  function emailError()
					{
						let email=document.querySelector(""#email"");
						if(validateEmail(email.value))
						{
							email.parentElement.querySelector("".error"").style.visibility=""hidden"";
							return false;
						}
						else
						{
							
							email.parentEl");
                WriteLiteral(@"ement.querySelector("".error"").style.visibility=""visible"";
							return true;
						}
					}
					function passwordError(passID)
					{
						let pass=document.querySelector(""#password"");
						let cpass=document.querySelector(""#confirm_password"");
						if(document.querySelector(""#""+passID).value==""""||document.querySelector(""#""+passID).value.length<5)
						{	
							document.querySelector(""#""+passID).parentElement.querySelector("".error"").innerHTML=""Password must be at least 5 characters long"";	
							document.querySelector(""#""+passID).parentElement.querySelector("".error"").style.visibility=""visible"";
							
							return true;
						}
						
						else 
						if(pass.value!=cpass.value)
						{
							document.querySelector(""#""+passID).parentElement.querySelector("".error"").innerHTML=""Passwords do not match"";	
							document.querySelector(""#""+passID).parentElement.querySelector("".error"").style.visibility=""visible"";
							
							return true;
						}
						
						else
						{
			");
                WriteLiteral(@"				pass.parentElement.querySelector("".error"").innerHTML=""Password must be at least 5 characters long"";	
						    pass.parentElement.querySelector("".error"").style.visibility=""hidden"";
							cpass.parentElement.querySelector("".error"").innerHTML=""Password must be at least 5 characters long"";	
						    cpass.parentElement.querySelector("".error"").style.visibility=""hidden"";
							
							
							return false;

						}


					}
					function nameError(inputId)
					{
							let name=document.querySelector(""#""+inputId);
						if(name.value==""""||isNullOrWhitespace(name.value))
						{
							
							name.parentElement.querySelector("".error"").style.visibility=""visible"";
							name.parentElement.querySelector("".error"").style.display=""block"";
							return true;
						}
						else
						{
							name.parentElement.querySelector("".error"").style.visibility=""hidden"";
							
							return false;
						}
					}
						document.addEventListener(""DOMContentLoaded"", function validateRegisterFor");
                WriteLiteral(@"m(event){
							
							
						
					
							let element=document.querySelector(""#firstname"");
					element.onfocus=function()
					{	
						this.onblur=()=>{ nameError(""firstname"");}
					}
					element.oninput=function(e)
					{
						nameError(""firstname"");
					}  
					element=document.querySelector(""#lastname"");
					element.onfocus=function()
					{	
						this.onblur=()=>{ nameError(""lastname"");}
					}
					element.oninput=function(e)
					{
						nameError(""lastname"");
					}  
					element=document.querySelector(""#email"");
					element.onfocus=function()
					{	
						this.onblur=()=>{ emailError();}
					}
					element.oninput=function(e)
					{
						emailError();
						element.parentElement.querySelectorAll(""label"")[1].style.display=""none"";
					}  
					element=document.querySelector(""#password"");
					element.onfocus=function()
					{	
						this.onblur=()=>{ passwordError(""password"");}
					}
					element.oninput=function(e)
					{
						passwordError(");
                WriteLiteral(@"""password"");
					}  
					element=document.querySelector(""#confirm_password"");
					element.onfocus=function()
					{	
						this.onblur=()=>{ passwordError(""confirm_password"");}
					}
					element.oninput=function(e)
					{
						passwordError(""confirm_password"");
					}  
					document.querySelector(""#signupForm"").onsubmit=()=>
					{

						
						
						let error=false;
						if(nameError(""firstname""))
						error=true;
					
						if(nameError(""lastname""))
						error=true;
						
						if(emailError())
						error=true;
						
						if(passwordError(""password""))
						error=true;
					
						if(passwordError(""confirm_password""))
						error=true;
						if(error)
						{
						
						return false;
						}
						return true;

						
					}
					});
	  
						
						</script>
						 <label class=""checkbox""><input type=""checkbox"" name=""wantBusiness"" value=""Business"" ><i> </i><label class=""register-cb-label"">Create business account, I want to advertise my restaur");
                WriteLiteral(@"ant</label></label>
						
					   </a>
					 </div> 
				     <div class=""register-bottom-grid"">
						    <h3>LOGIN INFORMATION</h3>
							 <div class=""wow fadeInLeft"" data-wow-delay=""0.4s"">
								<span>Password<label>*</label></span>
								");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6a6edf9d7aee3414b19e90bb618c4f011d0d102122385", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
#nullable restore
#line 219 "E:\Bitbucket\si.20.09.table4u\Aplikacija\Table4U v1\Pages\Register.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.password);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t\t\t\t\t\t\t\t<label class=\"error\" style=\"visibility: hidden;\">This field is required.</label>\r\n\t\t\t\t\t\t\t </div>\r\n\t\t\t\t\t\t\t <div class=\"wow fadeInRight\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t\t\t<span>Confirm Password<label>*</label></span>\r\n\t\t\t\t\t\t\t\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6a6edf9d7aee3414b19e90bb618c4f011d0d102124663", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
#nullable restore
#line 224 "E:\Bitbucket\si.20.09.table4u\Aplikacija\Table4U v1\Pages\Register.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.confirmPassword);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_11.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
								<label class=""error"" style=""visibility: hidden;"">This field is required.</label> 
							 </div>
					 </div>
					
					
					<div class=""clearfix""> </div>
					<button type=""submit"" class=""register-but"">submit</button>
					<div class=""clearfix""> </div>
					
				");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_13.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
				<!--<div class=""clearfix""> </div>
				<div class=""register-but"">
				   <form>
					   <input type=""submit"" value=""submit"">
					   <div class=""clearfix""> </div>
				   </form>
				</div>-->
				
		   </div>
	     </div>
	    </div>

<div class=""clearfix""></div>
		<div class=""contact-section"" id=""contact"">
			<div class=""container"">
				<div class=""contact-section-grids"">
					<div style=""width:45%;"" class=""col-md-3 contact-section-grid"">
						<h4>Site Links</h4>
						<ul>
							<li><i class=""point""></i></li>
							<li class=""data""><a href=""#"">About Us</a></li>
						</ul>
						<ul>
							<li><i class=""point""></i></li>
							<li class=""data""><a href=""#"">Contact Us</a></li>
						</ul>
						<ul>
							<li><i class=""point""></i></li>
							<li class=""data""><a href=""#"">Privacy Policy</a></li>
						</ul>
						<ul>
							<li><i class=""point""></i></li>
							<li class=""data""><a href=""#"">Terms of Use</a></li>
						</ul>
					</div>
					<div style=""width:45%;"" c");
            WriteLiteral(@"lass=""col-md-3 contact-section-grid"">
						<h4>Follow Us On...</h4>
						<ul>
							<li><i class=""fb""></i></li>
							<li class=""data""> <a href=""#"">  Facebook</a></li>
						</ul>
						<ul>
							<li><i class=""tw""></i></li>
							<li class=""data""> <a href=""#"">Twitter</a></li>
						</ul>
						<ul>
							<li><i class=""in""></i></li>
							<li class=""data""><a href=""#""> Linkedin</a></li>
						</ul>
						<ul>
							<li><i class=""gp""></i></li>
							<li class=""data""><a href=""#"">Google Plus</a></li>
						</ul>
					</div>
					<div class=""clearfix""></div>
				</div>
			</div>
		</div>
	</div>
	<!-- content-section-ends -->
    <!--<script type=""text/javascript"">
						$(document).ready(function() {
							/*
							var defaults = {
					  			containerID: 'toTop', // fading element id
								containerHoverID: 'toTopHover', // fading element hover id
								scrollSpeed: 1200,
								easingType: 'linear' 
					 		};
							*/
							
							$().UItoTop({ easingType:");
            WriteLiteral(" \'easeOutQuart\' });\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t});\r\n\t\t\t\t\t</script>\r\n\t\t\t\t<a href=\"#\" id=\"toTop\" style=\"display: block;\"> <span id=\"toTopHover\" style=\"opacity: 1;\"> </span></a>-->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyApp.Namespace.RegisterModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyApp.Namespace.RegisterModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyApp.Namespace.RegisterModel>)PageContext?.ViewData;
        public MyApp.Namespace.RegisterModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
