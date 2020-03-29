using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    class SimulatorViewModel : IViewModel {
        private IModel model;
        private double throttle;
        private double aileron;
      /*  private double longitude;
        private double latitude;*/
        private double rudder;
        private double elevator;

        public SimulatorViewModel(IModel m)
        {
            this.model = m;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
             {
                 NotifyPropertyChanged("VM_" + e.PropertyName);
             };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        // from Model Properties
       /* public double VM_HeadingDeg
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
        }*/

        //from view Properties
        public double VM_Elevator
        {
            get { return elevator; }
            set
            {
                elevator = value;
                model.moveJoystick(elevator, rudder);
            }
        }
        public double VM_Rudder
        {
            get { return rudder; }
            set
            {
                rudder = value;
                model.moveJoystick(elevator, rudder);
            }
        }
        public double VM_Throttle
        {
            get { return throttle; }
            set
            {
                throttle = value;
                model.moveSlider(throttle, aileron);
            }
        }
        public double VM_Aileron
        {
            get { return aileron; }
            set
            {
                aileron = value;
                model.moveSlider(throttle, aileron);
            }
        }

    }
}
