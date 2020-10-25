using ConsoleApp1.Model;
using ConsoleApp1.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static List<Aerodrom> aerodromi = new List<Aerodrom>();
        private static List<Korisnik> korisnici = new List<Korisnik>();
        private static List<Let> letovi = new List<Let>();

        static void Main(string[] args)
        {
            Aplikacija.Instance.UcitajSveAerodrome();
            Aplikacija.Instance.UcitajSveKorisnike();
            Aplikacija.Instance.UcitajSveLetove();
           

            String opcija = null;
            do
            {

                Console.WriteLine("1. Ispisi sve korisnike ");
                Console.WriteLine("2. Ispisi sve aerodrome ");
                Console.WriteLine("3. Dodavanje aerodroma ");
                Console.WriteLine("4. Modifikovanje aerodroma ");
                Console.WriteLine("5. Brisanje aerodroma ");
                Console.WriteLine("6. Pretraga korisnika po imenu ");
                Console.WriteLine("7. Sortiranje korisnika po imenu (rastuce) ");
                Console.WriteLine("8. Sortiranje korisnika po imenu (opadajuce) ");
                Console.WriteLine("9. Pretraga aerodroma po sifri ");
                Console.WriteLine("10. Registracija ");
                Console.WriteLine("11. Brisanje korisnika ");
                Console.WriteLine("12. Login ");
                Console.WriteLine("13. Logout ");
                Console.WriteLine("14. Izmena sifre ");
                Console.WriteLine("18. Exit");
                Console.WriteLine(">>");

                opcija = Console.ReadLine();

                switch (opcija)
                {
                    case "1":
                        IspisiKorisnike(Aplikacija.Instance.Korisnici);
                        Console.WriteLine("");
                        break;
                    case "2":
                        IspisiAerodrome(Aplikacija.Instance.Aerodromi);
                        Console.WriteLine("");

                        break;
                    case "3":
                        UnosAerodroma();
                        break;
                    case "4":
                        ModifikacijaAerodroma();
                        break;
                    case "5":
                        BrisanjeAerodroma();
                        break;
                    case "6":
                        PretragaKorisnikaPoImenu();
                        break;
                    case "7":
                        SortiranjeKorisnikaPoImenuRastuce();
                        IspisiKorisnike(Aplikacija.Instance.Korisnici);
                        break;
                    case "8":
                        IspisiKorisnike(SortiranjeKorisnikaPoImenuOpadajuce());
                        break;
                    case "9":
                        try
                        {
                            PretragaAerodromaPoSifri();
                        }
                        catch (AirportNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "10":
                        Registracija();
                        break;
                    case "11":
                        BrisanjeKorisnika();
                        break;
                    case "12":
                        Login();
                        break;
                    case "13":
                        Logout();
                        break;
                    case "14":
                        IzmenaSifre();
                        break;
                }

            } while (!opcija.Equals("18"));
        }



        private static void IspisiKorisnike(List<Korisnik> korisnici)
        {
            foreach (Korisnik korisnik in korisnici)
            {
                if (korisnik.Active)
                {
                    Console.WriteLine(korisnik.ToString());
                }
                
            }
        }

        private static void IspisiAerodrome(List<Aerodrom> aerodromi)
        {
            foreach (Aerodrom aerodrom in Aplikacija.Instance.Aerodromi)
            {
                Console.WriteLine(aerodrom.ToString());
            }
        }

        private static void UnosAerodroma()
        {
            Console.Write("Unesi sifru:\n");
            String sifra = Console.ReadLine();
            List<String> listaSifri = new List<String>();
            foreach (var sifrojko in Aplikacija.Instance.Aerodromi)
            {
                listaSifri.Add(sifrojko.Sifra);
            }

            var x = sifra.Length;
            if (x != 3)
            {
                Console.WriteLine("Morate uneti 3 slova za sifru aerodroma! (primer: BEG)");
                return;
            }
            else if (!sifra.All(char.IsUpper))
            {
                Console.WriteLine("Sva slova moraju biti velika! (primer: BEG)");
                return;
            }
            else if (listaSifri.Contains(sifra))
            {
                Console.WriteLine("Sifra vec postoji");
                return;
            }

            Console.Write("Unesi naziv:\n");
            String naziv = Console.ReadLine();
            Console.Write("Unesi grad:\n");
            String grad = Console.ReadLine();

            Aplikacija.Instance.Aerodromi.Add(new Aerodrom
            {
                Sifra = sifra,
                Naziv = naziv,
                Grad = grad
            });
            Console.WriteLine("Uspesno dodat aerodrom!");
            Aplikacija.Instance.SacuvajSveAerodrome();
        }

        private static void ModifikacijaAerodroma()
        {
            Console.Write("Unesi sifru aerodroma koji zelite da modifikujete\n");
            String sifra = Console.ReadLine();

            int indeks = -1;
            for (int i = 0; i < Aplikacija.Instance.Aerodromi.Count; i++)
            {
                if (Aplikacija.Instance.Aerodromi[i].Sifra.Equals(sifra))
                {
                    indeks = i;
                    break;
                }

            }
            if (indeks != -1)
            {
                Console.Write("Unesi novu sifru:\n");
                String novaSifra = Console.ReadLine();
                List<String> listaSifri = new List<String>();
                foreach (var sifrojko in Aplikacija.Instance.Aerodromi)
                {
                    listaSifri.Add(sifrojko.Sifra);
                }

                var x = novaSifra.Length;
                if (x != 3)
                {
                    Console.WriteLine("Morate uneti 3 slova za sifru aerodroma! (primer: BEG)");
                    return;
                }
                else if (!novaSifra.All(char.IsUpper))
                {
                    Console.WriteLine("Sva slova moraju biti velika! (primer: BEG)");
                    return;
                }
                else if (listaSifri.Contains(novaSifra))
                {
                    Console.WriteLine("Sifra vec postoji!");
                    return;
                }


                Console.Write("Unesi novi naziv:\n");
                String noviNaziv = Console.ReadLine();
                Console.Write("Unesi novi grad:\n");
                String noviGrad = Console.ReadLine();
                Aplikacija.Instance.Aerodromi[indeks] = new Aerodrom
                {
                    Sifra = novaSifra,
                    Grad = noviGrad,
                    Naziv = noviNaziv
                };
                Aplikacija.Instance.SacuvajSveAerodrome();
                Console.WriteLine("Uspesno izmenjen aerodrom!");
            }
            else
            {
                Console.WriteLine("Nije pronadjen aerodrom!");
                Console.WriteLine("");
            }
            
        }

        private static void BrisanjeAerodroma()
        {
            Console.WriteLine("Uneti sifru aerodroma koji zelite da obrisete:");
            String sifra = Console.ReadLine();

            Aerodrom obrisiAerodrom = null;
            bool tacnost = false;
            foreach (var aerodrom in Aplikacija.Instance.Aerodromi)
            {
                if (aerodrom.Sifra.Equals(sifra))
                {
                    obrisiAerodrom = aerodrom;
                    
                    Aplikacija.Instance.Aerodromi.Remove(obrisiAerodrom);
                    Console.WriteLine("Uspesno obrisan aerodrom!");
                    Aplikacija.Instance.SacuvajSveAerodrome();
                    tacnost = true;
                    break;
                }
               

            }
            if (!tacnost)
            {
                Console.WriteLine("Nepostojeca sifra aerodroma! ");
                Console.WriteLine("");
                return;
            }

        }

        private static void PretragaKorisnikaPoImenu()
        {
            Console.WriteLine("Uneti ime korisnika: ");
            String ime = Console.ReadLine();
            bool pronadjen = false;
            foreach(Korisnik korisnik in Aplikacija.Instance.Korisnici)
            {
                if(korisnik.Ime == ime)
                {
                    Console.WriteLine(korisnik);
                    Console.WriteLine("");
                    pronadjen = true;
                 
                }

            }
            if (!pronadjen)
            {
                Console.WriteLine("Nije pronadjen nijedan korisnik! ");
                Console.WriteLine("");
            }

        }

        private static void SortiranjeKorisnikaPoImenuRastuce()
        {
            for (int i = 0; i < Aplikacija.Instance.Korisnici.Count; i++)
            {
                for(int j = i; j < Aplikacija.Instance.Korisnici.Count; j++)
                {
                    if (Aplikacija.Instance.Korisnici[i].Ime.CompareTo(Aplikacija.Instance.Korisnici[j].Ime) > 0)
                    {
                        var temp = Aplikacija.Instance.Korisnici[i];
                        Aplikacija.Instance.Korisnici[i] = Aplikacija.Instance.Korisnici[j];
                        Aplikacija.Instance.Korisnici[j] = temp;
                    }
                }
            }
        }

        private static List<Korisnik> SortiranjeKorisnikaPoImenuOpadajuce()
        {
            return Aplikacija.Instance.Korisnici.OrderByDescending(k => k.Ime).ToList();
        }


        private static void PretragaAerodromaPoSifri()
        {
            Console.WriteLine("Uneti sifru aerodroma:  ");
            string sifra = Console.ReadLine();

            Aerodrom aerodrom = null;

            aerodrom = Aplikacija.Instance.Aerodromi.Find(a => a.Sifra.Equals(sifra));

            if(aerodrom == null)
            {
                throw new AirportNotFoundException($"Nije pronadjen nijedan aerodrom sa zadatom sifrom! : {sifra} \n ");
            }
            else
            {
                Console.WriteLine($"Aerodrom: {aerodrom} \n");
            }
        }

        private static void Registracija()
        {
            string username;
            do
            {
                Console.WriteLine("Uneti korisnicko ime: ");
                username = Console.ReadLine();
            } while (Aplikacija.Instance.Korisnici.Find(k => k.KorisnickoIme.Equals(username)) != null);
            
            Console.WriteLine("Uneti sifru: ");
            string sifra = Console.ReadLine();
            Console.WriteLine("Uneti ime: ");
            string ime = Console.ReadLine();
            Console.WriteLine("Uneti Prezime: ");
            string prezime = Console.ReadLine();

            Console.WriteLine("Unesite tip korisnika: ADMINISTRATOR(0), PUTNIK(1)");
            ETipKorisnika tipKorisnika = (ETipKorisnika)int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite pol: MUSKI(0), ZENSKI(1)");
            EPol pol = (EPol)int.Parse(Console.ReadLine());

            Console.WriteLine("Uneti adresu: ");
            string adresa = Console.ReadLine();
            Console.WriteLine("Uneti email: ");
            string email = Console.ReadLine();

            Aplikacija.Instance.Korisnici.Add(new Korisnik
            {
                Active = true,
                Ime = ime,
                Prezime = prezime,
                TipKorisnika = tipKorisnika,
                Pol = pol,
                KorisnickoIme = username,
                Lozinka = sifra,
                Adresa = adresa,
                Email = email
            });
            Console.WriteLine($"Kreiran nov korisnik sa korisnickim imenom {username}");
        }

        private static void BrisanjeKorisnika()
        {
            Console.WriteLine("Unesite korisnicko ime: ");
            string korisnickoIme = Console.ReadLine();

            int index = Aplikacija.Instance.Korisnici.FindIndex(k => k.KorisnickoIme.Equals(korisnickoIme));
            if(index > -1 && Aplikacija.Instance.Korisnici[index].Active)
            {
                Aplikacija.Instance.Korisnici[index].Active = false;
                Console.WriteLine($"Obrisan korisnik! : {Aplikacija.Instance.Korisnici[index]} ");
            }
            else
            {
                Console.WriteLine($"Nije pronadjen nijedan korisnik sa zadatim korisnickim imenom! : {korisnickoIme} ");
            }
            
        }

        private static void Login()
        {
            bool neuspesnologovanje = true;
            do
            {
                Console.WriteLine("Unesite korisnicko ime: ");
                string username = Console.ReadLine();
                Console.WriteLine("Unesite lozinku: ");
                string lozinka = Console.ReadLine();
                
                foreach (Korisnik korisnik in Aplikacija.Instance.Korisnici)
                {
                    if (korisnik.KorisnickoIme.Equals(username) && korisnik.Lozinka.Equals(lozinka))
                    {
                        Aplikacija.Instance.UlogovanKorisnik = username;
                        Console.WriteLine("Uspesno ulogovan korisnik! ");
                        Console.WriteLine("");
                        neuspesnologovanje = false;
                        break;
                    }
                }
            } while (neuspesnologovanje);

        }

        private static void Logout()
        {
            Aplikacija.Instance.UlogovanKorisnik = String.Empty;
            Console.WriteLine("Uspesno izlogovan! ");
        }

        private static void IzmenaSifre()
        {
            string sifra;
            do
            {
                Console.Write("Unesite staru lozinku: ");
                sifra = Console.ReadLine();

            } while (ProveraIspravnostiUlogovanogKorisnika(sifra) == null);

            string novaSifra;
            string novaSifra1;
            do
            {
                Console.WriteLine("Unesite novu lozinku: ");
                novaSifra = Console.ReadLine();
                Console.WriteLine("Unesite novu lozinku jos jednom: ");
                novaSifra1 = Console.ReadLine();
            } while (!novaSifra.Equals(novaSifra1));

            int index = Aplikacija.Instance.Korisnici.FindIndex(k => k.KorisnickoIme.Equals(Aplikacija.Instance.UlogovanKorisnik));
            Aplikacija.Instance.Korisnici[index].Lozinka = novaSifra;
            Console.WriteLine("Uspesno izmenjena sifra! ");
            
        }

        private static Korisnik ProveraIspravnostiUlogovanogKorisnika(string sifra)
        {
            return Aplikacija.Instance.Korisnici.Find(k => k.KorisnickoIme.Equals(Aplikacija.Instance.UlogovanKorisnik) && k.Lozinka.Equals(sifra));
        }
    }

   
}
















