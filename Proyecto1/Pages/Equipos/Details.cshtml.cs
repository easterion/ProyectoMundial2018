using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto1.Data;
using Proyecto1.Models;

namespace Proyecto1.Pages.Equipos
{
    public class DetailsModel : PageModel
    {
        private readonly Proyecto1.Data.Certamencontext _context;
        ConexionBD con = new ConexionBD();  // establece la conexion con la base de datos
        [BindProperty]
        public string nomeq { get; set; }
        [BindProperty]
        public string banequ { get; set; }

        public Equipo eqq = new Equipo();
        public DetailsModel(Proyecto1.Data.Certamencontext context)
        {
            _context = context;
        }

        public Equipo Equipo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            eqq = con.mostrareqp(id.Value);
            nomeq = eqq.NomEquipo;
            banequ = eqq.ImagenBandera;
            /*if (id == null)
            {
                return NotFound();
            }

            Equipo = await _context.Equiposins.SingleOrDefaultAsync(m => m.EquipoID == id);

            if (Equipo == null)
            {
                return NotFound();
            }*/
            return Page();
        }
    }
}
