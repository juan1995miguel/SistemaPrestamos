using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class TDetalleCobros
    {
        [PrimaryKey, Identity]
        public int IdDetalleCobro { get; set; }
        public string CodigoRecibo { get; set; }
        public int Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal Comision { get; set; }
        public decimal Seguro { get; set; }
        public int Mora { get; set; }
        public int Cargo { get; set; }
        
    }
}
