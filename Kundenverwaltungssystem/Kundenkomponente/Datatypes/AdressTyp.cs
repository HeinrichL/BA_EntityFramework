//using System;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Core.Metadata.Edm;
//using System.Data.Entity.ModelConfiguration;

//namespace Kundenkomponente.DataAccessLayer.Datatypes
//{
//    //[ComplexType]
//    public class AdressTyp// : ComplexType
//    {
//        public virtual string Strasse { get; }
//        public virtual string Hausnummer { get; }
//        public virtual string PLZ { get; }
//        public virtual string Ort { get; }

//        public AdressTyp(string strasse, string hausnummer, string plz, string ort)
//        {
//            Strasse = strasse;
//            Hausnummer = hausnummer;
//            PLZ = plz;
//            Ort = ort;
//        }
//    }

//    public class AdresseMap : ComplexTypeConfiguration<AdressTyp>
//    {
//        public AdresseMap()
//        {
//            Property(x => x.Strasse);
//            Property(x => x.Hausnummer);
//            Property(x => x.PLZ);
//            Property(x => x.Ort);
//        }
//    }
//}
