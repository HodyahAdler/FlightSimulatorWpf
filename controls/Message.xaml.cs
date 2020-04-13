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
	/// Interaction logic for Message.xaml
	/// </summary>
	public partial class Message : UserControl
	{

		public Message()
		{
			InitializeComponent();
			listErrorObject.Visibility = Visibility.Hidden;
		}

		private void errorInVeriable_TouchMove(object sender, TouchEventArgs e)
		{
			listErrorObject.Visibility = Visibility.Visible;
		}
	}
}