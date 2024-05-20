using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace CommunyStoreFrontEnd;

public partial class AgregarPublicacionView : ContentPage
{

    private FileResult _selectedFile;



    public AgregarPublicacionView()
	{
		InitializeComponent();
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
                await DisplayAlert("Campos vacíos", "Por favor, complete todos los campos.", "Aceptar");
                return; // Detener la ejecución del método si hay campos vacíos
            }

            ReqIngresarPublicacion req = new ReqIngresarPublicacion();


            req.publicacion = new Publicacion();
            req.publicacion.descripcionPublicacion = entryDescripcion.Text;
            req.publicacion.precioPublicacion = decimal.Parse(entryPrecio.Text);
            req.publicacion.categoriaPublicacion = entryCategoria.Text;
           
            req.publicacion.usuario = SesionFrontEnd.usuarioSesion;

            if (_selectedFile != null)
            {
                req.publicacion.nombresArchivos = _selectedFile.FullPath;
            }
            else
            {
                req.publicacion.nombresArchivos = string.Empty;
            }

            //  req.publicacion.nombresArchivos = entryIam


            var jsonPublicacion = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");



            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(laURL, jsonPublicacion);


                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Convertir la respuesta a un objeto dinámico
                    dynamic jsonResponse = JObject.Parse(responseContent);

                    ResIngresarPublicacion res = new ResIngresarPublicacion();
                    res.resultado = jsonResponse.resultado;
                    res.tipoRegistro = jsonResponse.tipoRegistro;
                    //JArray listaDeErrores = jsonResponse.listaDeErrores;

                    if (res.tipoRegistro == 1 && res.resultado)
                    {
                        await DisplayAlert("Registro exitoso!", "Tu publicación ha sido registrada exitosamente!", "Aceptar");

                        await Navigation.PushAsync(new PublicacionesView()); // Agrega una nueva instancia de PublicacionesView
                        PublicacionesView p = new PublicacionesView();
                        p.CargarPublicaciones();
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
            // Continuar con el proceso de subir las imágenes
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error interno", "Error en la aplicación: " + ex.StackTrace.ToString(), "Aceptar");
        }

    }

    private void Button_Clicked_view_new_publicacion(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AgregarPublicacionView());
    }

    private void Button_Clicked_view_home(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PublicacionesView());
    }

    private async void OnUploadImageClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Please select an image file",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                _selectedFile = result; // Almacenar el archivo seleccionado

                var stream = await result.OpenReadAsync();
                var image = ImageSource.FromStream(() => stream);
                UploadedImage.Source = image;
            }
        }
        catch (Exception ex)
        {
            // Handle exception, e.g., user canceled the picker
            Console.WriteLine(ex.Message);
        }
    }

  


}