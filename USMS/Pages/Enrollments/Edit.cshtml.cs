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

namespace USMS.Pages.Enrollments
{
    public class EditModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;
        private int grade;
        public EditModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Enrollment = await _context.Enrollments
                .Include(e => e.Lesson)
                .Include(e => e.Student).FirstOrDefaultAsync(m => m.EnrollmentID == id);

            if (Enrollment == null)
            {
                return NotFound();
            }
           ViewData["LessonID"] = new SelectList(_context.Lessons, "LessonID", "Title");
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

            if (Enrollment.midterm != null && Enrollment.final != null)
            {
                grade = (int)(Enrollment.midterm * 0.3 + Enrollment.final * 0.7);
                if (grade >= 90)
                {
                    Enrollment.grade = "AA";
                }
                else if (grade >= 85)
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
            _context.Attach(Enrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(Enrollment.EnrollmentID))
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

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollments.Any(e => e.EnrollmentID == id);
        }
    }
}
