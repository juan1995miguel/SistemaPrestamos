using LinqToDB.Mapping;

namespace AccesoDatos.Models
{
    public class TRutas
    {
        [PrimaryKey, Identity]
        public int IdRuta { get; set; }
        public string Descripcion { get; set; }
    }
}
