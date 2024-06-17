
using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Entidades.Request;
using CommunyStoreFrontEnd.Utilitarios;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Text;
using Microsoft.AspNet.SignalR.Client;
using System.Diagnostics;
namespace CommunyStoreFrontEnd;

public partial class ListaMensajes : ContentPage, INotifyPropertyChanged
{
    private IHubProxy _hubProxy;
    private HubConnection _hubConnection;
    private bool isFirstLoad = true;
    private int iDChatGlobal = 0;
    private List<Mensaje> _listaDeMensajes = new List<Mensaje>();
    private bool _isLoading = false;

    public bool IsLoading
    {
        get { return _isLoading; }
        set
        {
            _isLoading = value;
            OnPropertyChanged(nameof(IsLoading));
        }
    }

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

    public ListaMensajes(int Idchat)
    {
        InitializeComponent();
        BindingContext = this;
        iDChatGlobal = Idchat;
        InitializeSignalR();
        CargarMensajes(Idchat);
    }


    private void InitializeSignalR()
    {
        _hubConnection = new HubConnection("https://communystoreapi20240614184128.azurewebsites.net/signalr");
        _hubProxy = _hubConnection.CreateHubProxy("ChatHub");

        _hubProxy.On<string, string>("ReceiveMessage", (user, message) =>
        {
            RecargarMensajesDespuesDeEnviar();
        });

        _hubConnection.Start().Wait(); // Inicia la conexión SignalR
    }


    private async void CargarMensajes(int Idchat)
    {
        IsLoading = true;
        listaDeMensajes = await MensajesDelAPI(Idchat);
        IsLoading = false;

        // Realizar el scroll al final solo la primera vez que se carga la vista
        if (isFirstLoad)
        {
            ScrollToEnd(false);
            isFirstLoad = false;
        }
    }

    private async Task<List<Mensaje>> MensajesDelAPI(int Idchat)
    {
        List<Mensaje> retornarMensajesApi = new List<Mensaje>();

        try
        {
            ReqObtenerMensajes req = new ReqObtenerMensajes();
            req.idChat = Idchat;
            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/chats/obtenerMensajesConIdChat", jsonContent);

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
            var nuevoMensaje = new Mensaje
            {
                contenido = entryMensaje.Text,
                idUsuario = SesionFrontEnd.usuarioSesion.Id,
                idchat = iDChatGlobal
            };

            entryMensaje.Text = string.Empty;

            var req = new ReqIngresarMensaje { mensaje = nuevoMensaje };

            await IngresarMensajeBd(req);

            try
            {
                // Enviar mensaje a través de SignalR usando el mismo _hubProxy creado durante la inicialización
                await _hubProxy.Invoke("SendMessage", SesionFrontEnd.usuarioSesion.Id.ToString(), nuevoMensaje.contenido);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar mensaje a través de SignalR: {ex.Message}");
            }
        }
    }


    private async Task RecargarMensajesDespuesDeEnviar()
    {
        listaDeMensajes = await MensajesDelAPI(iDChatGlobal);
        OnPropertyChanged(nameof(listaDeMensajes));
        ScrollToNewMessage(false); // Sin animación visible
    }

    public async Task IngresarMensajeBd(ReqIngresarMensaje req)
    {
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
                var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/chats/ingresarMensaje", jsonMensaje);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    dynamic jsonResponse = JObject.Parse(responseContent);

                    ResIngresarMensaje res = new ResIngresarMensaje
                    {
                        resultado = jsonResponse.resultado,
                        tipoRegistro = jsonResponse.tipoRegistro
                    };

                    if (res.resultado && res.tipoRegistro == 1)
                    {
                        Console.WriteLine("Mensaje enviado con éxito.");
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

    private void ScrollToEnd(bool animate)
    {
        // Asegurarse de que el collectionView y la lista de mensajes no sean nulos
        if (collectionView == null || listaDeMensajes == null)
        {
            return;
        }

        // Asegurarse de que la lista de mensajes tenga al menos un mensaje
        if (listaDeMensajes.Count > 0)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(100); // Pequeño retraso para asegurar que los mensajes se carguen completamente

                // Verificar si hay suficientes mensajes para que el scroll tenga sentido
                if (listaDeMensajes.Count > 8) // Ajusta este valor según sea necesario
                {
                    collectionView.ScrollTo(listaDeMensajes[^1], position: ScrollToPosition.End, animate: animate);
                }
            });
        }
    }



    private void ScrollToNewMessage(bool animate)
    {
        if (listaDeMensajes != null && listaDeMensajes.Count > 0)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(100); // Pequeño retraso para asegurar que los mensajes se carguen completamente
                collectionView.ScrollTo(listaDeMensajes[^1], position: ScrollToPosition.MakeVisible, animate: animate);
            });
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Recargar los mensajes cada vez que la página aparece
        CargarMensajes(iDChatGlobal);
    }
}