using System;
namespace Backend.Entidades
{
    public class Publicacion
    {
        public int idPublicacion { get; set; }
        public DateTime fechaPublicacion { get; set; }
        public decimal precioPublicacion { get; set; }
        public string descripcionPublicacion { get; set; }
        public string categoriaPublicacion { get; set; }
        public int estadoPublicacion { get; set; }

        public Usuario usuario { get; set; }
    }
}
