using System.Linq;
using System.Web.Mvc;
using Licencias.Bussines;
using Licencias.Presentation.Models;

namespace Licencias.Presentation.Controllers
{
    public class SolicitudLicenciaController : Controller
    {
        #region Variables

        private readonly SolicitudLicenciaBusiness _licenciaBusiness;

        #endregion

        #region Constructor

        public SolicitudLicenciaController()
        {
            _licenciaBusiness = new SolicitudLicenciaBusiness();
        }

        #endregion

        #region Metodos Publicos

        public ActionResult Index()
        {
            var list =
                _licenciaBusiness.FindAll()
                    .ToList()
                    .ConvertAll(p => new SolicitudLicenciaModel
                    {
                        Id = p.Id,
                        GiroNombre = p.Giro.Descripcion,
                        AdministradoNombre = p.Administrado.Nombres
                    });

            return View(list);
        }

        public ActionResult Crear()
        {
            return View("Edit", new CronogramaFiscalizacionModel
            {
                Accion = "Crear"
            });
        }

        #endregion
    }
}