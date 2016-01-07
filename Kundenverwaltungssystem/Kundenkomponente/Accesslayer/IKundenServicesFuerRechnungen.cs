using Kundenkomponente.DataAccessLayer.Entities;
using System.Collections.Generic;
using PersistenceService._1___Implementation;

namespace Kundenkomponente.Accesslayer
{
    public interface IKundenServicesFuerRechnungen
    {
        Kunde FindKundeById(int id);

        List<Kunde> GetAlleKunden();
    }
}
