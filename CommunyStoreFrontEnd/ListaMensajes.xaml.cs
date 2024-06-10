using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Entidades.Request;
using CommunyStoreFrontEnd.Utilitarios;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Text;

namespace CommunyStoreFrontEnd;

public partial class ListaMensajes : ContentPage, INotifyPropertyChanged
{
    private int iDChatGlobal = 0;
    private List<Mensaje> _listaDeMensajes = new List<Mensaje>();

    // Refresca los componentes una vez se pintan en la vista
    #region refrezcarCompomentes
    public List<Mensaje> listaDeMensajes
    {
        get { return _listaDeMensajes; }
        set
        {
            _listaDeMensajes = value;
            OnPropertyChanged(nameof(listaDeMensajes));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

    public ListaMensajes(int Idchat)
    {
        InitializeComponent();
        BindingContext = this;
        iDChatGlobal = Idchat;
        CargarMensajes(Idchat);
    }

    private async void CargarMensajes(int Idchat)
    {
        listaDeMensajes = await MensajesDelAPI(Idchat);
    }

    private async Task<List<Mensaje>> MensajesDelAPI(int Idchat)
    {
        List<Mensaje> retornarMensajesApi = new List<Mensaje>();
        String laURL = "https://localhost:44308/CommunyStoreApi/chats/obtenerMensajesConIdChat";

        try
        {
            ReqObtenerMensajes req = new ReqObtenerMensajes();
            req.idChat = Idchat;
            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(laURL, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    ResObtenerMensajes res = JsonConvert.DeserializeObject<ResObtenerMensajes>(responseContent);

                    if (res.resultado)
                    {
                        retornarMensajesApi = res.mensajes;
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el API");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error interno: " + ex.Message);
        }

        return retornarMensajesApi;
    }

    private async void OnEnviarMensajeClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(entryMensaje.Text))
        {
            ReqIngresarMensaje req = new ReqIngresarMensaje
            {
                mensaje = new Mensaje
                {
                    contenido = entryMensaje.Text,
                    idUsuario = SesionFrontEnd.usuarioSesion.Id,
                    idchat = iDChatGlobal
                }
            };

            entryMensaje.Text = string.Empty;

            await IngresarMensajeBd(req);

            // Recargar los mensajes después de enviar uno nuevo
            CargarMensajes(iDChatGlobal);
        }
    }

    public async Task IngresarMensajeBd(ReqIngresarMensaje req)
    {
        String laURL = "https://localhost:44308/CommunyStoreApi/chats/ingresarMensaje";

        try
        {
            if (string.IsNullOrWhiteSpace(req.mensaje.contenido))
            {
                await DisplayAlert("Mensaje vacío", "Imposible enviar mensajes vacíos", "Aceptar");
                return;
            }

            var jsonMensaje = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(laURL, jsonMensaje);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Response Content: {responseContent}"); // Debugging: Print the response content

                    dynamic jsonResponse = JObject.Parse(responseContent);

                    ResIngresarMensaje res = new ResIngresarMensaje
                    {
                        resultado = jsonResponse.resultado,
                        tipoRegistro = jsonResponse.tipoRegistro
                    };

                    if (res.resultado && res.tipoRegistro == 1)
                    {
                        // Mensaje enviado con éxito
                        Console.WriteLine("Mensaje enviado con éxito."); // Debugging: Success message
                    }
                    else
                    {
                        string errorMessage = res.tipoRegistro switch
                        {
                            2 => "Error de lógica!",
                            3 => "Error de datos",
                            4 => "Error no controlado!",
                            _ => "Error desconocido"
                        };
                       // await DisplayAlert("Envio fallido!", errorMessage, "Aceptar");
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


    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Recargar los mensajes cada vez que la página aparece
        CargarMensajes(iDChatGlobal);
    }
}