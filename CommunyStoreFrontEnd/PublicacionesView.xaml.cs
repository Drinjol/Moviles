

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
    private int cantidad = 3; // Variable que determina la cantidad de pestañas
    private List<Publicacion> _listaDePublicaciones = new List<Publicacion>();
    private string categoriaSeleccionada = "";
    ReqObtenerListaPublicaciones req = new ReqObtenerListaPublicaciones();


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
           
            req.idUsuario = SesionFrontEnd.usuarioSesion.Id;
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

    private void Button_Clicked_view_new_publicacion(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AgregarPublicacionView());
    }

    private void Button_Clicked_view_home(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PublicacionesView());
    }

    private void Button_Clicked_view_lista_guardados(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ListaDeseos());
    }


    private void Button_Clicked_detalles(object sender, EventArgs e)
    {
        // guardar la interaccion del usuario con la publicacion
        agregarInteraccionUsuario(1);


        Navigation.PushAsync(new ListaDeseos());
    }

    private async void agregarInteraccionUsuario(int id_publicacion)
    {
        try
        {
            ReqAgregarInteraccionUsuario req = new ReqAgregarInteraccionUsuario();
            req.id_publicacion = id_publicacion;
            req.id_usuario = SesionFrontEnd.usuarioSesion.Id;
            
            var jsonUsuario = JsonSerializer.Serialize(req);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync("https://localhost:44308/CommunyStoreApi/usuario/agregarInteraccionUsuario", new StringContent(jsonUsuario, Encoding.UTF8, "application/json"));
            
                if (response.IsSuccessStatusCode)
                {
                    //mostrar el modal con la info de la pub
                }
                else
                {
                    await DisplayAlert("Problemas con la api", "Hubo un error en la comunicacion con la api", "Aceptar");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error interno", "Error en la aplicación: " + ex.StackTrace.ToString(), "Aceptar");
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

            ReqAgregarPublicacionGuardada req = new ReqAgregarPublicacionGuardada();
            req.idPublicacion = publication.idPublicacion;
            req.idUsuario = SesionFrontEnd.usuarioSesion.Id;

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

                    // Convertir la respuesta a un objeto dinámico
                    dynamic jsonResponse = JObject.Parse(responseContent);

                    bool resultado = jsonResponse.resultado;
                    int tipoRegistro = jsonResponse.tipoRegistro;
                    string mensaje = jsonResponse.descripcion;

                    if (resultado)
                    {
                        CargarPublicaciones();
                        string successMessage = publication.favorito
                            ? $"La publicación con ID {req.idPublicacion} se ha agregado a su lista de deseos."
                            : $"La publicación con ID {req.idPublicacion} se ha eliminado de su lista de deseos.";
                        await DisplayAlert("Operación exitosa", successMessage, "Aceptar");
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
            await DisplayAlert("Error interno", "Error en la aplicación: " + ex.StackTrace.ToString(), "Aceptar");
        }

    }


    private void btn_todo_Clicked(object sender, EventArgs e)
    {
        categoriaSeleccionada = null;
        CargarPublicaciones();
    }

    private void btn_tecnologia_Clicked(object sender, EventArgs e)
    {
        categoriaSeleccionada = "Tecnologia";
        CargarPublicaciones();
    }

    private void btn_hogar_Clicked(object sender, EventArgs e)
    {
        categoriaSeleccionada = "Hogar";
        CargarPublicaciones();
    }

    private void btn_mascotas_Clicked(object sender, EventArgs e)
    {
        categoriaSeleccionada = "Mascotas";
        CargarPublicaciones();
    }
}



