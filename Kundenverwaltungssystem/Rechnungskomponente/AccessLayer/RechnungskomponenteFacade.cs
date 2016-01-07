using System.Collections.Generic;
using Common;
using KursKomponente.AccessLayer;
using PersistenceService;
using PersistenceService._1___Implementation;
using Rechnungskomponente.BusinessLogicLayer;
using Rechnungskomponente.DataAccessLayer;
using Rechnungskomponente.DataAccessLayer.Entities;

namespace Rechnungskomponente.AccessLayer
{
    public class RechnungskomponenteFacade : IRechnungsServices
    {
        private RechnungsRepo rechnungsRepo;
        private RechnungsBusinessLogic businessLogic;

        public RechnungskomponenteFacade(IPersistenceService ps, ITransactionService ts, IKursServicesFuerRechnungen ks)
        {
            rechnungsRepo = new RechnungsRepo(ps);
            businessLogic = new RechnungsBusinessLogic(ts, rechnungsRepo, ks);
        }

        public List<Rechnung> ErstelleRechnungen()
        {
            return businessLogic.ErstelleRechnungen();
        }

        public Rechnung FindRechnungById(int id)
        {
            Check.Argument(id > 0, "ID muss größer als 0 sein");

            return rechnungsRepo.FindRechnungById(id);
        }

        public List<Rechnung> GetAlleRechnungen()
        {
            return rechnungsRepo.GetAlleRechnungen();
        }

        public List<Rechnung> GetRechnungByAbrechnungsZeitraum(AbrechnungsZeitraumTyp abrechnungsZeitraum)
        {
            return rechnungsRepo.GetRechnungenByAbrechnungszeitraum(abrechnungsZeitraum);
        }
    }
}