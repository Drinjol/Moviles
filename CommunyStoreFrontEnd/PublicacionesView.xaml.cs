

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

namespace CommunyStoreFrontEnd;

public partial class PublicacionesView : Shell, INotifyPropertyChanged
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

   







    private async void CargarPublicaciones()
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

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
         DisplayAlert("Men�", "Implementa tu l�gica de men� aqu�", "Aceptar");
    }


    private async void Mensajes_Clicked(object sender, EventArgs e)
    {
        // Implementa lo que quieras que haga el bot�n de Mensajes
    }

    private async void NuevaPublicacion_Clicked(object sender, EventArgs e)
    {
        // Implementa lo que quieras que haga el bot�n de Nueva Publicaci�n
    }

    private async void Perfil_Clicked(object sender, EventArgs e)
    {
        // Implementa lo que quieras que haga el bot�n de Perfil
    }

    private async void CerrarSesion_Clicked(object sender, EventArgs e)
    {
        // Implementa lo que quieras que haga el bot�n de Cerrar Sesi�n
    }

   

    private async void btnRegistrarPublicacion_Clicked(object sender, EventArgs e)
    {
        String laURL = "https://localhost:44308/CommunyStoreApi/publicacion/ingresarPublicacion";
        try
        {
            if (string.IsNullOrWhiteSpace(entryDescripcion.Text) ||
                string.IsNullOrWhiteSpace(entryPrecio.Text) ||
                string.IsNullOrWhiteSpace(entryCategoria.Text))
            {
                await DisplayAlert("Campos vac�os", "Por favor, complete todos los campos.", "Aceptar");
                return; // Detener la ejecuci�n del m�todo si hay campos vac�os
            }

          ReqIngresarPublicacion req = new ReqIngresarPublicacion();
           
           
            req.publicacion = new Publicacion();
            req.publicacion.descripcionPublicacion = entryDescripcion.Text;
            req.publicacion.precioPublicacion = decimal.Parse(entryPrecio.Text);
            req.publicacion.categoriaPublicacion = entryCategoria.Text;
            req.publicacion.nombresArchivos = image1.ToString();
            req.publicacion.usuario = SesionFrontEnd.usuarioSesion;
            
            //  req.publicacion.nombresArchivos = entryIam


            var jsonPublicacion = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");



            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(laURL, jsonPublicacion);
               

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Convertir la respuesta a un objeto din�mico
                    dynamic jsonResponse = JObject.Parse(responseContent);

                    ResIngresarPublicacion res = new ResIngresarPublicacion();
                    res.resultado = jsonResponse.resultado;
                    res.tipoRegistro = jsonResponse.tipoRegistro;
                     //JArray listaDeErrores = jsonResponse.listaDeErrores;

                    if (res.tipoRegistro == 1 && res.resultado)
                    {
                        await DisplayAlert("Registro exitoso!", "Tu publicaci�n ha sido registrada exitosamente!", "Aceptar");

                       await Navigation.PushAsync(new PublicacionesView()); // Agrega una nueva instancia de PublicacionesView
                    }
                    else if (res.tipoRegistro == 2)
                    {

                        await DisplayAlert("Registro fallido!", "Error de logica!", "Aceptar");
                    }
                    else if (res.tipoRegistro == 3)
                    {
                        await DisplayAlert("Registro fallido!", "Error de datos", "Aceptar");

                    }
                    else if (res.tipoRegistro == 4)
                    {
                        await DisplayAlert("Registro fallido!", "Error no controlado!", "Aceptar");

                    }

                  
                }
                else
                {
                    await DisplayAlert("Problemas con la api", "Hubo un error en la comunicacion con la api", "Aceptar");
                }
            }
            // Continuar con el proceso de subir las im�genes
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error interno", "Error en la aplicaci�n: " + ex.StackTrace.ToString(), "Aceptar");
        }

    }



  

}



