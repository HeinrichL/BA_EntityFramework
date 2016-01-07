using System.Collections.Generic;
using PersistenceService._1___Implementation;
using Rechnungskomponente.DataAccessLayer.Entities;

namespace Rechnungskomponente.AccessLayer
{
    public interface IRechnungsServices
    {
        List<Rechnung> ErstelleRechnungen();
        Rechnung FindRechnungById(int id);
        List<Rechnung> GetAlleRechnungen();
        List<Rechnung> GetRechnungByAbrechnungsZeitraum(AbrechnungsZeitraumTyp abrechnungsZeitraum);
    }
}