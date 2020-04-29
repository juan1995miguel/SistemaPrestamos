using LinqToDB.Mapping;
using System;

namespace AccesoDatos.Models
{
    public class TNotasSolicitudes
    {
        [PrimaryKey, Identity]
        public int IdNotaSolicitud { get; set; }
        public int CodigoSolicitud { get; set; }
        public int IdEstadoSolicitud { get; set; }
        public string DescripcionNS { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
