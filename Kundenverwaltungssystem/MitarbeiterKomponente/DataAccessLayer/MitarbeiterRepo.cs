//using MitarbeiterKomponente.DataAccessLayer.Entities;
using PersistenceService;
using PersistenceService._1___Implementation;

namespace MitarbeiterKomponente.DataAccessLayer.Repository
{
    public class MitarbeiterRepo
    {
        private IPersistenceService _persistenceService;

        public MitarbeiterRepo(IPersistenceService ps)
        {
            _persistenceService = ps;
        }

        public Rezeptionist SaveRezeptionist(Rezeptionist rezeptionist)
        {
            return _persistenceService.Save(rezeptionist);
        }

        public Trainer SaveTrainer(Trainer trainer)
        {
            return _persistenceService.Save(trainer);
        }

        public Rezeptionist UpdateRezeptionist(Rezeptionist rezeptionist)
        {
            return _persistenceService.Update(rezeptionist);
        }

        public Trainer UpdateTrainer(Trainer trainer)
        {
            return _persistenceService.Update(trainer);
        }

        public Rezeptionist FindRezeptionistById(int id)
        {
            return _persistenceService.GetById<Rezeptionist, int>(id);
        }

        public Trainer FindTrainerById(int id)
        {
            return _persistenceService.GetById<Trainer, int>(id);
        }

        public void DeleteRezeptionist(Rezeptionist rezeptionist)
        {
            _persistenceService.Delete(rezeptionist);
        }

        public void DeleteTrainer(Trainer trainer)
        {
            _persistenceService.Delete(trainer);
        }
    }
}