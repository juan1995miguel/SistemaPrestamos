using LinqToDB.Mapping;

namespace AccesoDatos.Models
{
    public class TEstadoPrestamos
    {
        [PrimaryKey, Identity]
        public int IdEstadoPrestamo { get; set; }
        public string DescripcionEp { get; set; }
    }
}
