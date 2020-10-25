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

namespace estet.Pages.LogPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
	{
		public RegistrationPage ()
		{
			InitializeComponent ();
            Init();
		}

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            RegEntries.BackgroundColor = Constants.EntriesColor;
            Lbl_Mail.TextColor = Constants.TextColor;
            Lbl_Phone.TextColor = Constants.TextColor;
            Lbl_Password.TextColor = Constants.TextColor;
            Lbl_RePassword.TextColor = Constants.TextColor;

            LogoIcon.HeightRequest = Constants.SmallLogoheight;
            LogoIcon.WidthRequest = Constants.SmallLogowidth;

            Entry_Mail.Completed += (s, e) => Entry_Phone.Focus();
            Entry_Phone.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => Entry_RePassword.Focus();
            Entry_RePassword.Completed += (s, e) => RegClick(s, e);

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }

        private async void RegClick(object sender, EventArgs e) //After user clicking on the reg button checking if everything is ok and if so adding user to the database 
                                                                //database is local atm, will be doing a connection to the SQL server via https+json 
        {


            if (!String.IsNullOrEmpty(Entry_Mail.Text)  && !String.IsNullOrEmpty(Entry_Phone.Text)  
                && !String.IsNullOrEmpty(Entry_Password.Text) && !String.IsNullOrEmpty(Entry_RePassword.Text)) 
            {

               if (App.UserDatabase.IsUniqueMail(Entry_Mail.Text)) //Something about it
                                                                    //System.InvalidOperationException: 'Sequence contains no elements' Will fix tomorrow, note for myself
               {

                    if (Entry_Password.Text.Equals(Entry_RePassword.Text))
                    {
                        User user = new User(Entry_Mail.Text, Entry_Password.Text, Entry_Phone.Text);
                        await DisplayAlert("Регистрация", "Вы успешно зарегистрировались!", "OK");
                        App.UserDatabase.SaveUser(user);
                        await DisplayAlert("ID", user.Id.ToString(), "OK");
                        Globals.Id = user.Id;
                        Application.Current.MainPage = new MasterMenu();
                    }
                    
                    else await DisplayAlert("Ошибка", "Введённые пароли не совпадают", "OK");
                }

               else await DisplayAlert("Ошибка", "Пользователь с такой почтой уже зарегистрирован", "OK");
            }

            else
            
                await DisplayAlert("Ошибка", "Ошибка при создании аккаунта, проверьте правильно ли заполнены все поля.", "OK");

        }

        private async void CancelClick(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            await Navigation.PushAsync(new LoginPage());
        }
    }
}