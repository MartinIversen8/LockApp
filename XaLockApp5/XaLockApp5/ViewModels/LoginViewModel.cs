﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XaLockApp5.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        bool isBusy = false;

        public ICommand NavigateToSentenceCMD => new Command(async () => {
            if (isBusy)
                return;
            isBusy = true;

            // navigate to the next page after you have logged in 
            await NavigationService.NavigateToAsync<LockViewModel>();

            isBusy = false;
        });
    }
}
