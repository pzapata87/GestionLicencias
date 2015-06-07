using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Licencias.DataAccess;

namespace Licencias.Bussines
{
    public class FiscalizadorBusiness
    {
        private readonly GLicenciasBDContainer _db;

        public FiscalizadorBusiness()
        {
            _db = new GLicenciasBDContainer();
        }

        public IDbSet<Fiscalizador> FindAll()
        {
            return _db.Fiscalizador;
        }

        public List<Fiscalizador> FindAll(string search)
        {
            return _db.Fiscalizador.Where(p => p.Nombre.Contains(search) || p.Apellido.Contains(search)).ToList();
        }

        public Fiscalizador Get(int id)
        {
            return _db.Fiscalizador.Find(id);
        }
    }
}