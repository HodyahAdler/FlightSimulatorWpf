using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulatorWpf.controls
{
    /// <summary>
    /// Interaction logic for Joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl
    {
        private Point startPoint;
        private Point endPoint;

        /// <summary>
        /// Dependency Properties for Joystick
        /// </summary>
        // Rudder dependencyProperty
        public static readonly DependencyProperty RudderProperty =
           DependencyProperty.Register("Rudder", typeof(double), typeof(Joystick), null);

        // Elevator dependencyProperty
        public static readonly DependencyProperty ElevatorProperty =
            DependencyProperty.Register("Elevator", typeof(double), typeof(Joystick), null);

        // current Rudder
        public double Rudder
        {
            get { return Convert.ToDouble(GetValue(RudderProperty)); }
            set { SetValue(RudderProperty, value); }
        }

        // current Elevator
        public double Elevator
        {
            get { return Convert.ToDouble(GetValue(ElevatorProperty)); }
            set { SetValue(ElevatorProperty, value); }
        }


        public Joystick()
        {
            InitializeComponent();

            //Events
            Knob.MouseMove += Knob_MouseMove;
            Knob.MouseUp += Knob_MouseUp;
            Knob.MouseDown += Knob_MouseDown;

        }

        private void Knob_MouseDown(object sender, MouseButtonEventArgs e)
        {
                this.startPoint = e.GetPosition(this); // the starting point (the center of the joystick)
           
        }


        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
            double width = Math.Abs(Constants.MIN_JOY_LIMIT) + Math.Abs(Constants.MAX_JOY_LIMIT);

            if (e.LeftButton==MouseButtonState.Pressed) // only if mouse is pressed (it also means there is a start point value)
            {
                endPoint = e.GetPosition(this);
                double x = endPoint.X - startPoint.X;
                double y = endPoint.Y - startPoint.Y;
                double lineLength = Math.Sqrt(x*x + y*y);
          
                /* the line is outside of the joystick circle - finding the dot on the line that is on the circle edge
                 * the circle center is (0,0), the current dot of the mouse is (x1,y1)
                 * Line: y-y0 = m(x-x0), circle: (x-x0)^2+(y-y0)^2=r^2
                 * the common dot is: x = r/sqrt(m^2+1) Pos/Neg  , y = m*x
                 */
                if (lineLength > width / 2)

                {
                    double m; // the slope
                    double r = width / 2;
                    if (x!=0)
                    {
                        m = y / x;
                        double newX = r / Math.Sqrt(Math.Pow(m, 2) + 1);
                        if (x > 0)
                        {
                            x = newX;
                        } else
                        {
                            x = -newX;
                        }
                        // finding the y value
                        y = m * x;
                    }
                    //special case because there is no slope, can not use the Linear equation, setting the y value to its closest value according to the limits
                    else
                    {
                        if (y > 0)
                        {
                            y = Constants.MAX_JOY_LIMIT;
                        } else
                        {
                            y = Constants.MIN_JOY_LIMIT;
                        }
                    }
                }

                knobPosition.X = x;
                knobPosition.Y = y;

                Rudder = normalize(knobPosition.X, width); // after normalization
                Elevator = -1 * (normalize(knobPosition.Y, width)); // after normalization;

            }
        }

        private double normalize(double inputValue, double width)
        {
            return ((2*(inputValue-(Constants.MIN_JOY_LIMIT)) /width)-1);
        }

        private void Knob_MouseUp(object sender, MouseEventArgs e)
        {
            Knob.ReleaseMouseCapture();

            Rudder = Elevator = 0; // setting back the Rudder & Elevator to 0;

            knobPosition.X = knobPosition.Y= 0;

        }

        // when the Animation is finished
        private void centerKnob_Completed(object sender, EventArgs e){}

    }


    static class Constants
    {
        // the limit of the joystick movement
        public const int MIN_JOY_LIMIT = -85;
        public const int MAX_JOY_LIMIT = 85;


        /* there is no name in the xaml for the Black circle so it is not dynamic here.
         * if we want the joystick to be in the Gray circle we will write: Base.Width/2- KnobBase.Width/2 */
    }

}
