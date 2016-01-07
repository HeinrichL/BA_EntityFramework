using System.Collections.Generic;
using Kundenkomponente.Accesslayer;
using KursKomponente.AccessLayer.Exceptions;
using KursKomponente.DataAccessLayer;
using KursKomponente.DataAccessLayer.Repository;
using PersistenceService;
using System.Linq;
using PersistenceService._1___Implementation;

namespace KursKomponente.BusinessLogicLayer
{
    public class KursBusinessLogic
    {
        private KursRepo kursRepo;
        private ITransactionService ts;
        private IKundenServicesFuerKurse kundenServices;

        public KursBusinessLogic(ITransactionService ts, IKundenServicesFuerKurse ks, KursRepo repo)
        {
            kursRepo = repo;
            this.ts = ts;
            kundenServices = ks;
        }

        public void BucheKurs(int idKunde, Kurs kurs)
        {
            ts.ExecuteInTransaction(() =>
            {
                if (KursHatFreiePlaetze(kurs))
                {
                    kurs.Teilnehmer.Add(kundenServices.FindKundeById(idKunde));
                    kursRepo.Update(kurs);
                }
                else
                {
                    throw new KursUeberfuelltException("Kurs ist bereits ausgebucht");
                }
            });
            
        }

        public void BucheKurs(List<int> idKunden, Kurs kurs)
        {
            ts.ExecuteInTransaction(() =>
            {
                if (KursHatFreiePlaetze(kurs, idKunden.Count))
                {
                    List<Kunde> kunden = kundenServices.GetKundenByIds(idKunden);
                    kunden.ForEach(kunde => kurs.Teilnehmer.Add(kunde));
                    kursRepo.Update(kurs);
                }
                else
                {
                    throw new KursUeberfuelltException("Kurs ist bereits ausgebucht");
                }
            });
        }

        public void BucheKundenAufAnderenKursUm(int idKunde, Kurs kursVon, Kurs kursNach)
        {
            ts.ExecuteInTransaction(() =>
            {
                if(KursHatFreiePlaetze(kursNach))
                {
                    Kunde k = kundenServices.FindKundeById(idKunde);
                    kursVon.Teilnehmer.Remove(k);
                    kursNach.Teilnehmer.Add(k);
                    kursRepo.Update(kursVon);
                    kursRepo.Update(kursNach);
                }
                else
                {
                    throw new KursUeberfuelltException("Zielkurs ist bereits ausgebucht");
                }
            });
        }

        public void BucheKundenAufAnderenKursUm(List<int> idKunden, Kurs kursVon, Kurs kursNach)
        {
            ts.ExecuteInTransaction(() =>
            {
                if (KursHatFreiePlaetze(kursNach, idKunden.Count))
                {
                    List<Kunde> kunden = kundenServices.GetKundenByIds(idKunden);
                    kunden.ForEach(kunde => kursVon.Teilnehmer.Remove(kunde));
                    kunden.ForEach(kunde => kursNach.Teilnehmer.Add(kunde));
                    kursRepo.Update(kursVon);
                    kursRepo.Update(kursNach);
                }
                else
                {
                    throw new KursUeberfuelltException("Zielkurs ist bereits ausgebucht");
                }
            });
        }

        private bool KursHatFreiePlaetze(Kurs k, int frei = 1)
        {
            return k.Teilnehmer.Count + frei <= k.MaximaleTeilnehmeranzahl;
        }
    }
}