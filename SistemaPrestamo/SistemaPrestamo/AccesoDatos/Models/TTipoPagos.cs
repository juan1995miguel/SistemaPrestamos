using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class TTipoPagos
    {
        [PrimaryKey, Identity]
        public int IdTipoPago { get; set; }
        public string Descripcion { get; set; }
    }
}
