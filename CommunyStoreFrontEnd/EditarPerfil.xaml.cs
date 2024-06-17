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
    private string nombre;
    public string Nombre
    {
        get => nombre;
        set
        {
            if (nombre != value)
            {
                nombre = value;
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
    private string password;
    public string Password
    {
        get => password;
        set
        {
            if (password != value)
            {
                password = value;
                OnPropertyChanged();
            }
        }
    }
    private string password2;
    public string Password2
    {
        get => password2;
        set
        {
            if (password2 != value)
            {
                password2 = value;
                OnPropertyChanged();
            }
        }
    }
    private string apellidos;
    public string Apellidos
    {
        get => apellidos;
        set
        {
            if (apellidos != value)
            {
                apellidos = value;
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
            Nombre = perfil.Nombre;
            Descripcion = perfil.Descripcion;
            Direccion = perfil.Direccion;
            Telefono = perfil.Telefono;
            EmailUsuario = perfil.EmailUsuario;
            Password = perfil.Password;
            Apellidos = perfil.Apellidos;
        }
    }
    private async void Volver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void GuardarInformacion_Clicked(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(txtname.Text) ||
        string.IsNullOrWhiteSpace(txtdireccion.Text) ||
        string.IsNullOrWhiteSpace(txtdescripcion.Text) ||
        string.IsNullOrWhiteSpace(txttelefono.Text) ||
        string.IsNullOrWhiteSpace(txtemail.Text) ||
        string.IsNullOrWhiteSpace(txtpassword.Text) ||
        string.IsNullOrWhiteSpace(txtpassword2.Text) ||
        string.IsNullOrWhiteSpace(txtapellidos.Text))

        {
            await DisplayAlert("Campos vacios", "Por favor, complete todos los campos.", "Aceptar");
            return;
        }
        else if (txtpassword.Text == txtpassword2.Text)
        {
            try
            {

                var usuario = new ReqActualizarUsuario
                {
                    Id = SesionFrontEnd.usuarioSesion.Id,
                    nombre = txtname.Text,

                    descripcion = txtdescripcion.Text,

                    direccion = txtdireccion.Text,
                    telefono = txttelefono.Text,
                    email = txtemail.Text,
                    password = txtpassword.Text,
                    apellidos = txtapellidos.Text
                };

                /* await DisplayAlert("Datos capturados",
                     $"Id: {usuario.Id}\n"+
                       $"Nombre: {usuario.nombre}\n" +
                       $"Descripci�n: {usuario.descripcion}\n" +
                       $"Direcci�n: {usuario.direccion}\n" +
                       $"Tel�fono: {usuario.telefono}\n" +

                       $"Password: {usuario.password}\n" +
                       $"Email: {usuario.email}"
                       ,
                       "Aceptar");*/


                var jsonContent = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
                // await DisplayAlert("Datos capturados, serializados", JsonConvert.SerializeObject(usuario), "Aceptar");


                //await DisplayAlert("Datos capturados", usuarioJson, "Aceptar");

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/usuario/actualizarUsuario", jsonContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();


                        dynamic jsonResponse = JObject.Parse(responseContent);

                        bool resultado = jsonResponse.resultado;
                        int tipoRegistro = jsonResponse.tipoRegistro;


                        if (tipoRegistro == 1)
                        {
                            await DisplayAlert("Registro exitoso!", "Has sido registrado exitosamente, ahora puedes iniciar sesion!", "Aceptar");
                            await Navigation.PopAsync();
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

                       /* if (resultado)
                        {
                            await DisplayAlert("correcto!", "registro correcto", "ok");
                            // Manejar el resultado exitoso
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            // Manejar errores
                            //  string errores = string.Join(", ", listaDeErrores);
                            await DisplayAlert("Error", "Hubo un problema con el registro, por favor volver a intentar", "Aceptar");
                        }*/
                    }
                    else
                    {
                        await DisplayAlert("Problemas con la api", "Hubo un error en la comunicacion con la api", "Aceptar");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error interno", "Error en la aplicacion: " + ex.StackTrace.ToString(), "Aceptar");
            }


        }
        else
        {
            await DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
        }

        await Navigation.PopAsync();
    }
    private void TogglePasswordVisibility(object sender, EventArgs e)
    {
        txtpassword.IsPassword = !txtpassword.IsPassword;

        // Cambiar el texto del bot�n
        if (txtpassword.IsPassword)
        {
            ((Button)sender).Text = "Ver";
        }
        else
        {
            ((Button)sender).Text = "Ocultar";
        }
    }
    private void TogglePasswordVisibility2(object sender, EventArgs e)
    {
        txtpassword2.IsPassword = !txtpassword2.IsPassword;

        // Cambiar el texto del bot�n
        if (txtpassword2.IsPassword)
        {
            ((Button)sender).Text = "Ver";
        }
        else
        {
            ((Button)sender).Text = "Ocultar";
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
