using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerodromWPF.Model
{
    public class Let : INotifyPropertyChanged, ICloneable
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

        public Let()
        {
            aktivan = true;
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnProperyChanged("Id"); }
        }

        private string sifra;
        public string Sifra
        {
            get { return sifra; }
            set { sifra = value; OnPropertyChanged("Sifra"); }
        }

        private string pilot;
        public string Pilot
        {
            get { return pilot; }
            set { pilot = value; OnPropertyChanged("Pilot"); }
        }

        private int brojLeta;
        public int BrojLeta
        {
            get { return brojLeta; }
            set { brojLeta = value; OnPropertyChanged("BrojLeta"); }
        }

        private string odrediste;
        public string Odrediste
        {
            get { return odrediste; }
            set { odrediste = value; OnProperyChanged("Odrediste"); }
        }

        private string destinacija;
        public string Destinacija
        {
            get { return destinacija; }
            set { destinacija = value; OnProperyChanged("Destinacija"); }
        }

        private DateTime vremePolaska;
        public DateTime VremePolaska
        {
            get { return vremePolaska; }
            set { vremePolaska = value; OnProperyChanged("Vreme Polaska"); }
        }


        private DateTime vremeDolaska;
        public DateTime VremeDolaska
        {
            get { return vremeDolaska; }
            set { vremeDolaska = value; OnProperyChanged("Vreme Dolaska"); }
        }

        private double cena;
        public double Cena
        {
            get { return cena; }
            set { cena = value; OnPropertyChanged("Cena"); }
        }

        public bool aktivan;
        public bool Aktivan
        {
            get { return aktivan; }
            set { aktivan = value; OnPropertyChanged("Aktivan"); }
        }


        public object Clone()
        {
            return new Let
            {
                Id = this.Id,
                Sifra = this.Sifra,
                Pilot = this.Pilot,
                BrojLeta = this.BrojLeta,
                Destinacija = this.Destinacija,
                Odrediste = this.Odrediste,
                VremePolaska = this.VremePolaska,
                VremeDolaska = this.VremeDolaska,
                Cena = this.Cena,
                Aktivan = this.Aktivan
            };
        }

        public override string ToString()
        {
            return $"Id {Id}, Sifra {Sifra}, Pilot {Pilot}, BrojLeta {BrojLeta}, Destinacija {Destinacija}, Odrediste {Odrediste},Vreme Polaska {vremePolaska}, Vreme Dolaska {VremeDolaska}, Cena {Cena}, Aktivan {Aktivan}";
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