using GerenRest.RazorPages.Data;
using GerenRest.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GerenRest.RazorPages.Pages.Garcon
{
    public class Edit : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public GarconModel GarconModel { get; set; } = new();
        public Edit(AppDbContext context)
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
            if(!ModelState.IsValid)
                return Page();

            var eventToUpdate = await _context.Garcons!.FindAsync(id);

            if(eventToUpdate == null) {
                return NotFound();
            }

            eventToUpdate.Nome = GarconModel.Nome;
            eventToUpdate.Sobrenome = GarconModel.Sobrenome;
            eventToUpdate.NumIdentificao = GarconModel.NumIdentificao;
            eventToUpdate.Telefone = GarconModel.Telefone;

            try {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Events/Index");
            } catch(DbUpdateException) {
                return Page();
            }
        }
    }
}