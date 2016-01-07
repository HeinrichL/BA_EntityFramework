using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using Kundenkomponente.DataAccessLayer.Entities;
using KursKomponente.DataAccessLayer;
using Rechnungskomponente.DataAccessLayer.Datatypes;

namespace Rechnungskomponente.DataAccessLayer.Entities
{
    public class Rechnung
    {
        public virtual int Rechnungsnummer { get; set; }
        public virtual Kunde Kunde { get; set; }
        public virtual AbrechnungsZeitraumTyp AbrechnungsZeitraum { get; set; }
        public virtual bool Bezahlt { get; set; }
        public virtual List<Rechnungsposition> Rechnungspositionen { get; set; }

        public Rechnung()
        {
            Rechnungspositionen = new List<Rechnungsposition>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (typeof(Rechnung) != obj.GetType()) return false;

            Rechnung r = (Rechnung)obj;

            return Rechnungsnummer == r.Rechnungsnummer &&
                   Equals(Kunde, r.Kunde) &&
                   Equals(AbrechnungsZeitraum, r.AbrechnungsZeitraum) &&
                   Bezahlt == r.Bezahlt &&
                   Rechnungspositionen.SequenceEqual(r.Rechnungspositionen);
        }
    }

    public class Rechnungsposition
    {
        public virtual int Rechnungspositionsnummer { get; set; }
        public virtual decimal Kosten { get; set; }
        public virtual Kurs Kurs { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (typeof(Rechnungsposition) != obj.GetType()) return false;

            Rechnungsposition r = (Rechnungsposition)obj;

            return Rechnungspositionsnummer == r.Rechnungspositionsnummer &&
                   Kosten == r.Kosten &&
                   Equals(Kurs, r.Kurs);
        }
    }

    public class RechnungMap : EntityTypeConfiguration<Rechnung>
    {
        public RechnungMap()
        {
            HasKey(x => x.Rechnungsnummer);

            Property(x => x.AbrechnungsZeitraum.Jahr);
            Property(x => x.AbrechnungsZeitraum.Monat);
            Property(x => x.Bezahlt);

            HasRequired(x => x.Kunde);
            HasMany(x => x.Rechnungspositionen).WithRequired().WillCascadeOnDelete();
        }
    }

    public class RechnungspositionMap : EntityTypeConfiguration<Rechnungsposition>
    {
        public RechnungspositionMap()
        {
            HasKey(x => x.Rechnungspositionsnummer);

            Property(x => x.Kosten);

            HasRequired(x => x.Kurs);
        }
    }
}