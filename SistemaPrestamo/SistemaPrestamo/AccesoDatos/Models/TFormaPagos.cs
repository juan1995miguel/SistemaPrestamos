using LinqToDB.Mapping;

namespace AccesoDatos.Models
{
    public class TFormaPagos
    {
        [PrimaryKey, Identity]
        public int IdFormaPago { get; set; }
        public string DescripcionFP { get; set; }
    }
}
