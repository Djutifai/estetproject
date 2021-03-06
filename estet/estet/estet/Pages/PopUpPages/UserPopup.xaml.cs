﻿using estet.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace estet.Pages.PopUpPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public UserPopup()
        {
            InitializeComponent();
        }

        private User user;
        private object sender;

        public UserPopup(User user, object sender)
        {
            this.user = user;
            InitializeComponent();
            OnClicking(this.user);
            this.sender = sender;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public void OnClicking(User user)
        {

            UserId.Text=user.Id.ToString();
            UserMail.Text = user.Mail;
        }
        private void AddOrder(object sender, EventArgs e)
        {

        }

        private void EditUser(object sender, EventArgs e)
        {

        }
        protected override void OnDisappearing()
        {

            base.OnDisappearing();
        }

        // ### Methods for supporting animations in your popup page ###

        // Invoked before an animation appearing
        protected override void OnAppearingAnimationBegin()
        {
            base.OnAppearingAnimationBegin();
        }

        // Invoked after an animation appearing
        protected override void OnAppearingAnimationEnd()
        {
            base.OnAppearingAnimationEnd();
        }

        // Invoked before an animation disappearing
        protected override void OnDisappearingAnimationBegin()
        {
            base.OnDisappearingAnimationBegin();
        }

        // Invoked after an animation disappearing
        protected override void OnDisappearingAnimationEnd()
        {
            try { ((ListView)sender).SelectedItem = null; }
            catch (NullReferenceException) { }
            return;
        }

        protected override Task OnAppearingAnimationBeginAsync()
        {
            return base.OnAppearingAnimationBeginAsync();
        }

        protected override Task OnAppearingAnimationEndAsync()
        {
            return base.OnAppearingAnimationEndAsync();
        }

        protected override Task OnDisappearingAnimationBeginAsync()
        {
            return base.OnDisappearingAnimationBeginAsync();
        }

        protected override Task OnDisappearingAnimationEndAsync()
        {
            return base.OnDisappearingAnimationEndAsync();

        }

        // ### Overrided methods which can prevent closing a popup page ###

        // Invoked when a hardware back button is pressed
        protected override bool OnBackButtonPressed()
        {
            // Return true if you don't want to close this popup page when a back button is pressed
            return base.OnBackButtonPressed();
        }

        // Invoked when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            return base.OnBackgroundClicked();
        }


    }
}
