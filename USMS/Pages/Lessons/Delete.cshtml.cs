using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using USMS.Data;
using USMS.Models;

namespace USMS.Pages.Lessons
{
    public class DeleteModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;

        public DeleteModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lesson Lesson { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lesson = await _context.Lessons.FirstOrDefaultAsync(m => m.LessonID == id);

            if (Lesson == null)
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

            Lesson = await _context.Lessons.FindAsync(id);

            if (Lesson != null)
            {
                _context.Lessons.Remove(Lesson);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
