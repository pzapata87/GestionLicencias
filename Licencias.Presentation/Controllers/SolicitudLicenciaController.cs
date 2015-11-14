using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Licencias.Bussines;
using Licencias.DataAccess;
using Licencias.Presentation.Core;
using Licencias.Presentation.Models;

namespace Licencias.Presentation.Controllers
{
    public class SolicitudLicenciaController : Controller
    {
        #region Variables

        private readonly SolicitudLicenciaBusiness _solLicenciaBusiness;
        private readonly LicenciaBusiness _licenciaBusiness;
        private readonly GiroBusiness _giroBusiness;
        private readonly AdministradoBusiness _administradoBusiness;

        #endregion

        #region Constructor

        public SolicitudLicenciaController()
        {
            _solLicenciaBusiness = new SolicitudLicenciaBusiness();
            _giroBusiness = new GiroBusiness();
            _administradoBusiness = new AdministradoBusiness();
            _licenciaBusiness = new LicenciaBusiness();
        }

        #endregion

        #region Metodos Publicos

        public ActionResult Index()
        {
            var list =
                _solLicenciaBusiness.FindAll()
                    .OrderByDescending(p => p.Id)
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
            var model = new SolicitudLicenciaModel
            {
                GiroList =
                    _giroBusiness.FindAll()
                        .ToList()
                        .ConvertAll(p => new KeyValuePair<int?, string>(p.Id, p.Descripcion)),
                AdministradoList =
                    _administradoBusiness.FindAll()
                        .ToList()
                        .ConvertAll(p => new KeyValuePair<int?, string>(p.Id, p.Nombres)),
                Fut = new FormularioUnicoTramiteModel(),
                SolicitudAnuncio = new SolicitudAnuncioModel(),
                DeclaracionJuradaList = new List<DeclaracionJuradaModel>(),
                Accion = "Crear"
            };

            model.GiroList.Insert(0, new KeyValuePair<int?, string>(null, "--Seleccionar--"));
            model.AdministradoList.Insert(0, new KeyValuePair<int?, string>(null, "--Seleccionar--"));

            return View("Edit", model);
        }

        public ActionResult Editar(int id)
        {
            var entity = _solLicenciaBusiness.Get(id);
            var model = new SolicitudLicenciaModel
            {
                Id = entity.Id,
                Solicitante = entity.Solicitante,
                GiroId = entity.GiroId,
                AdministradoId = entity.AdministradoId,
                GiroList =
                    _giroBusiness.FindAll()
                        .ToList()
                        .ConvertAll(p => new KeyValuePair<int?, string>(p.Id, p.Descripcion)),
                AdministradoList =
                    _administradoBusiness.FindAll()
                        .ToList()
                        .ConvertAll(p => new KeyValuePair<int?, string>(p.Id, p.Nombres)),
                DeclaracionJuradaList = entity.DeclaracionJuradas.Select(p => new DeclaracionJuradaModel
                {
                    RequisitoId = p.RequisitoId,
                    Valor = p.Requisito.Valor,
                    Corresponde = p.Corresponde
                }).ToList(),
                Fut = new FormularioUnicoTramiteModel
                {
                    CarnetExtranjeria = entity.FormularioUnicoTramite.CarnetExtranjeria,
                    Celular = entity.FormularioUnicoTramite.Celular,
                    Dni = entity.FormularioUnicoTramite.Dni,
                    Domicilio = entity.FormularioUnicoTramite.Domicilio,
                    Ruc = entity.FormularioUnicoTramite.Ruc,
                    Telefax = entity.FormularioUnicoTramite.Telefax,
                    Telefono = entity.FormularioUnicoTramite.Telefono,
                    Correo = entity.FormularioUnicoTramite.Correo,
                    FichaLiteral = entity.FormularioUnicoTramite.FichaLiteral,
                    Representante = entity.FormularioUnicoTramite.Correo,
                },
                SolicitudAnuncio = entity.FormularioUnicoTramite.SolicitudAnuncio != null
                    ? new SolicitudAnuncioModel
                    {
                        Alto = entity.FormularioUnicoTramite.SolicitudAnuncio.Alto,
                        Ancho = entity.FormularioUnicoTramite.SolicitudAnuncio.Ancho,
                        Color = entity.FormularioUnicoTramite.SolicitudAnuncio.Color,
                        Grafico = entity.FormularioUnicoTramite.SolicitudAnuncio.Grafico,
                        Largo = entity.FormularioUnicoTramite.SolicitudAnuncio.Largo,
                        Leyenda = entity.FormularioUnicoTramite.SolicitudAnuncio.Leyenda
                    }
                    : new SolicitudAnuncioModel(),
                Accion = "Editar"
            };

            model.GiroList.Insert(0, new KeyValuePair<int?, string>(null, "--Seleccionar--"));
            model.AdministradoList.Insert(0, new KeyValuePair<int?, string>(null, "--Seleccionar--"));

            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(SolicitudLicenciaModel model)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var solicitud = new SolicitudLicencia
                {
                    AdministradoId = model.AdministradoId,
                    GiroId = model.GiroId,
                    Solicitante = model.Solicitante,
                    DeclaracionJuradas = model.DeclaracionJuradaList.ConvertAll(p => new DeclaracionJurada
                    {
                        RequisitoId = p.RequisitoId,
                        Corresponde = p.Corresponde
                    }),
                    FormularioUnicoTramite = new FormularioUnicoTramite
                    {
                        CarnetExtranjeria = model.Fut.CarnetExtranjeria,
                        Celular = model.Fut.Celular,
                        Dni = model.Fut.Dni,
                        Domicilio = model.Fut.Domicilio,
                        Ruc = model.Fut.Ruc,
                        Telefax = model.Fut.Telefax,
                        Telefono = model.Fut.Telefono,
                        Correo = model.Fut.Correo,
                        FichaLiteral = model.Fut.FichaLiteral,
                        Representante = model.Fut.Correo,
                        SolicitudAnuncio = model.SolicitudAnuncio != null
                            ? new SolicitudAnuncio
                            {
                                Alto = model.SolicitudAnuncio.Alto,
                                Ancho = model.SolicitudAnuncio.Ancho,
                                Color = model.SolicitudAnuncio.Color,
                                Grafico = model.SolicitudAnuncio.Grafico,
                                Largo = model.SolicitudAnuncio.Largo,
                                Leyenda = model.SolicitudAnuncio.Leyenda
                            }
                            : null
                    }
                };

                _solLicenciaBusiness.Add(solicitud);

                var numLicencia = _licenciaBusiness.FindAll().Max(p => p.NumLicencia);

                var licencia = new Licencia
                {
                    FechaLicencia = DateTime.Now,
                    Direccion = model.Fut.Domicilio,
                    Responsable = model.Solicitante,
                    GiroId = model.GiroId,
                    UriImagen = "licencia001.jpg",
                    NumLicencia =
                        numLicencia != null
                            ? (Convert.ToInt32(numLicencia) + 1).ToString().PadLeft(4, '0')
                            : "1".PadLeft(4, '0')
                };

                _licenciaBusiness.Add(licencia);

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
        [ValidateAntiForgeryToken]
        public ActionResult Editar(SolicitudLicenciaModel model)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var entity = _solLicenciaBusiness.Get(model.Id);

                entity.AdministradoId = model.AdministradoId;
                entity.GiroId = model.GiroId;
                entity.Solicitante = model.Solicitante;

                entity.DeclaracionJuradas.Clear();
                entity.DeclaracionJuradas = model.DeclaracionJuradaList.ConvertAll(p => new DeclaracionJurada
                {
                    RequisitoId = p.RequisitoId,
                    Corresponde = p.Corresponde
                });
                entity.FormularioUnicoTramite.CarnetExtranjeria = model.Fut.CarnetExtranjeria;
                entity.FormularioUnicoTramite.Celular = model.Fut.Celular;
                entity.FormularioUnicoTramite.Dni = model.Fut.Dni;
                entity.FormularioUnicoTramite.Domicilio = model.Fut.Domicilio;
                entity.FormularioUnicoTramite.Ruc = model.Fut.Ruc;
                entity.FormularioUnicoTramite.Telefax = model.Fut.Telefax;
                entity.FormularioUnicoTramite.Telefono = model.Fut.Telefono;
                entity.FormularioUnicoTramite.Correo = model.Fut.Correo;
                entity.FormularioUnicoTramite.FichaLiteral = model.Fut.FichaLiteral;
                entity.FormularioUnicoTramite.Representante = model.Fut.Correo;

                if (model.SolicitudAnuncio != null)
                {
                    entity.FormularioUnicoTramite.SolicitudAnuncio.Alto = model.SolicitudAnuncio.Alto;
                    entity.FormularioUnicoTramite.SolicitudAnuncio.Ancho = model.SolicitudAnuncio.Ancho;
                    entity.FormularioUnicoTramite.SolicitudAnuncio.Color = model.SolicitudAnuncio.Color;
                    entity.FormularioUnicoTramite.SolicitudAnuncio.Grafico = model.SolicitudAnuncio.Grafico;
                    entity.FormularioUnicoTramite.SolicitudAnuncio.Largo = model.SolicitudAnuncio.Largo;
                    entity.FormularioUnicoTramite.SolicitudAnuncio.Leyenda = model.SolicitudAnuncio.Leyenda;
                }
                
                _solLicenciaBusiness.Update(entity);
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
        public JsonResult GetRequisitos(int giroId)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                jsonResponse.Data = _giroBusiness.Get(giroId).Requisitos.Select(p => new {p.Id, p.Valor}).ToList();
                jsonResponse.Success = true;
            }
            catch (Exception ex)
            {
                jsonResponse.Message = ex.Message;
            }

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ValidarRuc(string ruc)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var client = new Aduanet.wsadpdPortClient();
                var resp = client.verficaRUC(ruc);

                jsonResponse.Data = resp;
                jsonResponse.Success = true;
            }
            catch (Exception ex)
            {
                jsonResponse.Message = ex.Message.Contains("No Activo")
                    ? "No Activo"
                    : ex.Message.Contains("Activo") ? "Activo" : ex.Message;
            }

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        } 

        #endregion
    }
}