
namespace Backend.Entidades
{
    public class Imagen
    {
        public string Id { get; set; }
        public string nombre { get; set; }
        public byte[] imagenBinario { get; set; }
        public string extension { get; set; }
        public Publicacion publicacion { get; set; }
    }
}
