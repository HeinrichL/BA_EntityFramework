using System.Collections.Generic;
using System.Linq;
using PersistenceService;
using System.Data.Entity;

namespace KursKomponente.DataAccessLayer.Repository
{
    public class KursRepo
    {
        private IPersistenceService ps;

        public KursRepo(IPersistenceService ps)
        {
            this.ps = ps;
        }

        public Kurs Save(Kurs kurs)
        {
            return ps.Save(kurs);
        }

        public Kurs Update(Kurs kurs)
        {
            return ps.Update(kurs);
        }

        public Kurs FindById(int id)
        {
            return ps.GetById<Kurs, int>(id);
        }

        public List<Kurs> GetAllKurse()
        {
            return ps.GetAll<Kurs>();
        }

        public List<Kurs> GetKurseByVeranstaltungszeit(int monat, int jahr)
        {
            return (from kurse in ps.Query<Kurs>()
                    where kurse.Veranstaltungszeit.StartZeitpunkt.Month == monat
                          && kurse.Veranstaltungszeit.StartZeitpunkt.Year == jahr
                    select kurse).Include(x => x.Teilnehmer).ToList();
        }

        public void DeleteKurs(Kurs kurs)
        {
            ps.Delete(kurs);
        }


    }
}