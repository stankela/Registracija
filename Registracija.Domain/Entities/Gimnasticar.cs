using Registracija.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registracija.Domain
{
    public class Gimnasticar : DomainObject
    {
        private static readonly int IME_MAX_LENGTH = 32;
        private static readonly int SR_IME_MAX_LENGTH = 32;
        private static readonly int PREZIME_MAX_LENGTH = 32;
        private static readonly int REG_BROJ_MAX_LENGTH = 16;
        private static readonly int ADRESA_MAX_LENGTH = 64;
        private static readonly int MESTO_MAX_LENGTH = 32;
        private static readonly int TELEFON_MAX_LENGTH = 16;
        private static readonly int EMAIL_MAX_LENGTH = 64;
        private static readonly int FOTO_FILE_MAX_LENGTH = 64;
        
        private string ime;
        public virtual string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        private string srednjeIme;
        public virtual string SrednjeIme
        {
            get { return srednjeIme; }
            set { srednjeIme = value; }
        }

        private string prezime;
        public virtual string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        private Datum datumRodjenja;
        public virtual Datum DatumRodjenja
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

        private Gimnastika gimnastika;
        public virtual Gimnastika Gimnastika
        {
            get { return gimnastika; }
            set { gimnastika = value; }
        }

        private KategorijaGimnasticara kategorija;
        public virtual KategorijaGimnasticara Kategorija
        {
            get { return kategorija; }
            set { kategorija = value; }
        }

        private Klub klub;
        public virtual Klub Klub
        {
            get { return klub; }
            set { klub = value; }
        }

        private string registarskiBroj;
        public virtual string RegistarskiBroj
        {
            get { return registarskiBroj; }
            set { registarskiBroj = value; }
        }

        private Datum datumPoslednjeRegistracije;
        public virtual Datum DatumPoslednjeRegistracije
        {
            get { return datumPoslednjeRegistracije; }
            set { datumPoslednjeRegistracije = value; }
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

        private bool imaFoto;
        public virtual bool ImaFoto
        {
            get { return !String.IsNullOrEmpty(fotoFile); }
        }

        public Gimnasticar()
        { 
        
        }

        public virtual string ImeSrednjeIme
        {
            get
            {
                string result = Ime;
                if (!String.IsNullOrEmpty(SrednjeIme))
                    result += ' ' + SrednjeIme;
                return result;
            }
        }

        public virtual string ImeSrednjeImePrezime
        {
            get
            {
                return ImeSrednjeIme + ' ' + Prezime;
            }
        }

        public virtual string ImeSrednjeImePrezimeDatumRodjenja
        {
            get
            {
                string result = ImeSrednjeImePrezime;
                if (DatumRodjenja != null)
                {
                    result += ", " + DatumRodjenja.ToString("dd.MM.yyyy");
                }
                return result;
            }
        }

        public override string ToString()
        {
            return ImeSrednjeImePrezime;
        } 

        public override void validate(Notification notification)
        {
            // validate Ime
            if (string.IsNullOrEmpty(Ime))
            {
                notification.RegisterMessage(
                    "Ime", "Ime gimnasticara je obavezno.");
            }
            else if (Ime.Length > IME_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Ime", "Ime gimnasticara moze da sadrzi maksimalno "
                    + IME_MAX_LENGTH + " znakova.");
            }

            if (SrednjeIme == String.Empty)
            {
                notification.RegisterMessage(
                    "SrednjeIme", "Srednje ime gimnasticara ne sme da bude prazno.");
            }

            if (!string.IsNullOrEmpty(SrednjeIme)
            && SrednjeIme.Length > SR_IME_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "SrednjeIme", "Srednje ime gimnasticara moze da sadrzi maksimalno "
                    + SR_IME_MAX_LENGTH + " znakova.");
            }

            // validate Prezime
            if (string.IsNullOrEmpty(Prezime))
            {
                notification.RegisterMessage(
                    "Prezime", "Prezime gimnasticara je obavezno.");
            }
            else if (Prezime.Length > PREZIME_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Prezime", "Prezime gimnasticara moze da sadrzi maksimalno "
                    + PREZIME_MAX_LENGTH + " znakova.");
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
            && FotoFile.Length > FOTO_FILE_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "FotoFile", "Ime fajla sa fotografijom moze da sadrzi maksimalno "
                    + FOTO_FILE_MAX_LENGTH + " znakova.");
            }

            if (Gimnastika == Gimnastika.Undefined)
            {
                notification.RegisterMessage(
                    "Gimnastika", "Gimnastika je obavezna.");
            }
        }

        public override bool Equals(object other)
        {
            if (object.ReferenceEquals(this, other)) return true;
            if (!(other is Gimnasticar)) return false;
            
            Gimnasticar that = (Gimnasticar)other;
            bool result = this.Ime.ToUpper() == that.Ime.ToUpper()
                && this.Prezime.ToUpper() == that.Prezime.ToUpper();
            if (result)
            { 
                result = string.IsNullOrEmpty(this.SrednjeIme)
                    && string.IsNullOrEmpty(that.SrednjeIme)
                || (!string.IsNullOrEmpty(this.SrednjeIme)
                    && !string.IsNullOrEmpty(that.SrednjeIme)
                    && this.SrednjeIme.ToUpper() == that.SrednjeIme.ToUpper());
            }
            if (result)
            {
                result = this.DatumRodjenja == that.DatumRodjenja;
            }
            return result;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 14;
                result = 29 * result + Ime.GetHashCode();
                result = 29 * result + Prezime.GetHashCode();
                if (!string.IsNullOrEmpty(SrednjeIme))
                    result = 29 * result + SrednjeIme.GetHashCode();
                if (DatumRodjenja != null)
                    result = 29 * result + DatumRodjenja.GetHashCode();
                return result;
            }
        }
    }
}
