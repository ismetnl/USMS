using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USMS.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        
        [BindProperty]
        public string Password { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        { 
            if (Username == null || Password == null) return Page();
            if (Username.Equals("admin") && Password.Equals("123")){
                HttpContext.Session.SetString("username", Username);
                return RedirectToPage("Home/Index");
            }
            else return Page();
        }
    }
}
