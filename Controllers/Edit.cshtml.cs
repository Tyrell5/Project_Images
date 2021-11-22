using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Images.Data;
using Project_Images.Models;

namespace Project_Images.Controllers
{
    public class EditModel : PageModel
    {
        private readonly Project_Images.Data.ApplicationDbContext _context;

        public EditModel(Project_Images.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Images Images { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Images = await _context.Images.FirstOrDefaultAsync(m => m.Id == id);

            if (Images == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Images).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagesExists(Images.Id))
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

        private bool ImagesExists(int id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
