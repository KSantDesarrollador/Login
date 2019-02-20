using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using Login.Modelo;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Login
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();
            MainPage = new NavigationPage( new Login.MainPage(filename) );
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
