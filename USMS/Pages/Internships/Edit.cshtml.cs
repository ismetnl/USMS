using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using USMS.Data;
using USMS.Models;

namespace USMS.Pages.Internships
{
    public class EditModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;

        public EditModel(USMS.Data.USMSContext context)
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
           ViewData["StudentID"] = new SelectList(_context.Student, "ID", "FirstName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Internship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternshipExists(Internship.StudentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InternshipExists(int id)
        {
            return _context.Internships.Any(e => e.StudentID == id);
        }
    }
}
