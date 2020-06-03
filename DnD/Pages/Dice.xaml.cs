using DnD.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DnD.Pages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Dice : Page
	{
		ObservableCollection<Die> DiceCollection = new ObservableCollection<Die>
		{
			new Die(1, 20),
		};

		public Dice()
		{
			this.InitializeComponent();
			DiceList.ItemsSource = DiceCollection;
		}

		private void CreateBtn_Click(object sender, RoutedEventArgs e)
		{
			DiceCollection.Add(new Die((int)DieCount.Value, (int)DieSize.Value));

			if (this.AddDieBtn.Flyout is Flyout f)
			{
				f.Hide();
			}
		}

		private void DieRollBtn_Click(object sender, RoutedEventArgs e)
		{
			if (DiceList.SelectedIndex == -1)
			{
				DieOutput.Text = "Select a die from the list before rolling.";
			}
			else
			{
				Die currentDie = DiceCollection[DiceList.SelectedIndex];
				int[] values = currentDie.Roll();
				string output = "";

				for (int i = 0; i < values.Count(); i++)
				{
					output += values[i] + ", ";
				}
				output = output.Remove(output.Length - 2);
				DieOutput.Text = output;
			}
		}
	}
}
