using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerodromWPF.Model
{
    class Sediste
    {
        public enum klasaenum { Biznis, Ekonomska }
        public enum stanjeenum { Slobodno, Zauzeto}
        

        public int brojReda;
        public int BrojReda
        {
            get { return brojReda; }
            set { brojReda = value; OnPropertyChanged("BrojReda"); }
        }

        public int brojKolone;
        public int BrojKolone
        {
            get { return brojKolone; }
            set { brojKolone = value; OnPropertyChanged("BrojKolone"); }
        }

        public klasaenum klasa;
        public klasaenum Klasa
        {
            get { return klasa; }
            set { klasa = value; OnPropertyChanged("Klasa"); }
        }

        public stanjeenum stanje;
        public stanjeenum Stanje
        {
            get { return stanje; }
            set { stanje = value; OnPropertyChanged("Stanje"); }
        }

        public int idAviona;
        public int IdAviona
        {
            get { return idAviona; }
            set { idAviona = value; OnPropertyChanged("IdAviona"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"BrojReda {BrojReda}, BrojKolone {BrojKolone}, Klasa {Klasa}, Stanje {Stanje}, IdAviona {IdAviona}";
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
