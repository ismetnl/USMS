using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using USMS.Data;
using USMS.Models;

namespace USMS.Pages.LessonAssigments
{
    public class CreateModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;

        public CreateModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FirstName");
        ViewData["LessonID"] = new SelectList(_context.Lessons, "LessonID", "Title");
            return Page();
        }

        [BindProperty]
        public LessonAssigment LessonAssigment { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LessonAssigments.Add(LessonAssigment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
