using estet.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Extensions;
using estet.Pages.PopUpPages;

namespace estet.Pages.Administration
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : ContentPage
    {
        public List<User> UserList { get; set; }
        public AdminPage()
        {
            InitializeComponent();
            Init();
        }
        
       
        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;

            
            LogoIcon.HeightRequest = Constants.SmallLogoheight;
            LogoIcon.WidthRequest = Constants.SmallLogowidth;
            ShowAllUsers();
            NavigationPage.SetHasBackButton(this, false);
        }

        private void ShowAllUsers()
        {
            UserList = App.UserDatabase.GetAllUsers();

            usersShow.ItemsSource = UserList;

        }

        private async void UsersOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var user = (User)e.SelectedItem;
            await Navigation.PushPopupAsync(new UserPopup(user), true);
            //MessagingCenter.Subscribe<AdminPage>(this, "Ok");
            //((ListView)sender).SelectedItem = null;
            /*await DisplayAlert(Convert.ToString(Convert.ToBoolean(user.IntIsDev)), "is dev?", "OK");
            bool answer = await DisplayAlert("Hey", "do you want to delete this user", "Yes", "No");
            if (answer)
            {
                App.UserDatabase.DeleteUser(user.Id);
            }*/
        }
        


    }
}