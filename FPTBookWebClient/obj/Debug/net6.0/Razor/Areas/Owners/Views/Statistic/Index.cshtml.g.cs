#pragma checksum "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7080dcb9a8060840f1a235537ef1467d56af3d17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Owners_Views_Statistic_Index), @"mvc.1.0.view", @"/Areas/Owners/Views/Statistic/Index.cshtml")]
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
#line 1 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\_ViewImports.cshtml"
using FPTBookWebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\_ViewImports.cshtml"
using FPTBookWebClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7080dcb9a8060840f1a235537ef1467d56af3d17", @"/Areas/Owners/Views/Statistic/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9df26dc013fcd8f29fe11b47c1e876fbdb36450e", @"/Areas/Owners/Views/_ViewImports.cshtml")]
    public class Areas_Owners_Views_Statistic_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FPTBookWebClient.Areas.Owners.Models.StatisticsView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
  
	ViewData["Title"] = "Data Statistics";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""pt-2 mb-2"">
	<h1 class=""text-center"">Data Statistics</h1>
	<h3 class=""mt-5"">Who purchase the most</h3>
	<table class=""table table-striped table-bordered m-0"" width=""100%"">
		<thead class=""justify-content-md-between justify-content-sm-center align-content-center border-bottom border-2 my-2 bg-dark text-light p-3 rounded-3"">
			<tr>
				<th>
					<strong>ID</strong>
				</th>
				<th>
					<strong>Name</strong>
				</th>
				<th>
					<strong>Phone Number</strong>
				</th>
				<th>
					<strong>Email</strong>
				</th>
				<th>
					<strong>Address</strong>
				</th>
			</tr>
		</thead>

		<tbody class=""justify-content-md-between justify-content-sm-center border-bottom border-2 my-2 bg-light p-2 rounded-3"">
");
#nullable restore
#line 30 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
              
				int countUser = 0;
			

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
             foreach (var user in Model.UsersBuyMost)
			{
				countUser++;

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<tr>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 37 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(countUser);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 38 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 38 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                                   Write(user.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 39 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(user.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 40 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 41 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(user.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t</tr>\r\n");
#nullable restore
#line 43 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
			}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"		</tbody>
	</table>

	<h3 class=""mt-5"">Which books are purchased the most</h3>
	<table class=""table table-striped table-bordered m-0"" width=""100%"">
		<thead class=""justify-content-md-between justify-content-sm-center align-content-center border-bottom border-2 my-2 bg-dark text-light p-3 rounded-3"">
			<tr>
				<th>
					<strong>ID</strong>
				</th>
				<th>
					<strong>Book Title</strong>
				</th>
				<th>
					<strong>Genre</strong>
				</th>
				<th>
					<strong>Author</strong>
				</th>
				<th>
					<strong>Publisher</strong>
				</th>
				<th>
					<strong>Price</strong>
				</th>
				<th>
					<strong>Original Price</strong>
				</th>
				<th>
					<strong>Sale Percent</strong>
				</th>
				<th>
					<strong>Stock</strong>
				</th>
				<th>
					<strong>Image</strong>
				</th>
			</tr>
		</thead>

		<tbody class=""justify-content-md-between justify-content-sm-center border-bottom border-2 my-2 bg-light p-2 rounded-3"">
");
#nullable restore
#line 85 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
              
				int countBook = 0;
			

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
             foreach (var book in Model.BooksBuyMost)
			{
				countBook++;

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<tr>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 92 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(countBook);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 93 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(book.BookTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 94 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(book.Genre.GenreName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 95 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(book.Author.AuthorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 96 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(book.Publisher.PublisherName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>$");
#nullable restore
#line 97 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                    Write(book.BookPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 98 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(book.BookOriginalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 99 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(book.SalePercent);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 100 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(book.BookStock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td><img");
            BeginWriteAttribute("src", " src=\"", 2587, "\"", 2621, 3);
#nullable restore
#line 101 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
WriteAttributeValue("", 2593, ViewBag.api, 2593, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2605, "/", 2605, 1, true);
#nullable restore
#line 101 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
WriteAttributeValue("", 2606, book.BookImage, 2606, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"80\" width=\"50\" /></td>\r\n\t\t\t\t</tr>\r\n");
#nullable restore
#line 103 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
			}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t</tbody>\r\n\t</table>\r\n\r\n\t<h3 class=\"mt-5\">Total income for the month ");
#nullable restore
#line 107 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                                           Write(DateTime.Now.Month);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
	<table class=""table table-striped table-bordered m-0"" width=""100%"">
		<thead class=""justify-content-md-between justify-content-sm-center align-content-center border-bottom border-2 my-2 bg-dark text-light p-3 rounded-3"">
			<tr>
				<th>
					<strong>ID</strong>
				</th>
				<th>
					<strong>Order date</strong>
				</th>
				<th>
					<strong>Delivery date</strong>
				</th>
				<th>
					<strong>Customer Name</strong>
				</th>
				<th>
					<strong>Telephone</strong>
				</th>
				<th>
					<strong>Address</strong>
				</th>
				<th>
					<strong>Shipping Fee</strong>
				</th>
				<th>
					<strong>Amount</strong>
				</th>
			</tr>
		</thead>

		<tbody class=""justify-content-md-between justify-content-sm-center border-bottom border-2 my-2 bg-light p-2 rounded-3"">
");
#nullable restore
#line 139 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
              
				int countTotal = 0;
				decimal total = 0;
			

#line default
#line hidden
#nullable disable
#nullable restore
#line 143 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
             foreach (var order in Model.OrdersTotalInMonth)
			{
				countTotal++;

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<tr>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 147 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(countTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 148 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(order.OrderDate.ToString("MM/dd/yyyy HH:mm:ss"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 149 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(order.DeliveryDate.ToString("MM/dd/yyyy HH:mm:ss"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 150 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(order.OrderName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 151 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(order.OrderPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 152 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(order.DeliveryLocal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td><b>$");
#nullable restore
#line 153 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                       Write(order.ShippingFee.ToString("N2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\r\n");
#nullable restore
#line 154 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                      
						decimal amount = 0;
					

#line default
#line hidden
#nullable disable
#nullable restore
#line 157 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                     foreach (var od in order.OrderDetails)
					{
						amount += od.TotalPrice;
					}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<td>");
#nullable restore
#line 161 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                   Write(amount.ToString("N2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 162 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                      
						total += amount + order.ShippingFee;
					

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</tr>\r\n");
#nullable restore
#line 166 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
			}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t</tbody>\r\n\r\n\t\t<tfoot>\r\n\t\t\t<tr>\r\n\t\t\t\t<td colspan=\"6\" class=\"text-end\"><strong>Total</strong></td>\r\n\t\t\t\t<td colspan=\"2\" class=\"text-center\">$");
#nullable restore
#line 172 "D:\Greenwich\Personal\Junior\1670 - Application Development\Assignment\Source_code\FPTBook_Web-based_Software_System\FPTBookWebClient\Areas\Owners\Views\Statistic\Index.cshtml"
                                                Write(total.ToString("N2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t</tr>\r\n\t\t</tfoot>\r\n\t</table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FPTBookWebClient.Areas.Owners.Models.StatisticsView> Html { get; private set; }
    }
}
#pragma warning restore 1591
