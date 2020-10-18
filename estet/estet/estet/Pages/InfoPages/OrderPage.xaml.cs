using estet.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace estet.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderPage : ContentPage
	{
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
        }


	}
}