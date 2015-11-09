using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Licencias.Presentation.Core.Enums;

namespace Licencias.Presentation.Core
{
    public static class Utils
    {
        public static Dictionary<string, string> EstadoFiscalizacionList { get; private set; }

        #region Métodos adicionales y de extensión para fechas

        /// <summary>
        /// Convierte una fecha en una cadena con formato: dd/mm/yyyy.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns>dd/mm/yyyy</returns>
        public static string GetDate(this DateTime fecha)
        {
            return string.Format("{0:dd/MM/yyyy}", fecha);
        }

        /// <summary>
        /// Extrae la hora de una fecha en formato: hh:mm.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns>hh:mm</returns>
        public static string ConvertToHour(this DateTime fecha)
        {
            return string.Format("{0:HH:mm}", fecha);
        }

        /// <summary>
        /// Convierte una fecha en una cadena con formato: dd/mm/yyyy hh:mm:ss(includeSeconds = true), dd/mm/yyyy hh:mm
        /// (includeSeconds = false).
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="includeSeconds"></param>
        /// <returns>dd/mm/yyyy hh:mm:ss => (includeSeconds = true), dd/mm/yyyy hh:mm => (includeSeconds = false)</returns>
        public static string GetDateTime(this DateTime dateTime, bool includeSeconds = true)
        {
            return includeSeconds
                ? string.Format("{0:dd/MM/yyyy HH:mm:ss}", dateTime)
                : string.Format("{0:dd/MM/yyyy HH:mm}", dateTime);
        }

        /// <summary>
        /// Retorna la fecha con la última hora del dia: dd/mm/yy 23:59:59.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static DateTime GetDateEnd(this DateTime fecha)
        {
            return new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);
        }

        /// <summary>
        /// Retorna la fecha con la hora inicial del dia: dd/mm/yy 0:0:0.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static DateTime GetDateStar(this DateTime fecha)
        {
            return new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
        }

        /// <summary>
        /// Retorna la fecha equivalente en base al timezone origen hacia el timezone local
        /// </summary>
        /// <param name="dateAnotherTimeZone">fecha en otro timezone distinto al local</param>
        /// <param name="timeZoneSourceId">Id del timezone en el que viene la fecha</param>
        /// <returns>Fecha equivalente en el timezone local</returns>
        public static DateTime ConvertDateTimeToLocalTimeZone(DateTime dateAnotherTimeZone, string timeZoneSourceId)
        {
            DateTime fechaConvertida = TimeZoneInfo.ConvertTime(dateAnotherTimeZone,
                TimeZoneInfo.FindSystemTimeZoneById(timeZoneSourceId),
                TimeZoneInfo.Local);
            return fechaConvertida;
        }

        #endregion Métodos adicionales y de extensión para fechas

        public static void AsignarEstadoFiscalizacion()
        {
            EstadoFiscalizacionList = new Dictionary<string, string>
            {
                {Convert.ToString((int) EstadoFiscalizacion.Pendiente), "Pendiente"},
                {Convert.ToString((int) EstadoFiscalizacion.NoEncontrado), "No Encontrado"},
                {Convert.ToString((int) EstadoFiscalizacion.Finalizado), "Finalizado"},
                {Convert.ToString((int) EstadoFiscalizacion.FinalizadoVerificado), "Finalizado Verificado"}
            };
        }

        public static List<SelectListItem> SelectEstadoFiscalizacion()
        {
            var list =
                EstadoFiscalizacionList.Where(
                    p =>
                        p.Key != EstadoFiscalizacion.Pendiente.GetStringValue() &&
                        p.Key != EstadoFiscalizacion.FinalizadoVerificado.GetStringValue())
                    .Select(p => new SelectListItem
                    {
                        Text = p.Value,
                        Value = p.Key
                    }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "--Seleccionar--",
                Value = ""
            });

            return list;
        }

        #region Metodos Archivos

        public static bool ValidarExtensionImagen(string extension)
        {
            if (String.IsNullOrEmpty(extension)) return false;

            var extenciones = new[] { "bmp", "gif", "jpeg", "jpg", "png" };
            return extenciones.Contains(extension.ToLower());
        }

        public static void Guardar(HttpPostedFileBase file, string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var finalPath = ObtenerDireccion(path, file.FileName);

            file.SaveAs(finalPath);
        }

        public static void Borrar(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public static string ObtenerDireccion(string path, string filename)
        {
            return Path.Combine(path, Path.GetFileName(filename));
        }

        public static string ObtenerExtension(string path)
        {
            return Path.GetExtension(path);
        }

        public static string ObtenerNombreArchivo(string path)
        {
            return Path.GetFileName(path);
        }

        #endregion

        #region Extensiones enumeración

        public static string GetStringValue(this System.Enum value)
        {
            return Convert.ToString(Convert.ChangeType(value, value.GetTypeCode()));
        }

        public static int GetNumberValue(this System.Enum value)
        {
            return Convert.ToInt32(Convert.ChangeType(value, value.GetTypeCode()));
        }

        #endregion
    }
}