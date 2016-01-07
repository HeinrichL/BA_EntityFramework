using System.Collections.Generic;
using KursKomponente.DataAccessLayer;
using PersistenceService._1___Implementation;

namespace KursKomponente.AccessLayer
{
    public interface IKursServicesFuerRechnungen
    {
        Kurs FindKursById(int id);
        List<Kurs> GetKurseByVeranstaltungszeit(int monat, int jahr);
    }
}