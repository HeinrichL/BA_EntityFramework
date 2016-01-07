using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;

namespace Kundenkomponente.DataAccessLayer.Datatypes
{
    public class AdresseTyp
    {
        public string Strasse { get; private set; }
        public string Hausnummer { get; private set; }
        public string PLZ { get; private set; }
        public string Ort { get; private set; }

        public AdresseTyp(string strasse, string hausnummer, string plz, string ort)
        {
            Strasse = strasse;
            Hausnummer = hausnummer;
            PLZ = plz;
            Ort = ort;
        }

        private AdresseTyp() { }
    }
}
