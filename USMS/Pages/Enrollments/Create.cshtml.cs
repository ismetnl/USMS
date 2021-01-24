using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using USMS.Data;
using USMS.Models;

namespace USMS.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;
        private int grade;

        public CreateModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["LessonID"] = new SelectList(_context.Lessons, "LessonID", "Title");
        ViewData["StudentID"] = new SelectList(_context.Student, "ID", "FullName");
            
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var enrollExist = _context.Enrollments
                .Where(e => e.StudentID == Enrollment.StudentID && e.LessonID == Enrollment.LessonID)
                .FirstOrDefault<Enrollment>();

            if(enrollExist != null)
            {
                return Page();
            }

            if (Enrollment.midterm != null && Enrollment.final != null){
                grade = (int)(Enrollment.midterm * 0.3 + Enrollment.final * 0.7);
                if (grade >= 90)
                {
                    Enrollment.grade = "AA";
                }
                else if(grade >= 85)
                {
                    Enrollment.grade = "BA";
                }
                else if (grade >= 80)
                {
                    Enrollment.grade = "BB";
                }
                else if (grade >= 70)
                {
                    Enrollment.grade = "CB";
                }
                else if (grade >= 60)
                {
                    Enrollment.grade = "CC";
                }
                else if (grade >= 50)
                {
                    Enrollment.grade = "DD";
                }
                else
                {
                    Enrollment.grade = "FF";
                }
            }

            _context.Enrollments.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
