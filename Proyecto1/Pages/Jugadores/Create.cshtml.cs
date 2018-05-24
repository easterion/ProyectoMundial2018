using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto1.Data;
using Proyecto1.Models;

namespace Proyecto1.Pages.Jugadores
{
    public class CreateModel : PageModel
    {
        private readonly Proyecto1.Data.Certamencontext _context;

        public CreateModel(Proyecto1.Data.Certamencontext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Jugador Jugador { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Jugador.PaisJugador = Convert.ToString(Equipo.NomEquipo);
            _context.Juginscr.Add(Jugador);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}