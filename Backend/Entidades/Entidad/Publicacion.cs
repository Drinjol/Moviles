using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace Backend.Entidades
{
    public class Publicacion : INotifyPropertyChanged
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


        public bool _isFavorito;
        public bool IsFavorito
        {
            get => _isFavorito;
            set
            {
                if (_isFavorito != value)
                {
                    _isFavorito = value;
                    OnPropertyChanged(nameof(IsFavorito));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
