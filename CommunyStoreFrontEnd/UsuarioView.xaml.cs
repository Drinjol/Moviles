using System.ComponentModel;
using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CommunyStoreFrontEnd;

public partial class UsuarioView : ContentPage, INotifyPropertyChanged
{
    int usuarioID = 0;
    Usuario usuario = new Usuario();
    private double _lastScrollPosition;

    private List<Publicacion> _listaDePublicaciones = new List<Publicacion>();
    ReqObtenerPublicacionPorUsuarioId req = new ReqObtenerPublicacionPorUsuarioId();

    public List<Publicacion> listaDePublicaciones
    {
        get { return _listaDePublicaciones; }
        set
        {
            _listaDePublicaciones = value;
            OnPropertyChanged(nameof(listaDePublicaciones));
            OnPropertyChanged(nameof(PrimeraPublicacion));
        }
    }



    public event PropertyChangedEventHandler PropertyChanged;

    public Publicacion PrimeraPublicacion => listaDePublicaciones?.FirstOrDefault();

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    public UsuarioView(int usuarioID)
	{
		InitializeComponent();
        this.usuarioID = usuarioID;
        CargarPublicaciones();
        BindingContext = usuario;

    }

    public async void CargarPublicaciones()
    {
        listaDePublicaciones = await publicacionesDelApi();
        BindingContext = this;
        
    }

    private async Task<List<Publicacion>> publicacionesDelApi()
    {

        List<Publicacion> retornarPublicacionApi = new List<Publicacion>();


        try
        {

            req.Id = this.usuarioID;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/publicacion/publicaciones_por_usuarioID", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);

                    try
                    {

                        ResObtenerPublicacionPorIdUsuario res = JsonConvert.DeserializeObject<ResObtenerPublicacionPorIdUsuario>(responseContent);
                        if (res.resultado)
                        {

                            retornarPublicacionApi = res.listaDepublicacionPorUsuario;

                            usuario = res.listaDepublicacionPorUsuario[0].usuario;


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

    private async void OnFrameTapped(object sender, EventArgs e)
    {
        var frame = sender as Frame;
        var publicacion = frame.BindingContext as Publicacion; // Reemplaza con tu modelo de publicación
        if (publicacion != null)
        {
            int idPub = publicacion.idPublicacion;
            agregarInteraccionUsuario(idPub);
            await Navigation.PushAsync(new PublicacionDetalles(publicacion));
        }
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
                var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/usuario/agregarInteraccionUsuario", new StringContent(jsonUsuario, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    //await DisplayAlert("Correcto", "Correcto", "Aceptar");

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


    private async void OnCollectionViewScrolledAsync(object sender, ItemsViewScrolledEventArgs e)
    {
        // Detectar el desplazamiento hacia abajo
        if (e.VerticalDelta > 0 && _lastScrollPosition <= e.VerticalOffset)
        {
            // Ocultar el encabezado
            await encabezadoGrid.FadeTo(2, 250);

            encabezadoGrid.IsVisible = false;
        }
        else if (e.VerticalDelta < 0 && _lastScrollPosition >= e.VerticalOffset)
        {
            // Mostrar el encabezado
            encabezadoGrid.IsVisible = true;
            await encabezadoGrid.FadeTo(2, 250);
        }

        _lastScrollPosition = e.VerticalOffset;
    }


}