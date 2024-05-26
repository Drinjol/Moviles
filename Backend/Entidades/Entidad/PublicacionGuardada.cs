using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class PublicacionGuardada
    {
        public int idPublicacionGuardada {  get; set; }
        public Publicacion publicacion {  get; set; }
        public DateTime fechaGuardado {  get; set; }
        public int estadoGuardado { get; set; }

    }

}
