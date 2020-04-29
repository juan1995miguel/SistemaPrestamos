using LinqToDB.Mapping;

namespace AccesoDatos.Models
{
    public class TEstadoCuotas
    {
        [PrimaryKey, Identity]
        public int IdEstadoCuota { get; set; }
        public string DescripcionEC { get; set; }
    }
}
