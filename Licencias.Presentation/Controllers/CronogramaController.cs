using System;
using System.Linq;
using System.Web.Mvc;
using Licencias.Bussines;
using Licencias.DataAccess;
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

        public ActionResult Crear()
        {
            return View("Edit", new CronogramaFiscalizacionModel
            {
                Accion = "Crear"
            });
        }

        [HttpPost]
        public ActionResult Crear(CronogramaFiscalizacionModel model)
        {
            var jsonResponse = new JsonResponse {Success = false};
            try
            {
                var cronograma = new CronogramaFiscalizacion
                {
                    FechaFiscalizacion = Convert.ToDateTime(model.FechaFiscalizacion),
                    Fiscalizador = model.Fiscalizador,
                    Comentario = model.Comentario,
                    LicenciaId = 1,
                    UsuarioId = 1
                };

                _cronogramaBusiness.Add(cronograma);
                jsonResponse.Success = true;
                jsonResponse.Message = "La operación se realizó con éxito.";
            }
            catch (Exception ex)
            {
                jsonResponse.Message = ex.Message;
            }

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
