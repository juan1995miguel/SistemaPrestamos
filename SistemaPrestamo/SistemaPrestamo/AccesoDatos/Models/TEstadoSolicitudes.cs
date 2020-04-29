using LinqToDB.Mapping;

namespace AccesoDatos.Models
{
    public class TEstadoSolicitudes
    {
        [PrimaryKey, Identity]
        public int IdEstadoSolicitud { get; set; }
        public string DescripcionES { get; set; }
    }
}
