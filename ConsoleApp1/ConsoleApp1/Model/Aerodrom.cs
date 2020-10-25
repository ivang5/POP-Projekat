using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    class Aerodrom
    {
        public String Sifra { get; set; }
        public String Naziv { get; set; }
        public String Grad { get; set; }

        public override string ToString()
        {
            return $"Sifra {Sifra}, Naziv {Naziv}, Grad {Grad}";
        }
    }
}
