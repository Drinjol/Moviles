using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using CommunyStoreFrontEnd.Entidades;
using Google.Apis.Drive.v3;
using Microsoft.Maui.Controls;

namespace CommunyStoreFrontEnd
{
    public partial class ActualizarPublicacionUsuarioPerfil : ContentPage, INotifyPropertyChanged
    {
        private string _selectedFile;
        static string[] Scopes = { DriveService.Scope.DriveFile };
        static string ApplicationName = "Google Drive API .NET MAUI";
        static string FolderId = "1r7A7hITGX4WjarcooONMt4qPHKjxRhLU";

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

        public ActualizarPublicacionUsuarioPerfil(Publicacion publicacion)
        {
            InitializeComponent();
            BindingContext = publicacion;
        }

        private async void GuardarInformacion_Clicked(object sender, EventArgs e)
        {
            var publicacion = BindingContext as Publicacion;
            if (publicacion != null)
            {
                publicacion.descripcionPublicacion = DescripcionPublicacion;
                publicacion.precioPublicacion = PrecioPublicacion;
                publicacion.fechaPublicacion = FechaPublicacion;
                publicacion.categoriaPublicacion = CategoriaPublicacion;
                publicacion.nombresArchivos = NombresArchivos;
            }
            await DisplayAlert("Información", "Publicación actualizada con éxito", "OK");
            await Navigation.PopAsync();
        }

        private async void CargarImagen_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync();
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();

                // Convertir la imagen a una cadena base64
                var base64Image = Convert.ToBase64String(imageBytes);

                // Asignar la cadena base64 a nombresArchivos
                NombresArchivos = base64Image;

                // Actualizar la imagen en la propiedad de la publicación
                var publicacion = BindingContext as Publicacion;
                if (publicacion != null)
                {
                    publicacion.imagen = ImageSource.FromStream(() => new MemoryStream(imageBytes));
                }

                OnPropertyChanged(nameof(NombresArchivos));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
