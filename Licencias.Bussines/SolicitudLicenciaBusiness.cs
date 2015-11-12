using System.Data.Entity;
using System.Data.Entity.Migrations;
using Licencias.DataAccess;

namespace Licencias.Bussines
{
    public class SolicitudLicenciaBusiness
    {
        private readonly GLicenciasBDContainer _db;

        public SolicitudLicenciaBusiness()
        {
            _db = new GLicenciasBDContainer();
        }

        public IDbSet<SolicitudLicencia> FindAll()
        {
            return _db.SolicitudLicencia;
        }

        public SolicitudLicencia Get(int id)
        {
            return _db.SolicitudLicencia.Find(id);
        }

        public SolicitudLicencia Add(SolicitudLicencia entity)
        {
            entity = _db.SolicitudLicencia.Add(entity);
            _db.SaveChanges();

            return entity;
        }

        public SolicitudLicencia Update(SolicitudLicencia entity)
        {
            _db.SolicitudLicencia.AddOrUpdate(entity);
            _db.SaveChanges();

            return entity;
        }
    }
}