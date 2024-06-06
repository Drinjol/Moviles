using System;
using System.Collections.Generic;
using System.ComponentModel;
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

      //  public List<string> nombresArchivos {  get; set; }
        public string nombresArchivos { get; set; }
        public Usuario usuario { get; set; }
        public bool favorito {  get; set; }

        

    }
}
