using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    class SimulatorViewModel {
        IViewModel tb_vm;
        IViewModel m_vm;
        IViewModel j_vm;
       

        public SimulatorViewModel(IModel m)
        {
            tb_vm = new TunedBoardViewModel(m);
            m_vm = new MapViewModel(m);
            j_vm = new JoystickViewModel(m);
        }

    }
}
