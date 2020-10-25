using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerodromWPF.Model
{
    public class Karta : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnProperyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public enum klasaenum { Biznis, Ekonomska }

        public Karta()
        {
            aktivna = true;
        }

        public int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private int brojLeta;
        public int BrojLeta
        {
            get { return brojLeta; }
            set { brojLeta = value; OnProperyChanged("BrojLeta"); }
        }

        private string brojSedista;
        public string BrojSedista
        {
            get { return brojSedista; }
            set { brojSedista = value; OnProperyChanged("BrojSedista"); }
        }

        private string nazivPutnika;
        public string NazivPutnika
        {
            get { return nazivPutnika; }
            set { nazivPutnika = value; OnProperyChanged("NazivPutnika"); }
        }

        private klasaenum klasaSedista;
        public klasaenum KlasaSedista
        {
            get { return klasaSedista; }
            set { klasaSedista = value; OnProperyChanged("KlasaSedista"); }
        }

        private int kapija;
        public int Kapija
        {
            get { return kapija; }
            set { kapija = value; OnProperyChanged("Kapija"); }
        }

        private double cena;
        public double Cena
        {
            get { return cena; }
            set { cena = value; OnPropertyChanged("Cena"); }
        }

        public bool aktivna;
        public bool Aktivna
        {
            get { return aktivna; }
            set { aktivna = value; OnPropertyChanged("Aktivna"); }
        }

        public object Clone()
        {
            return new Karta
            {
                Id = this.Id,
                BrojLeta = this.BrojLeta,
                BrojSedista = this.BrojSedista,
                NazivPutnika = this.NazivPutnika,
                KlasaSedista = this.KlasaSedista,
                Kapija = this.Kapija,
                Cena = this.Cena,
                Aktivna = this.Aktivna
            };
        }

        public override string ToString()
        {
            return $"Id{Id}, BrojLeta {BrojLeta}, BrojSedista {BrojSedista}, NazivPutnika {NazivPutnika}, KlasaSedista {KlasaSedista}, Kapija {Kapija}, Cena {Cena}, Aktivna {Aktivna}";
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
