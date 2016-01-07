//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersistenceService._1___Implementation
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kurs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kurs()
        {
            this.Teilnehmer = new HashSet<Kunde>();
            this.Veranstaltungszeit = new VeranstaltungszeitTyp();
        }
    
        public int ID { get; set; }
        public string Titel { get; set; }
        public string Beschreibung { get; set; }
        public int MaximaleTeilnehmeranzahl { get; set; }
        public Kursstatus Kursstatus { get; set; }
    
        public VeranstaltungszeitTyp Veranstaltungszeit { get; set; }
    
        public virtual Trainer Kursleiter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kunde> Teilnehmer { get; set; }
        public virtual Rezeptionist AngelegtVon { get; set; }
    }
}
