using estet.Classes;
using estet.Pages.Administration;
using estet.Pages.InfoPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace estet.Pages.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMenu : MasterDetailPage
    {
        public List<MasterMenuItems> MenuList { get; set; }
        public MasterMenu()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            MenuList = new List<MasterMenuItems>();  //Making a list here for the side menu navigation 

            var orderPage = new MasterMenuItems() { Title = "Ваши заказы", IconSource = "ordersIcon.png", TargetType = typeof(OrderPage) };
            var settingPage = new MasterMenuItems() { Title = "Настройки", IconSource = "settingsIcon.png", TargetType = typeof(SettingsPage) };
            MenuList.Add(orderPage);
            MenuList.Add(settingPage);
            if (Convert.ToBoolean(App.UserDatabase.GetUser(Globals.Id).IntIsDev))
            {
                var adminPanel = new MasterMenuItems() { Title = "Админ-панель", IconSource = "adminIcon.png", TargetType = typeof(AdminPage) };
                MenuList.Add(adminPanel);
            }
            

            mainMenuList.ItemsSource = MenuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(OrderPage)));

        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e) //On selecting any page from the side menu 
        {
            var item = (MasterMenuItems)e.SelectedItem;
            Type page = item.TargetType;
            
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false; //MasterDetailPage.Master now hidden from our eyesight
        }
    }
}