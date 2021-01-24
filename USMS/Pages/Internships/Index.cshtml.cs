using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using USMS.Data;
using USMS.Models;

namespace USMS.Pages.Internships
{
    public class IndexModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;

        public IndexModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }

        public IList<Internship> Internship { get;set; }

        public async Task OnGetAsync()
        {
            Internship = await _context.Internships
                .Include(i => i.Student).ToListAsync();
        }
    }
}
