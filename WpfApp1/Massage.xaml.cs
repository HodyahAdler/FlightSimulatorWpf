using System;
using System.Collections.Generic;
using System.Linq;
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

namespace FlightSimulatorWpf.controls
{
	/// <summary>
	/// Interaction logic for Massage.xaml
	/// </summary>
	public partial class Massage : UserControl
	{
		String ip;
		String port;
		public Massage()
		{
			InitializeComponent();
		}
		public String Ip { get { return this.ip; } }
		public String Port { get { return this.port; } }



		private void Button_MouseMove(object sender, MouseEventArgs e)
		{

		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
	}
}
