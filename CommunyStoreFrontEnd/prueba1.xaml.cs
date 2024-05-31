using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CommunyStoreFrontEnd;

public partial class prueba1 : ContentPage, INotifyPropertyChanged 
{

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


    public prueba1()
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

    

    private async void Button_Clicked_add_lista_deseos(object sender, EventArgs e)
    {
       
        var button = sender as ImageButton;
        var publication = button?.BindingContext as Publicacion;

        // Alternar el estado de IsFavorito
        publication.IsFavorito = !publication.IsFavorito;

       

        try
            {

            ReqAgregarPublicacionGuardada req = new ReqAgregarPublicacionGuardada();
            req.idPublicacion = publication.idPublicacion;
            req.idUsuario = SesionFrontEnd.usuarioSesion.Id;

            string apiEndpoint = publication.IsFavorito
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
                        string successMessage = publication.IsFavorito
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

    private void Button_Clicked_detalles(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ListaDeseos());
    }



    





}