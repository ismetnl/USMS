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
    public class DeleteModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;

        public DeleteModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Internship Internship { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Internship = await _context.Internships
                .Include(i => i.Student).FirstOrDefaultAsync(m => m.StudentID == id);

            if (Internship == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Internship = await _context.Internships.FindAsync(id);

            if (Internship != null)
            {
                _context.Internships.Remove(Internship);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
