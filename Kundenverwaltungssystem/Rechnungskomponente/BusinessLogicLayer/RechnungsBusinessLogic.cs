﻿using System;
using System.Collections.Generic;
using KursKomponente.AccessLayer;
using KursKomponente.DataAccessLayer;
using PersistenceService;
using Rechnungskomponente.DataAccessLayer;
using Rechnungskomponente.DataAccessLayer.Entities;
using Kundenkomponente.DataAccessLayer.Entities;
using Rechnungskomponente.DataAccessLayer.Datatypes;

namespace Rechnungskomponente.BusinessLogicLayer
{
    public class RechnungsBusinessLogic
    {
        private IKursServicesFuerRechnungen ks;
        private RechnungsRepo repo;
        private ITransactionService ts;

        public RechnungsBusinessLogic(ITransactionService ts, RechnungsRepo repo, IKursServicesFuerRechnungen ks)
        {
            this.repo = repo;
            this.ts = ts;
            this.ks = ks;
        }

        public List<Rechnung> ErstelleRechnungen()
        {
            int monat = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            List<Rechnung> rechnungen = new List<Rechnung>();
            Dictionary<Kunde, List<Kurs>> kundenKurse = new Dictionary<Kunde, List<Kurs>>();
            return ts.ExecuteInTransaction(() =>
            {
                var kurse = ks.GetKurseByVeranstaltungszeit(monat, year);
                foreach (var kurs in kurse)
                {
                    foreach (var teilnehmer in kurs.Teilnehmer)
                    {
                        if (!kundenKurse.ContainsKey(teilnehmer))
                        {
                            var listKurse = new List<Kurs>();
                            listKurse.Add(kurs);
                            kundenKurse.Add(teilnehmer, listKurse);
                        }
                        else
                        {
                            kundenKurse[teilnehmer].Add(kurs);
                        }
                    }
                }

                foreach (var pair in kundenKurse)
                {
                    List<Rechnungsposition> positionen = new List<Rechnungsposition>();

                    foreach (var kurs in pair.Value)
                    {
                        Rechnungsposition position = new Rechnungsposition()
                        {
                            Kurs = kurs
                        };
                        positionen.Add(position);
                    }

                    Rechnung r = new Rechnung()
                    {
                        Kunde = pair.Key,
                        AbrechnungsZeitraum =
                                         new AbrechnungsZeitraumTyp(monat, year),
                        Bezahlt = false,
                        Rechnungspositionen = positionen
                    };
                    rechnungen.Add(r);
                }
                return repo.SaveAll(rechnungen);
            });
        }
    }
}