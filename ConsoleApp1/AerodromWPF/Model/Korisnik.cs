using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerodromWPF.Model
{
    public class Korisnik : INotifyPropertyChanged
    {

        public enum polenum { Musko, Zensko }
        public enum tipenum { Admin, Putnik }

        public Korisnik()
        {
            aktivan = true;
        }

        public int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public string ime;
        public string Ime
        {
            get { return ime; }
            set { ime = value; OnPropertyChanged("Ime"); }
        }

        public string prezime;
        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; OnPropertyChanged("Prezime"); }
        }

        public string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        public string adresa;
        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; OnPropertyChanged("Adresa"); }
        }

        public polenum pol;
        public polenum Pol
        {
            get { return pol; }
            set { pol = value; OnPropertyChanged("Pol"); }
        }



        public string korisnickoIme;
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; OnPropertyChanged("Korisnicko Ime"); }
        }

        public string lozinka;
        public string Lozinka
        {
            get { return lozinka; }
            set { lozinka = value; OnPropertyChanged("Lozinka"); }
        }

        public tipenum tip;
        public tipenum Tip
        {
            get { return tip; }
            set { tip = value; OnPropertyChanged("Tip"); }
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
            return $"Id{Id}, Ime {Ime}, Prezime {Prezime}, Email {Email}, Adresa {Adresa}, Pol {Pol}, Korisnicko Ime {KorisnickoIme}, Lozinka {Lozinka}, Tip {Tip}, Aktivan {Aktivan}";
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
