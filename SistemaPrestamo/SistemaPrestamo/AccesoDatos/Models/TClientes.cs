using LinqToDB.Mapping;
using System;

namespace AccesoDatos.Models
{
    public class TClientes
    {
        [PrimaryKey, Identity]
        public int IdCliente { get; set; }
        public string NoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Apodo { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public bool EstadoCliente { get; set; }
        public int CodigoCliente { get; set; }

        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }

        public int IdSucursal { get; set; }

    }






}
