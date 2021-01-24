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
    public class IndexModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;

        public IndexModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }
        public PaginatedList<Lesson> Lesson { get; set; }

        public async Task OnGetAsync(string current, string searchString, int? pageIndex)
        {
            //Lesson = await _context.Lessons.ToListAsync();
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = current;
            }
            CurrentFilter = searchString;

            IQueryable<Lesson> lessonIQ = from l in _context.Lessons
                                             select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                lessonIQ = lessonIQ.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            Lesson = await PaginatedList<Lesson>.CreateAsync(
                lessonIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
