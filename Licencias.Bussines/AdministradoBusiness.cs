using System.Data.Entity;
using Licencias.DataAccess;

namespace Licencias.Bussines
{
    public class AdministradoBusiness
    {
        private readonly GLicenciasBDContainer _db;

        public AdministradoBusiness()
        {
            _db = new GLicenciasBDContainer();
        }

        public IDbSet<Administrado> FindAll()
        {
            return _db.Administrado;
        }

        public Administrado Get(int id)
        {
            return _db.Administrado.Find(id);
        }
    }
}