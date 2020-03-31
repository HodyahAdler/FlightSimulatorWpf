using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    class JoystickViewModel : IViewModel
    {
        private IModel model;

        private double throttle;
        private double aileron;
        private double rudder;
        private double elevator;

        public event PropertyChangedEventHandler PropertyChanged;

        public JoystickViewModel(IModel m)
        {
            this.model = m;
            this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

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

        public void NotifyPropertyChanged(string PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}