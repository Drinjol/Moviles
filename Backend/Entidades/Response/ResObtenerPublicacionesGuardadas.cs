using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class ResObtenerPublicacionesGuardadas : ResBase
    {
        public List<PublicacionGuardada> listaPublicacionGuardada { get; set; }
    }
}
