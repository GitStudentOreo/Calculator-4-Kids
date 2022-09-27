using dragon.Services;
using dragon.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dragon
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage( new theme_menu());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
