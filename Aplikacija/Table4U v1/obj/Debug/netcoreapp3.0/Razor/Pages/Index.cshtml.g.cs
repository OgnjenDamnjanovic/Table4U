#pragma checksum "E:\Bitbucket\si.20.09.table4u\Aplikacija\Table4U v1\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d7ef806cc2eddec9e2a24b623ed8f980919d9689"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Table4U.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7ef806cc2eddec9e2a24b623ed8f980919d9689", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"437a0f754b7e44e517ed0728dd7819dada6fbd8e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("search.html"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d7ef806cc2eddec9e2a24b623ed8f980919d96893488", async() => {
                WriteLiteral("\r\n\t<title>Table4U | Home</title>\r\n");
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
<header>
			</div>
		<div class=""banner wow fadeInUp"" data-wow-delay=""0.4s"" id=""Home"">
		    <div class=""container"">
				<div class=""banner-info"">
					<div class=""banner-info-head text-center wow fadeInLeft"" data-wow-delay=""0.5s"">
						<h1>Network of over 5000 Restaurants</h1>
						<div class=""line"">
							<h2> To Order Online</h2>
						</div>
					</div>
					<div class=""form-list wow fadeInRight"" data-wow-delay=""0.5s"">
						");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d7ef806cc2eddec9e2a24b623ed8f980919d96894956", async() => {
                WriteLiteral(@"
						  <ul class=""navmain"">
							<li><span>Location Name</span>
							 <input type=""text"" class=""text"" value=""Secunderabad"" onfocus=""this.value = '';"" onblur=""if (this.value == '') {this.value = 'Secunderabad';}"">
							</li>
							<li><span>Restaurant Name</span>
							 <input type=""text"" class=""text"" value=""Swagath Grand"" onfocus=""this.value = '';"" onblur=""if (this.value == '') {this.value = 'Swagath Grand';}"">
							</li>
							<li><span>Cuisine Name</span>
							 <input type=""text"" class=""text"" value=""Chicken Biriyani"" onfocus=""this.value = '';"" onblur=""if (this.value == '') {this.value = 'Chicken Biriyani';}"">
						    </li>
						  </ul>
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
            WriteLiteral("\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t<!-- start search-->\r\n\t\t <div class=\"main-search\">\r\n\t        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d7ef806cc2eddec9e2a24b623ed8f980919d96897000", async() => {
                WriteLiteral("\r\n\t           <input type=\"text\" value=\"Search\" onFocus=\"this.value = \'\';\" onBlur=\"if (this.value == \'\') {this.value = \'Search\';}\" class=\"text\"/>\r\n\t            <input type=\"submit\"");
                BeginWriteAttribute("value", " value=\"", 1509, "\"", 1517, 0);
                EndWriteAttribute();
                WriteLiteral("/>\r\n\t        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
	        <div class=""close""><img src=""images/cross.png"" /></div>
	    </div>
	    <div class=""srch""><button></button></div>
		<script type=""text/javascript"">
	         $('.main-search').hide();
	        $('button').click(function (){
	            $('.main-search').show();
	            $('.main-search text').focus();
	        }
	        );
	        $('.close').click(function(){
	            $('.main-search').hide();
	        });
	    </script>
					
				</div>
			</div>
		</div>
</header>
	<!-- content-section-starts -->
	<div class=""content"">
		<div class=""ordering-section"" id=""Order"">
			<div class=""container"">
				<div class=""ordering-section-head text-center wow bounceInRight"" data-wow-delay=""0.4s"">
					<h3>Ordering food was never so easy</h3>
					<div class=""dotted-line"">
						<h4>Just 4 steps to follow </h4>
					</div>
				</div>
				<div class=""ordering-section-grids"">
					<div class=""col-md-3 ordering-section-grid"">
						<div class=""ordering-section-grid-process w");
            WriteLiteral(@"ow fadeInRight"" data-wow-delay=""0.4s"""">
							<i class=""one""></i><br>
							<i class=""one-icon""></i>
							<p>Choose <span>Your Restaurant</span></p>
							<label></label>
						</div>
					</div>
					<div class=""col-md-3 ordering-section-grid"">
						<div class=""ordering-section-grid-process wow fadeInRight"" data-wow-delay=""0.4s"""">
							<i class=""two""></i><br>
							<i class=""two-icon""></i>
							<p>Order  <span>Your Cuisine</span></p>
							<label></label>
						</div>
					</div>
					<div class=""col-md-3 ordering-section-grid"">
						<div class=""ordering-section-grid-process wow fadeInRight"" data-wow-delay=""0.4s"""">
							<i class=""three""></i><br>
							<i class=""three-icon""></i>
							<p>Pay   <span> online / on delivery</span></p>
							<label></label>
						</div>
					</div>
					<div class=""col-md-3 ordering-section-grid"">
						<div class=""ordering-section-grid-process wow fadeInRight"" data-wow-delay=""0.4s"""">
							<i class=""four""></i><br>
							<i class=""fou");
            WriteLiteral(@"r-icon""></i>
							<p>Enjoy <span>your food </span></p>
						</div>
					</div>
					<div class=""clearfix""></div>
				</div>
			</div>
		</div>
		<div class=""special-offers-section"">
			<div class=""container"">
				<div class=""special-offers-section-head text-center dotted-line"">
					<h4>Special Offers</h4>
				</div>
				<div class=""special-offers-section-grids"">
				 <div class=""m_3""><span class=""middle-dotted-line""> </span> </div>
				   <div class=""container"">
					  <ul id=""flexiselDemo3"">
						<li>
							<div class=""offer"">
								<div class=""offer-image"">	
									<img src=""images/p1.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 4237, "\"", 4243, 0);
            EndWriteAttribute();
            WriteLiteral(@"/>
								</div>
								<div class=""offer-text"">
									<h4>Olister Combo pack lorem</h4>
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. </p>
									<input type=""button"" value=""Grab It"">
									<span></span>
								</div>
								<div class=""clearfix""></div>
							</div>
						</li>
						<li>
							<div class=""offer"">
								<div class=""offer-image"">	
									<img src=""images/p2.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 4704, "\"", 4710, 0);
            EndWriteAttribute();
            WriteLiteral(@"/>
								</div>
								<div class=""offer-text"">
									<h4>Chicken Jumbo pack lorem</h4>
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. </p>
									<input type=""button"" value=""Grab It"">
									<span></span>
								</div>
								<div class=""clearfix""></div>
							</div>
						</li>
						<li>
							<div class=""offer"">
								<div class=""offer-image"">	
									<img src=""images/p1.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 5171, "\"", 5177, 0);
            EndWriteAttribute();
            WriteLiteral(@"/>
								</div>
								<div class=""offer-text"">
									<h4>Crab Combo pack lorem</h4>
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. </p>
									<input type=""button"" value=""Grab It"">
									<span></span>
								</div>
								
								<div class=""clearfix""></div>
								</div>
						</li>
						<li>
							<div class=""offer"">
								<div class=""offer-image"">	
									<img src=""images/p2.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 5646, "\"", 5652, 0);
            EndWriteAttribute();
            WriteLiteral(@"/>
								</div>
								<div class=""offer-text"">
									<h4>Chicken Jumbo pack lorem</h4>
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. </p>
									<input type=""button"" value=""Grab It"">
									<span></span>
								</div>
								
								<div class=""clearfix""></div>
								</div>
					    </li>
					 </ul>
				 <script type=""text/javascript"">
					$(window).load(function() {
						
						$(""#flexiselDemo3"").flexisel({
							visibleItems: 3,
							animationSpeed: 1000,
							autoPlay: false,
							autoPlaySpeed: 3000,    		
							pauseOnHover: true,
							enableResponsiveBreakpoints: true,
							responsiveBreakpoints: { 
								portrait: { 
									changePoint:480,
									visibleItems: 1
								}, 
								landscape: { 
									changePoint:640,
									visibleItems: 2
								},
								tablet: { 
									changePoint:768,
									visibleItems: 3
								}
							}
						});
						
					});
				    </script>
				    <scri");
            WriteLiteral(@"pt type=""text/javascript"" src=""js/jquery.flexisel.js""></script>
				</div>
			</div>
		</div>
		</div>
		<div class=""popular-restaurents"" id=""Popular-Restaurants"">
			<div class=""container"">
				<div class=""col-md-4 top-restaurents"">
					<div class=""top-restaurent-head"">
						<h3>Top Restaurants</h3>
					</div>
					<div class=""top-restaurent-grids"">
						<div class=""top-restaurent-logos"">
							<div class=""res-img-1 wow bounceIn"" data-wow-delay=""0.4s"">
								<img src=""images/restaurent-1.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 7219, "\"", 7225, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<div class=\"res-img-2 wow bounceIn\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t\t    <img src=\"images/restaurent-2.jpg\" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 7381, "\"", 7387, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<div class=\"res-img-1 wow bounceIn\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t\t    <img src=\"images/restaurent-3.jpg\" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 7543, "\"", 7549, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<div class=\"res-img-2 wow bounceIn\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t\t    <img src=\"images/restaurent-4.jpg\" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 7705, "\"", 7711, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<div class=\"res-img-1 nth-grid1 wow bounceIn\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t\t    <img src=\"images/restaurent-5.jpg\" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 7877, "\"", 7883, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<div class=\"res-img-2 nth-grid1 wow bounceIn\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t\t    <img src=\"images/restaurent-6.jpg\" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 8049, "\"", 8055, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
							</div>
							<div class=""clearfix""></div>
						</div>
					</div>
				</div>
				<div class=""col-md-8 top-cuisines"">
					<div class=""top-cuisine-head"">
						<h3>Top Cuisines</h3>
					</div>
					<div class=""top-cuisine-grids"">
						<div class=""top-cuisine-grid wow bounceIn"" data-wow-delay=""0.4s"">
						    <a");
            BeginWriteAttribute("href", " href=\"", 8395, "\"", 8402, 0);
            EndWriteAttribute();
            WriteLiteral("><img src=\"images/cuisine1.jpg\" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 8457, "\"", 8463, 0);
            EndWriteAttribute();
            WriteLiteral(" /> </a>\r\n\t\t\t\t\t\t\t<label>Cuisine Name</label>\r\n\t\t\t\t\t    </div>\r\n\t\t\t\t\t\t<div class=\"top-cuisine-grid wow bounceIn\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t    <a");
            BeginWriteAttribute("href", " href=\"", 8612, "\"", 8619, 0);
            EndWriteAttribute();
            WriteLiteral("><img src=\"images/cuisine2.jpg\" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 8674, "\"", 8680, 0);
            EndWriteAttribute();
            WriteLiteral(" /> </a>\r\n\t\t\t\t\t\t\t<label>Cuisine Name</label>\r\n\t\t\t\t\t    </div>\r\n\t\t\t\t\t\t<div class=\"top-cuisine-grid wow bounceIn\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t    <a");
            BeginWriteAttribute("href", " href=\"", 8829, "\"", 8836, 0);
            EndWriteAttribute();
            WriteLiteral("><img src=\"images/cuisine3.jpg\" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 8891, "\"", 8897, 0);
            EndWriteAttribute();
            WriteLiteral(" /> </a>\r\n\t\t\t\t\t\t\t<label>Cuisine Name</label>\r\n\t\t\t\t\t    </div>\r\n\t\t\t\t\t\t<div class=\"top-cuisine-grid nth-grid wow bounceIn\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t    <a");
            BeginWriteAttribute("href", " href=\"", 9055, "\"", 9062, 0);
            EndWriteAttribute();
            WriteLiteral("><img src=\"images/cuisine4.jpg\" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 9117, "\"", 9123, 0);
            EndWriteAttribute();
            WriteLiteral(" /> </a>\r\n\t\t\t\t\t\t\t<label>Cuisine Name</label>\r\n\t\t\t\t\t    </div>\r\n\t\t\t\t\t\t<div class=\"top-cuisine-grid nth-grid1 wow bounceIn\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t    <a");
            BeginWriteAttribute("href", " href=\"", 9282, "\"", 9289, 0);
            EndWriteAttribute();
            WriteLiteral("><img src=\"images/cuisine5.jpg\" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 9344, "\"", 9350, 0);
            EndWriteAttribute();
            WriteLiteral(" /> </a>\r\n\t\t\t\t\t\t\t<label>Cuisine Name</label>\r\n\t\t\t\t\t    </div>\r\n\t\t\t\t\t\t<div class=\"top-cuisine-grid nth-grid1 wow bounceIn\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t    <a");
            BeginWriteAttribute("href", " href=\"", 9509, "\"", 9516, 0);
            EndWriteAttribute();
            WriteLiteral("><img src=\"images/cuisine6.jpg\" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 9571, "\"", 9577, 0);
            EndWriteAttribute();
            WriteLiteral(" /> </a>\r\n\t\t\t\t\t\t\t<label>Cuisine Name</label>\r\n\t\t\t\t\t    </div>\r\n\t\t\t\t\t\t<div class=\"top-cuisine-grid nth-grid1 wow bounceIn\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t    <a");
            BeginWriteAttribute("href", " href=\"", 9736, "\"", 9743, 0);
            EndWriteAttribute();
            WriteLiteral("><img src=\"images/cuisine7.jpg\" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 9798, "\"", 9804, 0);
            EndWriteAttribute();
            WriteLiteral(" /> </a>\r\n\t\t\t\t\t\t\t<label>Cuisine Name</label>\r\n\t\t\t\t\t    </div>\r\n\t\t\t\t\t\t<div class=\"top-cuisine-grid nth-grid nth-grid1 wow bounceIn\" data-wow-delay=\"0.4s\">\r\n\t\t\t\t\t\t    <a");
            BeginWriteAttribute("href", " href=\"", 9972, "\"", 9979, 0);
            EndWriteAttribute();
            WriteLiteral("><img src=\"images/cuisine8.jpg\" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 10034, "\"", 10040, 0);
            EndWriteAttribute();
            WriteLiteral(@" /> </a>
							<label>Cuisine Name</label>
					    </div>
						<div class=""clearfix""></div>
					</div>
				</div>
				<div class=""clearfix""></div>
			</div>
		</div>
		<div class=""service-section"">
			<div class=""service-section-top-row"">
				<div class=""container"">
					<div class=""service-section-top-row-grids wow bounceInLeft"" data-wow-delay=""0.4s"">
					<div class=""col-md-3 service-section-top-row-grid1"">
						<h3>Enjoy Exclusive Food Order any of these</h3>
					</div>
					<div class=""col-md-2 service-section-top-row-grid2"">
						<ul>
							<li><i class=""arrow""></i></li>
							<li class=""lists"">Party Orders</li>
						</ul>
						<ul>
							<li><i class=""arrow""></i></li>
							<li class=""lists"">Home Made Food</li>
						</ul>
						<ul>
							<li><i class=""arrow""></i></li>
							<li class=""lists""> Diet Food </li>
						</ul>
					</div>
					<div class=""col-md-5 service-section-top-row-grid3"">
						<img src=""images/lunch.png"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 11053, "\"", 11059, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
					</div>
					<div class=""col-md-2 service-section-top-row-grid4 wow swing animated"" data-wow-delay= ""0.4s"">
						<a href=""order.html""><input type=""submit"" value=""Order Now""></a>
					</div>
					<div class=""clearfix""></div>
					</div>
				</div>
			</div>
			<div class=""service-section-bottom-row"">
				<div class=""container"">
					<div class=""col-md-4 service-section-bottom-grid wow bounceIn ""data-wow-delay=""0.2s"">
						<div class=""icon"">
							<img src=""images/icon1.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 11584, "\"", 11590, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
						</div>
						<div class=""icon-data"">
							<h4>100% Service Guarantee</h4>
							<p>Lorem ipsum dolor sit amet, consect-etuer adipiscing elit. </p>
						</div>
						<div class=""clearfix""></div>
					</div>
					<div class=""col-md-4 service-section-bottom-grid wow bounceIn ""data-wow-delay=""0.2s"">
						<div class=""icon"">
							<img src=""images/icon2.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 11994, "\"", 12000, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
						</div>
						<div class=""icon-data"">
							<h4>Fully Secure Payment</h4>
							<p>Lorem ipsum dolor sit amet, consect-etuer adipiscing elit. </p>
						</div>
						<div class=""clearfix""></div>
					</div>
					<div class=""col-md-4 service-section-bottom-grid wow bounceIn ""data-wow-delay=""0.2s"">
						<div class=""icon"">
							<img src=""images/icon3.jpg"" class=""img-responsive""");
            BeginWriteAttribute("alt", " alt=\"", 12402, "\"", 12408, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
						</div>
						<div class=""icon-data"">
							<h4>Track Your Order</h4>
							<p>Lorem ipsum dolor sit amet, consect-etuer adipiscing elit. </p>
						</div>
						<div class=""clearfix""></div>
					</div>
					<div class=""clearfix""></div>
				</div>
			</div>
		</div>
		<div class=""contact-section"" id=""contact"">
			<div class=""container"">
				<div class=""contact-section-grids"">
					<div class=""col-md-3 contact-section-grid wow fadeInLeft"" data-wow-delay=""0.4s"">
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
				");
            WriteLiteral(@"	<div class=""col-md-3 contact-section-grid wow fadeInLeft"" data-wow-delay=""0.4s"">
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
					<div class=""col-md-3 contact-section-grid wow fadeInRight"" data-wow-delay=""0.4s"">
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
							<li");
            WriteLiteral(@" class=""data""><a href=""#""> Linkedin</a></li>
						</ul>
						<ul>
							<li><i class=""gp""></i></li>
							<li class=""data""><a href=""#"">Google Plus</a></li>
						</ul>
					</div>
					<div class=""col-md-3 contact-section-grid nth-grid wow fadeInRight"" data-wow-delay=""0.4s"">
						<h4>Subscribe Newsletter</h4>
						<p>To get latest updates and food deals every week</p>
						<input type=""text"" class=""text""");
            BeginWriteAttribute("value", " value=\"", 14881, "\"", 14889, 0);
            EndWriteAttribute();
            WriteLiteral(@" onfocus=""this.value = '';"" onblur=""if (this.value == '') {this.value = '';}"">
						<input type=""submit"" value=""submit"">
						</div>
					<div class=""clearfix""></div>
				</div>
			</div>
		</div>
	</div>
	<!-- content-section-ends -->
	  <script type=""text/javascript"">
						$(document).ready(function() {
							/*
							var defaults = {
					  			containerID: 'toTop', // fading element id
								containerHoverID: 'toTopHover', // fading element hover id
								scrollSpeed: 1200,
								easingType: 'linear' 
					 		};
							*/
							
							$().UItoTop({ easingType: 'easeOutQuart' });
							
						});
					</script>
				<a href=""#"" id=""toTop"" style=""display: block;""> <span id=""toTopHover"" style=""opacity: 1;""> </span></a>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
