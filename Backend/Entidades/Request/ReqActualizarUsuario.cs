using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades.Request
{
    //enpdpoitn donde se conecta la api
     class ReqActualizarUsuario: ReqBase
    {
        public Usuario usuario { get; set; }
    }
}
