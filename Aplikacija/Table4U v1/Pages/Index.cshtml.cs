using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SWEProject.Models;

namespace Table4U.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Table4UContext db;
        
        public String eMail {get; set;}
        public IndexModel(Table4UContext dataBase)
        {
            db = dataBase;
        }

        public void OnGet()
        {
           eMail = HttpContext.Session.GetString("email");
        }

        public void OnGetLogout()
        {
            HttpContext.Session.Remove("email");
        }
    }
}
