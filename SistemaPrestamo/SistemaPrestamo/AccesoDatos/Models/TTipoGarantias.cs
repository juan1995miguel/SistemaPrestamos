using LinqToDB.Mapping;

namespace AccesoDatos.Models
{
    public class TTipoGarantias
    {
        [PrimaryKey, Identity]
        public int IdTipoGarantia { get; set; }
        public string Descripcion { get; set; }
    }
}
