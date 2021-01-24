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

namespace USMS.Pages.LessonAssigments
{
    public class EditModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;

        public EditModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LessonAssigment LessonAssigment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LessonAssigment = await _context.LessonAssigments
                .Include(l => l.Instructor)
                .Include(l => l.Lesson).FirstOrDefaultAsync(m => m.LessonID == id);

            if (LessonAssigment == null)
            {
                return NotFound();
            }
           ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "ID");
           ViewData["LessonID"] = new SelectList(_context.Lessons, "LessonID", "Title");
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

            _context.Attach(LessonAssigment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonAssigmentExists(LessonAssigment.LessonID))
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

        private bool LessonAssigmentExists(int id)
        {
            return _context.LessonAssigments.Any(e => e.LessonID == id);
        }
    }
}
