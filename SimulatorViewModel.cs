using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    class SimulatorViewModel
    {
        public IViewModel vm_dashBoard;
        public IViewModel vm_map;
        public IViewModel vm_joystick;
        public IViewModel vm_message;


        public SimulatorViewModel(IModel m)
        {
            vm_dashBoard = new DashBoardViewModel(m);
            vm_map = new MapViewModel(m);
            vm_joystick = new JoystickViewModel(m);
            vm_message = new MessageViewModel(m);
        }

    }
}
