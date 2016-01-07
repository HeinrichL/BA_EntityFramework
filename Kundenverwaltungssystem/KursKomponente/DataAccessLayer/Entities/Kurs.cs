using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using PersistenceService._1___Implementation;
//using Kunde = Kundenkomponente.DataAccessLayer.Entities.Kunde;

//using MitarbeiterKomponente.DataAccessLayer.Entities;

namespace KursKomponente.DataAccessLayer
{
    //public enum Kursstatus
    //{
    //    Geplant, FindetStatt, Vorbei, Abgesagt
    //}

    //public partial class Kurs
    //{

    //    public virtual bool HatFreiePlaetze(int anzahl = 1)
    //    {
    //        return Teilnehmer.Count + anzahl <= MaximaleTeilnehmeranzahl;
    //    }

        //    public override bool Equals(object obj)
        //    {
        //        if (obj == null) return false;
        //        if (obj == this) return true;
        //        if (typeof(Kurs) != obj.GetType()) return false;

        //        Kurs k = (Kurs)obj;

        //        return ID == k.ID &&
        //               Titel == k.Titel &&
        //               Beschreibung == k.Beschreibung &&
        //               MaximaleTeilnehmeranzahl == k.MaximaleTeilnehmeranzahl &&
        //               Teilnehmer.SequenceEqual(k.Teilnehmer) &&
        //               Equals(Veranstaltungszeit, k.Veranstaltungszeit) &&
        //               Kursstatus == k.Kursstatus &&
        //               Equals(Kursleiter, k.Kursleiter) &&
        //               Equals(AngelegtVon, k.AngelegtVon);
        //    }
        //}
}