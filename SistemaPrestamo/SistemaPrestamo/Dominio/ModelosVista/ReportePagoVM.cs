using AccesoDatos.Conexion;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ModelosVista
{
    public  class ReportePagoVM : Conexion
    {
        public void DiasSinPagar()
        {
            var query = reportePagos.Where(r => r.Estado.Equals(true) && r.FechaUltimoPago != "").ToList();

            if (query.Count >  0)
            {
                DateTime FechaActual = System.DateTime.Now.Date;
                TimeSpan diasTrascurridos;

                query.ForEach(item => 
                {
                    diasTrascurridos = FechaActual.Subtract( Convert.ToDateTime(item.FechaUltimoPago));
                    reportePagos.Where(r => r.CodigoSolicitud.Equals(item.CodigoSolicitud))
                                .Set(r => r.DiasSinPagar, Convert.ToInt32(diasTrascurridos.TotalDays))
                                .Update();

                });
            }
        }

        public void AtrasoUpdate()
        {

        }
    }
}
