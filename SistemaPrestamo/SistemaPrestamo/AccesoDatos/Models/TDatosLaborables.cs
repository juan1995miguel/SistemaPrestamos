using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class TDatosLaborables
    {
        [PrimaryKey, Identity]
        public int IdDatosLaborables { get; set; }
        public string Empresa { get; set; }
        public string TelefonoEmp { get; set; }
        public string DireccionEmp { get; set; }
        public string Cargo { get; set; }
        public string TiempoLaborando { get; set; }
        public decimal Sueldo { get; set; }
        public decimal OtroIngresos { get; set; }
        public string DetalleOtroIngresos { get; set; }
        public decimal UtilidadNeta { get; set; }
        public int CodigoCliente { get; set; }
        public decimal Gastos { get; set; }
    }
}
