using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;

namespace FlightSimulatorWpf
{
    public interface IModel : INotifyPropertyChanged
    {
        double HeadingDeg { get; /*set;*/ }
        double VerticalSpeed { get; /*set;*/ }
        double GroundSpeed { get; /*set;*/ }
        double IndicatedSpeed { get; /*set;*/ }
        double GpsAltitude { get;/*set;*/ }
        double InternalRoll { get;/*set;*/ }
        double InternalPitch { get; /*set;*/ }
        double AltimeterAltitude { get; /*set;*/ }
        double Latitude { get; /**set;*/ }
        double Longitude { get; /*set;*/ }
        double Throttle { get; set; }
        double Aileron { get; set; }
        double Elevator { get; set; }
        double Rudder { get; set; }

        List<string> IndicatedSpeedErrorsList { get; }
        List<string> GpsAltitudeErrorsList { get; }
        List<string> InternalRollErrorsList { get; }
        List<string> InternalPitchErrorsList { get; }
        List<string> AltimeterAltitudeErrorsList { get; }
        List<string> HeadingDegErrorsList { get; }
        List<string> GroundSpeedErrorsList { get; }
        List<string> VerticalSpeedErrorsList { get; }
        Location AirPlaneLocation { get; }
        List<string> GeneralErrList { get; }

        void NotifyPropertyChanged(string PropertyName);

        void Connect(string ip, string port);
        void Connect();
        void Disconnect();
        void Start();

        void MoveNavigation(string propName);


       
    }
}