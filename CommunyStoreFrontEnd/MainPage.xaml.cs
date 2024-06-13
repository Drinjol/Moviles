namespace CommunyStoreFrontEnd
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadInitialView();

            NavigationBar.SetMainPage(this);
        }

        private void LoadInitialView()
        {
            NavigateTo(new PublicacionesView());
        }

        public async void NavigateTo(ContentPage page)
        {
            await NavigationPageContainer.Navigation.PushAsync(page);
        }
    }
}
