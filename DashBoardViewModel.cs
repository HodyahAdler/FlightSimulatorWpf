using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FlightSimulatorWpf
{
    class DashBoardViewModel : IViewModel
    {
        private IModel model;

        public event PropertyChangedEventHandler PropertyChanged;

        public System.Windows.Media.Color[] ColorsA {get; private set; }
        public DashBoardViewModel(IModel m)
        {
            this.model = m;
            this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };

            // INITIALIZING HEADERS COLORS
            ColorsA = new System.Windows.Media.Color[8];
            for (int i = 0; i < ColorsA.Length; i++)
            {
                ColorsA[i] = Colors.Black;
            }
            NotifyPropertyChanged("ColorsA");
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
            get
            { return model.GroundSpeed; }
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

        public List<string> VM_HeadingDegErrorsList
        {
            get
            {
                List<string> list = this.model.HeadingDegErrorsList;
                if (!first_update(list))
                {
                    changed(0);
                }
                return list;
            }
        }

        public List<string> VM_VerticalSpeedErrorsList
        {
            get
            {
                List<string> list = this.model.VerticalSpeedErrorsList;
                if (!first_update(list))
                {
                    changed(1);
                }
                return list;
            }
        }
        public List<string> VM_GroundSpeedErrorsList
        {
            get
            {
                List<string> list = this.model.GroundSpeedErrorsList;
                if (!first_update(list))
                {
                    changed(2);
                }
                return list;
            }
        }

        public List<string> VM_IndicatedSpeedErrorsList
        {
            get
            {
                List<string> list = this.model.IndicatedSpeedErrorsList;
                if (!first_update(list))
                {
                    changed(3);
                }
                return list;
            }
        }

        public List<string> VM_GpsAltitudeErrorsList
        {
            get
            {
                List<string> list = this.model.GpsAltitudeErrorsList;
                if (!first_update(list))
                {
                    changed(4);
                }
                return list;
            }
        }

        public List<string> VM_InternalRollErrorsList
        {
            get
            {
                List<string> list = this.model.InternalRollErrorsList;
                if (!first_update(list))
                {
                    changed(5);
                }
                return list;
            }
        }

        public List<string> VM_InternalPitchErrorsList
        {
            get
            {
                List<string> list = this.model.InternalPitchErrorsList;
                if (!first_update(list))
                {
                    changed(6);
                }
                return list;
            }
        }

        public List<string> VM_AltimeterAltitudeErrorsList
        {
            get
            {
                List<string> list = this.model.AltimeterAltitudeErrorsList;
                if (!first_update(list))
                {
                    changed(7);
                }
                return list;
            }
        }


        private bool first_update(List<string> list)
        {
            if (list.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void changed(int location)
        {
            ColorsA[location] = Colors.Red;
            NotifyPropertyChanged("ColorsA");
            await Task.Delay(3000);
            ColorsA[location] = Colors.Black;
            NotifyPropertyChanged("ColorsA");
        }

    }
}