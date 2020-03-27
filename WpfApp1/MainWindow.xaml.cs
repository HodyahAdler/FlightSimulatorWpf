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

namespace WpfApp1
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
			flyModel flyModel = new flyModel();
			flyModel.connect();
			flyModel.start();

			flyModel.disconnect();
		}
		public MainWindow()
		{
		//			MainA();
			InitializeComponent();
		}


		private void heading_deg_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			int x = 0;
			sender = x;
		}
		private void vartical_speed_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			int x = 0;
			sender = x;
		}
		private void ground_speed_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			int x = 0;
			sender = x;
		}
		private void indicator_indicated_speed_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			int x = 0;
			sender = x;
		}
		private void gps_indicated_altitude_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			int x = 0;
			sender = x;
		}
		private void indicator_internal_roll_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			int x = 0;
			sender = x;
		}
		private void indicator_internal_pitch_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			int x = 0;
			sender = x;
		}
		private void altimeter_indicated_altitude_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			int x = 0;
			sender = x;
		}
	}
}

