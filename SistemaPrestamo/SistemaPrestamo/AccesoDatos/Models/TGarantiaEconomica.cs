using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class TGarantiaEconomica
    {
        [PrimaryKey, Identity]
        public int IdGarantiaE { get; set; }
        public int CodigoGarantia { get; set; }
        public string NombreGE { get; set; }
        public string DescripcionGE { get; set; }
        public bool MatriculaOTituloGE { get; set; }
        public decimal ValorEstimadoGE { get; set; }
        public int CodigoCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public int IdUsuario { get; set; }
    }
}
