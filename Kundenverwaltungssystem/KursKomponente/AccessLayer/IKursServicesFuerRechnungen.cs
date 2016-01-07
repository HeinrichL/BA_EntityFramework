using System.Collections.Generic;
using KursKomponente.DataAccessLayer;

namespace KursKomponente.AccessLayer
{
    public interface IKursServicesFuerRechnungen
    {
        Kurs FindKursById(int id);
        List<Kurs> GetKurseByVeranstaltungszeit(int monat, int jahr);
    }
}