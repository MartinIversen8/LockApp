﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XaLockApp5.Models;
using XaLockApp5.ViewModels;
using System.Reflection;

namespace XaLockApp5.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetail : MasterDetailPage
    {
		public MasterDetail ()
		{
			InitializeComponent ();
            profileImage.Source = ImageSource.FromFile("padLock.png");

            navigationList.ItemsSource = GetMenuList();

            IsPresented = false;
        }

        public List<MasterMenuItems> GetMenuList()
        {
            var list = new List<MasterMenuItems>();

            list.Add(new MasterMenuItems()
            {
                Text = "Try ViewModel",
                Detail = "Try it out",
                ImagePath = "skeleton.png",
                TargetViewModel = typeof(TryViewModel) 
            });

            list.Add(new MasterMenuItems()
            {
                Text = "Test ViewModel",
                Detail = "Test it out",
                ImagePath = "grill.png",
                TargetViewModel = typeof(TestViewModel)
            });
            
            return list;
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = (MasterMenuItems)e.SelectedItem;

            var viewModel = (ViewModels.MasterDetailViewModel)this.BindingContext;
            viewModel.ChangeVMCMD.Execute(selectedMenuItem);

            IsPresented = false;
        }
    }
}