using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Diagnostics;


namespace CommunyStoreFrontEnd;

public partial class AgregarPublicacionView : ContentPage
{

    private string _selectedFile;

    static string[] Scopes = { DriveService.Scope.DriveFile };
    static string ApplicationName = "Google Drive API .NET MAUI";

    // ID de la carpeta "ImagenesSarapiquiEmprende"
    static string FolderId = "1r7A7hITGX4WjarcooONMt4qPHKjxRhLU";


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
                req.publicacion.nombresArchivos = _selectedFile;
                // await DisplayAlert("prueba imagen", _selectedFile, "aceptar");
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
                PickerTitle = "Seleccione un archivo",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                // _selectedFile = result; // Almacenar el archivo seleccionado

                var service = await GetDriveService();
                if (service != null)
                {
                    // Subir el archivo seleccionado a la carpeta "ImagenesSarapiquiEmprende"
                    var fileId = await UploadFile(service, result.FileName, result.FullPath, FolderId);

                    if (fileId != null)
                    {
                        // Obtener la URL de descarga del archivo
                        var fileUrl = await GetFileUrl(service, fileId);
                        if (!string.IsNullOrEmpty(fileUrl))
                        {
                            var stream = await result.OpenReadAsync();
                            var image = ImageSource.FromStream(() => stream);
                            UploadedImage.Source = image;
                            _selectedFile = fileUrl; // Almacenar la URL del archivo en _selectedFile
                                                     // await DisplayAlert("Resultado", $"El archivo se ha subido correctamente. URL: {fileUrl}", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Error", "No se pudo obtener la URL del archivo.", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo subir el archivo.", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo obtener el servicio de Google Drive.", "OK");
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exception, e.g., user canceled the picker
            Console.WriteLine(ex.Message);
        }
    }


    private async Task<DriveService> GetDriveService()
    {
        try
        {
            UserCredential credential;

            // Obtener la ruta al archivo de credenciales dentro del directorio de datos de la aplicación
            string credPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "credentials.json");

            // Obtener la ruta al directorio donde se encuentra el ejecutable de la aplicación
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Construir la ruta completa al archivo credentials.json dentro del proyecto
            string filePath = Path.Combine(baseDirectory, "Resources", "Raw", "credentials.json");

            // Copiar el archivo de recursos al directorio de datos de la aplicación, si aún no existe
            if (!File.Exists(credPath))
            {
                File.Copy(filePath, credPath);
            }

            // Autorizar al usuario
            using (var stream = new FileStream(credPath, FileMode.Open, FileAccess.Read))
            {
                string tokenPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "token.json");
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    System.Threading.CancellationToken.None,
                    new FileDataStore(tokenPath, true));
            }

            // Crear el servicio de Google Drive
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error al obtener el servicio de Google Drive: {ex.Message}", "OK");
            return null;
        }
    }


    static async Task<string> UploadFile(DriveService service, string fileName, string filePath, string folderId)
    {
        try
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = fileName,
                Parents = new[] { folderId } // Especificar la carpeta en la que se debe subir el archivo
            };

            FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                request = service.Files.Create(fileMetadata, stream, "image/jpeg");
                request.Fields = "id";
                var response = await request.UploadAsync();
                return request.ResponseBody?.Id;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error", $"Error al subir el archivo a Google Drive: {ex.Message}", "OK");
            return null;
        }
    }

    static async Task<string> GetFileUrl(DriveService service, string fileId)
    {
        try
        {
            // Crear una solicitud para obtener los metadatos del archivo
            var getRequest = service.Files.Get(fileId);
            getRequest.Fields = "webContentLink"; // Solicitar solo el enlace de contenido web

            // Ejecutar la solicitud para obtener los metadatos del archivo
            var file = await getRequest.ExecuteAsync();

            // Obtener el enlace de contenido web del archivo
            var webContentLink = file.WebContentLink;

            // Si el enlace de contenido web está disponible, devolverlo
            if (!string.IsNullOrEmpty(webContentLink))
            {
                return webContentLink;
            }
            else
            {
                Console.WriteLine("El enlace de contenido web del archivo está vacío.");
                return null;
            }


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener la URL del archivo: {ex.Message}");
            return null;
        }
    }










}