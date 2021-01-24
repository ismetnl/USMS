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
    public class IndexModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;

        public IndexModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }

        public IList<LessonAssigment> LessonAssigment { get;set; }

        public async Task OnGetAsync()
        {
            LessonAssigment = await _context.LessonAssigments
                .Include(l => l.Instructor)
                .Include(l => l.Lesson).ToListAsync();
        }
    }
}
