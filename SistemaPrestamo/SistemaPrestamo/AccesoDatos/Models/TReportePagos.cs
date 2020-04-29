using LinqToDB.Mapping;
using System;

namespace AccesoDatos.Models
{
    public class TReportePagos
    {
        [PrimaryKey, Identity]
        public int IdReportePago { get; set; }
        public int CodigoSolicitud { get; set; }
        public int MontoPrestamo { get; set; }
        public int CapitalPagado { get; set; }
        public decimal InteresPagado { get; set; }
        public decimal ComisionPagado { get; set; }
        public decimal SeguroPagado { get; set; }
        public int MoraPagada { get; set; }
        public int CargosPagado { get; set; }
        public int SaldoActual { get; set; }
        public string FechaUltimoPago { get; set; }
        public int DiasSinPagar { get; set; }
        public bool Estado { get; set; }
    }
}
