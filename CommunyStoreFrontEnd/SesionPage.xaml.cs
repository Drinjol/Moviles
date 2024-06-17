using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Newtonsoft.Json;
using System.Text;

namespace CommunyStoreFrontEnd
{
    public partial class SesionPage : ContentPage
    {

        public SesionPage()
        {
            InitializeComponent();
        }

        private async void btn_StartSession_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(emailTxt.Text) || String.IsNullOrEmpty(passwordEntry.Text))
            {
                await DisplayAlert("Datos incompletos", "Por favor, ingrese todos los datos!", "Aceptar");
                return;
            }

            // Mostrar el indicador de carga y ocultar el botón de inicio de sesión
            btn_StartSession.IsVisible = false;
            loadingIndicatorLayout.IsVisible = true;
            loadingIndicator.IsRunning = true;

            try
            {
                ReqIniciarSesion req = new ReqIniciarSesion
                {
                    correo = emailTxt.Text,
                    password = passwordEntry.Text
                };

                var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/Login/iniciarSesion", jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        ResIniciarSesion res = JsonConvert.DeserializeObject<ResIniciarSesion>(responseContent);

                        if (res.resultado)
                        {
                            SesionFrontEnd.usuarioSesion = res.usuario;
                            Application.Current.MainPage = new MainPage();
                        }
                        else
                        {
                            await DisplayAlert("Incorrecto", "¡Usuario o contraseña incorrecto!", "Aceptar");
                        }
                    }
                    else
                    {
                        await DisplayAlert("No se encontró el backend", "Error en la conexión con el EndPoint", "Aceptar");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error interno", "Error en la aplicación: " + ex.StackTrace.ToString(), "Aceptar");
            }
            finally
            {
                // Ocultar el indicador de carga y mostrar el botón de inicio de sesión
                loadingIndicator.IsRunning = false;
                loadingIndicatorLayout.IsVisible = false;
                btn_StartSession.IsVisible = true;
            }
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

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
