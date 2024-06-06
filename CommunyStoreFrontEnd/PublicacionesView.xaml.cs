

using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Microsoft.Maui.Controls;


using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.FilePicker.Abstractions;
using Plugin.FilePicker;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;

using System.Xml.Linq;

namespace CommunyStoreFrontEnd;

public partial class PublicacionesView : ContentPage, INotifyPropertyChanged
{
    private int cantidad = 3; // Variable que determina la cantidad de pesta�as
    private List<Publicacion> _listaDePublicaciones = new List<Publicacion>();
    public string categoriaSeleccionada = "";
    ReqObtenerListaPublicaciones req = new ReqObtenerListaPublicaciones();

    private StackLayout _lastSelectedStack;
    private ImageButton _lastSelectedButton;


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
        categoriaSeleccionada = null;
        CargarPublicaciones();
       

    }


    public async void CargarPublicaciones()
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
           
            req.usuarioID = SesionFrontEnd.usuarioSesion.Id;
            req.categoria = categoriaSeleccionada;
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
                            DisplayAlert("No se encontr� el backend", "Error con la API", "ACEPTAR");
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
                    // Manejar c�digo de estado de respuesta incorrecto
                    Console.WriteLine("C�digo de estado de respuesta incorrecto: " + response.StatusCode);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error interno", "ERROR CON BACKEND", "ACEPTAR");
        }


        return retornarPublicacionApi;
    }

    private void Button_Clicked_view_new_publicacion(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AgregarPublicacionView());
       
        if (_lastSelectedButton != null)
        {
            _lastSelectedButton.BackgroundColor = Colors.Transparent;
        }

        var button = sender as ImageButton;
        if (button != null)
        {
            button.BackgroundColor = Colors.LightBlue;
            _lastSelectedButton = button;
        }
    }

    private void Button_Clicked_view_home(object sender, EventArgs e)
    {

        Navigation.PushAsync(new PublicacionesView());

        if (_lastSelectedButton != null)
        {
            _lastSelectedButton.BackgroundColor = Colors.LightBlue;
        }

        var button = sender as ImageButton;
        if (button != null)
        {
            button.BackgroundColor = Colors.LightBlue;
            _lastSelectedButton = button;
        }
    }

    private void Button_Clicked_view_lista_guardados(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ListaDeseos());

        if (_lastSelectedButton != null)
        {
            _lastSelectedButton.BackgroundColor = Colors.LightBlue;
        }

        var button = sender as ImageButton;
        if (button != null)
        {
            button.BackgroundColor = Colors.LightBlue;
            _lastSelectedButton = button;
        }
    }


    private void Button_Clicked_detalles(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ListaDeseos());

        if (_lastSelectedButton != null)
        {
            _lastSelectedButton.BackgroundColor = Colors.LightBlue;
        }

        var button = sender as ImageButton;
        if (button != null)
        {
            button.BackgroundColor = Colors.LightBlue;
            _lastSelectedButton = button;
        }
    }


    private async void Button_Clicked_add_lista_deseos(object sender, EventArgs e)
    {

        var button = sender as ImageButton;
        var publication = button?.BindingContext as Publicacion;

        // Alternar el estado de IsFavorito
        publication.favorito = !publication.favorito;

        try
        {

            object req;

            if (publication.favorito)
            {
                var reqAgregar = new ReqAgregarPublicacionGuardada
                {
                    idPublicacion = publication.idPublicacion,
                    idUsuario = SesionFrontEnd.usuarioSesion.Id
                };
                req = reqAgregar;
            }
            else
            {
                var reqEliminar = new ReqEliminarPublicacionGuardada
                {
                    publicacionGuardadaId = publication.idPublicacion,
                    usuarioId = SesionFrontEnd.usuarioSesion.Id
                };
                req = reqEliminar;
            }


            string apiEndpoint = publication.favorito
               ? "CommunyStoreApi/publicacion/agregarPublicacionGuardado"
               : "CommunyStoreApi/publicacion/eliminarPublicacionGuardada";

            var jsonreq = JsonSerializer.Serialize(req);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(API_LINK.link + apiEndpoint, new StringContent(jsonreq, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Convertir la respuesta a un objeto din�mico
                    dynamic jsonResponse = JObject.Parse(responseContent);

                    bool resultado = jsonResponse.resultado;
                    int tipoRegistro = jsonResponse.tipoRegistro;
                    string mensaje = jsonResponse.descripcion;

                    if (resultado)
                    {
                        CargarPublicaciones();
                        string successMessage = publication.favorito
                            ? $"La publicaci�n se ha agregado a su lista de deseos."
                            : $"La publicaci�n se ha eliminado de su lista de deseos.";
                        await DisplayAlert("Operaci�n exitosa", successMessage, "Aceptar");
                    }
                    else
                    {
                        await DisplayAlert("Error", $"{mensaje}", "Aceptar");
                    }
                }
                else
                {
                    await DisplayAlert("Problemas con la api", "Hubo un error en la comunicacion con la api", "Aceptar");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error interno", "Error en la aplicaci�n: " + ex.StackTrace.ToString(), "Aceptar");
        }

    }


    private void btn_todo_Clicked(object sender, EventArgs e)
    {
        

        categoriaSeleccionada = null;
        CargarPublicaciones();



        if (_lastSelectedStack != null)
        {
            // Reset background color of the previous selected button and label
            foreach (var child in _lastSelectedStack.Children)
            {
                if (child is ImageButton prevButton)
                {
                    prevButton.BackgroundColor = Colors.Transparent;
                }
                else if (child is Label prevLabel)
                {
                    prevLabel.TextColor = Colors.Black;
                }
            }
        }

        // Set background color of the newly selected button and label
        var button = sender as ImageButton;
        if (button != null)
        {
            var parentStack = button.Parent as StackLayout;
            if (parentStack != null)
            {
                foreach (var child in parentStack.Children)
                {
                    if (child is ImageButton selectedButton)
                    {
                        selectedButton.BackgroundColor = Colors.LightBlue;
                    }
                    else if (child is Label selectedLabel)
                    {
                        selectedLabel.TextColor = Colors.SeaGreen;
                    }
                }
                _lastSelectedStack = parentStack;
            }

        }
    }

    private void btn_tecnologia_Clicked(object sender, EventArgs e)
    {
        categoriaSeleccionada = "Tecnologia";
        CargarPublicaciones();
    if (_lastSelectedStack != null)
    {
        // Reset background color of the previous selected button and label
        foreach (var child in _lastSelectedStack.Children)
        {
            if (child is ImageButton prevButton)
            {
                prevButton.BackgroundColor = Colors.Transparent;
            }
            else if (child is Label prevLabel)
            {
                prevLabel.TextColor = Colors.Black;
            }
        }
    }

    // Set background color of the newly selected button and label
    var button = sender as ImageButton;
    if (button != null)
    {
        var parentStack = button.Parent as StackLayout;
        if (parentStack != null)
        {
            foreach (var child in parentStack.Children)
            {
                if (child is ImageButton selectedButton)
                {
                    selectedButton.BackgroundColor = Colors.LightBlue;
                }
                else if (child is Label selectedLabel)
                {
                    selectedLabel.TextColor = Colors.SeaGreen;
                }
            }
            _lastSelectedStack = parentStack;
        }
    
}
    }

    private void btn_hogar_Clicked(object sender, EventArgs e)
    {
        categoriaSeleccionada = "Hogar";
        CargarPublicaciones();

        if (_lastSelectedStack != null)
        {
            // Reset background color of the previous selected button and label
            foreach (var child in _lastSelectedStack.Children)
            {
                if (child is ImageButton prevButton)
                {
                    prevButton.BackgroundColor = Colors.Transparent;
                }
                else if (child is Label prevLabel)
                {
                    prevLabel.TextColor = Colors.Black;
                }
            }
        }

        // Set background color of the newly selected button and label
        var button = sender as ImageButton;
        if (button != null)
        {
            var parentStack = button.Parent as StackLayout;
            if (parentStack != null)
            {
                foreach (var child in parentStack.Children)
                {
                    if (child is ImageButton selectedButton)
                    {
                        selectedButton.BackgroundColor = Colors.LightBlue;
                    }
                    else if (child is Label selectedLabel)
                    {
                        selectedLabel.TextColor = Colors.SeaGreen;
                    }
                }
                _lastSelectedStack = parentStack;
            }

        }
    }

    private void btn_mascotas_Clicked(object sender, EventArgs e)
    {
        categoriaSeleccionada = "Mascotas";
        CargarPublicaciones();

        if (_lastSelectedStack != null)
        {
            // Reset background color of the previous selected button and label
            foreach (var child in _lastSelectedStack.Children)
            {
                if (child is ImageButton prevButton)
                {
                    prevButton.BackgroundColor = Colors.Transparent;
                }
                else if (child is Label prevLabel)
                {
                    prevLabel.TextColor = Colors.Black;
                }
            }
        }

        // Set background color of the newly selected button and label
        var button = sender as ImageButton;
        if (button != null)
        {
            var parentStack = button.Parent as StackLayout;
            if (parentStack != null)
            {
                foreach (var child in parentStack.Children)
                {
                    if (child is ImageButton selectedButton)
                    {
                        selectedButton.BackgroundColor = Colors.LightBlue;
                    }
                    else if (child is Label selectedLabel)
                    {
                        selectedLabel.TextColor = Colors.Blue;
                    }
                }
                _lastSelectedStack = parentStack;
            }

        }
    }

    private async void OnFrameTapped(object sender, EventArgs e)
    {
        var frame = sender as Frame;
        var publicacion = frame.BindingContext as Publicacion; // Reemplaza con tu modelo de publicaci�n
        if (publicacion != null)
        {
            // Navega a la p�gina de detalles, pasando la publicaci�n como par�metro
            await Navigation.PushAsync(new PublicacionDetalles(publicacion)); // Aseg�rate de tener una p�gina de detalles
        }
    }

    private void btnViewPerfil(object sender, TappedEventArgs e)
    {

    }
}



