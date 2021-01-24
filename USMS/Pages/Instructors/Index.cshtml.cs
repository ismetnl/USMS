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
    public class IndexModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;

        public IndexModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }

        public IList<Instructor> Instructor { get;set; }
        public int InstructorID { get; set; }
        public int LessonID { get; set; }
        public async Task OnGetAsync()
        {
            Instructor = await _context.Instructors
                .Include(i => i.Department).ToListAsync();
        }
    }
}
