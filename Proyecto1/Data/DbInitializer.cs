using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto1.Data;

namespace Proyecto1.Data
{
    public class DbInitializer
    {
        public static void Initializer(Certamencontext context)
        {
            context.Database.EnsureCreated();
            if(context.Juginscr.Any())
            {
                return;
            }

        }
    }
}
