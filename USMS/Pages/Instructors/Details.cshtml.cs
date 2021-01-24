using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using USMS.Data;
using USMS.Models;

namespace USMS.Pages.Instructors
{
    public class DetailsModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;

        public DetailsModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }

        public Instructor Instructor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Instructor = await _context.Instructors
                .AsNoTracking()
                .Include(i=>i.LessonAssigments)
                .ThenInclude(l=>l.Lesson)
                .Include(i => i.Department).FirstOrDefaultAsync(m => m.ID == id);

            if (Instructor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
