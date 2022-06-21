using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(SchoolContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string IdSort { get; set; }
        public string FirstNameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public int PageSize { get; set; }

        public PaginatedList<Student> Students { get; set; }

        //q = query, o = order, cq = currentQuery, p = pageNumber
        public async Task OnGetAsync(string o, string cq, string q, int? p)
        {
            CurrentSort = o;
            NameSort = String.IsNullOrEmpty(o) ? "name_desc" : "";
            DateSort = o == "Date" ? "date_desc" : "Date";
            IdSort = o == "id" ? "id_desc" : "id";
            FirstNameSort = o == "fname" ? "fname_desc" : "fname";
            PageSize = 4;
            if (q != null)
            {
                p = 1;
            }
            else
            {
                q = cq;
            }

            CurrentFilter = q;

            IQueryable<Student> studentsIQ = from s in _context.Students
                                             select s;

            if (!String.IsNullOrEmpty(q))
            {
                studentsIQ = studentsIQ.Where(s => s.LastName.Contains(q)
                                       || s.FirstMidName.Contains(q));
            }

            switch (o)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    studentsIQ = studentsIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                case "id":
                    studentsIQ = studentsIQ.OrderBy(s => s.ID);
                    break;
                case "id_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.ID);
                    break;
                case "fname":
                    studentsIQ = studentsIQ.OrderBy(s => s.FirstMidName);
                    break;
                case "fname_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.FirstMidName);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.LastName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", PageSize);
            Students = await PaginatedList<Student>.CreateAsync(
                studentsIQ.AsNoTracking(), p ?? 1, pageSize);
        }
    }
}
