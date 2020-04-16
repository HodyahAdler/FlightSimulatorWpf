using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulatorWpf
{
	/// <summary>
	/// Interaction logic for InputUserData.xaml
	/// </summary>
	public partial class InputUserData : Window
	{
		public InputUserData()
		{
			InitializeComponent();
			DataContext = (Application.Current as App).Simulator_vm;
			this.Show();
		}
		private void Button_Click_On_Ip_Message(object sender, RoutedEventArgs e)
		{
			try
			{
				(Application.Current as App).Simulator_vm.Start_Run(ipUserInput.Text, portUserInput.Text);

				this.Hide();
				//creating the Main Window
				MainWindow mainWindow = new MainWindow();
				mainWindow.Show();
				this.Close();

			}
			catch(Exception exc)
			{
				Console.WriteLine("{0}", exc.Message);
			}
		}
	}
}