using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using Registracija.Domain;

namespace Registracija.Dao
{
    public class GimnasticarBilten
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string SrednjeIme { get; set; }
        public Nullable<byte> DanRodj { get; set; }
        public Nullable<byte> MesecRodj { get; set; }
        public Nullable<short> GodRodj { get; set; }
        public Gimnastika Gimnastika { get; set; }
        public string NazivKluba { get; set; }
        public string MestoKluba { get; set; }
        public string NazivKategorije { get; set; }

        public Datum DatumRodjenja
        {
            get
            {
                if (DanRodj == null && MesecRodj == null && GodRodj == null)
                    return null;
                if (DanRodj == null && MesecRodj == null && GodRodj != null)
                    return new Datum(GodRodj.Value);
                if (DanRodj != null && MesecRodj != null && GodRodj != null)
                    return new Datum(new DateTime(GodRodj.Value, MesecRodj.Value, DanRodj.Value));
                throw new Exception("Nelegalan datum.");
            }
        }
    }

    public class GimnasticarBiltenDAO
    {
        public string ConnectionString;

        private string findGimnasticariBiltenSQL = @"
            select g.ime, g.prezime, g.srednje_ime, g.dan_rodj, g.mesec_rodj, g.god_rodj, g.gimnastika,
            k.naziv naziv_kluba, m.naziv mesto_kluba, kat.naziv naziv_kategorije
            from gimnasticari g
            left join klubovi k
                on g.klub_id = k.klub_id
            left join kategorije_gimnasticara kat
                on g.kat_id = kat.kategorija_id
            left join mesta m
                on k.mesto_id = m.mesto_id";

        // can throw InfrastructureException
        public List<GimnasticarBilten> findGimnasticariBilten(string ime, string prezime, Nullable<Gimnastika> gimnastika,
            string nazivKluba)
        {
            string WHERE = " where ";
            if (!String.IsNullOrEmpty(ime))
            {
                findGimnasticariBiltenSQL += WHERE + "lower(g.ime) like @ime";
                WHERE = " and ";
            }
            if (!String.IsNullOrEmpty(prezime))
            {
                findGimnasticariBiltenSQL += WHERE + "lower(g.prezime) like @prezime";
                WHERE = " and ";
            }
            if (gimnastika != null)
            {
                findGimnasticariBiltenSQL += WHERE + "g.gimnastika = @gimnastika";
                WHERE = " and ";
            }
            if (!String.IsNullOrEmpty(nazivKluba))
            {
                findGimnasticariBiltenSQL += WHERE + "lower(k.naziv) like @klub";
                WHERE = " and ";
            }
            findGimnasticariBiltenSQL += " order by g.prezime asc, g.ime asc";

            SqlCeCommand cmd = new SqlCeCommand(findGimnasticariBiltenSQL);
            if (!String.IsNullOrEmpty(ime))
                cmd.Parameters.Add("@ime", SqlDbType.NVarChar).Value = ime.ToLower() + '%';
            if (!String.IsNullOrEmpty(prezime))
                cmd.Parameters.Add("@prezime", SqlDbType.NVarChar).Value = prezime.ToLower() + '%';
            if (gimnastika != null)
                cmd.Parameters.Add("@gimnastika", SqlDbType.TinyInt).Value = (byte)gimnastika.Value;
            if (!String.IsNullOrEmpty(nazivKluba))
                cmd.Parameters.Add("@klub", SqlDbType.NVarChar).Value = nazivKluba.ToLower() + '%';

            SqlCeDataReader rdr = Database.executeReader(cmd, Strings.DatabaseAccessExceptionMessage, ConnectionString);

            List<GimnasticarBilten> result = new List<GimnasticarBilten>();
            while (rdr.Read())
            {
                GimnasticarBilten g = new GimnasticarBilten();
                g.Ime = (string)rdr["ime"];
                g.Prezime = (string)rdr["prezime"];
                g.SrednjeIme = Convert.IsDBNull(rdr["srednje_ime"]) ? null : (string)rdr["srednje_ime"];
                g.DanRodj = Convert.IsDBNull(rdr["dan_rodj"]) ? null : (Nullable<byte>)rdr["dan_rodj"];
                g.MesecRodj = Convert.IsDBNull(rdr["mesec_rodj"]) ? null : (Nullable<byte>)rdr["mesec_rodj"];
                g.GodRodj = Convert.IsDBNull(rdr["god_rodj"]) ? null : (Nullable<short>)rdr["god_rodj"];
                g.Gimnastika = (Gimnastika)(byte)rdr["gimnastika"];

                g.NazivKluba = Convert.IsDBNull(rdr["naziv_kluba"]) ? null : (string)rdr["naziv_kluba"];
                g.MestoKluba = Convert.IsDBNull(rdr["mesto_kluba"]) ? null : (string)rdr["mesto_kluba"];

                g.NazivKategorije = Convert.IsDBNull(rdr["naziv_kategorije"]) ? null : (string)rdr["naziv_kategorije"];
                result.Add(g);
            }

            rdr.Close(); // obavezno, da bi se zatvorila konekcija otvorena u executeReader
            return result;
        }
    }
}