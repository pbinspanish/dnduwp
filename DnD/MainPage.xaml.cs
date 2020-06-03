using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DnD.Pages;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DnD
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		public static Random rng;

        public MainPage()
        {
			rng = new Random();
            this.InitializeComponent();
        }

		private void nvSample_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
		{
			if (args.IsSettingsInvoked)
			{
				// contentFrame.Navigate(typeof(Settings));
			}
			else
			{
				var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
				MainNav_Navigate(item as NavigationViewItem);
			}
		}

		private void MainNav_Navigate(NavigationViewItem item)
		{
			switch (item.Tag)
			{
				case "home":
					contentFrame.Navigate(typeof(Home));
					break;
				case "dice":
					contentFrame.Navigate(typeof(Dice));
					break;
				case "character":
					contentFrame.Navigate(typeof(Character));
					break;
			}
		}

		private void nvSample_Loaded(object sender, RoutedEventArgs e)
		{
			nvSample.SelectedItem = nvSample.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Tag == "home");
			contentFrame.Navigate(typeof(Home));
		}
	}
}
