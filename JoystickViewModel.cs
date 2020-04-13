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

        /* private double vm_throttle;
         private double vm_aileron;
         private double vm_rudder;
         private double vm_elevator;*/

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
            get { return model.Elevator; }
            set
            {
                if (model.Elevator != value)
                {
                    Console.WriteLine("elevJoy= {0}", value);

                    model.Elevator = value;
                    model.moveNavigation("elevator");

                }
            }
        }
        public double VM_Rudder
        {
            get { return model.Rudder; }
            set
            {
                if (model.Rudder != value)
                {
                    //Console.WriteLine("rudderJoy= {0}", value);

                    model.Rudder = value;
                    model.moveNavigation("rudder");

                }
            }
        }
        public double VM_Throttle
        {
            get { return model.Throttle; }
            set
            {
                if (model.Throttle != value)
                {
                    //if (value < 0) value = 0; else if (value > 1) value = 1;
                    //Console.WriteLine("throt= {0}", value);
                    model.Throttle = value;
                    model.moveNavigation("throttle");
                }
            }
        }
        public double VM_Aileron
        {
            get { return model.Aileron; }
            set
            {
                if (model.Aileron != value)
                {
                    //if (value < -1) value = -1; else if (value > 1) value = 1;
                    //Console.WriteLine("aile= {0}", value);

                    model.Aileron = value;
                    model.moveNavigation("aileron");
                }
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
