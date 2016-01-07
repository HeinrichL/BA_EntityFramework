using System.Collections.Generic;
using System.Linq;
using Kunde = Kundenkomponente.DataAccessLayer.Entities.Kunde;

using MitarbeiterKomponente.DataAccessLayer.Entities;
using KursKomponente.DataAccessLayer.Datatypes;
using System.Data.Entity.ModelConfiguration;

namespace KursKomponente.DataAccessLayer
{
    public enum Kursstatus
    {
        Geplant, FindetStatt, Vorbei, Abgesagt
    }

    public class Kurs
    {

        public int ID { get; set; }
        public string Titel { get; set; }
        public string Beschreibung { get; set; }
        public int MaximaleTeilnehmeranzahl { get; set; }
        public Kursstatus Kursstatus { get; set; }
        public VeranstaltungszeitTyp Veranstaltungszeit { get; set; }
        public virtual Trainer Kursleiter { get; set; }
        public virtual ICollection<Kunde> Teilnehmer { get; set; }
        public virtual Rezeptionist AngelegtVon { get; set; }

        public Kurs()
        {
            Teilnehmer = new List<Kunde>();
        }

        public virtual bool HatFreiePlaetze(int anzahl = 1)
        {
            return Teilnehmer.Count + anzahl <= MaximaleTeilnehmeranzahl;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (typeof(Kurs) != obj.GetType()) return false;

            Kurs k = (Kurs)obj;

            return ID == k.ID &&
                   Titel == k.Titel &&
                   Beschreibung == k.Beschreibung &&
                   MaximaleTeilnehmeranzahl == k.MaximaleTeilnehmeranzahl &&
                   Teilnehmer.SequenceEqual(k.Teilnehmer) &&
                   Equals(Veranstaltungszeit, k.Veranstaltungszeit) &&
                   Kursstatus == k.Kursstatus &&
                   Equals(Kursleiter, k.Kursleiter) &&
                   Equals(AngelegtVon, k.AngelegtVon);
        }
    }

    public class KursMap : EntityTypeConfiguration<Kurs>
    {
        public KursMap()
        {
            HasKey(x => x.ID);

            Property(x => x.Titel);
            Property(x => x.Beschreibung);
            Property(x => x.MaximaleTeilnehmeranzahl);
            HasMany(x => x.Teilnehmer).WithMany();//.WillCascadeOnDelete(false);
                //.Map(m =>
                //{
                //    m.MapLeftKey("Teilnehmer");
                //    m.MapRightKey("IDKurs");
                //    m.ToTable("KundenKurse");
                //});
            Property(x => x.Veranstaltungszeit.StartZeitpunkt);
            Property(x => x.Veranstaltungszeit.EndZeitpunkt);
            Property(x => x.Kursstatus);
            HasRequired(x => x.Kursleiter);
            HasRequired(x => x.AngelegtVon);
        }
    }
}