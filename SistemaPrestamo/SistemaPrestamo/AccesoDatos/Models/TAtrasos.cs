using LinqToDB.Mapping;
using System;


namespace AccesoDatos.Models
{
    public class TAtrasos
    {
        [PrimaryKey, Identity]
        public int IdAtraso { get; set; }
        public int CodigoSolicitud { get; set; }
        public int Capital { get; set; }
        public decimal Intere { get; set; }
        public decimal Comision { get; set; }
        public decimal Seguro { get; set; }
        public int Mora { get; set; }
        public int Cargos { get; set; }
    }
}
