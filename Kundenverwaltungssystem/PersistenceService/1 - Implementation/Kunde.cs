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
    
    public partial class Kunde
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kunde()
        {
            this.Adresse = new AdresseTyp();
            this.EmailAdresse = new EmailAdresseTyp();
        }
    
        public int Kundennummer { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Telefonnummer { get; set; }
        public System.DateTime Geburtsdatum { get; set; }
        public Kundenstatus Kundenstatus { get; set; }
    
        public AdresseTyp Adresse { get; set; }
        public EmailAdresseTyp EmailAdresse { get; set; }
    
        public virtual Rezeptionist AngelegtVon { get; set; }
    }
}
