using System.Collections.Generic;
using System.Linq;
using Kundenkomponente.DataAccessLayer.Entities;
using PersistenceService;

namespace Kundenkomponente.DataAccessLayer.Repository
{
    public class KundenRepo
    {
        IPersistenceService ps;

        public KundenRepo(IPersistenceService ps)
        {
            this.ps = ps;
        }

        public Kunde SaveKunde(Kunde k)
        {
            return ps.Save(k);
        }

        public Kunde FindKundeById(int id)
        {
            return ps.GetById<Kunde, int>(id);
        }

        public Kunde UpdateKunde(Kunde k)
        {
            return ps.Update(k);
        }

        public void DeleteKunde(Kunde k)
        {
            ps.Delete(k);
        }

        public List<Kunde> GetAlleKunden()
        {
            return ps.GetAll<Kunde>();
        }

        public List<Kunde> GetKundenByIds(List<int> ids)
        {
            return (from kunden in ps.Query<Kunde>()
                   where ids.Contains(kunden.Kundennummer)
                   select kunden).ToList();

        }
    }
}