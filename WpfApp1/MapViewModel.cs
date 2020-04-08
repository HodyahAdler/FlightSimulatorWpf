using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    class MapViewModel : IViewModel
    {
        private IModel model;
        public event PropertyChangedEventHandler PropertyChanged;
        public MapViewModel(IModel m)
        {
            this.model = m;
            //Location VM_airPlaneLocation = new Location(VM_latitude, VM_longitude);
            this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        //        public Location VM_AirPlaneLocation{ get { return new Location(this.model.Longitude, this.model.Latitude);} 
        //      }
        public Location VM_AirPlaneLocation
        {
            get { return this.model.AirPlaneLocation; }
        }
        public Double VM_AngleFly { get { return 0; } }

        public void NotifyPropertyChanged(string PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}