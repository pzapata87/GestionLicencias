using System.Data.Entity;
using Licencias.DataAccess;

namespace Licencias.Bussines
{
    public class GiroBusiness
    {
        private readonly GLicenciasBDContainer _db;

        public GiroBusiness()
        {
            _db = new GLicenciasBDContainer();
        }

        public IDbSet<Giro> FindAll()
        {
            return _db.Giro;
        }

        public Giro Get(int id)
        {
            return _db.Giro.Find(id);
        }
    }
}