using LinqToDB.Mapping;
using System;

namespace AccesoDatos.Models
{
    public class TSolicitudes
    {
        [PrimaryKey, Identity]
        public int IdSolicitud { get; set; }
        public int CodigoSolicitud { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoCoDeudor { get; set; }
        public int CodigoGarantia { get; set; }
        public int IdTipoPrestamo { get; set; }
        public int IdFormaPago { get; set; }
        public int IdClasePrestamo { get; set; }
        public int IdTipoGarantia { get; set; }
        public int IdRuta { get; set; }
        public int IdZona { get; set; }
        public int IdGestor { get; set; }
        public DateTime FechaPago { get; set; }
        public string DescripcionInversion { get; set; }
        public int MontoSolicitado { get; set; }
        public int GastosLegales { get; set; }
        public int MontoTotal { get; set; }
        public int CantidadCuotas { get; set; }
        public decimal TasaInteresAnual { get; set; }
        public decimal TasaComisionAnual { get; set; }
        public decimal TasaSeguroAnual { get; set; }
        public int MontoCuota { get; set; }
        public int IdEstadoSolicitud { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public int IdUsuario { get; set; }
        public int IdSucursal { get; set; }
        public int IdEstadoPrestamo { get; set; }
        public string Mes { get; set; }
        public string Year { get; set; }
    }
}
