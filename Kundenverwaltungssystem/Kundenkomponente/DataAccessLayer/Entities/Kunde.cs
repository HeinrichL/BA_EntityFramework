﻿using Kundenkomponente.DataAccessLayer.Datatypes;
using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using MitarbeiterKomponente.DataAccessLayer.Entities;


namespace Kundenkomponente.DataAccessLayer.Entities
{
    public enum Kundenstatus
    {
        Basic, Premium, Gekuendigt
    }

    public class Kunde
    {
        public virtual int Kundennummer { get; set; }
        public virtual string Vorname { get; set; }
        public virtual string Nachname { get; set; }
        public virtual AdresseTyp Adresse { get; set; }
        public virtual EmailAdresseTyp EmailAdresse { get; set; }
        public virtual string Telefonnummer { get; set; }
        public virtual DateTime Geburtsdatum { get; set; }
        public virtual Kundenstatus Kundenstatus { get; set; }
        public virtual Rezeptionist AngelegtVon { get; set; }

        public Kunde() { }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (typeof(Kunde) != obj.GetType()) return false;

            Kunde k = (Kunde)obj;

            return Kundennummer == k.Kundennummer &&
                   Vorname == k.Vorname &&
                   Nachname == k.Nachname &&
                   Equals(Adresse, k.Adresse) &&
                   Equals(EmailAdresse, k.EmailAdresse) &&
                   Telefonnummer == k.Telefonnummer &&
                   Geburtsdatum == k.Geburtsdatum &&
                   Kundenstatus == k.Kundenstatus &&
                   Equals(AngelegtVon, k.AngelegtVon);
        }
    }

    public class KundeMap : EntityTypeConfiguration<Kunde>
    {
        public KundeMap()
        {
            HasKey(x => x.Kundennummer);
            Property(x => x.Vorname);
            Property(x => x.Nachname);
            Property(x => x.Adresse.Strasse);
            Property(x => x.Adresse.Hausnummer);
            Property(x => x.Adresse.PLZ);
            Property(x => x.Adresse.Ort);
            Property(x => x.EmailAdresse.Email);
            Property(x => x.Telefonnummer);
            Property(x => x.Geburtsdatum);
            Property(x => x.Kundenstatus);
            HasRequired(x => x.AngelegtVon);
        }
    }
}
