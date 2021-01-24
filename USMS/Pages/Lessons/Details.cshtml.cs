﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;

        public DetailsModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }

        public Lesson Lesson { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lesson = await _context.Lessons
                .Include(m=> m.LessonAssigments)
                .ThenInclude(a => a.Instructor)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.LessonID == id);

            if (Lesson == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
