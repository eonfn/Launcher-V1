using ModernWpf.Controls;
using ModernWpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp6.Pages;
using ModernWpf.Media.Animation;
using System;
using System.Net;
//using WpfApp6.Services;

namespace WpfApp6
{


	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		// Sets Up The Pages
		Home home = new Home();
		Settings settings = new Settings();

		public MainWindow()
		{
			InitializeComponent();

		/*	WebClient omg = new WebClient();
			try
			{
				string fds = omg.DownloadString("http://api.eonfn.com/eon/version");


				if (fds == "0.1")
				{
					//
				}
				else
				{
					MessageBox.Show("Please Update The Launcher");
					Application.Current.Shutdown();
				}
			}catch (Exception ex)
			{
				MessageBox.Show("Failed Connecting To Eon Servers, Please Check The Discord");
				Application.Current.Shutdown();
			}*/
			
		}

		private void NavView_Loaded(object sender, RoutedEventArgs e)
		{
			ContentFrame.Navigate(home);

			

			//base.OnStartup(e);
			//ContentFrame.Navigate(home);
		}

		private void NavView_SelectionChanged(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewSelectionChangedEventArgs args)
		{
			if (args.IsSettingsSelected)
			{
				ContentFrame.Navigate(settings);
			}else
			{
				NavigationViewItem item = args.SelectedItem as NavigationViewItem;

				if (item.Tag.ToString() == "Home")
				{
					ContentFrame.Navigate(home);
				}
			}
		}

		private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new Exception("Failed to load Page."); // Never TBH
		}
	}
}
