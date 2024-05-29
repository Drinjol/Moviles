namespace CommunyStoreFrontEnd
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Prueba());
            
        }
        public void NavigateToAppShell()
        {
            MainPage = new AppShell();
        }
    }
}