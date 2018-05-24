using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto1.Data;
using Proyecto1.Models;

namespace Proyecto1.Pages.Equipos
{
    public class EditModel : PageModel
    {
        private readonly Proyecto1.Data.Certamencontext _context;

        public EditModel(Proyecto1.Data.Certamencontext context)
        {
            _context = context;
        }

        [BindProperty]
        public Equipo Equipo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipo = await _context.Equiposins.SingleOrDefaultAsync(m => m.EquipoID == id);

            if (Equipo == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Equipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoExists(Equipo.EquipoID))
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

        private bool EquipoExists(int id)
        {
            return _context.Equiposins.Any(e => e.EquipoID == id);
        }
    }
}
