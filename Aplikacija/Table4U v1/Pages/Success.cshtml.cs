using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWEProject.Models;

namespace MyApp.Namespace
{
    public class SuccessModel : PageModel
    {
        [BindProperty]
        public Korisnik TKorisnik { get; set; }
        [BindProperty]
        public string  Message { get; set; }
      
       
    
        public void OnGet()
        {
        }
    }
}
