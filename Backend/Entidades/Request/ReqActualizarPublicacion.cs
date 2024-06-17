using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class ReqActualizarPublicacion
    {

        public int IdPublicacion { get; set; }
        public string DescripcionPublicacion { get; set; }
        public decimal PrecioPublicacion { get; set; }
        public string CategoriaPublicacion { get; set; }
        public string NombresArchivos { get; set; } 
        public int IdUsuario { get; set; }
        public bool Favorito { get; set; }
        public DateTime fechaPublicacion { get; set; }
    }
}
