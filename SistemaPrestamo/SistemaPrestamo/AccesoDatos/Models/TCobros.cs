using LinqToDB.Mapping;
using System;

namespace AccesoDatos.Models
{
    public class TCobros
    {
        [PrimaryKey, Identity]
        public int IdCobro { get; set; }
        public int CodigoPrestamo { get; set; }
        public DateTime FechaCobro { get; set; }
        public string HoraCobro { get; set; }
        public string CodigoRecibo { get; set; }
        public string ConceptoCobro { get; set; }
        public int IdUsuario { get; set; }
        public int IdSucursal { get; set; }
        public bool EstadoCobro { get; set; }
        public int IdDistribucion { get; set; }
    }
}
