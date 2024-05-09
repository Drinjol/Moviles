using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;
namespace CommunyStoreFrontEnd;

public partial class RegisterPage : ContentPage
{

    String apiLink = "https://localhost:44308/";
    public RegisterPage()
	{
		InitializeComponent();
	}

    private async void btn_Register_Clicked(object sender, EventArgs e)
    {
        try
        {

            if (string.IsNullOrWhiteSpace(txtname.Text) ||
            string.IsNullOrWhiteSpace(txtapellidos.Text) ||
            string.IsNullOrWhiteSpace(txtcorreo.Text) ||
            string.IsNullOrWhiteSpace(passwordEntry.Text) ||
            string.IsNullOrWhiteSpace(txtdireccion.Text) ||
            string.IsNullOrWhiteSpace(txttelefono.Text) ||
            string.IsNullOrWhiteSpace(txtdesc.Text))
            {
                await DisplayAlert("Campos vacíos", "Por favor, complete todos los campos.", "Aceptar");
                return; // Detener la ejecución del método si hay campos vacíos
            }


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
                var jsonContent = new StringContent(jsonUsuario, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(apiLink + "CommunyStoreApi/usuario/agregarUsuario", jsonContent);

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
                    }else if(tipoRegistro == 2)
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
                        await Navigation.PushAsync(new SesionPage());
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
   
    private void OnLoginTapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new SesionPage());
    }

    private void TogglePasswordVisibility(object sender, EventArgs e)
    {
        passwordEntry.IsPassword = !passwordEntry.IsPassword;

        // Cambiar el texto del botón
        if (passwordEntry.IsPassword)
        {
            ((Button)sender).Text = "Ver";
        }
        else
        {
            ((Button)sender).Text = "Ocultar";
        }
    }



}