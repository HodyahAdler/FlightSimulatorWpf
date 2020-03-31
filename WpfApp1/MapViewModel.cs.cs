using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    class MapViewModel : IViewModel
    {
        private IModel model;

        //private IModel model;
        private double longitude;
        private double latitude;
        public event PropertyChangedEventHandler PropertyChanged;
        public MapViewModel(IModel m)
        {
            this.model = m;
            this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }



        public void NotifyPropertyChanged(string PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }


    }
}