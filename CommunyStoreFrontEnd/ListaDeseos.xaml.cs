using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Entidades.Response;
using CommunyStoreFrontEnd.Utilitarios;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Text;

namespace CommunyStoreFrontEnd;

public partial class ListaDeseos : ContentPage, INotifyPropertyChanged
{

    private List<PublicacionGuardada> _listaPublicacionesGuardadas = new List<PublicacionGuardada>();

    public List<PublicacionGuardada> listaDePublicacionesGuardadas
    {
        get { return _listaPublicacionesGuardadas; }
        set
        {
            _listaPublicacionesGuardadas = value;
            OnPropertyChanged(nameof(listaDePublicacionesGuardadas));
        }
    }



    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    public ListaDeseos()
	{
		InitializeComponent();
        CargarPublicaciones();

    }


    public async void CargarPublicaciones()
    {
        listaDePublicacionesGuardadas = await publicacionesGuardadasDelApi();
        BindingContext = this;
    }

    private async Task<List<PublicacionGuardada>> publicacionesGuardadasDelApi()
    {
        List<PublicacionGuardada> retornarPublicacionGuardadasApi = new List<PublicacionGuardada>();
        

        try
        {
            
            ReqObtenerPublicacionesGuardadas req = new ReqObtenerPublicacionesGuardadas();

            req.usuarioid = SesionFrontEnd.usuarioSesion.Id;
            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/publicacion/obtenerPublicacionGuardadas", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    // Imprimir el contenido de la respuesta para verificar
                    Console.WriteLine(responseContent);

                    // Intenta deserializar el JSON
                    try
                    {

                        ResObtenerPublicacionesGuardadas res = JsonConvert.DeserializeObject<ResObtenerPublicacionesGuardadas>(responseContent);
                        if (res.resultado)
                        {


                            retornarPublicacionGuardadasApi = res.listaPublicacionGuardada;

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


        return retornarPublicacionGuardadasApi;
    }

    private async void Button_Clicked_delete_publicacion_guardadaAsync(object sender, EventArgs e)
    {

        Button button = (Button)sender; // Cast the sender to Button
        PublicacionGuardada publication = (PublicacionGuardada)button.CommandParameter;
        
        try
        {

            ReqEliminarPublicacionGuardada req = new ReqEliminarPublicacionGuardada();

            req.usuarioId = SesionFrontEnd.usuarioSesion.Id;
            req.publicacionGuardadaId = publication.publicacion.idPublicacion;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/publicacion/eliminarPublicacionGuardada", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    // Imprimir el contenido de la respuesta para verificar
                    Console.WriteLine(responseContent);

                    // Intenta deserializar el JSON
                    try
                    {

                        ResEliminarPublicacionGuardada res = JsonConvert.DeserializeObject<ResEliminarPublicacionGuardada>(responseContent);
                        if (res.resultado)
                        {


                            res.resultado = true;
                            await DisplayAlert("¡Publicación eliminada de la lista!", $"La publicación con ID {publication.publicacion.idPublicacion} se ha eliminado.", "Aceptar");
                            CargarPublicaciones();
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

    }

    private void Button_Clicked_contactar_usuario(object sender, EventArgs e)
    {

        var button = sender as Button;
        if (button != null)
        {
            var publicGuardada = button.CommandParameter as PublicacionGuardada; // Asegúrate de tener el modelo Publicacion correctamente definido
            var publicacion = publicGuardada.publicacion;
            if (publicacion != null)
            {

                    // Lógica para manejar la creación del chat con la información de la publicación
                    CrearChatConPublicacion(publicacion);
                
            }
        }

    }


    private async void CrearChatConPublicacion(Publicacion publicacion)
    {

        bool answer = await DisplayAlert("Confirmar", "¿Desea crear un chat con la información de esta publicación?", "Sí", "No");
        if (answer)
        {

            // Lógica para manejar la creación del chat con la información de la publicación

            String laURL = "https://localhost:44308/CommunyStoreApi/chats/crearChat";

            try
            {
                ReqCrearChat req = new ReqCrearChat();
                req.idUsuario1 = SesionFrontEnd.usuarioSesion.Id;
                req.idUsuario2 = publicacion.usuario?.Id ?? 0;

                if (req.idUsuario1 == req.idUsuario2)
                {
                    await DisplayAlert("Error", "No se puede contactar a uno mismo", "Aceptar");
                    return;
                }

                var jsonchat = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsync(laURL, jsonchat);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Response Content: {responseContent}"); // Debugging: Print the response content

                        dynamic jsonResponse = JObject.Parse(responseContent);

                        ResCrearChat res = new ResCrearChat
                        {
                            resultado = jsonResponse.resultado,
                            tipoRegistro = jsonResponse.tipoRegistro,
                            idChat = jsonResponse.idChat,
                        };

                        if (res.resultado)
                        {








                            String laURL2 = "https://localhost:44308/CommunyStoreApi/chats/ingresarMensaje";

                            try
                            {
                                ReqIngresarMensaje req2 = new ReqIngresarMensaje();
                                string desc = publicacion.descripcionPublicacion;

                                string price = publicacion.precioPublicacion.ToString() ?? "0.00"; // Manejar el null para precioPublicacion

                                req2.mensaje = new Mensaje
                                {
                                    contenido = desc + Environment.NewLine + price,
                                    idchat = res.idChat,
                                    idUsuario = SesionFrontEnd.usuarioSesion.Id
                                };
                                var jsonMensaje = new StringContent(JsonConvert.SerializeObject(req2), Encoding.UTF8, "application/json");

                                using (var httpClient2 = new HttpClient())
                                {
                                    var response2 = await httpClient2.PostAsync(laURL2, jsonMensaje);

                                    if (response.IsSuccessStatusCode)
                                    {
                                        var responseContent2 = await response2.Content.ReadAsStringAsync();
                                        Console.WriteLine($"Response Content: {responseContent2}"); // Debugging: Print the response content

                                        dynamic jsonResponse2 = JObject.Parse(responseContent2);

                                        ResIngresarMensaje res2 = new ResIngresarMensaje
                                        {
                                            resultado = jsonResponse.resultado,
                                            tipoRegistro = jsonResponse.tipoRegistro
                                        };

                                        if (res2.resultado)
                                        {


                                            // Mensaje enviado con éxito
                                            //Console.WriteLine("Mensaje enviado con éxito."); // Debugging: Success message
                                            Navigation.PushAsync(new ListaMensajes(res.idChat));
                                        }
                                        else
                                        {
                                            string errorMessage = res2.tipoRegistro switch
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
                        else
                        {
                          
                             await DisplayAlert("Error de chat", "Ha ocurrido un error al crear la conversación", "Aceptar");
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


       
        // Ejemplo: Navigation.PushAsync(new ChatPage(publicacion));
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


    private void btnMensajes_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ChatsList());

    }


}