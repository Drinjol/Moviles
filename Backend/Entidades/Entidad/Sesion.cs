using System;

namespace Backend.Entidades
{
    public class Sesion
    {

        public int id { get; set; }
        public Usuario usuario { get; set; }
        public string sesion { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin {  get; set; }
        public bool esValido { get; set; }
    }
}
