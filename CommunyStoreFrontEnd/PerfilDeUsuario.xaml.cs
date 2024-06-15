using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Text;
namespace CommunyStoreFrontEnd;

public partial class PerfilDeUsuario : ContentPage, INotifyPropertyChanged
{
    // Propiedades del usuario
    private string _nombreUsuario;
    public string NombreUsuario

    {
        get { return _nombreUsuario; }
        set
        {
            _nombreUsuario = value;
            OnPropertyChanged(nameof(NombreUsuario));
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
        // Asumiendo que la sesión ya tiene los datos del usuario
        NombreUsuario = SesionFrontEnd.usuarioSesion.NombreCompleto;
        EmailUsuario = SesionFrontEnd.usuarioSesion.email;
        Direccion = SesionFrontEnd.usuarioSesion.direccion;
        Telefono = SesionFrontEnd.usuarioSesion.telefono;
        Descripcion = SesionFrontEnd.usuarioSesion.descripcion;

        BindingContext = this; // Asegúrate de establecer el BindingContext aquí o en el método CargarPublicaciones
    }

    public async void CargarPublicaciones()
    {
        listaDepublicacionPorUsuario = await publicacionesDelApi();
        BindingContext = this;
    }

    private async Task<List<Publicacion>> publicacionesDelApi()
    {
        List<Publicacion> retornarPublicacionApi = new List<Publicacion>();
        

        try
        {

            req.Id = SesionFrontEnd.usuarioSesion.Id;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/publicacion/obtenerPublicacionPorIdUsuario", jsonContent);

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
        Navigation.PushAsync(new EditarPerfil(BindingContext));
    }


    private async void Eliminar_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Título", "Eliminar", "Aceptar");

    }
    private async void Actualizar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ActualizarPublicacionUsuarioPerfil(BindingContext));

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