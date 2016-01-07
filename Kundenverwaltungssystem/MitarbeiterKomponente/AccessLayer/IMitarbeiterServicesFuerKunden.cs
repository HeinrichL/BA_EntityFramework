//using MitarbeiterKomponente.DataAccessLayer.Entities;
using PersistenceService._1___Implementation;

namespace MitarbeiterKomponente.AccessLayer
{
    public interface IMitarbeiterServicesFuerKunden
    {
        Rezeptionist FindRezeptionistById(int id);
        Trainer FindTrainerById(int id);
    }
}