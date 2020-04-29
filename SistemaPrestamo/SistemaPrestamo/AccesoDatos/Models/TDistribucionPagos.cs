using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class TDistribucionPagos
    {
        [PrimaryKey, Identity]
        public int IdDistribucion { get; set; }
        public string Descripcion { get; set; }
    }
}
