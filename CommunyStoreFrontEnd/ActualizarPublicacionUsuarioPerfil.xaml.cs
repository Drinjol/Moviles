using System;
using System.ComponentModel;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Google.Apis.Drive.v3;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;

namespace CommunyStoreFrontEnd
{
    public partial class ActualizarPublicacionUsuarioPerfil : ContentPage, INotifyPropertyChanged
    {

        private int idPublicacion;
        public int IdPublicacion
        {
            get => idPublicacion;
            set
            {
                if (idPublicacion != value)
                {
                    idPublicacion = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public ActualizarPublicacionUsuarioPerfil(int idPublicacion, string descripcionPublicacion, string categoriaPublicacion, decimal precioPublicacion)
        {
            InitializeComponent();
            IdPublicacion = idPublicacion;
            DescripcionPublicacion = descripcionPublicacion;
            NombreCompletoUsuario = SesionFrontEnd.usuarioSesion.NombreCompleto;
            CategoriaPublicacion = categoriaPublicacion;
            PrecioPublicacion = precioPublicacion;
            BindingContext = this;
        }

        // M�todo para guardar la informaci�n
        private async void GuardarInformacion_Clicked(object sender, EventArgs e)
        {
            try
            {
                var publicacion = new ReqActualizarPublicacion
                {
                    IdPublicacion = IdPublicacion,
                    DescripcionPublicacion = DescripcionPublicacion,
                    CategoriaPublicacion = CategoriaPublicacion,
                    PrecioPublicacion = PrecioPublicacion
                };

                var jsonContent = new StringContent(JsonConvert.SerializeObject(publicacion), Encoding.UTF8, "application/json");
                await DisplayAlert("Datos capturados, serializados", JsonConvert.SerializeObject(publicacion), "Aceptar");

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/publicacion/actualizarPublicacion", jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var resActualizarPublicacion = JsonConvert.DeserializeObject<ResActualizarPublicacion>(responseContent);

                        if (resActualizarPublicacion != null && resActualizarPublicacion.resultado)
                        {
                            await DisplayAlert("�xito", "Publicaci�n actualizada con �xito", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Error", "Hubo un problema al actualizar la publicaci�n: " + string.Join(", ", resActualizarPublicacion?.listaDeErrores), "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Hubo un problema al actualizar la publicaci�n", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ocurri� un error: " + ex.Message, "OK");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
