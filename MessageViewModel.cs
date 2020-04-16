using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FlightSimulatorWpf
{
    class MessageViewModel : IViewModel
    {
        private IModel model;

     /*   private Color offline_message_color;
        private Color slow_message_color;
        private Color unexpected_message_color;
        private Color airplaneOutOfRange_message_color;*/

        public event PropertyChangedEventHandler PropertyChanged;

       // public List<string> myList;

        public MessageViewModel(IModel m)
        {
            this.model = m;
            this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };

         /*   myList = new List<string>();
            this.myList.Add("The server is very Slow");
            this.myList.Add("The server is offline");
            this.myList.Add("Unexpected Error");
            this.myList.Add("The Airplane is out of Boundaries");*/
           // NotifyPropertyChanged("GeneralErrList");

          /*  // setting Errors Colors
            offline_message_color = Color.FromRgb(249, 17, 17);
            slow_message_color = Color.FromRgb(255, 220, 0);
            unexpected_message_color = Color.FromRgb(0, 150, 255);
            airplaneOutOfRange_message_color = Color.FromRgb(64, 192, 31);
*/

        }
        public void NotifyPropertyChanged(string PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        /*    public Color Offline_message_color
            {
                get { return this.offline_message_color; }
            }
            public Color Slow_message_color
            {
                get { return this.slow_message_color; }
            }
            public Color Unexpected_message_color
            {
                get { return this.unexpected_message_color; }
            }
            public Color AirplaneOutOfRange_message_color
            {
                get { return this.airplaneOutOfRange_message_color; }
            }*/

        public List<string> VM_GeneralErrList
        {
            get {
                /*Console.WriteLine("entered\n");
                List<string> l = this.model.GenErrors;
                foreach (string i in l)
                {
                    Console.WriteLine("list: " + i + "\n");
                }*/
                return this.model.GeneralErrList; }
        }

        /*public List<string> MyList
        {
            get { return this.myList; }
        }*/


    }
}