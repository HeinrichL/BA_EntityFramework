using System.Collections.Generic;
using System.Linq;
using PersistenceService;
using Rechnungskomponente.DataAccessLayer.Entities;
using Rechnungskomponente.DataAccessLayer.Datatypes;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Core.Objects;

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
            //return (from rechnungen in ps.Query<Rechnung>()
            //        where rechnungen.AbrechnungsZeitraum.Jahr == zeitraum.Jahr
            //        && rechnungen.AbrechnungsZeitraum.Monat == zeitraum.Monat
            //        select rechnungen).Include(r => r.Rechnungspositionen).ToList();
            return ps.Query<Rechnung>(@"select value r from KundenverwaltungContext.Rechnungs as r 
                                        where r.AbrechnungsZeitraum.Jahr == @jahr
                                        and r.AbrechnungsZeitraum.Monat == @monat",
                                      new ObjectParameter("jahr", zeitraum.Jahr),
                                      new ObjectParameter("monat", zeitraum.Monat))
                     .Cast<Rechnung>().ToList();
        }
    }
}