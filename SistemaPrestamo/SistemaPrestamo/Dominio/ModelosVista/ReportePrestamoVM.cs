using AccesoDatos.Conexion;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dominio.ModelosVista
{
    public class ReportePrestamoVM : Conexion 
    {
        private DataGridView _dataGridViewPrestamos;

        public ReportePrestamoVM(object[] objetos)
        {
           // _dataGridViewPrestamos = (DataGridView)objetos[0];
        }

        public int diasEnElMes()
        {
            int DiasMesActual;

            int yearInt = System.DateTime.Now.Year;
            int mesInt = System.DateTime.Now.Month;
            DiasMesActual = System.DateTime.DaysInMonth(yearInt, mesInt);

            return DiasMesActual;
        }

        /*OBTENER TODAS LAS CUOTAS VENCIDAS*/
        public int UpdateEstadoCuotas()
        {
            int cuotas = 0;
            string fechaAc = System.DateTime.Now.ToString("dd/MM/yyy");
            DateTime Fecha = Convert.ToDateTime(fechaAc);

            var query = from s in solicitudes
                    join r in reportePrestamos on s.CodigoSolicitud equals r.CodigoSolicitud
                    where r.FechaPago <= Fecha && r.IdEstadoCuota.Equals(1) && s.IdEstadoPrestamo.Equals(2) && s.IdEstadoSolicitud.Equals(3) 
                    select new
                    {
                        s.CodigoSolicitud,
                        r.IdReportePrestamos,
                        r.Capital,
                        r.Interes,
                        r.Comision,
                        r.Seguro,
                        r.Mora,
                    };

            var list = query.ToList();

            if (list.Count > 0)
            {
                cuotas = query.Count();

                list.ForEach(item => 
                {

                    reportePrestamos.Where(r => r.IdReportePrestamos.Equals(item.IdReportePrestamos))
                                  .Set(r => r.IdEstadoCuota, 2)
                                  .Update();
                    
                });

               // SubtotalMoraCalc();
            }

            return cuotas;
        }

        
        public void SubtotalMoraAtrasoCalc()
        {
            //CALCULAR EL SUB
            var query = reportePrestamos.Where(r => r.IdEstadoCuota.Equals(2)).ToList();
            if (query.Count > 0)
            {
                int yearInt = System.DateTime.Now.Year;
                int mesInt = System.DateTime.Now.Month;
                int DiasMesActual = System.DateTime.DaysInMonth(yearInt, mesInt);
                string fechaAc = System.DateTime.Now.ToString("dd/MM/yyy");
                DateTime Fecha = Convert.ToDateTime(fechaAc);

                double capital = 0, interes = 0, comision = 0, seguro = 0, mora = 0, cargos = 0, pormora = 0.05;
                int total_atraso = 0;
                TimeSpan diasTrascurridos;

                query.ForEach( item => 
                {

                    capital = Convert.ToDouble(item.Capital);
                    interes = Convert.ToDouble(item.Interes);
                    comision = Convert.ToDouble(item.Comision);
                    seguro = Convert.ToDouble(item.Seguro);

                    var query1 = reportePagos.Where(r => r.CodigoSolicitud.Equals(item.CodigoSolicitud) && r.FechaUltimoPago != "").ToList();

                    if (query1.Count > 0)
                    {
                        diasTrascurridos = Fecha.Subtract(Convert.ToDateTime(query1[0].FechaUltimoPago));
                    }
                    else
                    {
                        diasTrascurridos = Fecha.Subtract(item.FechaPago);
                    }
                    

                    mora = ((Convert.ToDouble(item.Capital) * pormora ) / DiasMesActual) * Convert.ToDouble(diasTrascurridos.TotalDays);
                    cargos = Convert.ToDouble(item.Cargos);

                    total_atraso = Convert.ToInt32(capital + interes + comision + seguro + mora + cargos);

                    reportePrestamos.Where(r => r.IdReportePrestamos.Equals(item.IdReportePrestamos))
                                    .Set(r => r.Mora, mora)
                                    .Set(r => r.Cargos, cargos)
                                    .Set(r => r.SubTotal, total_atraso)
                                    .Update();

                });
            }
           
            //PARA ACTUALIZAR LA TABLA ATRASO SEGUN LAS CUOTAS VENCIDA VENCIDAS QUE TENGA EL CLIENTE
            if (query.Count > 0)
            {

                query.ForEach(it => {

                    int cap = 0;
                    int inte = 0;
                    int com = 0;
                    int seg = 0;
                    int mor = 0;
                    int car = 0;

                    int codiSo = 0;

                    var q = reportePrestamos.Where(r => r.IdEstadoCuota.Equals(2) && r.CodigoSolicitud.Equals(it.CodigoSolicitud)).ToList();
                    
                    if (q.Count > 0)
                    {
                        q.ForEach(itq => {

                            codiSo = itq.CodigoSolicitud;

                            cap += itq.Capital;
                            inte += Convert.ToInt32(itq.Interes);
                            com += Convert.ToInt32(itq.Comision);
                            seg += Convert.ToInt32(itq.Seguro);
                            mor += itq.Mora;
                            car += itq.Cargos;

                        });

                        atraso.Where(a => a.CodigoSolicitud.Equals(codiSo))
                                   .Set(a => a.Capital, cap)
                                   .Set(a => a.Intere, inte)
                                   .Set(a => a.Comision, com)
                                   .Set(a => a.Seguro, seg)
                                   .Set(a => a.Mora, mor)
                                   .Set(a => a.Cargos, car)
                                   .Update();
                    }

                });
            }
        }

    }
}
