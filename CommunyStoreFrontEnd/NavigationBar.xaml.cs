namespace CommunyStoreFrontEnd
{
    public partial class NavigationBar : ContentView
    {
        private ImageButton _lastSelectedButton;
        private MainPage _mainPage;

        public NavigationBar()
        {
            InitializeComponent();
        }

        public void SetMainPage(MainPage mainPage)
        {
            _mainPage = mainPage;
        }
        private void Button_Clicked_view_new_publicacion(object sender, EventArgs e)
        {
            _mainPage.NavigateTo(new AgregarPublicacionView());
            HighlightButton(sender as ImageButton);
        }

        private void Button_Clicked_view_home(object sender, EventArgs e)
        {
            _mainPage.NavigateTo(new PublicacionesView());
            HighlightButton(sender as ImageButton);
        }

        private void Button_Clicked_view_lista_guardados(object sender, EventArgs e)
        {
            _mainPage.NavigateTo(new ListaDeseos());
            HighlightButton(sender as ImageButton);
        }

        private void btnMensajes_Clicked(object sender, EventArgs e)
        {

            _mainPage.NavigateTo(new ChatsList());
            HighlightButton(sender as ImageButton);
        }

        private void Button_Clicked_view_Perfil_Usuario(object sender, EventArgs e)
        {
            _mainPage.NavigateTo(new PerfilDeUsuario());
            HighlightButton(sender as ImageButton);
        }

        private void HighlightButton(ImageButton button)
        {
            if (_lastSelectedButton != null)
            {
                _lastSelectedButton.BackgroundColor = Colors.Transparent;
            }

            if (button != null)
            {
                button.BackgroundColor = Colors.LightBlue;
                _lastSelectedButton = button;
            }
        }
    }
}
