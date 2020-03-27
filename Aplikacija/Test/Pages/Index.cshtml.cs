using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Test.Models;
using MongoDB.Driver.Linq;

namespace Test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BookService bookService;
        [BindProperty]
        public IList<Book>Knjige {get; set;}
        [BindProperty(SupportsGet=true)]
        public Book NovaKnjiga{get; set;}

        public IndexModel(BookService bs)
        {
            bookService = bs;
        }

        public async Task<IActionResult> OnGet()
        {
            var knjige = bookService.getBooks().AsQueryable<Book>();
            Knjige = knjige.ToList();
            
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            bookService.Create(NovaKnjiga);
            return RedirectToPage("/Index");
        }
    }
}
