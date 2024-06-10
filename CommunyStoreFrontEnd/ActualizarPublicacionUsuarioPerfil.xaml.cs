using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunyStoreFrontEnd.Entidades;
using Microsoft.Maui.Controls;

namespace CommunyStoreFrontEnd
{
    public partial class ActualizarPublicacionUsuarioPerfil : ContentPage, INotifyPropertyChanged
    {
        private string descripcionPublicacion;
        public string DescripcionPublicacion
        {
            get => descripcionPublicacion;
            set
            {
                if (descripcionPublicacion != value)
                {
                    descripcionPublicacion = value;
                    OnPropertyChanged();
                }
            }
        }

        private string nombreCompletoUsuario;
        public string NombreCompletoUsuario
        {
            get => nombreCompletoUsuario;
            set
            {
                if (nombreCompletoUsuario != value)
                {
                    nombreCompletoUsuario = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime fechaPublicacion;
        public DateTime FechaPublicacion
        {
            get => fechaPublicacion;
            set
            {
                if (fechaPublicacion != value)
                {
                    fechaPublicacion = value;
                    OnPropertyChanged();
                }
            }
        }

        private string nombresArchivos;
        public string NombresArchivos
        {
            get => nombresArchivos;
            set
            {
                if (nombresArchivos != value)
                {
                    nombresArchivos = value;
                    OnPropertyChanged();
                }
            }
        }

        private string categoriaPublicacion;
        public string CategoriaPublicacion
        {
            get => categoriaPublicacion;
            set
            {
                if (categoriaPublicacion != value)
                {
                    categoriaPublicacion = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal precioPublicacion;
        public decimal PrecioPublicacion
        {
            get => precioPublicacion;
            set
            {
                if (precioPublicacion != value)
                {
                    precioPublicacion = value;
                    OnPropertyChanged();
                }
            }
        }

        public ActualizarPublicacionUsuarioPerfil(object bindingContext)
        {
            InitializeComponent();
            BindingContext = bindingContext;
            var publicacion = bindingContext as Publicacion; // Suponiendo que Publicacion es la clase que representa los datos de una publicación
            if (publicacion != null)
            {
                DescripcionPublicacion = publicacion.descripcionPublicacion;
                NombreCompletoUsuario = publicacion.usuario.NombreCompleto;
                FechaPublicacion = publicacion.fechaPublicacion;
                NombresArchivos = publicacion.nombresArchivos;
                CategoriaPublicacion = publicacion.categoriaPublicacion;
                PrecioPublicacion = publicacion.precioPublicacion;
                // Asigna otros campos de la publicación según sea necesario
            }
        }

        private async void GuardarInformacion_Clicked(object sender, EventArgs e)
        {
            var publicacion = BindingContext as Publicacion;
            if (publicacion != null)
            {
                publicacion.descripcionPublicacion = DescripcionPublicacion;
                

               
            }
            await DisplayAlert("Información", "Publicación actualizada con éxito", "OK");
            await Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
