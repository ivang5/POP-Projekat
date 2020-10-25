using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1.Util
{
    class Aplikacija
    {
        public List<Korisnik> Korisnici { get; set; }
        public List<Aerodrom> Aerodromi { get; set; }
        public List<Let> Letovi { get; set; }
        public String UlogovanKorisnik { get; set; }

        private Aplikacija()
        {
            Korisnici = new List<Korisnik>();
            Aerodromi = new List<Aerodrom>();
            Letovi = new List<Let>();
        }

        private static Aplikacija _instance = null;

        public static Aplikacija Instance
        {

            get
            {
                if (_instance == null)
                    _instance = new Aplikacija();
                return _instance;
            }
        }

        public void UcitajSveAerodrome()
        {
            XmlReader reader = XmlReader.Create("..//..//Data//Aerodromi.xml");
            while (reader.Read())
            {
                if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("aerodrom"))
                {
                    string sifra = reader.GetAttribute("sifra");
                    string naziv = reader.GetAttribute("naziv");
                    string grad = reader.GetAttribute("grad");

                    Aerodromi.Add(new Aerodrom { Sifra = sifra, Naziv = naziv, Grad = grad });
                }
            }

            reader.Close();
        }
        
        public void UcitajSveKorisnike()
        {
            Korisnik korisnik1 = new Korisnik();
            korisnik1.Ime = "Jimmy";
            korisnik1.Prezime = "McGill";
            korisnik1.KorisnickoIme = "Jimmy123";
            korisnik1.Lozinka = "Password123";
            korisnik1.TipKorisnika = ETipKorisnika.NEPRIJAVLJEN;
            korisnik1.Adresa = "adresa bb";
            korisnik1.Email = "jimmy@gmail.com";
            korisnik1.Pol = EPol.M;
            korisnik1.Active = true;

            Korisnik korisnik2 = new Korisnik();
            korisnik2.Ime = "Mike";
            korisnik2.Prezime = "Ehrmantraut";
            korisnik2.KorisnickoIme = "Mike123";
            korisnik2.Lozinka = "Password123";
            korisnik2.TipKorisnika = ETipKorisnika.PUTNIK;
            korisnik2.Adresa = "adresa bb";
            korisnik2.Email = "mike@gmail.com";
            korisnik2.Pol = EPol.M;
            korisnik2.Active = true;

            Korisnik korisnik3 = new Korisnik
            {
                Ime = "Gustavo",
                Prezime = "Fring",
                KorisnickoIme = "Gustavo123",
                Lozinka = "Password123",
                TipKorisnika = ETipKorisnika.ADMINISTRATOR,
                Adresa = "adresa bb",
                Email = "gus@gmail.com",
                Pol = EPol.M,
                Active = true
            };
            Korisnici = new List<Korisnik>();

            Korisnici.Add(korisnik1);
            Korisnici.Add(korisnik2);
            Korisnici.Add(korisnik3);
        }

        public void UcitajSveLetove()
        {
            Letovi = new List<Let>();

            Let let1 = new Let
            {
                BrojLeta = "123",
                Odrediste = "BEG",
                Destinacija = "AMS",
                CenaLeta = 13000,
                VremeProlaska = new DateTime(2018, 11, 16, 18, 15, 00),
                VremeDolaska = new DateTime(2018, 11, 16, 20, 15, 00)
            };

            Letovi.Add(let1);
            Letovi.Add(new Let
            {
                BrojLeta = "124",
                Odrediste = "BEG",
                Destinacija = "LON",
                CenaLeta = 18000,
                VremeProlaska = new DateTime(2018, 11, 16, 19, 15, 00),
                VremeDolaska = new DateTime(2018, 11, 16, 21, 45, 00)
            });

            
        }

        public void SacuvajSveAerodrome()
        {
            XmlWriter writer = XmlWriter.Create("..//..//Data//Aerodromi.xml");

            writer.WriteStartElement("aerodromi");
            foreach(Aerodrom aerodrom in Aerodromi)
            {
                writer.WriteStartElement("aerodrom");
                writer.WriteAttributeString("sifra", aerodrom.Sifra);
                writer.WriteAttributeString("naziv", aerodrom.Naziv);
                writer.WriteAttributeString("grad", aerodrom.Grad);
                writer.WriteEndElement();
            }

            writer.WriteEndDocument();
            writer.Close();


        }
    }

    
}
