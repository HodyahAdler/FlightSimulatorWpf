using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    interface IViewModel : INotifyPropertyChanged
    {
        void NotifyPropertyChanged(string PropertyName);

    }
}
