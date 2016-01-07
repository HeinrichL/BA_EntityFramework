using System.Collections.Generic;
using System.Linq;
using PersistenceService;
using PersistenceService._1___Implementation;
using Rechnungskomponente.DataAccessLayer.Entities;

namespace Rechnungskomponente.DataAccessLayer
{
    public class RechnungsRepo
    {
        private IPersistenceService ps;

        public RechnungsRepo(IPersistenceService ps)
        {
            this.ps = ps;
        }

        public List<Rechnung> SaveAll(List<Rechnung> rechnungen)
        {
            return ps.SaveAll(rechnungen);
        }

        public Rechnung FindRechnungById(int id)
        {
            return ps.GetById<Rechnung, int>(id);
        }

        public List<Rechnung> GetAlleRechnungen()
        {
            return ps.GetAll<Rechnung>();
        }

        public List<Rechnung> GetRechnungenByAbrechnungszeitraum(AbrechnungsZeitraumTyp zeitraum)
        {
            return (from rechnungen in ps.Query<Rechnung>()
                    where rechnungen.AbrechnungsZeitraum.Equals(zeitraum)
                    select rechnungen).ToList();
        }
    }
}