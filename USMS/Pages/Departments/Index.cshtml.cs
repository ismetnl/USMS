using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using USMS.Data;
using USMS.Models;

namespace USMS.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly USMS.Data.USMSContext _context;

        public IndexModel(USMS.Data.USMSContext context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }
        public PaginatedList<Department> Department { get;set; }

        public async Task OnGetAsync(string current, string searchString, int? pageIndex)
        {
            //Department = await _context.Departments.ToListAsync();
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = current;
            }
            CurrentFilter = searchString;

            IQueryable<Department> departmentIQ = from d in _context.Departments
                                          select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                departmentIQ = departmentIQ.Where(l => l.Name.Contains(searchString));
            }

            int pageSize = 4;
            Department = await PaginatedList<Department>.CreateAsync(
                departmentIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
