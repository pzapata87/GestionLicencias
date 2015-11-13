using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Licencias.DataAccess;

namespace Licencias.Bussines
{
    public class LicenciaBusiness
    {
        private readonly GLicenciasBDContainer _db;

        public LicenciaBusiness()
        {
            _db = new GLicenciasBDContainer();
        }

        public IDbSet<Licencia> FindAll()
        {
            return _db.Licencia;
        }

        public List<Licencia> FindAll(string search)
        {
            return _db.Licencia.Where(p => p.Direccion.Contains(search)).ToList();
        }

        public Licencia Get(int id)
        {
            return _db.Licencia.Find(id);
        }

        public Licencia Add(Licencia entity)
        {
            entity = _db.Licencia.Add(entity);
            _db.SaveChanges();

            return entity;
        }

        public Licencia Update(Licencia entity)
        {
            _db.Licencia.AddOrUpdate(entity);
            _db.SaveChanges();

            return entity;
        }
    }
}