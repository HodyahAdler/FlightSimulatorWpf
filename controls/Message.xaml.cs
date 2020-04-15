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

		}

        private Boolean AutoScrolling = true;

        private void errors_ScrollChanged(Object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer scroll = sender as ScrollViewer;

            // User scroll event : set or unset auto-scroll mode
            if (e.ExtentHeightChange == 0)
            {   // Content unchanged : user scroll event
                if (scroll.VerticalOffset == scroll.ScrollableHeight)
                {   // Scroll bar is in bottom
                    // Set auto-scroll mode
                    AutoScrolling = true;
                }
                else
                {   // Scroll bar isn't in bottom
                    // Unset auto-scroll mode
                    AutoScrolling = false;
                }
            }

            // Content scroll event : auto-scroll eventually
            if (AutoScrolling && e.ExtentHeightChange != 0)
            {   // Content changed and auto-scroll mode set
                // Autoscroll
                scroll.ScrollToVerticalOffset(scroll.ExtentHeight);
            }
        }

        private void Disconnect_Button_Clicked(object sender, RoutedEventArgs e)
        {
          
        }

        private void Connect_Button_Clicked(object sender, RoutedEventArgs e)
        {

        }
    }
}