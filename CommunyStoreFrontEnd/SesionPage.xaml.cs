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

        private void btn_agregar_usuario_Clicked(object sender, EventArgs e)
        {

        }

        private async void btn_StartSession_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(emailTxt.Text)||String.IsNullOrEmpty(passwordEntry.Text))
            {
                await DisplayAlert("Datos incompletos", "Por favor, ingrese todos los datos!", "Aceptar");
                return;
            }
            else
            {
                try
                {
                    ReqIniciarSesion req = new ReqIniciarSesion();

                    req.correo = emailTxt.Text;
                    req.password = passwordEntry.Text;

                    var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                    using (var httpClient = new HttpClient())
                    {
                        var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/Login/iniciarSesion", jsonContent);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            ResIniciarSesion res = new ResIniciarSesion();

                            res = JsonConvert.DeserializeObject<ResIniciarSesion>(responseContent);

                            if (res.resultado)
                            {

                                SesionFrontEnd.usuarioSesion = res.usuario;

                                _ = Navigation.PushAsync(new PublicacionesView());

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
