using System.Data.Entity;
using System.Data.Entity.Migrations;
using Licencias.DataAccess;

namespace Licencias.Bussines
{
    public class CronogramaFiscalizacionBusiness
    {
        private readonly GLicenciasBDContainer _db;

        public CronogramaFiscalizacionBusiness()
        {
            _db = new GLicenciasBDContainer();
        }

        public IDbSet<CronogramaFiscalizacion> FindAll()
        {
            return _db.CronogramaFiscalizacion;
        }

        public CronogramaFiscalizacion Get(int id)
        {
            return _db.CronogramaFiscalizacion.Find(id);
        }

        public CronogramaFiscalizacion Add(CronogramaFiscalizacion entity)
        {
            entity = _db.CronogramaFiscalizacion.Add(entity);
            _db.SaveChanges();

            return entity;
        }

        public CronogramaFiscalizacion Update(CronogramaFiscalizacion entity)
        {
            _db.CronogramaFiscalizacion.AddOrUpdate(entity);
            _db.SaveChanges();

            return entity;
        }
    }
}