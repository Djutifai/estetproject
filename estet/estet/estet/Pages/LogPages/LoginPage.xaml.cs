using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using estet.Classes;
using estet.Pages.LogPages;
using estet.Pages.Menu;
using Xamarin.Forms.PlatformConfiguration;

namespace estet.Pages.LogPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            Init(); 
		}

        private void Init() 
        {
            BackgroundColor = Constants.BackgroundColor;
            LogEntries.BackgroundColor = Constants.EntriesColor;
            Lbl_Mail.TextColor = Constants.TextColor;
            Lbl_Password.TextColor = Constants.TextColor;

            LogoIcon.HeightRequest = Constants.BigLogoheight;
            LogoIcon.WidthRequest = Constants.BigLogowidth;

            Entry_Mail.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => LoginClick(s, e);

            NavigationPage.SetHasBackButton(this, false);
        }

        private async void LoginClick(object sender, EventArgs e) // After user clicking on the login button checking for the entries from user
        {


            if (Entry_Mail.Text!=null && Entry_Password.Text!=null)
            {
                if (App.UserDatabase.LoginValidate(Entry_Mail.Text, Entry_Password.Text))
                {
                    await DisplayAlert("Вход", "Успешно авторизовано", "OK");

                    Application.Current.MainPage = new MasterMenu();

                }

                else
                    await DisplayAlert("Ошибка", "Пользователя с такими данными не существует", "OK");

            }
            else if (Entry_Mail.Text == null || Entry_Password.Text == null)
            {
                await DisplayAlert("Ошибка", "Поле почты или/и пароля пустые", "OK");
            }
            else
            {
                await DisplayAlert("Some strange error", "I dont know what to do", "OK");
            }
        }

        private async void RegClick(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}