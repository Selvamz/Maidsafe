using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Maidsafe
{
    public class Subject : INotifyPropertyChanged
    {
        private int subject1;
        private int subject2;
        private int subject3;

        public int Subject1
        {
            get { return subject1; }
            set
            {
                if(subject1 != value)
                {
                    subject1 = value;
                    OnPropertyChanged("Subject1");
                }
            }
        }

        public int Subject2
        {
            get { return subject2; }
            set
            {
                if (subject2 != value)
                {
                    subject2 = value;
                    OnPropertyChanged("Subject2");
                }
            }
        }

        public int Subject3
        {
            get { return subject3; }
            set
            {
                if (subject3 != value)
                {
                    subject3 = value;
                    OnPropertyChanged("Subject3");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
