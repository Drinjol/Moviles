using CommunyStoreFrontEnd.Utilitarios;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;  // Importar el namespace para expresiones regulares

namespace CommunyStoreFrontEnd;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void btn_Register_Clicked(object sender, EventArgs e)
    {
        // Validaciones
        if (string.IsNullOrWhiteSpace(txtname.Text) ||
            string.IsNullOrWhiteSpace(txtapellidos.Text) ||
            string.IsNullOrWhiteSpace(txtcorreo.Text) ||
            string.IsNullOrWhiteSpace(passwordEntry.Text) ||
            string.IsNullOrWhiteSpace(txtdireccion.Text) ||
            string.IsNullOrWhiteSpace(txttelefono.Text) ||
            string.IsNullOrWhiteSpace(txtdesc.Text))
        {
            await DisplayAlert("Campos vacíos", "Por favor, complete todos los campos.", "Aceptar");
            return;
        }

        // Validar que el nombre y los apellidos no contengan números
        if (Regex.IsMatch(txtname.Text, @"\d") || Regex.IsMatch(txtapellidos.Text, @"\d"))
        {
            await DisplayAlert("Nombre inválido", "El nombre y los apellidos no deben contener números.", "Aceptar");
            return;
        }

        // Validar que el número de teléfono solo contenga números
        if (!Regex.IsMatch(txttelefono.Text, @"^\d+$"))
        {
            await DisplayAlert("Teléfono inválido", "El número de teléfono solo debe contener números.", "Aceptar");
            return;
        }

        // Validar que el correo electrónico tenga el formato correcto
        if (!Regex.IsMatch(txtcorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            await DisplayAlert("Correo inválido", "El correo electrónico no tiene un formato válido.", "Aceptar");
            return;
        }

        // Mostrar el indicador de carga y ocultar el botón de registro
        btn_Register.IsVisible = false;
        loadingIndicatorLayout.IsVisible = true;
        loadingIndicator.IsRunning = true;

        try
        {
            var usuario = new
            {
                nombre = txtname.Text,
                apellidos = txtapellidos.Text,
                email = txtcorreo.Text,
                password = passwordEntry.Text,
                direccion = txtdireccion.Text,
                telefono = txttelefono.Text,
                descripcion = txtdesc.Text
            };

            var jsonUsuario = JsonSerializer.Serialize(usuario);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/usuario/agregarUsuario", new StringContent(jsonUsuario, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Convertir la respuesta a un objeto dinámico
                    dynamic jsonResponse = JObject.Parse(responseContent);

                    bool resultado = jsonResponse.resultado;
                    int tipoRegistro = jsonResponse.tipoRegistro;

                    if (tipoRegistro == 1)
                    {
                      
                    }
                    else if (tipoRegistro == 2)
                    {
                        await DisplayAlert("Registro fallido!", "Error de lógica!", "Aceptar");
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
                        await DisplayAlert("Registro exitoso!", "Has sido registrado exitosamente, ahora puedes iniciar sesión!", "Aceptar");
                        // Manejar el resultado exitoso
                        await Navigation.PushAsync(new SesionPage());
                    }
                    else
                    {
                        // Manejar errores
                        await DisplayAlert("Error", "Hubo un problema con el registro, por favor volver a intentar", "Aceptar");
                    }
                }
                else
                {
                    await DisplayAlert("Problemas con la api", "Hubo un error en la comunicación con la API", "Aceptar");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error interno", "Error en la aplicación: " + ex.StackTrace.ToString(), "Aceptar");
        }
        finally
        {
            // Ocultar el indicador de carga y mostrar el botón de registro
            loadingIndicator.IsRunning = false;
            loadingIndicatorLayout.IsVisible = false;
            btn_Register.IsVisible = true;
        }
    }

    private void OnLoginTapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new SesionPage());
    }

    private void TogglePasswordVisibility(object sender, EventArgs e)
    {
        passwordEntry.IsPassword = !passwordEntry.IsPassword;

        // Cambiar el texto del botón
        ((Button)sender).Text = passwordEntry.IsPassword ? "Ver" : "Ocultar";
    }
}
