using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    class Korisnik
    {
        public String KorisnickoIme { get; set; }
        public String Lozinka { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public ETipKorisnika TipKorisnika { get; set; }
        public EPol Pol { get; set; }
        public String Adresa { get; set; }
        public String Email { get; set; }
        public Boolean Active { get; set; }


        public override string ToString()
        {
            return $"Korisnicko ime: {KorisnickoIme}, Tip korisnika: {TipKorisnika}";
        }

        

        
    }
}
