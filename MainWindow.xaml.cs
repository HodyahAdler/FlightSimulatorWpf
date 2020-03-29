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
            vm = new SimulatorViewModel(new FlyModel(new FlyTelnetClient()));
            DataContext = vm;

        }

        private void MyJoystick_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Map_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
