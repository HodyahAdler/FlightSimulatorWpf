
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
        public MainWindow(string ip, string port)
        {
            InitializeComponent();

            IModel model = new FlyModel(new TelnetClient());
            SimulatorViewModel viewModelSimulator = new SimulatorViewModel(model);

            joystickView.DataContext = viewModelSimulator.vm_joystick;
            dashBoardView.DataContext = viewModelSimulator.vm_dashBoard;
            mapView.DataContext = viewModelSimulator.vm_map;
            messagesView.DataContext = viewModelSimulator.vm_message;


            model.Connect(ip, port);
            model.Start();
        }

    }
}