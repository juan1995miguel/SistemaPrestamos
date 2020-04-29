using AccesoDatos.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ModelosVista
{
    public class GetReporteVM : Conexion
    {
        public string Valuereturn;
        public string Reporte(int condigo)
        {
            
            var query = solicitudes.Where(s => s.CodigoSolicitud.Equals(condigo)).ToList();

            if (query.Count > 0)
            {
                if (query[0].CodigoCliente > 0 && query[0].CodigoCoDeudor > 0 && query[0].CodigoGarantia == 0)
                {
                    Valuereturn = "CON CODEUDOR";
                }
                else
                {
                    if (query[0].CodigoCliente > 0 && query[0].CodigoCoDeudor == 0 && query[0].CodigoGarantia > 0)
                    {
                        Valuereturn = "CON GARANTIA";
                    }
                    else
                    {
                        if (query[0].CodigoCliente > 0 && query[0].CodigoCoDeudor > 0 && query[0].CodigoGarantia > 0)
                        {
                            Valuereturn = "CODEUDOR Y GARANTIA";
                        }
                        else
                        {
                            if (query[0].CodigoCliente > 0 && query[0].CodigoCoDeudor == 0 && query[0].CodigoGarantia == 0)
                            {
                                Valuereturn = "SOLO FIRMA";
                            }
                           
                        }
                    }
                }
            }
            return Valuereturn;
        }

    }
}
