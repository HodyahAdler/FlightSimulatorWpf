  
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
        SimulatorViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new SimulatorViewModel(new FlyModel(new TelnetClient()));
            DataContext = vm;


            InitializeComponent();
            IModel model = new FlyModel(new TelnetClient());
            model.connect();
            model.start();
            SimulatorViewModel viewModelSimulator = new SimulatorViewModel(model);
            TunedBoardView.DataContext = viewModelSimulator.tb_vm;

        }

    }
}
