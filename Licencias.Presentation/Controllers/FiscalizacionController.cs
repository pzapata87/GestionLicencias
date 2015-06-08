using System;
using System.Linq;
using System.Web.Mvc;
using Licencias.Bussines;
using Licencias.DataAccess;
using Licencias.Presentation.Core;
using Licencias.Presentation.Core.Enums;
using Licencias.Presentation.Models;

namespace Licencias.Presentation.Controllers
{
    public class FiscalizacionController : Controller
    {
        #region Variables

        private readonly FiscalizacionBusiness _fiscalizacionBusiness;
        private readonly LicenciaBusiness _licenciaBusiness;
        private readonly FiscalizadorBusiness _fiscalizadorBusiness;

        #endregion

        #region Constructor

        public FiscalizacionController()
        {
            _fiscalizacionBusiness = new FiscalizacionBusiness();
            _licenciaBusiness = new LicenciaBusiness();
            _fiscalizadorBusiness = new FiscalizadorBusiness();
        }

        #endregion

        #region Metodos Publicos

        #region Cronograma Fiscalizacion

        public ActionResult Index()
        {
            string estadoPendiente = Convert.ToString((int) EstadoFiscalizacion.Pendiente);

            var list =
                _fiscalizacionBusiness.FindAll()
                    .Where(p => p.Estado == estadoPendiente)
                    .ToList()
                    .ConvertAll(p => new CronogramaFiscalizacionModel
                    {
                        Id = p.Id,
                        FiscalizadorId = p.FiscalizadorId,
                        FiscalizadorNombre = p.Fiscalizador.Nombre,
                        FechaFiscalizacion = p.FechaProgramada.GetDate(),
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
            var entity = _fiscalizacionBusiness.Get(id);
            return View("Edit", new CronogramaFiscalizacionModel
            {
                Id = entity.Id,
                LicenciaId = entity.LicenciaId,
                Comentario = entity.Comentario,
                FechaFiscalizacion = entity.FechaProgramada.GetDate(),
                FiscalizadorId = entity.FiscalizadorId,
                FiscalizadorNombre = entity.Fiscalizador.Nombre,
                LocalId = entity.Licencia.LocalId,
                LocalDireccion = entity.Licencia.Local.Direccion,
                NumLicencia = entity.Licencia.NumLicencia,
                Accion = "Editar"
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(CronogramaFiscalizacionModel model)
        {
            var jsonResponse = new JsonResponse {Success = false};

            try
            {
                string estadoNoEncontrado = Convert.ToString((int) EstadoFiscalizacion.NoEncontrado);
                var list = _fiscalizacionBusiness.FindAll().Where(p => p.LicenciaId == model.LicenciaId).ToList();

                if (list.Count == 0 || (list.Count < 2 && list.First().Estado == estadoNoEncontrado))
                {
                    var cronograma = new Fiscalizacion
                    {
                        FechaProgramada = Convert.ToDateTime(model.FechaFiscalizacion),
                        FiscalizadorId = model.FiscalizadorId,
                        Comentario = model.Comentario,
                        LicenciaId = model.LicenciaId,
                        Estado = Convert.ToString((int) EstadoFiscalizacion.Pendiente)
                    };

                    _fiscalizacionBusiness.Add(cronograma);
                    jsonResponse.Success = true;
                    jsonResponse.Message = "La operación se realizó con éxito.";
                }
                else
                {
                    if (list.Count == 1)
                    {
                        var estado = list.First().Estado;
                        jsonResponse.Message =
                            string.Format(estado == Convert.ToString((int) EstadoFiscalizacion.Pendiente)
                                ? "No se permiten fiscalizaciones para esta licencia ya que existe una programación pendiente."
                                : "No se permiten fiscalizaciones para esta licencia se realizó la fiscalización.");
                    }
                    else
                        jsonResponse.Message = "No se permiten más fiscalizaciones para esta licencia.";
                }
            }
            catch (Exception ex)
            {
                jsonResponse.Message = ex.Message;
            }

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CronogramaFiscalizacionModel model)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var entity = _fiscalizacionBusiness.Get(model.Id);

                entity.FechaProgramada = Convert.ToDateTime(model.FechaFiscalizacion);
                entity.FiscalizadorId = model.FiscalizadorId;
                entity.Comentario = model.Comentario;
                entity.LicenciaId = model.LicenciaId;

                _fiscalizacionBusiness.Update(entity);
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
            var entity = _fiscalizacionBusiness.Get(id);

            return View("Ver", new CronogramaFiscalizacionModel
            {
                Id = entity.Id,
                LicenciaId = entity.LicenciaId,
                Comentario = entity.Comentario,
                FechaFiscalizacion = entity.FechaProgramada.GetDate(),
                FiscalizadorId = entity.FiscalizadorId,
                FiscalizadorNombre = entity.Fiscalizador.Nombre,
                LocalId = entity.Licencia.LocalId,
                LocalDireccion = entity.Licencia.Local.Direccion,
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

        #region Fiscalizacion

        public ActionResult Fiscalizaciones()
        {
            var list = _fiscalizacionBusiness.FindAll().ToList().ConvertAll(p => new FiscalizacionModel
            {
                Id = p.Id,
                LocalDireccion = p.Licencia.Local.Direccion,
                FechaFiscalizacion = p.FechaProgramada.GetDate(),
                NumLicencia = p.Licencia.NumLicencia,
                EstadoId = p.Estado,
                EstadoNombre = Utils.EstadoFiscalizacionList[p.Estado]
            });

            return View(list);
        }

        public ActionResult EditarFiscalizacion(int id)
        {
            var entity = _fiscalizacionBusiness.Get(id);

            return View("EditarFiscalizacion", new FiscalizacionModel
            {
                Id = entity.Id,
                FechaFiscalizacion = entity.FechaProgramada.GetDate(),
                Observacion = entity.Observacion,
                LocalDireccion = entity.Licencia.Local.Direccion,
                NumLicencia = entity.Licencia.NumLicencia,
                Detalle = entity.Detalle,
                EstadoNombre = Utils.EstadoFiscalizacionList[entity.Estado],
                EstadoId = entity.Estado,
                UriImagen = entity.Licencia.UriImagen
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarFiscalizacion(FiscalizacionModel model)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var entity = _fiscalizacionBusiness.Get(model.Id);

                entity.FechaReal = Convert.ToDateTime(model.FechaFiscalizacion);
                entity.Observacion = model.Observacion;
                entity.Detalle = model.Detalle;
                entity.Estado = model.EstadoId;

                _fiscalizacionBusiness.Update(entity);
                jsonResponse.Success = true;
                jsonResponse.Message = "La operación se realizó con éxito.";
            }
            catch (Exception ex)
            {
                jsonResponse.Message = ex.Message;
            }

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult VerFiscalizacion(int id)
        {
            var entity = _fiscalizacionBusiness.Get(id);

            return View("VerFiscalizacion", new FiscalizacionModel
            {
                Id = entity.Id,
                FechaFiscalizacion = entity.FechaProgramada.GetDate(),
                Observacion = entity.Observacion,
                LocalDireccion = entity.Licencia.Local.Direccion,
                NumLicencia = entity.Licencia.NumLicencia,
                Detalle = entity.Detalle,
                EstadoNombre = Utils.EstadoFiscalizacionList[entity.Estado],
                UriImagen = entity.Licencia.UriImagen
            });
        }

        #endregion

        #endregion
    }
}
