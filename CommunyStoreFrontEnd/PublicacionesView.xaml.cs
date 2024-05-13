

using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CommunyStoreFrontEnd;

public partial class PublicacionesView : Shell, INotifyPropertyChanged
{
    private int cantidad = 3; // Variable que determina la cantidad de pestañas
    private List<Publicacion> _listaDePublicaciones = new List<Publicacion>();


    public List<Publicacion> listaDePublicaciones
    {
        get { return _listaDePublicaciones; }
        set
        {
            _listaDePublicaciones = value;
            OnPropertyChanged(nameof(listaDePublicaciones));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public PublicacionesView()
    {
        InitializeComponent();
        CargarPublicaciones();

        // Generar botones para las pestañas
        // GenerarBotonesPestanas();

        // Mostrar el contenido inicial (primera pestaña)
        // MostrarContenidoPestana(3);


    }

    /* private List<StackLayout> contenidosPestanas = new List<StackLayout>();

     private void Button_Clicked(object sender, EventArgs e)
     {
         var button = (Button)sender;
         int numeroPestana = Convert.ToInt32(button.Text.Split(' ')[1]);
         MostrarContenidoPestana(numeroPestana);
     }

     private void MostrarContenidoPestana(int numeroPestana)
     {
         // Ocultar todos los contenidos de las pestañas
         foreach (var contenidoPestana in contenidosPestanas)
         {
             contenidoPestana.IsVisible = false;
         }

         // Mostrar el contenido de la pestaña seleccionada
         contenidosPestanas[numeroPestana - 1].IsVisible = true;
     }

     // Método para generar dinámicamente los botones de las pestañas
     private void GenerarBotonesPestanas()
     {
         for (int i = 0; i < cantidad; i++)
         {
             Button button = new Button { Text = $"Pestaña {i + 1}" };
             button.Clicked += Button_Clicked;
           //  botonesContainer.Children.Add(button);

             // Crear un StackLayout para el contenido de cada pestaña
             StackLayout contenidoPestana = new StackLayout();
             contenidosPestanas.Add(contenidoPestana);

             // Agregar el contenido de la pestaña al contenedor
             //collectionViewContainer.Children.Add(contenidoPestana);
         }
     }*/







    private async void CargarPublicaciones()
    {
        listaDePublicaciones = await publicacionesDelApi();
        BindingContext = this;
    }

    private async Task<List<Publicacion>> publicacionesDelApi()
    {
        List<Publicacion> retornarPublicacionApi = new List<Publicacion>();
        String laURL = "https://localhost:44308/CommunyStoreApi/publicacion/obtenerPublicacion";

        try
        {
            ReqObtenerListaPublicaciones req = new ReqObtenerListaPublicaciones();
            req.idUsuario = SesionFrontEnd.usuarioSesion.Id;
            req.categoria = null;
            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(laURL, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    // Imprimir el contenido de la respuesta para verificar
                    Console.WriteLine(responseContent);

                    // Intenta deserializar el JSON
                    try
                    {

                        ResObtenerListaPublicaciones res = JsonConvert.DeserializeObject<ResObtenerListaPublicaciones>(responseContent);
                        if (res.resultado)
                        {

                            retornarPublicacionApi = res.publicaciones;

                        }
                        else
                        {
                            DisplayAlert("No se encontró el backend", "Error con la API", "ACEPTAR");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejar excepciones al deserializar el JSON
                        Console.WriteLine("Error al deserializar JSON: " + ex.Message);
                    }
                }
                else
                {
                    // Manejar código de estado de respuesta incorrecto
                    Console.WriteLine("Código de estado de respuesta incorrecto: " + response.StatusCode);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error interno", "ERROR CON BACKEND", "ACEPTAR");
        }


        return retornarPublicacionApi;
    }

}



