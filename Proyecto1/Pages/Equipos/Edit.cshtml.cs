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
        ConexionBD con = new ConexionBD();  // establece la conexion con la base de datos

        public EditModel(Proyecto1.Data.Certamencontext context)
        {
            _context = context;
        }

        [BindProperty]
        public Equipo Equipo { get; set; }
        [BindProperty]
        public Equipo Equp { get; set; }
        [BindProperty]
        public string Eqnom { get; set; }
        [BindProperty]
        public string Eqband { get; set; }
        [BindProperty]
        public static int ide { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ide = id.Value;
            Equp = con.mostrareqp(ide);
            if (id == null)
            {
                return NotFound();
            }

            Equipo = await _context.Equiposins.SingleOrDefaultAsync(m => m.EquipoID == id);


            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            con.ModEquipo(ide,Eqnom,Eqband);
            _context.Attach(Equipo).State = EntityState.Modified;

            return RedirectToPage("/Equipos/Index");
        }

        private bool EquipoExists(int id)
        {
            return _context.Equiposins.Any(e => e.EquipoID == id);
        }
    }
}
