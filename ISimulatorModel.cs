using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    interface ISimulatorModel : INotifyPropertyChanged
    {
        void NotifyPropertyChanged(string PropertyName);

        void connect(string ip, int port);
        void disconnect();
        void start();


        void moveJoystick(double elevator, double rudder);
        void moveSlider(double throttle, double aileron);

    }
}
