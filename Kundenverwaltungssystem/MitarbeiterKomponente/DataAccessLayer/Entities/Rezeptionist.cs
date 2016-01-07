//using System.Data.Entity.ModelConfiguration;
//using System.Data.Entity.ModelConfiguration.Configuration;

//namespace MitarbeiterKomponente.DataAccessLayer.Entities
//{
//    public class Rezeptionist : Mitarbeiter
//    {
//        public Rezeptionist() { }

//        public override bool Equals(object obj)
//        {
//            if (obj == null) return false;
//            if (obj == this) return true;
//            if (typeof(Rezeptionist) != obj.GetType()) return false;

//            Rezeptionist r = (Rezeptionist)obj;

//            return ID == r.ID &&
//                   Vorname == r.Vorname &&
//                   Nachname == r.Nachname;
//        }
//    }

//    public class RezeptionistMap : EntityTypeConfiguration<Rezeptionist>
//    {
//        public RezeptionistMap()
//        {
//            HasKey(x => x.ID);

//            Property(x => x.Vorname);
//            Property(x => x.Nachname);
//        }
//    }
//}