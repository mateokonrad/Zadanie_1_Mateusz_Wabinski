// Mateusz Wabinski_2_rok_4_semestr_nr_indeksu_146326_Grupa_D1

using System;

namespace Samochody
{
    internal static class Samochody
    {
        internal static void Main()
        {
            Samochod s1 = new Samochod();
            s1.Marka = "Porsche";
            s1.Model = "911";
            s1.IloscDrzwi = 2;
            s1.PojemnoscSilnika = 3996;
            s1.SrednieSpalanie = 20;
            s1.NumerRejestracyjny = "AAA-00AA";
            Samochod s2 = new Samochod("Fiat", "126p", 2, 650, 6.0, "BBB-00BB");
            Samochod s3 = new Samochod("Samochod", "Nieznany", 2, 650, 6.0, "CCC-00CC");
            Samochod s4 = new Samochod("Samochod", "Inny", 2, 650, 6.0, "DDD-00DD");

            Osoba o1 = new Osoba("Jan", "Nowak", "Jakieś miasto, ulica 10/12", 0);

            o1.DodajSamochod(s1.NumerRejestracyjny);
            o1.DodajSamochod(s2.NumerRejestracyjny);
            o1.DodajSamochod(s3.NumerRejestracyjny);
            o1.DodajSamochod(s4.NumerRejestracyjny);

            o1.WypiszInfo();

            o1.UsunSamochod(s2.NumerRejestracyjny);

            o1.WypiszInfo();

            Console.ReadKey();
        }
    }

    public class Osoba
    {
        private string imie;
        private string nazwisko;
        private string adresZamieszkania;
        private int iloscSamochodow = 0;

        private readonly string[] numeryRejestracyjne;

        public Osoba() : this("nieznane", "nieznane", "nieznany", 0) { }

        public Osoba(string imie_, string nazwisko_, string adresZamieszkania_, int iloscSamochodow_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
            adresZamieszkania = adresZamieszkania_;
            iloscSamochodow = iloscSamochodow_;

            numeryRejestracyjne = new string[3];

            for (int j = 0; j < numeryRejestracyjne.Length; j++)
                numeryRejestracyjne[j] = null;
        }

        public void WypiszInfo()
        {
            Console.WriteLine($"\nImie: {imie}\nNazwisko: {nazwisko}\nAdres zamieszkania: {adresZamieszkania}\nIlosc samochodow: {iloscSamochodow}");

            for (int i = 0; i < numeryRejestracyjne.Length; i++)
                if (numeryRejestracyjne[i] != null)
                    Console.WriteLine($"Numer rejestracyjny: {numeryRejestracyjne[i]}");
        }

        public void DodajSamochod(string numerRejestracyjny)
        {
            if (iloscSamochodow == 3)
            {
                Console.WriteLine("Limit samochodów na osobę został przekroczony.");
                return;
            }

            for (int i = 0; i < numeryRejestracyjne.Length; i++)
                if (numeryRejestracyjne[i] == null)
                {
                    numeryRejestracyjne[i] = numerRejestracyjny;
                    iloscSamochodow++;
                    return;
                }
        }

        public void UsunSamochod(string numerRejestracyjny)
        {
            for (int i = 0; i < numeryRejestracyjne.Length; i++)
                if (numeryRejestracyjne[i].Equals(numerRejestracyjny))
                {
                    numeryRejestracyjne[i] = null;
                    iloscSamochodow--;
                    return;
                }
        }

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }
        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }
        public string AdresZamieszkania
        {
            get { return adresZamieszkania; }
            set { adresZamieszkania = value; }
        }
        public int IloscSamochodow
        {
            get { return iloscSamochodow; }
        }
    }

    public class Samochod
    {
        private string marka;
        private string model;
        private int iloscDrzwi;
        private int pojemnoscSilnika;
        private double srednieSpalanie;
        private string numerRejestracyjny;
        private static int iloscSamochodow = 0;

        public Samochod()
        {
            marka = "nieznana";
            model = "nieznany";
            iloscDrzwi = 0;
            pojemnoscSilnika = 0;
            srednieSpalanie = 0;
            iloscSamochodow = iloscSamochodow + 1;
            numerRejestracyjny = "nieznany";
        }

        public Samochod(string _marka, string _model, int _iloscDrzwi, int _pojemnoscSilnika, double _srednieSpalanie, string _numerRejestracyjny)
        {
            marka = _marka;
            model = _model;
            iloscDrzwi = _iloscDrzwi;
            pojemnoscSilnika = _pojemnoscSilnika;
            srednieSpalanie = _srednieSpalanie;
            iloscSamochodow += 1;
            numerRejestracyjny = _numerRejestracyjny;
        }

        private double ObliczSpalanie(double dlugoscTrasy)
        {
            double spalanie = (srednieSpalanie * dlugoscTrasy) / 100;
            return spalanie;
        }

        public double ObliczKosztPrzejazdu(double dlugoscTrasy, double cenaPaliwa)
        {
            double kosztPrzejazdu = ObliczSpalanie(dlugoscTrasy) * cenaPaliwa;
            return kosztPrzejazdu;
        }

        public void WpiszInfo()
        {
            Console.WriteLine("Marka: " + marka);
            Console.WriteLine("Model: " + model);
            Console.WriteLine("Ilosc Drzwi: " + iloscDrzwi);
            Console.WriteLine("pojemnosc silnika: " + pojemnoscSilnika);
            Console.WriteLine("Srednie spalanie: " + srednieSpalanie);
        }

        public static void WypiszIloscSamochodow()
        {
            Console.WriteLine("Ilosc samochodów " + iloscSamochodow);
        }

        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int IloscDrzwi
        {
            get { return iloscDrzwi; }
            set { iloscDrzwi = value; }
        }

        public int PojemnoscSilnika
        {
            get { return pojemnoscSilnika; }
            set { pojemnoscSilnika = value; }
        }

        public double SrednieSpalanie
        {
            get { return srednieSpalanie; }
            set { srednieSpalanie = value; }
        }

        public string NumerRejestracyjny
        {
            get { return numerRejestracyjny; }
            set { numerRejestracyjny = value; }
        }
    }
}
