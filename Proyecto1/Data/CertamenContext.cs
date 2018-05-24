using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto1.Models;

namespace Proyecto1.Data
{
    public class Certamencontext:DbContext
    {
        public Certamencontext(DbContextOptions<Certamencontext> options)
            : base(options)
        { }
        public DbSet<Equipo> Equiposins { get; set; }
        public DbSet<Inscripcion> Inscripequ { get; set; }
        public DbSet<Jugador> Juginscr { get; set; }
    }
}
