using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class Chats
    {

        public int idChat { get; set; }
        public Usuario idUsuario1 { get; set; }
        public Usuario idUsuario2 { get; set; }
       
        public int estado { get; set; }


        public int tempId { get; set; }
        public string tempContenido { get; set; }

        public DateTime tempFecha { get; set; }



    }
}
