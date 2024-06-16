using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    //enpdpoitn donde se conecta la api
    public class ReqActualizarUsuario: ReqBase
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
       
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string descripcion { get; set; }
        public string password { get; set; }
     
  
    }
}
