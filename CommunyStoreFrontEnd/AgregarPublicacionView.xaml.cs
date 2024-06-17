using Microsoft.Maui.Controls;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Newtonsoft.Json;
using System.Text;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace CommunyStoreFrontEnd
{
    public partial class AgregarPublicacionView : ContentPage
    {
        private string _selectedFile;
        private ImageButton _lastSelectedButton;

        public AgregarPublicacionView()
        {
            InitializeComponent();
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

                    // Subir archivo a Azure Blob Storage
                    var blobUrl = await UploadFileToAzureBlob(stream, photo.FileName);

                    if (!string.IsNullOrEmpty(blobUrl))
                    {
                        // Rebobinar el stream
                        stream.Seek(0, SeekOrigin.Begin);

                        // Mostrar la imagen capturada en la interfaz de usuario
                        var image = ImageSource.FromStream(() => stream);
                        UploadedImage.Source = image;
                        _selectedFile = blobUrl;

                        await DisplayAlert("Éxito", "Archivo subido correctamente a Azure Blob Storage.", "OK");
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

        private async void OnUploadImageClicked(object sender, EventArgs e)
        {
            try
            {
                activityIndicator.IsRunning = true;
                activityIndicator.IsVisible = true;

                var result = await Microsoft.Maui.Storage.FilePicker.PickAsync(new Microsoft.Maui.Storage.PickOptions
                {
                    PickerTitle = "Seleccione un archivo",
                    FileTypes = Microsoft.Maui.Storage.FilePickerFileType.Images
                });

                if (result != null)
                {
                    using (var stream = await result.OpenReadAsync())
                    {
                        // Subir archivo a Azure Blob Storage
                        var blobUrl = await UploadFileToAzureBlob(stream, result.FileName);
                        if (!string.IsNullOrEmpty(blobUrl))
                        {
                            // Rebobinar el stream
                            stream.Seek(0, SeekOrigin.Begin);

                            var image = ImageSource.FromStream(() => stream);
                            UploadedImage.Source = image; // Aquí asigna la imagen al control Image
                            _selectedFile = blobUrl;

                            await DisplayAlert("Éxito", "Archivo subido correctamente a Azure Blob Storage.", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Error", "No se pudo subir el archivo a Azure Blob Storage.", "OK");
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

        private async Task<string> UploadFileToAzureBlob(Stream fileStream, string fileName)
        {
            try
            {
                string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=sarapiquiemprende1;AccountKey=dg+a7ESJkwz85VWaLZRLJT2PN2osMmLiZjK5TviihQTIGh5hTMvY5m6fGRBa6047SAJc50DnWJy5+ASt8YFB7w==;EndpointSuffix=core.windows.net";
                string containerName = "imagenes";

                // Crear cliente de almacenamiento de Azure
                var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference(containerName);

                // Verificar si el contenedor existe y crearlo si no existe
                bool containerExists = await container.ExistsAsync();
                if (!containerExists)
                {
                    await container.CreateAsync();
                }

                // Generar un nombre único para el blob
                var uniqueBlobName = $"{Guid.NewGuid().ToString()}-{fileName}";

                // Obtener referencia al blob que se va a crear
                var blob = container.GetBlockBlobReference(uniqueBlobName);

                blob.Properties.ContentType = "image/jpeg"; // Reemplaza "image/jpeg" con el tipo de contenido correcto según el tipo de archivo que estás subiendo
                await blob.UploadFromStreamAsync(fileStream);

                // Obtener la URL pública del blob (accesible para público si está configurado)
                return blob.Uri.AbsoluteUri;
            }
            catch (StorageException ex)
            {
                // Capturar excepciones específicas de Azure Storage
                Console.WriteLine($"Error al subir archivo a Azure Blob Storage: {ex.Message}");
                await DisplayAlert("Error", $"Error al subir archivo a Azure Blob Storage: {ex.Message}", "OK");
                return null;
            }
            catch (Exception ex)
            {
                // Capturar excepciones generales
                Console.WriteLine($"Error general al subir archivo a Azure Blob Storage: {ex.Message}");
                await DisplayAlert("Error", $"Error general al subir archivo a Azure Blob Storage: {ex.Message}", "OK");
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
