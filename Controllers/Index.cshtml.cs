using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Images.Data;
using Project_Images.Models;

namespace Project_Images.Controllers
{
    public class IndexModel : PageModel
    {
        private readonly Project_Images.Data.ApplicationDbContext _context;

        public IndexModel(Project_Images.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Images> Images { get;set; }

        public async Task OnGetAsync()
        {
            Images = await _context.Images.ToListAsync();
        }
    }
}
