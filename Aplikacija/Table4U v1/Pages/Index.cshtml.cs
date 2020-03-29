using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SWEProject.Models;

namespace Table4U.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Table4UContext db;
        [BindProperty]
        public string Test { get; set; }
        public IndexModel(Table4UContext dataBase)
        {
            db = dataBase;
        }

        public void OnGet()
        {
           Test="Test123";
        }
    }
}
