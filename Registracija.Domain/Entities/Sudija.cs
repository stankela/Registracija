using Registracija.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registracija.Domain
{
    public class Sudija : DomainObject
    {
        private static readonly int IME_MAX_LENGTH = 32;
        private static readonly int PREZIME_MAX_LENGTH = 32;
        private static readonly int REG_BROJ_MAX_LENGTH = 16;
        private static readonly int ADRESA_MAX_LENGTH = 64;
        private static readonly int MESTO_MAX_LENGTH = 32;
        private static readonly int TELEFON_MAX_LENGTH = 16;
        private static readonly int EMAIL_MAX_LENGTH = 64;
        private static readonly int FILE_NAME_MAX_LENGTH = 64;
        private static readonly int POSLEDNJE_SUD_ZVANJE_MAX_LENGTH = 64;
        private static readonly int NIVO_SUD_ZVANJA_MAX_LENGTH = 32;

        private string ime;
        public virtual string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        private string prezime;
        public virtual string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        private Pol pol;
        public virtual Pol Pol
        {
            get { return pol; }
            set { pol = value; }
        }

        private Klub klub;
        public virtual Klub Klub
        {
            get { return klub; }
            set { klub = value; }
        }

        private Nullable<DateTime> datumRodjenja;
        public virtual Nullable<DateTime> DatumRodjenja
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value; }
        }

        private string jmbg;
        public virtual string JMBG
        {
            get { return jmbg; }
            set { jmbg = value; }
        }

        private string registarskiBroj;
        public virtual string RegistarskiBroj
        {
            get { return registarskiBroj; }
            set { registarskiBroj = value; }
        }

        private string adresa;
        public virtual string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

        private string mesto;
        public virtual string Mesto
        {
            get { return mesto; }
            set { mesto = value; }
        }

        private string telefon1;
        public virtual string Telefon1
        {
            get { return telefon1; }
            set { telefon1 = value; }
        }

        private string telefon2;
        public virtual string Telefon2
        {
            get { return telefon2; }
            set { telefon2 = value; }
        }

        private string email;
        public virtual string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string fotoFile;
        public virtual string FotoFile
        {
            get { return fotoFile; }
            set { fotoFile = value; }
        }

        public virtual bool ImaFoto
        {
            get { return !String.IsNullOrEmpty(FotoFile); }
        }

        private string izvorMKRFile;
        public virtual string IzvodMKRFile
        {
            get { return izvorMKRFile; }
            set { izvorMKRFile = value; }
        }

        public virtual bool ImaIzvodMKR
        {
            get { return !String.IsNullOrEmpty(IzvodMKRFile); }
        }

        private string poslednjeSudijskoZvanje;
        public virtual string PoslednjeSudijskoZvanje
        {
            get { return poslednjeSudijskoZvanje; }
            set { poslednjeSudijskoZvanje = value; }
        }

        private string nivoSudijskogZvanja;
        public virtual string NivoSudijskogZvanja
        {
            get { return nivoSudijskogZvanja; }
            set { nivoSudijskogZvanja = value; }
        }

        Nullable<short> godinaPoslednjegSudijskogZvanja;
        public virtual Nullable<short> GodinaPoslednjegSudijskogZvanja
        {
            get { return godinaPoslednjegSudijskogZvanja; }
            set { godinaPoslednjegSudijskogZvanja = value; }
        }

        Nullable<short> godinaPrvogSudijskogZvanja;
        public virtual Nullable<short> GodinaPrvogSudijskogZvanja
        {
            get { return godinaPrvogSudijskogZvanja; }
            set { godinaPrvogSudijskogZvanja = value; }
        }

        public Sudija()
        { 
        
        }

        public override string ToString()
        {
            return Ime + ' ' + Prezime;
        }

        public override void validate(Notification notification)
        {
            // validate Ime
            if (string.IsNullOrEmpty(Ime))
            {
                notification.RegisterMessage(
                    "Ime", "Ime sudije je obavezno.");
            }
            else if (Ime.Length > IME_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Ime", "Ime sudije moze da sadrzi maksimalno "
                    + IME_MAX_LENGTH + " znakova.");
            }

            // validate Prezime
            if (string.IsNullOrEmpty(Prezime))
            {
                notification.RegisterMessage(
                    "Prezime", "Prezime sudije je obavezno.");
            }
            else if (Prezime.Length > PREZIME_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Prezime", "Prezime sudije moze da sadrzi maksimalno "
                    + PREZIME_MAX_LENGTH + " znakova.");
            }

            // validate Pol
            if (Pol != Pol.Muski && Pol != Pol.Zenski)
            {
                notification.RegisterMessage(
                    "Pol", "Neispravna vrednost za pol.");
            }

            // validate JMBG
            if (!string.IsNullOrEmpty(JMBG) && JMBG.Length != 13)
            {
                notification.RegisterMessage(
                    "JMBG", "JMBG mora da sadrzi 13 brojeva.");
            }

            // validate RegBroj
            if (!string.IsNullOrEmpty(RegistarskiBroj) && RegistarskiBroj.Length > REG_BROJ_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "RegistarskiBroj", "Registarski broj moze da sadrzi maksimalno "
                    + REG_BROJ_MAX_LENGTH + " znakova.");
            }

            // validate Adresa
            if (!string.IsNullOrEmpty(Adresa)
            && Adresa.Length > ADRESA_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Adresa", "Adresa moze da sadrzi maksimalno "
                    + ADRESA_MAX_LENGTH + " znakova.");
            }

            // validate Mesto
            if (!string.IsNullOrEmpty(Mesto)
            && Mesto.Length > MESTO_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Mesto", "Mesto moze da sadrzi maksimalno "
                    + MESTO_MAX_LENGTH + " znakova.");
            }

            // validate Telefon1
            if (!string.IsNullOrEmpty(Telefon1)
            && Telefon1.Length > TELEFON_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Telefon1", "Telefon moze da sadrzi maksimalno "
                    + TELEFON_MAX_LENGTH + " znakova.");
            }

            // validate Telefon2
            if (!string.IsNullOrEmpty(Telefon2)
            && Telefon2.Length > TELEFON_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Telefon2", "Telefon moze da sadrzi maksimalno "
                    + TELEFON_MAX_LENGTH + " znakova.");
            }

            // validate Email
            if (!string.IsNullOrEmpty(Email)
            && Email.Length > EMAIL_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Email", "E-mail moze da sadrzi maksimalno "
                    + EMAIL_MAX_LENGTH + " znakova.");
            }

            // validate FotoFile
            if (!string.IsNullOrEmpty(FotoFile)
            && FotoFile.Length > FILE_NAME_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "FotoFile", "Ime fajla sa fotografijom moze da sadrzi maksimalno "
                    + FILE_NAME_MAX_LENGTH + " znakova.");
            }

            // validate IzvodMKRFile
            if (!string.IsNullOrEmpty(IzvodMKRFile)
            && IzvodMKRFile.Length > FILE_NAME_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "IzvodMKRFile", "Ime fajla sa izvodom iz MKR moze da sadrzi maksimalno "
                    + FILE_NAME_MAX_LENGTH + " znakova.");
            }

            // validate PoslednjeSudijskoZvanje
            if (!string.IsNullOrEmpty(PoslednjeSudijskoZvanje)
            && PoslednjeSudijskoZvanje.Length > POSLEDNJE_SUD_ZVANJE_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "PoslednjeSudijskoZvanje", "Poslednje steceno sudijsko zvanje moze da sadrzi maksimalno "
                    + POSLEDNJE_SUD_ZVANJE_MAX_LENGTH + " znakova.");
            }

            // validate NivoSudijskogZvanja
            if (!string.IsNullOrEmpty(NivoSudijskogZvanja)
            && NivoSudijskogZvanja.Length > NIVO_SUD_ZVANJA_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "NivoSudijskogZvanja", "Nivo stecenog sudijskog zvanja moze da sadrzi maksimalno "
                    + NIVO_SUD_ZVANJA_MAX_LENGTH + " znakova.");
            }
        }

        // NOTE: Metodi Equals i GetHashCode su mi trebali prilikom parsiranja
        // fajla sa rasporedom sudija (sudije sam stavljao u ISet, a on
        // zahteva ove metode)
        public override bool Equals(object other)
        {
            if (object.ReferenceEquals(this, other)) return true;
            if (!(other is Sudija)) return false;
            Sudija that = (Sudija)other;
            return this.Ime.ToUpper() == that.Ime.ToUpper()
                && this.Prezime.ToUpper() == that.Prezime.ToUpper();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 14;
                result = 29 * result + Ime.GetHashCode();
                result = 29 * result + Prezime.GetHashCode();
                return result;
            }
        }
    }
}
