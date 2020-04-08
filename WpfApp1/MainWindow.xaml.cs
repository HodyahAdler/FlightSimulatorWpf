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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		static public void MainA()
		{
			Console.WriteLine("hii");
			/**
				ClientServer client = new ClientServerSimple();
				client.openIp();
				int x = 0;
				while (x < 500)
				{
					x++;
				}
				client.close();
		*/


		//					flyModel.disconnect();
				
		}

		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public MainWindow(string ip, string port)
		{
			InitializeComponent();
			IModel model = new FlyModel(new TelnetClient());
			model.connect(ip, port);
			model.start();
			SimulatorViewModel viewModelSimultor = new SimulatorViewModel(model);
			TunedBoardView.DataContext = viewModelSimultor.vm_dashBoard;
			mapView.DataContext = viewModelSimultor.vm_map;
		}
	}
}


