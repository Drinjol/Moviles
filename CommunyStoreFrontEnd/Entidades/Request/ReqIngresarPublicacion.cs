using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunyStoreFrontEnd.Entidades
{
    public class ReqIngresarPublicacion
    {
        public Publicacion publicacion {  get; set; }
        public int idUsuario { get; set; }
    }
}
