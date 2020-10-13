using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using estet.Classes;

namespace estet.Pages
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

            LogoIcon.HeightRequest = Constants.Logoheight;
            LogoIcon.WidthRequest = Constants.Logowidth;

            Entry_Mail.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => LoginClick(s, e); 
        }

        private void LoginClick(object sender, EventArgs e)
        {
            User user = new User(Entry_Mail.Text, Entry_Password.Text);

            if (!user.CheckIfEmpty())
            {
                DisplayAlert("Вход", "Успешно авторизовано", "OK");
                App.UserDatabase.SaveUser(user);
            }
            else
            {
                DisplayAlert("Ошибка", "Поле почты или/и пароля пустые", "OK");
            }
        }

        private void RegClick(object sender, EventArgs e)
        {

        }
    }
}