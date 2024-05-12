

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunyStoreFrontEnd.Entidades
{
    public class ResObtenerListaPublicaciones:ResBase
    {
        
       
        public List<Publicacion> publicaciones { get; set; }
    }
}
