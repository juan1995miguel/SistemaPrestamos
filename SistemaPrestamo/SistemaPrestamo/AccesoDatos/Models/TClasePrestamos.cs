using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class TClasePrestamos
    {
        [PrimaryKey, Identity]
        public int IdClasePrestamo { get; set; }
        public string Descripcion { get; set; }
    }
}
