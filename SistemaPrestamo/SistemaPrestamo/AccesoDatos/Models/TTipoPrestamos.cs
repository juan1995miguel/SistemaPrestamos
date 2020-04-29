using LinqToDB.Mapping;

namespace AccesoDatos.Models
{
    public class TTipoPrestamos
    {
        [PrimaryKey, Identity]
        public int IdTipoPrestamo { get; set; }
        public string Descripcion { get; set; }
    }
}
