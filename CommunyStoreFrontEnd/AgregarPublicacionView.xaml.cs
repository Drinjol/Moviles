
using Firebase.Storage;
using CommunyStoreFrontEnd.Entidades;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using CommunyStoreFrontEnd.Utilitarios;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace CommunyStoreFrontEnd
{
    public partial class AgregarPublicacionView : ContentPage
    {
        private string _selectedFile;

        // Configuración de Firebase
        private readonly string _apiKey = "AIzaSyDaxNrlp3WKUNM6bbw9D3inp4zh7JmgS1c";
        private readonly string _authDomain = "api-imagenes-moviles.firebaseapp.com";
        private readonly string _projectId = "api-imagenes-moviles";
        private readonly string _storageBucket = "api-imagenes-moviles.appspot.com";
        private readonly string _messagingSenderId = "783078696326";
        private readonly string _appId = "1:783078696326:web:614274ac450f0c83373807";

        public AgregarPublicacionView()
        {
            InitializeComponent();
        }

     

        private async void OnUploadImageClicked(object sender, EventArgs e)
        {
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;
            try
            {
                
                // Capturar una foto usando MediaPicker
                var result = await MediaPicker.PickPhotoAsync();
                

                if (result != null)
                {
                    using (var stream = await result.OpenReadAsync())
                    {
                        var firebaseUrl = await UploadFileToFirebaseStorage(stream, result.FileName);
                        if (!string.IsNullOrEmpty(firebaseUrl))
                        {
                            
                        
                            UploadedImage.Source = firebaseUrl;
                            _selectedFile = firebaseUrl;

                          //  await DisplayAlert("Éxito", "Archivo subido correctamente a Firebase Storage.", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Error", "No se pudo subir el archivo a Firebase Storage.", "OK");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Hubo un error al seleccionar o subir el archivo: {ex.Message}", "OK");
            }
            finally
            {
                activityIndicator.IsRunning = false;
                activityIndicator.IsVisible = false;
            }
        }

        private async void OnCameraImageClicked(object sender, EventArgs e)
        {
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;

            try
            {
                // Solicitar permiso para acceder a la cámara
                var status = await Permissions.RequestAsync<Permissions.Camera>();
                if (status != PermissionStatus.Granted)
                {
                    await DisplayAlert("Permiso denegado", "No se puede acceder a la cámara.", "Aceptar");
                    return;
                }

                // Capturar una foto usando MediaPicker
                var photo = await MediaPicker.CapturePhotoAsync();

                if (photo != null)
                {
                    // Obtener una referencia al flujo de la imagen capturada
                    var stream = await photo.OpenReadAsync();

                  
                    var firebaseUrl = await UploadFileToFirebaseStorage(stream, photo.FileName);

                    if (!string.IsNullOrEmpty(firebaseUrl))
                    {
                     
                        UploadedImage.Source = firebaseUrl;
                        _selectedFile = firebaseUrl;

                      //  await DisplayAlert("Éxito", "Archivo subido correctamente a Azure Blob Storage.", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo subir el archivo a Azure Blob Storage.", "OK");
                    }
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Error", "La captura de fotos no es compatible en este dispositivo.", "Aceptar");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Error", "Permiso de cámara denegado.", "Aceptar");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Hubo un error al capturar la foto: {ex.Message}", "Aceptar");
            }
            finally
            {
                activityIndicator.IsRunning = false;
                activityIndicator.IsVisible = false;
            }
        }

        private async Task<string> UploadFileToFirebaseStorage(Stream fileStream, string fileName)
        {
            try
            {
                // Inicializar FirebaseStorage con la configuración
                var firebaseStorage = new FirebaseStorage(_storageBucket);

                // Subir archivo a Firebase Storage
                var imageUrl = await firebaseStorage
                    .Child("imagenes")
                    .Child(fileName)
                    .PutAsync(fileStream);

              
              

                return imageUrl;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al subir archivo a Firebase Storage: {ex.Message}");
                await DisplayAlert("Error", $"Error al subir archivo a Firebase Storage: {ex.Message}", "OK");
                return null;
            }
        }


        private async void btnRegistrarPublicacion_Clicked(object sender, EventArgs e)
        {
            String laURL = API_LINK.link + "CommunyStoreApi/publicacion/ingresarPublicacion";
            try
            {
                if (string.IsNullOrWhiteSpace(entryDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(entryPrecio.Text) ||
                    string.IsNullOrWhiteSpace((string)entryCategoria.SelectedItem))
                {
                    await DisplayAlert("Campos vacíos", "Por favor, complete todos los campos.", "Aceptar");
                    return;
                }

                ReqIngresarPublicacion req = new ReqIngresarPublicacion();
                req.publicacion = new Publicacion();
                req.publicacion.descripcionPublicacion = entryDescripcion.Text;
                req.publicacion.precioPublicacion = decimal.Parse(entryPrecio.Text);
                req.publicacion.categoriaPublicacion = (string)entryCategoria.SelectedItem;

                // Supongamos que SesionFrontEnd.usuarioSesion es el usuario actualmente logueado
                req.publicacion.usuario = SesionFrontEnd.usuarioSesion;

                if (_selectedFile != null)
                {
                    req.publicacion.nombresArchivos = _selectedFile;
                }
                else
                {
                    req.publicacion.nombresArchivos = string.Empty;
                }

                var jsonPublicacion = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsync(laURL, jsonPublicacion);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        dynamic jsonResponse = JObject.Parse(responseContent);

                        ResIngresarPublicacion res = new ResIngresarPublicacion();
                        res.resultado = jsonResponse.resultado;
                        res.tipoRegistro = jsonResponse.tipoRegistro;
                        if (res.tipoRegistro == 1 && res.resultado)
                        {
                            await DisplayAlert("Registro exitoso!", "Tu publicación ha sido registrada exitosamente!", "Aceptar");
                            await Navigation.PushAsync(new PublicacionesView());
                        }
                        else if (res.tipoRegistro == 2)
                        {
                            await DisplayAlert("Registro fallido!", "Error de lógica!", "Aceptar");
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
                        await DisplayAlert("Problemas con la API", "Hubo un error en la comunicación con la API", "Aceptar");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error interno", "Error en la aplicación: " + ex.StackTrace.ToString(), "Aceptar");
            }
        }
    }
}