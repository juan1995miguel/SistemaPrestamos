using LinqToDB.Mapping;

namespace AccesoDatos.Models
{
    public class TTasaMoras
    {
        [PrimaryKey, Identity]
        public int IdTasaMora { get; set; }
        public decimal Valor { get; set; }
    }
}
