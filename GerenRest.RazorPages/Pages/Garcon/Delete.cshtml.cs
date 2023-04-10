using GerenRest.RazorPages.Data;
using GerenRest.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GerenRest.RazorPages.Pages.Garcon
{
    public class Delete : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public GarconModel GarconModel { get; set; } = new();
        public Delete(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null || _context.Garcons == null) {
                return NotFound();
            }

            var garconModel = await _context.Garcons.FirstOrDefaultAsync(e => e.GarconID == id);

            if(garconModel == null) {
                return NotFound();
            }

            GarconModel = garconModel;

            return Page();
        }
    
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var eventToDelete = await _context.Garcons!.FindAsync(id);

            if(eventToDelete == null) {
                return NotFound();
            }

            try {
                _context.Garcons.Remove(eventToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Events/Index");
            } catch(DbUpdateException) {
                return Page();
            }
        }
    }
}