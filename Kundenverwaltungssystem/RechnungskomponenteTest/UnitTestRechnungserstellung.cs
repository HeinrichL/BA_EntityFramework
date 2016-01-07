using System;
using System.Collections.Generic;
using System.Linq;
using Kundenkomponente.Accesslayer;
using KursKomponente.AccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MitarbeiterKomponente.AccessLayer;
using MitarbeiterKomponente.DataAccessLayer.Entities;
using PersistenceService;
using Rechnungskomponente.AccessLayer;
using Kundenkomponente.DataAccessLayer.Entities;
using KursKomponente.DataAccessLayer;
using Kundenkomponente.DataAccessLayer.Datatypes;
using KursKomponente.DataAccessLayer.Datatypes;
using Rechnungskomponente.DataAccessLayer.Entities;
using Rechnungskomponente.DataAccessLayer.Datatypes;

namespace RechnungskomponenteTest
{
    [TestClass]
    public class UnitTestRechnungserstellung
    {
        private static IPersistenceService ps;
        private static ITransactionService ts;

        private static IKundenServices kundenServices;
        private static IMitarbeiterServices mitarbeiterServices;
        private static IKursServices kursServices;
        private static IRechnungsServices rechnungsServices;

        private static Rezeptionist r;
        private static Trainer t;

        private static Kunde kunde1;
        private static Kunde kunde2;

        private static Kurs kurs1;
        private static Kurs kurs2;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            ps = new EFPersistenceService();
            ts = ps as ITransactionService;

            mitarbeiterServices = new MitarbeiterkomponenteFacade(ps, ts);
            kundenServices = new KundenkomponenteFacade(ps, ts, mitarbeiterServices as IMitarbeiterServicesFuerKunden);
            kursServices = new KurskomponenteFacade(ps, ts, kundenServices as IKundenServicesFuerKurse, mitarbeiterServices as IMitarbeiterServicesFuerKurse);
            rechnungsServices = new RechnungskomponenteFacade(ps, ts, kursServices as IKursServicesFuerRechnungen);

            r = new Rezeptionist()
            {
                Vorname = "Rezep",
                Nachname = "tionist"
            };
            mitarbeiterServices.CreateRezeptionist(r);
            t = new Trainer()
            {
                Vorname = "Guter",
                Nachname = "Trainer"
            };
            mitarbeiterServices.CreateTrainer(t);

            kunde1 = new Kunde()
            {
                Vorname = "Klaus",
                Nachname = "Müller",
                Adresse = new AdresseTyp("Berliner Tor", "7", "22091", "Hamburg"),
                EmailAdresse = new EmailAdresseTyp("bla@test.de"),
                Geburtsdatum = new DateTime(1990, 01, 01),
                Kundenstatus = Kundenstatus.Basic,
                Telefonnummer = "123456"
            };
            kundenServices.CreateKunde(kunde1, r.ID);
            kunde2 = new Kunde()
            {
                Vorname = "Heinz",
                Nachname = "Schmidt",
                Adresse = new AdresseTyp("Berliner Tor", "7", "22091", "Hamburg"),
                EmailAdresse = new EmailAdresseTyp("bla2@test.de"),
                Geburtsdatum = new DateTime(1995, 01, 01),
                Kundenstatus = Kundenstatus.Premium,
                Telefonnummer = "654321"
            };
            kundenServices.CreateKunde(kunde2, r.ID);

            kurs1 = new Kurs()
            {
                Titel = "Kurs1",
                Beschreibung = "Beschreibung",
                MaximaleTeilnehmeranzahl = 3,
                Veranstaltungszeit = new VeranstaltungszeitTyp(DateTime.Now, DateTime.Now.AddHours(2)),
                Kursstatus = Kursstatus.Vorbei
            };
            kurs2 = new Kurs()
            {
                Titel = "Kurs2",
                Beschreibung = "Beschreibung2",
                MaximaleTeilnehmeranzahl = 3,
                Veranstaltungszeit = new VeranstaltungszeitTyp(DateTime.Now, DateTime.Now.AddHours(3)),
                Kursstatus = Kursstatus.Vorbei
            };
            kursServices.CreateKurs(kurs1, r.ID, t.ID);
            kursServices.CreateKurs(kurs2, r.ID, t.ID);

            kursServices.BucheKurs(kunde1.Kundennummer, kurs1);
            kursServices.BucheKurs(kunde1.Kundennummer, kurs2);
            kursServices.BucheKurs(kunde2.Kundennummer, kurs2);
        }

        [ClassCleanup]
        public static void Clean()
        {
            ps.Delete(kurs1);
            ps.Delete(kurs2);
            ps.Delete(kunde1);
            ps.Delete(kunde2);
            ps.Delete(r);
            ps.Delete(t);
        }

        [TestMethod]
        public void TestMethodErstelleRechnungen()
        {
            List<Rechnung> rechnungen = rechnungsServices.ErstelleRechnungen();

            //Rechnung für Kunde1
            Rechnungsposition rpos = new Rechnungsposition()
            {
                Rechnungspositionsnummer = rechnungen.ElementAt(0).Rechnungspositionen.ElementAt(0).Rechnungspositionsnummer,
                Kurs = kurs1
            };
            Rechnungsposition rPos2 = new Rechnungsposition()
            {
                Rechnungspositionsnummer = rechnungen.ElementAt(0).Rechnungspositionen.ElementAt(1).Rechnungspositionsnummer,
                Kurs = kurs2
            };
            List<Rechnungsposition> rpositions = new List<Rechnungsposition>();
            rpositions.Add(rpos);
            rpositions.Add(rPos2);
            Rechnung r1 = new Rechnung()
            {
                Rechnungsnummer = rechnungen[0].Rechnungsnummer,
                AbrechnungsZeitraum = new AbrechnungsZeitraumTyp(DateTime.Now.Month, DateTime.Now.Year),
                Bezahlt = false,
                Kunde = kunde1,
                Rechnungspositionen = rpositions
            };

            //Rechnung für Kunde2
            Rechnungsposition rPos3 = new Rechnungsposition()
            {
                Rechnungspositionsnummer = rechnungen.ElementAt(1).Rechnungspositionen.ElementAt(0).Rechnungspositionsnummer,
                Kurs = kurs2
            };
            
            List<Rechnungsposition> rpositions2 = new List<Rechnungsposition>();
            rpositions2.Add(rPos3);

            Rechnung r2 = new Rechnung()
            {
                Rechnungsnummer = rechnungen[1].Rechnungsnummer,
                AbrechnungsZeitraum = new AbrechnungsZeitraumTyp(DateTime.Now.Month, DateTime.Now.Year),
                Bezahlt = false,
                Kunde = kunde2,
                Rechnungspositionen = rpositions2
            };
            List<Rechnung> expected = new List<Rechnung>();
            expected.Add(r1);
            expected.Add(r2);
            //CollectionAssert.AreEqual(expected, rechnungen.ToList());
            Assert.AreEqual(2, rechnungen.Count);
            Assert.AreEqual(3, rechnungen.Sum(r => r.Rechnungspositionen.Count));

            ps.DeleteRange(rechnungen);
        }

        [TestMethod]
        public void TestFindByIdSuccess()
        {
            List<Rechnung> rechnungen = rechnungsServices.ErstelleRechnungen();

            Rechnung re = rechnungsServices.FindRechnungById(rechnungen[0].Rechnungsnummer);

            Assert.AreEqual(re, rechnungen[0]);

            ps.DeleteRange(rechnungen);
        }

        [TestMethod]
        public void TestGetAlleRechnungen()
        {
            List<Rechnung> rechnungen = rechnungsServices.ErstelleRechnungen();

            List<Rechnung> re = rechnungsServices.GetAlleRechnungen();

            Assert.AreEqual(2, rechnungen.Count);
            ps.DeleteRange(rechnungen);
        }

        [TestMethod]
        public void TestGetRechnungenByAbrechnungszeitraum()
        {
            kurs2.Veranstaltungszeit = new VeranstaltungszeitTyp(DateTime.Now.AddMonths(-4), DateTime.Now.AddMonths(-4).AddHours(2));
            kursServices.UpdateKurs(kurs2);

            List<Rechnung> rechnungen = rechnungsServices.ErstelleRechnungen();

            //Nur 1 Kurs wird abgerechnet
            Assert.IsTrue(rechnungen.Count == 1);

            ps.DeleteRange(rechnungen);
        }
    }
}
