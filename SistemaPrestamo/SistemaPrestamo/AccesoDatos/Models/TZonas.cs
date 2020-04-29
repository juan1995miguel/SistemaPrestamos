using LinqToDB.Mapping;

namespace AccesoDatos.Models
{
    public class TZonas
    {
        [PrimaryKey, Identity]
        public int IdZona { get; set; }
        public string Descripcion { get; set; }
    }
}
