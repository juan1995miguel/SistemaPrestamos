using LinqToDB.Mapping;
using System;

namespace AccesoDatos.Models
{
    public class TDetalleSolicitudes
    {
        [PrimaryKey, Identity]
        public int IdDetalleSolicitud { get; set; }
        public int CodigoSolicitud { get; set; }
        public int NoCuota { get; set; }
        public DateTime FechaPago { get; set; }
        public int Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal Comision { get; set; }
        public decimal Seguro { get; set; }
        public int ValorCuota { get; set; }
        
    }
}
