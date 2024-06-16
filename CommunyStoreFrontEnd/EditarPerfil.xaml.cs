using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommunyStoreFrontEnd;

public partial class EditarPerfil : ContentPage, INotifyPropertyChanged
{
    private string nombreUsuario;
    public string NombreUsuario
    {
        get => nombreUsuario;
        set
        {
            if (nombreUsuario != value)
            {
                nombreUsuario = value;
                OnPropertyChanged();
            }
        }
    }

    private string descripcion;
    public string Descripcion
    {
        get => descripcion;
        set
        {
            if (descripcion != value)
            {
                descripcion = value;
                OnPropertyChanged();
            }
        }
    }

    private string direccion;
    public string Direccion
    {
        get => direccion;
        set
        {
            if (direccion != value)
            {
                direccion = value;
                OnPropertyChanged();
            }
        }
    }

    private string telefono;
    public string Telefono
    {
        get => telefono;
        set
        {
            if (telefono != value)
            {
                telefono = value;
                OnPropertyChanged();
            }
        }
    }

    private string emailUsuario;
    public string EmailUsuario
    {
        get => emailUsuario;
        set
        {
            if (emailUsuario != value)
            {
                emailUsuario = value;
                OnPropertyChanged();
            }
        }
    }

    public EditarPerfil(object bindingContext)
    {
        InitializeComponent();
        BindingContext = bindingContext;
        var perfil = bindingContext as PerfilDeUsuario;
        if (perfil != null)
        {
            NombreUsuario = perfil.NombreUsuario;
            Descripcion = perfil.Descripcion;
            Direccion = perfil.Direccion;
            Telefono = perfil.Telefono;
            EmailUsuario = perfil.EmailUsuario;
        }
    }

    private async void GuardarInformacion_Clicked(object sender, EventArgs e)
    {

            if (string.IsNullOrWhiteSpace(txtname.Text) ||
            string.IsNullOrWhiteSpace(txtdireccion.Text) ||
            string.IsNullOrWhiteSpace(txtdescripcion.Text) ||
            string.IsNullOrWhiteSpace(txttelefono.Text) ||
            string.IsNullOrWhiteSpace(txtemail.Text))
            
            {
                await DisplayAlert("Campos vacíos", "Por favor, complete todos los campos.", "Aceptar");
                return;
        }
        else
        {
            try
            {

                var usuario = new
                {
                    nombre = txtname.Text,

                    descripcion = txtdescripcion.Text,

                    direccion = txtdireccion.Text,
                    telefono = txttelefono.Text,
                    email = txtemail.Text
                };

                await DisplayAlert("Datos capturados",
                    $"Nombre: {usuario.nombre}\n" +
                    $"Descripción: {usuario.descripcion}\n" +
                    $"Dirección: {usuario.direccion}\n" +
                    $"Teléfono: {usuario.telefono}\n" +
                    $"Email: {usuario.email}",
                    "Aceptar");

                ReqActualizarUsuario req = new ReqActualizarUsuario();

                    var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

                // await DisplayAlert("Datos capturados", usuarioJson, "Aceptar");

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/usuario/actualizarUsuario", jsonContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        // Convertir la respuesta a un objeto dinámico
                        dynamic jsonResponse = JObject.Parse(responseContent);

                        bool resultado = jsonResponse.resultado;
                        int tipoRegistro = jsonResponse.tipoRegistro;
                        // JArray listaDeErrores = jsonResponse.listaDeErrores;

                        if (tipoRegistro == 1)
                        {
                            await DisplayAlert("Registro exitoso!", "Has sido registrado exitosamente, ahora puedes iniciar sesion!", "Aceptar");
                        }
                        else if (tipoRegistro == 2)
                        {

                            await DisplayAlert("Registro fallido!", "Error de logica!", "Aceptar");
                        }
                        else if (tipoRegistro == 3)
                        {
                            await DisplayAlert("Registro fallido!", "Error de datos", "Aceptar");

                        }
                        else if (tipoRegistro == 4)
                        {
                            await DisplayAlert("Registro fallido!", "Error no controlado!", "Aceptar");

                        }

                        if (resultado)
                        {
                            await DisplayAlert("Registro exitoso!", "Has sido registrado exitosamente, ahora puedes iniciar sesion!", "Aceptar");
                            // Manejar el resultado exitoso
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            // Manejar errores
                            //  string errores = string.Join(", ", listaDeErrores);
                            await DisplayAlert("Error", "Hubo un problema con el registro, por favor volver a intentar", "Aceptar");
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

        await DisplayAlert("Información", "Información guardada con éxito", "OK");
        await Navigation.PopAsync();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
