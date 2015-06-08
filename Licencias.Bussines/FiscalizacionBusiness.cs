using System.Data.Entity;
using System.Data.Entity.Migrations;
using Licencias.DataAccess;

namespace Licencias.Bussines
{
    public class FiscalizacionBusiness
    {
        private readonly GLicenciasBDContainer _db;

        public FiscalizacionBusiness()
        {
            _db = new GLicenciasBDContainer();
        }

        public IDbSet<Fiscalizacion> FindAll()
        {
            return _db.Fiscalizacion;
        }

        public Fiscalizacion Get(int id)
        {
            return _db.Fiscalizacion.Find(id);
        }

        public Fiscalizacion Add(Fiscalizacion entity)
        {
            entity = _db.Fiscalizacion.Add(entity);
            _db.SaveChanges();

            return entity;
        }

        public Fiscalizacion Update(Fiscalizacion entity)
        {
            _db.Fiscalizacion.AddOrUpdate(entity);
            _db.SaveChanges();

            return entity;
        }
    }
}