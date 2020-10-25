using AerodromWPF.Database;
using AerodromWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerodromWPF.Model
{
    public class Aerodrom : INotifyPropertyChanged
    {

        public Aerodrom()
        {
            aktivan = true;
        }

        public int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }

        public string grad;
        public string Grad
        {
            get { return grad; }
            set { grad = value; OnPropertyChanged("Grad"); }
        }

        public string sifra;
        public string Sifra
        {
            get { return sifra; }
            set { sifra = value; OnPropertyChanged("Sifra"); }
        }

        public bool aktivan;
        public bool Aktivan
        {
            get { return aktivan; }
            set { aktivan = value; OnPropertyChanged("Aktivan"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"Id {Id}, Sifra {Sifra}, Naziv {Naziv}, Grad {Grad}, Aktivan {Aktivan}";
        }

        private void OnPropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(name));
            }
        }
    }
}
