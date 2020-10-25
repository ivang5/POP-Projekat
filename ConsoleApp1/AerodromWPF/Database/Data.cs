using AerodromWPF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml;
using static AerodromWPF.Model.Karta;
using static AerodromWPF.Model.Korisnik;

namespace AerodromWPF.Database
{
    class Data
    {
        public List<Korisnik> Korisnici { get; set; }
        public List<Aerodrom> Aerodromi { get; set; }
        public List<Let> Letovi { get; set; }
        public List<Aviokompanija> Aviokompanije { get; set; }
        public List<Let> AviokompanijeLetovi { get; set; }
        public List<Avion> Avioni { get; set; }
        public List<Sediste> Sedista { get; set; }
        public List<Sediste> SedistaAvion { get; set; }
        public List<Karta> Karte { get; set; }
        public List<Karta> PutnikKarte { get; set; }
        public Korisnik UlogovanKorisnik { get; set; }

        string sql = null;
        public const String CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pecar\Desktop\ja\pop-2018-sf-30-2017\ConsoleApp1\AerodromWPF\Database.mdf;Integrated Security=True";

        public Data()
        {
            Korisnici = new List<Korisnik>();
            Aerodromi = new List<Aerodrom>();
            Letovi = new List<Let>();
            Aviokompanije = new List<Aviokompanija>();
            AviokompanijeLetovi = new List<Let>();
            Avioni = new List<Avion>();
            Sedista = new List<Sediste>();
            SedistaAvion = new List<Sediste>();
            Karte = new List<Karta>();
            PutnikKarte = new List<Karta>();
            UcitajSveAerodrome();
            UcitajSveLetove();
            UcitajSveKorisnike();
            UcitajSveAviokompanije();
            UcitajSveKarte();
            UcitajSveAvione();
        }

        private static Data _instance = null;
        public static Data Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Data();
                return _instance;
            }
        }


        //static private string GetConnectionString()
        //{
        //    return "Data Source=MSSQL1;Initial Catalog=AdventureWorks;"
        //        + "Integrated Security=true;";
        //}

        //string connectionString = GetConnectionString();

        public void UcitajSveAerodrome()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Aerodromi.Clear();
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM Aerodromi WHERE aktivan=1";
                SqlDataAdapter daAerodromi = new SqlDataAdapter();
                DataSet dsAerodromi = new DataSet();
                daAerodromi.SelectCommand = command;
                daAerodromi.Fill(dsAerodromi, "Aerodromi");
                foreach (DataRow row in dsAerodromi.Tables["Aerodromi"].Rows)
                {
                    Aerodrom aerodrom = new Aerodrom();
                    aerodrom.Id = (int)row["Id"];
                    aerodrom.Sifra = (string)row["Sifra"];
                    aerodrom.Naziv = (string)row["Naziv"];
                    aerodrom.Grad = (string)row["Grad"];
                    aerodrom.Aktivan = (bool)row["Aktivan"];
                    Aerodromi.Add(aerodrom);
                }
            }
        }
        
        public void UcitajSveLetove()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Letovi.Clear();
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM Letovi WHERE aktivan=1";
                SqlDataAdapter daLetovi = new SqlDataAdapter();
                DataSet dsLetovi = new DataSet();
                daLetovi.SelectCommand = command;
                daLetovi.Fill(dsLetovi, "Letovi");
                foreach (DataRow row in dsLetovi.Tables["Letovi"].Rows)
                {
                    Let let = new Let();
                    let.Id = (int)row["Id"];
                    let.Sifra = (string)row["Sifra"];
                    let.Pilot = (string)row["Pilot"];
                    let.BrojLeta = (int)row["BrojLeta"];
                    let.Odrediste = (string)row["Odrediste"];
                    let.Destinacija = (string)row["Destinacija"];
                    let.VremePolaska = (DateTime)Convert.ToDateTime(row["VremePolaska"]);
                    let.VremeDolaska = (DateTime)Convert.ToDateTime(row["VremeDolaska"]);
                    let.Cena = (double)Convert.ToDouble(row["Cena"]);
                    let.Aktivan = (bool)row["Aktivan"];
                    Letovi.Add(let);
                }
            }
        }


        public void UcitajSveKorisnike()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Korisnici.Clear();
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM Korisnici WHERE aktivan=1";
                SqlDataAdapter daKorisnici = new SqlDataAdapter();
                DataSet dsKorisnici = new DataSet();
                daKorisnici.SelectCommand = command;
                daKorisnici.Fill(dsKorisnici, "Korisnici");
                foreach (DataRow row in dsKorisnici.Tables["Korisnici"].Rows)
                {
                    Korisnik korisnik = new Korisnik();
                    korisnik.Id = (int)row["Id"];
                    korisnik.Ime = (string)row["Ime"];
                    korisnik.Prezime = (string)row["Prezime"];
                    korisnik.Email = (string)row["Email"];
                    korisnik.Adresa = (string)row["Adresa"];
                    korisnik.Pol = (polenum)Enum.Parse(typeof(polenum), row["Pol"].ToString());
                    korisnik.KorisnickoIme = (string)row["KorisnickoIme"];
                    korisnik.Lozinka = (string)row["Lozinka"];
                    korisnik.Tip = (tipenum)Enum.Parse(typeof(tipenum), row["Tip"].ToString());
                    korisnik.Aktivan = (bool)row["Aktivan"];
                    Korisnici.Add(korisnik);
                }
            }
        }


        public void UcitajSveAviokompanije()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Aviokompanije.Clear();
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM Aviokompanije WHERE aktivan=1";
                SqlDataAdapter daAviokompanije = new SqlDataAdapter();
                DataSet dsAviokompanije = new DataSet();
                daAviokompanije.SelectCommand = command;
                daAviokompanije.Fill(dsAviokompanije, "Aviokompanije");
                foreach (DataRow row in dsAviokompanije.Tables["Aviokompanije"].Rows)
                {
                    Aviokompanija aviokompanija = new Aviokompanija();
                    aviokompanija.Id = (int)row["Id"];
                    aviokompanija.Sifra = (string)row["Sifra"];
                    aviokompanija.Naziv = (string)row["Naziv"];
                    aviokompanija.Aktivna = (bool)row["Aktivan"];
                    Aviokompanije.Add(aviokompanija);
                }
            }
        }


        public void UcitajSveAvione()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Avioni.Clear();
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM Avioni WHERE aktivan=1";
                SqlDataAdapter daAvioni = new SqlDataAdapter();
                DataSet dsAvioni = new DataSet();
                daAvioni.SelectCommand = command;
                daAvioni.Fill(dsAvioni, "Avioni");
                foreach (DataRow row in dsAvioni.Tables["Avioni"].Rows)
                {
                    Avion avion = new Avion();
                    avion.Id = (int)row["Id"];
                    avion.BrojLeta = (int)row["BrojLeta"];
                    avion.SedistaBiznis = (int)row["SedistaBiznis"];
                    avion.SedistaEkonomska = (int)row["SedistaEkonomska"];
                    avion.NazivAviokompanije = (string)row["NazivAviokompanije"];
                    avion.Aktivan = (bool)row["Aktivan"];
                    Avioni.Add(avion);
                    //PRAVLJENJE SEDISTA U AVIONU
                    int brojKolone = 0;
                    int brojReda = 1;
                    for (int i = 0; i < avion.SedistaBiznis; i++)
                    {
                        brojKolone += 1;
                        if (brojKolone > 6)
                        {
                            brojReda += 1;
                            brojKolone = 1;
                        }
                        bool sediste = false;
                        foreach (var karta in Karte)
                            if(karta.BrojLeta == avion.BrojLeta && karta.BrojSedista.Trim() == brojReda.ToString() + "-" + brojKolone.ToString())
                            {
                                sediste = true;
                            }
                        if (sediste == true)
                        {
                            Sedista.Add(new Sediste { BrojReda = brojReda, BrojKolone = brojKolone, Klasa = Sediste.klasaenum.Biznis, Stanje = Sediste.stanjeenum.Zauzeto, IdAviona = avion.Id });
                        }
                        else
                        {
                            Sedista.Add(new Sediste { BrojReda = brojReda, BrojKolone = brojKolone, Klasa = Sediste.klasaenum.Biznis, Stanje = Sediste.stanjeenum.Slobodno, IdAviona = avion.Id });
                        }
                    }
                    for (int i = 0; i < avion.SedistaEkonomska; i++)
                    {
                        brojKolone += 1;
                        if (brojKolone > 6)
                        {
                            brojReda += 1;
                            brojKolone = 1;
                        }
                        bool sediste = false;
                        foreach (var karta in Karte)
                            if (karta.BrojLeta == avion.BrojLeta && karta.BrojSedista.Trim() == brojReda.ToString() + "-" + brojKolone.ToString())
                            {
                                sediste = true;
                            }
                        if (sediste == true)
                        {
                            Sedista.Add(new Sediste { BrojReda = brojReda, BrojKolone = brojKolone, Klasa = Sediste.klasaenum.Ekonomska, Stanje = Sediste.stanjeenum.Zauzeto, IdAviona = avion.Id });
                        }
                        else
                        {
                            Sedista.Add(new Sediste { BrojReda = brojReda, BrojKolone = brojKolone, Klasa = Sediste.klasaenum.Ekonomska, Stanje = Sediste.stanjeenum.Slobodno, IdAviona = avion.Id });
                        }
                    }
                }
            }
        }


        public void UcitajSveKarte()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Karte.Clear();
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM Karte WHERE aktivan=1";
                SqlDataAdapter daKarte = new SqlDataAdapter();
                DataSet dsKarte = new DataSet();
                daKarte.SelectCommand = command;
                daKarte.Fill(dsKarte, "Karte");
                foreach (DataRow row in dsKarte.Tables["Karte"].Rows)
                {
                    Karta karta = new Karta();
                    karta.Id = (int)row["Id"];
                    karta.BrojLeta = (int)row["BrojLeta"];
                    karta.BrojSedista = (string)row["BrojSedista"];
                    karta.NazivPutnika = (string)row["NazivPutnika"];
                    karta.KlasaSedista = (klasaenum)Enum.Parse(typeof(klasaenum), row["KlasaSedista"].ToString());
                    karta.Kapija = (int)row["Kapija"];
                    karta.Cena = (double)Convert.ToDouble(row["Cena"]);
                    karta.Aktivna = (bool)row["Aktivan"];
                    Karte.Add(karta);
                }
            }
        }


        public void UcitajSvePutnikKarte()
        {
            foreach(Karta karta in Karte)
            {
                if (karta.NazivPutnika.Trim() == UlogovanKorisnik.KorisnickoIme.Trim())
                {
                    PutnikKarte.Add(karta);
                }
            }
        }


        //OVO MI VISE NE TREBA

        //public void SacuvajSveAerodrome()
        //{
        //    XmlWriter writer = XmlWriter.Create("..//..//Data//Aerodromi.xml");

        //    writer.WriteStartElement("aerodromi");
        //    foreach (Aerodrom aerodrom in Aerodromi)
        //    {
        //        writer.WriteStartElement("aerodrom");
        //        writer.WriteAttributeString("sifra", aerodrom.Sifra);
        //        writer.WriteAttributeString("naziv", aerodrom.Naziv);
        //        writer.WriteAttributeString("grad", aerodrom.Grad);
        //        writer.WriteAttributeString("aktivan", aerodrom.Aktivan.ToString());
        //        writer.WriteEndElement();
        //    }

        //    writer.WriteEndDocument();
        //    writer.Close();

        //}


        //public void SacuvajSveLetove()
        //{
        //    XmlWriter writer = XmlWriter.Create("..//..//Data//Letovi.xml");

        //    writer.WriteStartElement("letovi");
        //    foreach (Let let in Letovi)
        //    {
        //        writer.WriteStartElement("let");
        //        writer.WriteAttributeString("sifra", let.Sifra);
        //        writer.WriteAttributeString("brojLeta", let.BrojLeta.ToString());
        //        writer.WriteAttributeString("vremePolaska", let.VremePolaska.ToString());
        //        writer.WriteAttributeString("vremeDolaska", let.VremeDolaska.ToString());
        //        writer.WriteAttributeString("cena", let.Cena.ToString());
        //        writer.WriteAttributeString("odrediste", let.Odrediste);
        //        writer.WriteAttributeString("destinacija", let.Destinacija);
        //        writer.WriteEndElement();
        //    }

        //    writer.WriteEndDocument();
        //    writer.Close();

        //}


        //public void SacuvajSveKorisnike()
        //{
        //    XmlWriter writer = XmlWriter.Create("..//..//Data//Korisnici.xml");

        //    writer.WriteStartElement("korisnici");
        //    foreach (Korisnik korisnik in Korisnici)
        //    {
        //        writer.WriteStartElement("korisnik");
        //        writer.WriteAttributeString("ime", korisnik.Ime);
        //        writer.WriteAttributeString("prezime", korisnik.Prezime);
        //        writer.WriteAttributeString("email", korisnik.Email);
        //        writer.WriteAttributeString("adresa", korisnik.Adresa);
        //        writer.WriteAttributeString("pol", korisnik.Pol.ToString());
        //        writer.WriteAttributeString("korisnickoIme", korisnik.KorisnickoIme);
        //        writer.WriteAttributeString("lozinka", korisnik.Lozinka);
        //        writer.WriteAttributeString("tip", korisnik.Tip.ToString());
        //        writer.WriteEndElement();
        //    }

        //    writer.WriteEndDocument();
        //    writer.Close();

        //}


        //public void SacuvajSveAviokompanije()
        //{
        //    XmlWriter writer = XmlWriter.Create("..//..//Data//Aviokompanije.xml");

        //    writer.WriteStartElement("aviokompanije");
        //    foreach (Aviokompanija aviokompanija in Aviokompanije)
        //    {
        //        writer.WriteStartElement("aviokompanija");
        //        writer.WriteAttributeString("sifra", aviokompanija.Sifra);
        //        writer.WriteAttributeString("naziv", aviokompanija.Naziv);
        //        writer.WriteEndElement();
        //    }

        //    writer.WriteEndDocument();
        //    writer.Close();

        //}


        //public void SacuvajSveAvione()
        //{
        //    XmlWriter writer = XmlWriter.Create("..//..//Data//Avioni.xml");

        //    writer.WriteStartElement("avioni");
        //    foreach (Avion avion in Avioni)
        //    {
        //        writer.WriteStartElement("avion");
        //        writer.WriteAttributeString("pilot", avion.Pilot);
        //        writer.WriteAttributeString("brojLeta", avion.BrojLeta.ToString());
        //        writer.WriteAttributeString("sedistaBiznis", avion.SedistaBiznis.ToString());
        //        writer.WriteAttributeString("sedistaEkonomska", avion.SedistaEkonomska.ToString());
        //        writer.WriteAttributeString("naziv", avion.NazivAviokompanije);
        //        writer.WriteEndElement();
        //    }

        //    writer.WriteEndDocument();
        //    writer.Close();

        //}


        //public void SacuvajSveKarte()
        //{
        //    XmlWriter writer = XmlWriter.Create("..//..//Data//Karte.xml");

        //    writer.WriteStartElement("karte");
        //    foreach (Karta karta in Karte)
        //    {
        //        writer.WriteStartElement("karta");
        //        writer.WriteAttributeString("brojLeta", karta.BrojLeta.ToString());
        //        writer.WriteAttributeString("brojSedista", karta.BrojSedista);
        //        writer.WriteAttributeString("nazivPutnika", karta.NazivPutnika);
        //        writer.WriteAttributeString("klasaSedista", karta.KlasaSedista.ToString());
        //        writer.WriteAttributeString("kapija", karta.Kapija);
        //        writer.WriteAttributeString("cena", karta.Cena.ToString());
        //        writer.WriteEndElement();
        //    }

        //    writer.WriteEndDocument();
        //    writer.Close();

        //}

    }
            
}
