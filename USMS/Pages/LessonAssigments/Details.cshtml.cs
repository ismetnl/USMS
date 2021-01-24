using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using USMS.Data;
using USMS.Models;

namespace USMS.Pages.LessonAssigments
{
    public class DetailsModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;

        public DetailsModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
