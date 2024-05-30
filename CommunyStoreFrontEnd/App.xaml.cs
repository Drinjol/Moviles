namespace CommunyStoreFrontEnd
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new prueba1());
            
        }
        public void NavigateToAppShell()
        {
            MainPage = new AppShell();
        }
    }
}