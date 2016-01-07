using System.Collections.Generic;
using Rechnungskomponente.DataAccessLayer.Entities;
using Rechnungskomponente.DataAccessLayer.Datatypes;

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