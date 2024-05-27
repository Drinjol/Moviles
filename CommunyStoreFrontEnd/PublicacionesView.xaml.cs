

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
    }

    private void Button_Clicked_view_home(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PublicacionesView());
    }

    private void Button_Clicked_view_lista_guardados(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ListaDeseos());
    }

    


    private async void Button_Clicked_add_lista_deseos(object sender, EventArgs e)
    {

        Button button = (Button)sender; // Cast the sender to Button
        Publicacion publication = (Publicacion)button.CommandParameter; // Get the publication data item

        try
        {

            ReqAgregarPublicacionGuardada req = new ReqAgregarPublicacionGuardada();
            req.idPublicacion = publication.idPublicacion;
            req.idUsuario = SesionFrontEnd.usuarioSesion.Id;

            var jsonreq = JsonSerializer.Serialize(req);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/publicacion/agregarPublicacionGuardado", new StringContent(jsonreq, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Convertir la respuesta a un objeto din�mico
                    dynamic jsonResponse = JObject.Parse(responseContent);

                    bool resultado = jsonResponse.resultado;
                    int tipoRegistro = jsonResponse.tipoRegistro;
                    string mensaje = jsonResponse.descripcion;

                    if (tipoRegistro == 1)
                    {
                        await DisplayAlert("�Publicaci�n agregada!", $"{mensaje}", "Aceptar");

                    }
                    else if (tipoRegistro == 2)
                    {

                        await DisplayAlert("Registro fallido!", "Error de logica!", "Aceptar");
                    }
                    else if (tipoRegistro == 3)
                    {
                        await DisplayAlert("Registro fallido!", "Error de datos", "Aceptar");

                    }
                    else if (tipoRegistro == 4)
                    {
                        await DisplayAlert("Registro fallido!", "Error no controlado!", "Aceptar");

                    }

                    if (resultado)
                    {
                        await DisplayAlert("�Publicaci�n agregada!", $"La publicaci�n con ID {req.idPublicacion} se ha agregado a su lista de deseos.", "Aceptar");


                    }
                    else
                    {
                        // Manejar errores
                        //  string errores = string.Join(", ", listaDeErrores);
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

    


}



