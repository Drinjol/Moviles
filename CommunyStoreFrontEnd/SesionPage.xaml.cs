using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

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

        private void btn_StartSession_Clicked(object sender, EventArgs e)
        {

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
