using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studienverlaufsplaner
{
    public class Noteneintragung : INotifyPropertyChanged
    {
        private string fach = string.Empty; //wegen nullable standardwert geben
        public string Fach
        {
            get => fach;
            set
            {
                if (fach != value)
                {
                    fach = value;
                    OnPropertyChanged(nameof(Fach));
                }
            }
        }

        private double note;
        public double Note
        {
            get => note;
            set
            {
                if (note != value)
                {
                    note = value;
                    OnPropertyChanged(nameof(Note));
                }
            }
        }

        private int ects;
        public int ECTS
        {
            get => ects;
            set
            {
                if (ects != value)
                {
                    ects = value;
                    OnPropertyChanged(nameof(ECTS));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
