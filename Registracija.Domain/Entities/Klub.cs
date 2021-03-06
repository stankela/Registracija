using System;
using System.Collections.Generic;
using System.Text;
using Registracija.Exceptions;
using Registracija.Util;

namespace Registracija.Domain
{
    public class Klub : DomainObject, IComparable<Klub>
    {
        private static readonly int NAZIV_MAX_LENGTH = 128;
        private static readonly int MESTO_MAX_LENGTH = 32;
        private static readonly int ADRESA_MAX_LENGTH = 64;
        private static readonly int TELEFON_MAX_LENGTH = 16;
        private static readonly int EMAIL_MAX_LENGTH = 64;
 
        private string naziv;
        public virtual string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private string mesto;
        public virtual string Mesto
        {
            get { return mesto; }
            set { mesto = value; }
        }

        private string adresa;
        public virtual string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
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

        public Klub()
        { 
        
        }

        public override string ToString()
        {
            return Naziv;
        }

        public override void validate(Notification notification)
        {
            // validate Naziv
            if (string.IsNullOrEmpty(Naziv))
            {
                notification.RegisterMessage(
                    "Naziv", "Naziv kluba je obavezan.");
            }
            else if (Naziv.Length > NAZIV_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Naziv", "Naziv kluba moze da sadrzi maksimalno "
                    + NAZIV_MAX_LENGTH + " znakova.");
            }

            // validate Mesto
            if (String.IsNullOrEmpty(Mesto))
            {
                notification.RegisterMessage(
                    "Mesto", "Mesto kluba je obavezno.");
            }
            else if (Mesto.Length > MESTO_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Mesto", "Mesto moze da sadrzi maksimalno "
                    + MESTO_MAX_LENGTH + " znakova.");
            }

            // validate Adresa
            if (Adresa.Length > ADRESA_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Adresa", "Adresa moze da sadrzi maksimalno "
                    + ADRESA_MAX_LENGTH + " znakova.");
            }

            // validate Telefon1
            if (Telefon1.Length > TELEFON_MAX_LENGTH)
            {
                notification.RegisterMessage(
                    "Telefon1", "Telefon moze da sadrzi maksimalno "
                    + TELEFON_MAX_LENGTH + " znakova.");
            }

            // validate Telefon2
            if (Telefon2.Length > TELEFON_MAX_LENGTH)
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
        }

        public override bool Equals(object other)
        {
            if (object.ReferenceEquals(this, other)) return true;
            if (!(other is Klub)) return false;
            Klub that = (Klub)other;
            return this.Naziv.ToUpper() == that.Naziv.ToUpper();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 14;
                result = 29 * result + Naziv.GetHashCode();
                return result;
            }
        }
        
        #region IComparable<Klub> Members

        public virtual int CompareTo(Klub other)
        {
            return this.Naziv.CompareTo(other.Naziv);
        }

        #endregion
    }
}
