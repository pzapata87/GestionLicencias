using System.Linq;
using System.Web.Mvc;
using Licencias.Bussines;
using Licencias.Presentation.Core;
using Licencias.Presentation.Models;

namespace Licencias.Presentation.Controllers
{
    public class CronogramaController : Controller
    {
        #region Variables

        private readonly CronogramaFiscalizacionBusiness _cronogramaBusiness;

        #endregion

        #region Constructor

        public CronogramaController()
        {
            _cronogramaBusiness = new CronogramaFiscalizacionBusiness();
        }

        #endregion

        #region Metodos Publicos

        public ActionResult Index()
        {
            var list = _cronogramaBusiness.FindAll().ToList().ConvertAll(p => new CronogramaFiscalizacionModel
            {
                Id = p.Id,
                Fiscalizador = p.Fiscalizador,
                FechaFiscalizacion = p.FechaFiscalizacion.GetDate(),
                NumLicencia = p.Licencia.NumLicencia,
                LicenciaId = p.LicenciaId
            });
            
            return View(list);
        }

        #endregion
    }
}
