using LinqToDB.Mapping;

namespace AccesoDatos.Models
{
    public class TReferencias
    {
        [PrimaryKey, Identity]
        public int IdReferencias { get; set; }
        public string NombreRef { get; set; }
        public string Parentesco { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public int CodigoCliente { get; set; }
    }
}
