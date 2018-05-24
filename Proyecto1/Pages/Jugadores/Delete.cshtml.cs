using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto1.Data;
using Proyecto1.Models;

namespace Proyecto1.Pages.Jugadores
{
    public class DeleteModel : PageModel
    {
        private readonly Proyecto1.Data.Certamencontext _context;

        public DeleteModel(Proyecto1.Data.Certamencontext context)
        {
            _context = context;
        }

        [BindProperty]
        public Jugador Jugador { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jugador = await _context.Juginscr.SingleOrDefaultAsync(m => m.JugadorID == id);

            if (Jugador == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jugador = await _context.Juginscr.FindAsync(id);

            if (Jugador != null)
            {
                _context.Juginscr.Remove(Jugador);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
