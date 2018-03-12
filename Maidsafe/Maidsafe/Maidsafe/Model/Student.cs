using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Maidsafe
{
    public class Student : INotifyPropertyChanged
    {
        private string name;
        private Subject subject;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public Subject Subject
        {
            get { return subject; }
            set
            {
                if (subject != value)
                {
                    subject = value;
                    OnPropertyChanged("Subject");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
