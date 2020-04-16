using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    public class SimulatorViewModel
    {
        private IModel model;

        public IViewModel vm_dashBoard;
        public IViewModel vm_map;
        public IViewModel vm_joystick;
        public IViewModel vm_message;

        public SimulatorViewModel(IModel m)
        {
            this.model = m;

            vm_dashBoard = new DashBoardViewModel(model);
            vm_map = new MapViewModel(model);
            vm_joystick = new JoystickViewModel(model);
            vm_message = new MessageViewModel(model);
            InputUserData input = new InputUserData();

        }

        public void Start_Run(string ip,string port)
        {
            this.model.Connect(ip, port);
            this.model.Start();
        }

    }
}
