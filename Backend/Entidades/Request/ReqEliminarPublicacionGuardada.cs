using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class ReqEliminarPublicacionGuardada
    {
        public int usuarioid { get; set; }
        public int publicacionGuardadaId { get; set; }

    }
}
