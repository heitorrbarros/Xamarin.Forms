using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	// TODO hartez 9:11:48 AM Clean this up should be gh, 1331

	[Issue(IssueTracker.Bugzilla, 9991331, "[Android] ViewCell shows ContextActions on tap instead of long press", PlatformAffected.Android)]
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Github1331 : TestContentPage
	{
		public Github1331 ()
		{
			InitializeComponent ();
		}

		private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			DisplayAlert("Item clicked", $"Content: {e.Item}", "Cancel");
		}

		protected override void Init()
		{
			var mainViewModel = new MainViewModel
			{
				Items = new ObservableCollection<ListItemViewModel>(new[]
				{
					new ListItemViewModel
					{
						Text = "item 1",
						ActionTappedCommand =
							new Command(() => DisplayAlert("Action tapped", "item 1", "Cancel"))
					},
					new ListItemViewModel
					{
						Text = "item 2",
						ActionTappedCommand =
							new Command(() => DisplayAlert("Action tapped", "item 2", "Cancel"))
					},
					new ListItemViewModel
					{
						Text = "item 3",
						ActionTappedCommand =
							new Command(() => DisplayAlert("Action tapped", "item 3", "Cancel"))
					}
				})
			};

			BindingContext = mainViewModel;

			Title = "GH 1331";
		}

		[Preserve(AllMembers = true)]
		private class MainViewModel
		{
			public ObservableCollection<ListItemViewModel> Items { get; set; }
		}

		[Preserve(AllMembers = true)]
		private class ListItemViewModel
		{
			public string Text { get; set; }
			public ICommand ActionTappedCommand { get; set; }
		}
	}

	
}