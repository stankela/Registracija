using Registracija.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registracija.Domain
{
    public class Trener : DomainObject
    {
        private static readonly int IME_MAX_LENGTH = 32;
        private static readonly int PREZIME_MAX_LENGTH = 32;

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

        public Trener()
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
                    "Ime", "Ime je obavezno.");
            }
            else if (Ime.Length > IME_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Ime", "Ime moze da sadrzi maksimalno "
                    + IME_MAX_LENGTH + " znakova.");
            }

            // validate Prezime
            if (string.IsNullOrEmpty(Prezime))
            {
                notification.RegisterMessage(
                    "Prezime", "Prezime je obavezno.");
            }
            else if (Prezime.Length > PREZIME_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Prezime", "Prezime moze da sadrzi maksimalno "
                    + PREZIME_MAX_LENGTH + " znakova.");
            }

            // validate Pol
            if (Pol != Pol.Muski && Pol != Pol.Zenski)
            {
                notification.RegisterMessage(
                    "Pol", "Neispravna vrednost za pol.");
            }
        }

        public override bool Equals(object other)
        {
            if (object.ReferenceEquals(this, other)) return true;
            if (!(other is Trener)) return false;
            Trener that = (Trener)other;
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
