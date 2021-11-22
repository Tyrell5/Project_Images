using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Images.Data;
using Project_Images.Models;

namespace Project_Images.Controllers
{
    public class CreateModel : PageModel
    {
        private readonly Project_Images.Data.ApplicationDbContext _context;

        public CreateModel(Project_Images.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Images Images { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Images.Add(Images);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
