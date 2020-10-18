using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using estet.Pages;
using estet.Pages.LogPages;
using estet.Classes;
using estet.Data;
using System.Net.Http;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace estet
{
    public partial class App : Application
    {

        static TokenDatabaseController tokenDatabase;
        static UserDatabaseController userDatabase;
        private HttpClient _client = new HttpClient();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
            
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

        public static UserDatabaseController UserDatabase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                    if (!userDatabase.LoginValidate("admin", "admin"))
                    {
                        userDatabase.CreateAdmin();
                    }

                }
                return userDatabase;
            }
        }

        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDatabaseController();

                }
                return tokenDatabase;
            }
        }


    }
}
