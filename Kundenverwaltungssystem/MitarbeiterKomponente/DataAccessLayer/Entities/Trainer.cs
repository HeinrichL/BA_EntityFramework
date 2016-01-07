using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace MitarbeiterKomponente.DataAccessLayer.Entities
{
    public class Trainer : Mitarbeiter
    {
        public Trainer() { }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (typeof(Trainer) != obj.GetType()) return false;

            Trainer t = (Trainer)obj;

            return ID == t.ID &&
                   Vorname == t.Vorname &&
                   Nachname == t.Nachname;
        }
    }

    public class TrainerMap : EntityTypeConfiguration<Trainer>
    {
        public TrainerMap()
        {
            HasKey(x => x.ID);

            Property(x => x.Vorname);
            Property(x => x.Nachname);
        }
    }
}