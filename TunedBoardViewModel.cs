using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    class TunedBoardViewModel : IViewModel
    {
        private IModel model;

        public event PropertyChangedEventHandler PropertyChanged;

        public TunedBoardViewModel(IModel m)
        {
            this.model = m;
            this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public double VM_HeadingDeg
        {
            get { return model.HeadingDeg; }
        }
        public double VM_VerticalSpeed
        {
            get { return model.VerticalSpeed; }
        }
        public double VM_GroundSpeed
        {
            get { return model.GroundSpeed; }
        }
        public double VM_IndicatedSpeed
        {
            get { return model.IndicatedSpeed; }
        }
        public double VM_GpsAltitude
        {
            get { return model.GpsAltitude; }
        }
        public double VM_InternalRoll
        {
            get { return model.InternalRoll; }
        }
        public double VM_InternalPitch
        {
            get { return model.InternalPitch; }
        }
        public double VM_AltimeterAltitude
        {
            get { return model.AltimeterAltitude; }
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