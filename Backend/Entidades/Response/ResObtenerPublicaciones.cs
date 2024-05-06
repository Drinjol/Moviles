using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades.Response
{
    public class ResObtenerPublicaciones: ResBase
    {
        public List<Publicacion> publicaciones;
        public Publicacion publicacion;
    }
}
