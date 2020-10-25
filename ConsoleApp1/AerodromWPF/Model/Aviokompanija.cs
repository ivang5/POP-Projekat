using AerodromWPF.Database;
using AerodromWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace AerodromWPF.Model
{
    public class Aviokompanija : INotifyPropertyChanged
    {
        public Aviokompanija()
        {
            aktivna = true;
        }

        public int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public string sifra;
        public string Sifra
        {
            get { return sifra; }
            set { sifra = value; OnPropertyChanged("Sifra"); }
        }

        public string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }

        public bool aktivna;
        public bool Aktivna
        {
            get { return aktivna; }
            set { aktivna = value; OnPropertyChanged("Aktivna"); }
        }
        //       public List listaLetova;
        //       public List ListaLetova
        //        {
        //            get { return listaLetova; }
        //            set { listaLetova = value; OnPropertyChanged("ListaLetova"); }
        //        }

        public event PropertyChangedEventHandler PropertyChanged;

 //       public override string ToString()
 //       {
 //           return $"Sifra {Sifra}, ListaLetova {ListaLetova}";
 //       }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
