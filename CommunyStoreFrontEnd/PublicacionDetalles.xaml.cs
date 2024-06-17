using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CommunyStoreFrontEnd;

public partial class PublicacionDetalles : ContentPage
{
	public PublicacionDetalles(Publicacion publicacion)
	{
		InitializeComponent();
        BindingContext = publicacion;
    }



    private async void Button_Clicked_add_lista_deseos(object sender, EventArgs e)
    {

        var button = sender as Button;
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

                    // Convertir la respuesta a un objeto dinámico
                    dynamic jsonResponse = JObject.Parse(responseContent);

                    bool resultado = jsonResponse.resultado;
                    int tipoRegistro = jsonResponse.tipoRegistro;
                    string mensaje = jsonResponse.descripcion;

                    if (resultado)
                    {
                        //CargarPublicaciones();
                        string successMessage = publication.favorito
                            ? $"La publicación se ha agregado a su lista de deseos."
                            : $"La publicación se ha eliminado de su lista de deseos.";
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


    private void Button_Clicked_contactar_usuario(object sender, EventArgs e)
    {

        var button = sender as Button;
        if (button != null)
        {
            var publicacion = button.CommandParameter as Publicacion; // Asegúrate de tener el modelo Publicacion correctamente definido           
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
                    var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/chats/crearChat", jsonchat);

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

                            try
                            {
                                ReqIngresarMensaje req2 = new ReqIngresarMensaje();
                                string desc = publicacion.descripcionPublicacion;
                                string urlImg = publicacion.nombresArchivos;
                                string price = publicacion.precioPublicacion.ToString() ?? "0.00"; // Manejar el null para precioPublicacion

                                req2.mensaje = new Mensaje
                                {
                                    contenido = desc + Environment.NewLine + price,
                                    idchat = res.idChat,
                                    idUsuario = SesionFrontEnd.usuarioSesion.Id,
                                     URLimg = urlImg
                                };
                                var jsonMensaje = new StringContent(JsonConvert.SerializeObject(req2), Encoding.UTF8, "application/json");

                                using (var httpClient2 = new HttpClient())
                                {
                                    var response2 = await httpClient2.PostAsync(API_LINK.link + "CommunyStoreApi/chats/ingresarMensaje", jsonMensaje);

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
    }


    private void Button_informacion_anunciante(object sender, EventArgs e)
    {

        var button = sender as Button;
        if (button != null)
        {
            var publicacion = button.CommandParameter as Publicacion; // Asegúrate de tener el modelo Publicacion correctamente definido           
            if (publicacion != null)
            {
                int usuarioID = publicacion.usuario.Id;

                // Lógica para manejar la creación del chat con la información de la publicación
                Navigation.PushAsync(new UsuarioView(usuarioID));

            }
        }

        

        
    }






}