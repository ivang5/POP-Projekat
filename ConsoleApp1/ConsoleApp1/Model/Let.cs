using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    class Let
    {
        public String BrojLeta { get; set; }
        public String Odrediste { get; set; }
        public String Destinacija { get; set; }
        public DateTime VremeProlaska { get; set; }
        public DateTime VremeDolaska { get; set; }
        public Double CenaLeta { get; set; }


        public override string ToString()
        {
            return $"Broj leta {BrojLeta}, Odrediste {Odrediste}, Destinacija{Destinacija}";
        }
    }
}
