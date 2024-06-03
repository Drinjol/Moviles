using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunyStoreFrontEnd.Entidades
{
    public class Publicacion : INotifyPropertyChanged
    {
        public int idPublicacion { get; set; }
        public DateTime fechaPublicacion { get; set; }
         public decimal precioPublicacion { get; set; }
        public string descripcionPublicacion { get; set; }
        public string categoriaPublicacion { get; set; }
        public int estadoPublicacion { get; set; }
        public string nombresArchivos { get; set; }

        public ImageSource imagen {  get; set; }

        public Usuario usuario { get; set; }
        public bool favorito { get; set; }


        private bool _isFavorito;
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
