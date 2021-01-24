using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using USMS.Data;
using USMS.Models;

namespace USMS.Pages.Students
{
    public class CreateModel : PageModel
    {
        public const string MessageKey = nameof(MessageKey);
        private readonly USMS.Data.USMSContext _context;
        public DateTime myDate = DateTime.Now;
        TimeSpan t = DateTime.Now.TimeOfDay;

        public CreateModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }
        
        
       

        public IActionResult OnGet()
        {

            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //var emptyStudent = new Student();

            //if (await TryUpdateModelAsync<Student>(
            //    emptyStudent,
            //    "student",   // Prefix for form value.
            //    s => s.FirstName, s => s.LastName, s => s.EnrollmentDate))
            //{
            //    _context.Student.Add(emptyStudent);
            //    await _context.SaveChangesAsync();
            //    return RedirectToPage("./Index");
            //}

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Student.EnrollmentDate < myDate.Subtract(t))
            {
                TempData[MessageKey] = "invalid old date";
                return Page();
                //return RedirectToAction(Request.Path);
            }


            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");


        }
    }
}
