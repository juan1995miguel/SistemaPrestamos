using LinqToDB.Mapping;

namespace AccesoDatos.Models
{
    public class TGestores
    {
        [PrimaryKey, Identity]
        public int IdGestor { get; set; }
        public string Nombre { get; set; }
    }
}
