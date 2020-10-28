using estet.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace estet.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderPage : ContentPage
	{
		private Order _order = App.OrderDatabase.GetOrder(Globals.Id);
		public OrderPage ()
		{
			InitializeComponent ();

            Init();
		}

		void Init()
		{

			BackgroundColor = Constants.BackgroundColor;
			LogoIcon.HeightRequest = Constants.SmallLogoheight;
			LogoIcon.WidthRequest = Constants.SmallLogowidth;
			NavigationPage.SetHasBackButton(this, false);
			if (_order != null)
			{
				MakeMagic();	
			}
			else
            {
				OrderName.Text = "Если Вы уже сделали заказ, то в скором времени он у Вас здесь отобразится!"; OrderName.FontSize = 30;
            }
		}

		public Order CheckForOrder(int id)
        {
			return App.OrderDatabase.GetOrder(id); 
        }

		private void MakeMagic()
        {
			OrderName.Text = $"Заказ #{_order.OrderId:0000}";
			/*MakingImage.Source = "Making.png";
			MakingText.FontAttributes = FontAttributes.None;
			OrderImage.Source = "Order.png";
			OrderText.FontAttributes = FontAttributes.None;
			CheckingImage.Source = "Checking.png";
			CheckingText.FontAttributes = FontAttributes.None;
			DoneImage.Source = "Checkmark.png";
			DoneText.FontAttributes = FontAttributes.None;
			*/
			ColumnGrid.IsVisible = true;
			OrderName.FontSize = 40;
			switch (_order.Status)
			{
				case 0:
					MakingImage.Source = "MakingDone.png";
					MakingText.FontAttributes = FontAttributes.Bold;
					return;
				case 1:
					OrderImage.Source = "OrderDone.png";
					OrderText.FontAttributes = FontAttributes.Bold;
					return;
				case 2:
					CheckingImage.Source = "CheckingDone.png";
					CheckingText.FontAttributes = FontAttributes.Bold;
					return;
				case 3:
					DoneImage.Source = "CheckmarkDone.png";
					DoneText.FontAttributes = FontAttributes.Bold;
					return;

			}
		}
    }
}