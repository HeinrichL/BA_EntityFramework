using Kundenkomponente.DataAccessLayer.Entities;
using System.Collections.Generic;
using PersistenceService._1___Implementation;

namespace Kundenkomponente.Accesslayer
{
    public interface IKundenServicesFuerKurse
    {
        Kunde FindKundeById(int id);

        List<Kunde> GetAlleKunden();
        List<Kunde> GetKundenByIds(List<int> ids);
    }
}
