﻿namespace CommunyStoreFrontEnd
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new SesionPage());
            
        }
        public void NavigateToAppShell()
        {
            MainPage = new AppShell();
        }
    }
}