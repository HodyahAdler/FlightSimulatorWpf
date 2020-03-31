using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    public interface IViewModel : INotifyPropertyChanged
    {
        void NotifyPropertyChanged(string PropertyName);
    }
}
