using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;

using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Text;
namespace CommunyStoreFrontEnd;
using JsonSerializer = System.Text.Json.JsonSerializer;

public partial class PerfilDeUsuario : ContentPage, INotifyPropertyChanged
{
    // Propiedades del usuario
    private string _nombre;
    public string Nombre

    {
        get { return _nombre; }
        set
        {
            _nombre = value;
            OnPropertyChanged(nameof(Nombre));
        }
    }

    private string _emailUsuario;
    public string EmailUsuario
    {
        get { return _emailUsuario; }
        set
        {
            _emailUsuario = value;
            OnPropertyChanged(nameof(EmailUsuario));
        }
    }

    public string _direccion;
    public string Direccion
    {
        get { return _direccion; }
        set
        {
            _direccion = value;
            OnPropertyChanged(nameof(Direccion));
        }

    }
    public string _telefono;
    public string Telefono
    {
        get { return _telefono; }
        set
        {
            _telefono = value;
            OnPropertyChanged(nameof(Telefono));
        }

    }
    public string _archivos;
    public string Archivos
    {
        get { return _archivos; }
        set
        {
            _archivos = value;
            OnPropertyChanged(nameof(Archivos));
        }

    }

    public string _Descripcion;
    public string Descripcion
    {
        get { return _Descripcion; }
        set
        {
            _Descripcion = value;
            OnPropertyChanged(nameof(Descripcion));
        }

    }
    private string password;
    public string Password
    {
        get => password;
        set
        {
            if (password != value)
            {
                password = value;
                OnPropertyChanged();
            }
        }
    }
    private string apellidos;
    public string Apellidos
    {
        get => apellidos;
        set
        {
            if (apellidos != value)
            {
                apellidos = value;
                OnPropertyChanged();
            }
        }
    }

    private List<Publicacion> _listaDepublicacionPorUsuario = new List<Publicacion>();

    ReqObtenerPublicacionPorUsuarioId req = new ReqObtenerPublicacionPorUsuarioId();
    public string categoriaSeleccionada = "";
    private StackLayout _lastSelectedStack;
    private ImageButton _lastSelectedButton;

    public List<Publicacion> listaDepublicacionPorUsuario
    {
        get { return _listaDepublicacionPorUsuario; }
        set
        {
            _listaDepublicacionPorUsuario = value;
            OnPropertyChanged(nameof(listaDepublicacionPorUsuario));
        }
    }



    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public PerfilDeUsuario()
    {
        InitializeComponent();
        CargarDatosUsuario();
        CargarPublicaciones();

    }

    private void CargarDatosUsuario()
    {

        Nombre = SesionFrontEnd.usuarioSesion.nombre;
        EmailUsuario = SesionFrontEnd.usuarioSesion.email;
        Direccion = SesionFrontEnd.usuarioSesion.direccion;
        Telefono = SesionFrontEnd.usuarioSesion.telefono;
        Descripcion = SesionFrontEnd.usuarioSesion.descripcion;
        password = SesionFrontEnd.usuarioSesion.password;
        Apellidos =SesionFrontEnd.usuarioSesion.apellidos;

        BindingContext = this;
    }

    public async void CargarPublicaciones()
    {
        listaDepublicacionPorUsuario = await publicacionesDelApi();
        BindingContext = this;
    }

    private async Task<List<Publicacion>> publicacionesDelApi()
    {
        List<Publicacion> retornarPublicacionApi = new List<Publicacion>();
        String laURL = "CommunyStoreApi/publicacion/obtenerPublicacionPorIdUsuario";

        try
        {

            req.Id = SesionFrontEnd.usuarioSesion.Id;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(API_LINK.link+laURL, jsonContent);

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
    private void EditarPerfil_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditarPerfil(this));
    }


    private async void Eliminar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var publicationId = button?.CommandParameter as int?;

        if (publicationId.HasValue)
        {
            bool confirmed = await DisplayAlert("Confirmación", "¿Está seguro de que desea eliminar esta publicación?", "Sí", "No");
            if (confirmed)
            {
                try
                {
                    var reqEliminar = new ReqEliminarPublicacion
                    {
                        Id = publicationId.Value,
                        usuarioid = SesionFrontEnd.usuarioSesion.Id
                    };
                    var jsonreq = JsonSerializer.Serialize(reqEliminar);

                    using (var httpClient = new HttpClient())
                    {
                        var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/publicacion/eliminarPublicacion", new StringContent(jsonreq, Encoding.UTF8, "application/json"));

                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();

                            // Convertir la respuesta a un objeto dinámico
                            dynamic jsonResponse = JObject.Parse(responseContent);

                            bool resultado = jsonResponse.resultado;
                            string mensaje = jsonResponse.descripcion;

                            if (resultado)
                            {
                                CargarPublicaciones();
                            }
                            else
                            {
                                await DisplayAlert("Error", $"{mensaje}", "Aceptar");
                            }
                        }
                        else
                        {
                            await DisplayAlert("Problemas con la API", "Hubo un error en la comunicación con la API", "Aceptar");
                        }
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error interno", "Error en la aplicación: " + ex.StackTrace, "Aceptar");
                }
            }
        }
        else
        {
            await DisplayAlert("Error", "No se pudo obtener el ID de la publicación.", "OK");
        }
        
    }

    private void Actualizar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button != null)
        {
            var publicacion = button.BindingContext as Publicacion;
            if (publicacion != null)
            {
                Navigation.PushAsync(new ActualizarPublicacionUsuarioPerfil(
                    publicacion.idPublicacion,
                    publicacion.descripcionPublicacion,
                  
                    publicacion.categoriaPublicacion,
                    publicacion.precioPublicacion
                ));
            }
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




}