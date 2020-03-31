using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    class SimulatorViewModel {
        public IViewModel tb_vm;
        public IViewModel m_vm;
        public IViewModel j_vm;
       

        public SimulatorViewModel(IModel m)
        {
            tb_vm = new TunedBoardViewModel(m);
            m_vm = new MapViewModel(m);
            j_vm = new JoystickViewModel(m);
        }

    }
}
