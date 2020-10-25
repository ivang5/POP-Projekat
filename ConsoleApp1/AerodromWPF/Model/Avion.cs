using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerodromWPF.Model
{
    public class Avion : INotifyPropertyChanged, ICloneable
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

        public Avion()
        {
            aktivan = true;
        }

        private int id;
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

        private int sedistaBiznis;
        public int SedistaBiznis
        {
            get { return sedistaBiznis; }
            set { sedistaBiznis = value; OnProperyChanged("SedistaBiznis"); }
        }

        private int sedistaEkonomska;
        public int SedistaEkonomska
        {
            get { return sedistaEkonomska; }
            set { sedistaEkonomska = value; OnProperyChanged("SedistaEkonomska"); }
        }

        private string nazivAviokompanije;
        public string NazivAviokompanije
        {
            get { return nazivAviokompanije; }
            set { nazivAviokompanije = value; OnProperyChanged("NazivAviokompanije"); }
        }

        public bool aktivan;
        public bool Aktivan
        {
            get { return aktivan; }
            set { aktivan = value; OnPropertyChanged("Aktivan"); }
        }

        public object Clone()
        {
            return new Avion
            {
                Id = this.Id,
                BrojLeta = this.BrojLeta,
                SedistaBiznis = this.SedistaBiznis,
                SedistaEkonomska = this.SedistaEkonomska,
                NazivAviokompanije = this.NazivAviokompanije,
                Aktivan = this.Aktivan
            };
        }

        public override string ToString()
        {
            return $"Id {Id}, BrojLeta {BrojLeta}, SedistaBiznis {SedistaBiznis}, SedistaEkonomska {SedistaEkonomska}, NazivAviokompanije {NazivAviokompanije}, Aktivan {Aktivan}";
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
