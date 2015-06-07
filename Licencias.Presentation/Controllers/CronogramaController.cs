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
        private readonly LicenciaBusiness _licenciaBusiness;
        private readonly FiscalizadorBusiness _fiscalizadorBusiness;

        #endregion

        #region Constructor

        public CronogramaController()
        {
            _cronogramaBusiness = new CronogramaFiscalizacionBusiness();
            _licenciaBusiness = new LicenciaBusiness();
            _fiscalizadorBusiness = new FiscalizadorBusiness();
        }

        #endregion

        #region Metodos Publicos

        public ActionResult Index()
        {
            var list = _cronogramaBusiness.FindAll().ToList().ConvertAll(p => new CronogramaFiscalizacionModel
            {
                Id = p.Id,
                FiscalizadorId = p.FiscalizadorId,
                FiscalizadorNombre = p.Fiscalizador.Nombre,
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

        public ActionResult Editar(int id)
        {
            var entity = _cronogramaBusiness.Get(id);
            return View("Edit", new CronogramaFiscalizacionModel
            {
                Id = entity.Id,
                LicenciaId = entity.LicenciaId,
                Comentario = entity.Comentario,
                FechaFiscalizacion = entity.FechaFiscalizacion.GetDate(),
                FiscalizadorId = entity.FiscalizadorId,
                FiscalizadorNombre = entity.Fiscalizador.Nombre,
                LocalId = entity.Licencia.LocalId,
                LocalNombre = entity.Licencia.Local.Direccion,
                NumLicencia = entity.Licencia.NumLicencia,
                Accion = "Editar"
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
                    FiscalizadorId = model.FiscalizadorId,
                    Comentario = model.Comentario,
                    LicenciaId = model.LicenciaId
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

        [HttpPost]
        public ActionResult Editar(CronogramaFiscalizacionModel model)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var entity = _cronogramaBusiness.Get(model.Id);

                entity.FechaFiscalizacion = Convert.ToDateTime(model.FechaFiscalizacion);
                entity.FiscalizadorId = model.FiscalizadorId;
                entity.Comentario = model.Comentario;
                entity.LicenciaId = model.LicenciaId;

                _cronogramaBusiness.Update(entity);
                jsonResponse.Success = true;
                jsonResponse.Message = "La operación se realizó con éxito.";
            }
            catch (Exception ex)
            {
                jsonResponse.Message = ex.Message;
            }

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Ver(int id)
        {
            var entity = _cronogramaBusiness.Get(id);
            return View("Ver", new CronogramaFiscalizacionModel
            {
                Id = entity.Id,
                LicenciaId = entity.LicenciaId,
                Comentario = entity.Comentario,
                FechaFiscalizacion = entity.FechaFiscalizacion.GetDate(),
                FiscalizadorId = entity.FiscalizadorId,
                FiscalizadorNombre = entity.Fiscalizador.Nombre,
                LocalId = entity.Licencia.LocalId,
                LocalNombre = entity.Licencia.Local.Direccion,
                NumLicencia = entity.Licencia.NumLicencia
            });
        }

        [HttpPost]
        public JsonResult GetLicencias(string search)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                jsonResponse.Data = _licenciaBusiness.FindAll(search).Select(p => new
                {
                    id = p.Id,
                    text = p.Local.Direccion,
                    numLicencia = p.NumLicencia
                });

                jsonResponse.Success = true;
            }
            catch (Exception ex)
            {
                jsonResponse.Message = ex.Message;
            }

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetFiscalizadores(string search)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                jsonResponse.Data = _fiscalizadorBusiness.FindAll(search).Select(p => new
                {
                    id = p.Id,
                    text = string.Format("{0}, {1}", p.Apellido, p.Nombre)
                });

                jsonResponse.Success = true;
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
