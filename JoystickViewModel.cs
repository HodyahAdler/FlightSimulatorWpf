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

        private double vm_throttle;
        private double vm_aileron;
        private double vm_rudder;
        private double vm_elevator;

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
            get { return vm_elevator; }
            set
            {
                vm_elevator = value;
                model.moveJoystick(vm_elevator, vm_rudder);
            }
        }
        public double VM_Rudder
        {
            get { return vm_rudder; }
            set
            {
                vm_rudder = value;
                model.moveJoystick(vm_elevator, vm_rudder);
            }
        }
        public double VM_Throttle
        {
            get { return vm_throttle; }
            set
            {
                if (value < 0) value = 0; else if (value > 1) value = 1;

                Console.WriteLine("throt= {0}", value);
                vm_throttle = value;
                model.updateSliders(vm_throttle, vm_aileron);
            }
        }
        public double VM_Aileron
        {
            get { return vm_aileron; }
            set
            {
                if (value < -1) value = -1; else if (value > 1) value = 1;

                Console.WriteLine("aile= {0}", value);

                vm_aileron = value;
                model.updateSliders(vm_throttle, vm_aileron);
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
