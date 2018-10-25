using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kelompok29.View;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Kelompok29
{
    public partial class App : Application
    { 
        public static bool IsUserLoggedIn { get; internal set; }

    
        public App()
        {
            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());

            }
            else
            {
                MainPage = new NavigationPage(new HalamanUtama());

            }
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

