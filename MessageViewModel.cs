using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    class MessageViewModel : IViewModel
    {
        private IModel model;

        public event PropertyChangedEventHandler PropertyChanged;
        public MessageViewModel(IModel m)
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
        public List<string> VM_ErrorMessageList { get { return this.model.ErrorMessageList; } }
        public int VM_GetErrFromServer
        {
            get
            {
                if (this.model.GetErrFromServer) { return 1; }
                else { return 0; }
            }
        }
    }
}