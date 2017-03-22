using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Collections;

namespace Registracija.Domain
{
    public class Opcije : DomainObject
    {
        protected static Opcije instance = null;

        // TODO4: Ovo bi trebalo da bude singleton.

        // can throw InfrastructureException
        public static Opcije Instance
        {
            get
            {
                if (instance == null)
                    instance = new Opcije();
                return instance;
            }
            set { instance = value; }
        }

        public Opcije()
        { 

        }

        private string biltenConnectionString;
        public virtual string BiltenConnectionString
        {
            get { return biltenConnectionString; }
            set { biltenConnectionString = value; }
        }
    }
}
