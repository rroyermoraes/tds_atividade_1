using Aula05.RazorPages.Data;
using Aula05.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula05.RazorPages.Pages.Events
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;
        public List<EventModel> EventList { get; set; } = new();
        public Index(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            EventList = await _context.Events!.ToListAsync();
            return Page();
        }
    }
}