using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunyStoreFrontEnd.Entidades
{
    public class ReqEliminarPublicacionGuardada
    {
        public int usuarioId {  get; set; }
        public int publicacionGuardadaId { get; set; }
    }
}
