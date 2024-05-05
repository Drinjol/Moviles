using Backend.Entidades.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class ReqIngresarPublicacion:ReqBase
    {

        public Publicacion publicacion {  get; set; }
    }
}
