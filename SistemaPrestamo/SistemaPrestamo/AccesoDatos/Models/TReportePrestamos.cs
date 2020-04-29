using LinqToDB.Mapping;
using System;

namespace AccesoDatos.Models
{
    public class TReportePrestamos
    {
        [PrimaryKey, Identity]
        public int IdReportePrestamos { get; set; }
        public int CodigoSolicitud { get; set; }
        public int NoCuota { get; set; }
        public DateTime FechaPago { get; set; }
        public int Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal Comision { get; set; }
        public decimal Seguro { get; set; }
        public int Mora { get; set; }
        public int Cargos { get; set; }
        public int SubTotal { get; set; }
        public int IdEstadoCuota { get; set; }
        public bool EstadoFecha { get; set; }
    }
}
