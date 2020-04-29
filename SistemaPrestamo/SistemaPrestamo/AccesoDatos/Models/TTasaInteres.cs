using LinqToDB.Mapping;

namespace AccesoDatos.Models
{
    public class TTasaInteres
    {
        [PrimaryKey, Identity]
        public int IdTasaInteres { get; set; }
        public decimal Valor { get; set; }
    }
}
