using AccesoDatos.Conexion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Dominio.ModelosVista
{
    public class GeneraleVM: Conexion
    {
        
        private Button _iconButtonIncio_NoSolicitudes;
        private Button _iconButtonIncio_NoPrest;
        private Button _iconButtonIncio_NoCuotasV;
        private Button _iconButtonIncio_CapitalInvertido;
        private Chart _chartReportes_PrestamosPorMes;
        private Chart _chartReportes_VigentesVsVencidas;
        private Chart _chartReportes_FormaPago;
        private Button _iconButtonIncio_CapitalVencido;
        private Button _iconButtonIncio_ReporteCobros;


        public GeneraleVM(object[] objectos)
        {
            _iconButtonIncio_NoSolicitudes = (Button)objectos[0];
            _iconButtonIncio_NoPrest = (Button)objectos[1];
            _iconButtonIncio_NoCuotasV = (Button)objectos[2];
            _iconButtonIncio_CapitalInvertido = (Button)objectos[3];
            _chartReportes_PrestamosPorMes = (Chart)objectos[4];
            _chartReportes_VigentesVsVencidas = (Chart)objectos[5];
            _chartReportes_FormaPago = (Chart)objectos[6];
            _iconButtonIncio_CapitalVencido = (Button)objectos[7];
            _iconButtonIncio_ReporteCobros = (Button)objectos[8];
        }

        public void GetCountSolPend()
        {
            try {
                var solictud = solicitudes.Where(s => s.Estado.Equals(true) && s.IdEstadoSolicitud.Equals(1)).ToList();
                _iconButtonIncio_NoSolicitudes.Text = solictud.Count.ToString();
            }
            catch (Exception ex) {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void GetCountPrestVig()
        {
            try {
                var solictud = solicitudes.Where(s => s.Estado.Equals(true) && s.IdEstadoSolicitud.Equals(3) && s.IdEstadoPrestamo.Equals(2)).ToList();
                _iconButtonIncio_NoPrest.Text = solictud.Count.ToString();
            }
            catch (Exception ex) {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void GetCountCuotasVen()
        {
            try
            {
                var cuotasEnAtraso = atraso.Where(a => a.Capital > 0 || a.Intere > 0 || a.Comision > 0 || a.Seguro > 0 || a.Mora > 0 || a.Cargos > 0).ToList();
                if (cuotasEnAtraso.Count > 0)
                {
                    _iconButtonIncio_NoCuotasV.Text = cuotasEnAtraso.Count.ToString();
                }

                #region
                /*

                var cuotasEnAtraso = from p in reportePrestamos
                                     join c in estadoCuotas on p.IdEstadoCuota equals c.IdEstadoCuota
                                     join s in solicitudes on p.CodigoSolicitud equals s.CodigoSolicitud
                                     where p.IdEstadoCuota.Equals(2) && s.IdEstadoSolicitud.Equals(3) && s.IdEstadoPrestamo.Equals(2)
                                     group p by new
                                     {
                                         p.CodigoSolicitud,

                                     } into Vencimiento
                                     select Vencimiento;

                var list = cuotasEnAtraso.ToList();

                if (list.Count() > 0)
                {
                    button.Text = list.Count.ToString();
                }

                */
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void GetCapitalInvertido()
        {
            try
            {
                var ci = from r in reportePrestamos
                         join s in solicitudes on r.CodigoSolicitud equals s.CodigoSolicitud
                         where r.Capital > 0 && s.IdEstadoSolicitud.Equals(3) && s.IdEstadoPrestamo.Equals(2)
                         select new
                         {
                            r.Capital
                         };

                var capitanInv = ci.ToList();

                int capital = 0;

                if (capitanInv.Count > 0)
                {
                    capitanInv.ForEach( item => {

                        capital += item.Capital; 
                    });
                }

                _iconButtonIncio_CapitalInvertido.Text = String.Format("{0:#,###,###,##0####}", capital);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void GetCapitalVencido()
        {
            try
            {
                var query = atraso.Where(a => a.Capital > 0).ToList();

                int capital = 0;

                if (query.Count > 0)
                {
                    query.ForEach(item => {

                        capital += item.Capital;

                    });
                }

                _iconButtonIncio_CapitalVencido.Text = String.Format("{0:#,###,###,##0####}", capital);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void GetReporteCobrosDiario()
        {
            try
            {
                DateTime fechaActual = System.DateTime.Now.Date;

                var query = from c in cobros
                         join d in detalleCobros on c.CodigoRecibo equals d.CodigoRecibo
                         where c.FechaCobro.Equals(fechaActual) && c.EstadoCobro.Equals(true)
                         select new
                         {
                             d.Capital,
                             d.Interes,
                             d.Comision,
                             d.Seguro,
                             d.Mora,
                             d.Cargo
                         };

                var montoCobrado = query.ToList();
                int monto = 0;

                if (montoCobrado.Count() > 0)
                {
                    montoCobrado.ForEach(item => 
                    {

                        monto += item.Capital + Convert.ToInt32(item.Interes) + Convert.ToInt32(item.Comision) + Convert.ToInt32(item.Seguro) + item.Mora + item.Cargo;

                    });
                }

                _iconButtonIncio_ReporteCobros.Text = String.Format("{0:#,###,###,##0####}", monto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void GraficoPrestamosPorMes()
        {
            var query = solicitudes.ToList();
            string year = DateTime.Now.ToString("yyy");

            //Arreglo con los mese del year
            string[] Meses = {"Total", "Ene.", "Feb.", "Mar.", "Abr.", "May.", "Jun.", "Jul.", "Ago.", "Sep.", "Oct.", "Nov.", "Dec." };

            _chartReportes_PrestamosPorMes.Series[0].Points.Clear();
            _chartReportes_PrestamosPorMes.Series[0].Name = "Meses";

            for (int i = 0; i <= 12; i++)
            {
                decimal cant = 0;

                if (i > 0)
                {
                    var list = solicitudes.Where(s => s.Mes.Equals(i.ToString()) && s.Year.Equals(year)).ToList();
                    cant = list.Count();
                }
                else
                {
                    var list = solicitudes.Where(s => s.Year.Equals(year)).ToList();
                    cant = list.Count();
                }
                

                //Agregar los datos para el reporte
                _chartReportes_PrestamosPorMes.Series[0].Points.Add(Convert.ToDouble(cant));
                _chartReportes_PrestamosPorMes.Series[0].Points[i].AxisLabel = Meses[i];
            }
         
        }

        public void GraficoPrestamosVigentesVsVencidos()
        {

            //Arreglo con los Estados del year
            string[] Estado = { "Vigentes.", "Vencidos" };

            _chartReportes_VigentesVsVencidas.Series[0].Points.Clear();
            _chartReportes_VigentesVsVencidas.Series[0].Name = "VG vs VC";

            for (int i = 0; i <= 1; i++)
            {
                decimal cant = 0;

                if (i == 0)
                {
                    var conuntVigentes = atraso.Where(a => a.Capital == 0 && a.Intere == 0 && a.Comision == 0 && a.Seguro == 0 && a.Mora == 0 && a.Cargos == 0).ToList();

                    if (conuntVigentes.Count() > 0)
                    {
                        cant = conuntVigentes.Count();
                    }
                }
                else
                {
                    var conuntAtraso = atraso.Where(a => a.Capital > 0 || a.Intere > 0 || a.Comision > 0 || a.Seguro > 0 || a.Mora > 0 || a.Cargos > 0).ToList();

                    if (conuntAtraso.Count() > 0)
                    {
                        cant = conuntAtraso.Count();
                    }
                }

                //Agregar los datos para el reporte
                _chartReportes_VigentesVsVencidas.Series[0].Points.Add(Convert.ToDouble(cant));
                _chartReportes_VigentesVsVencidas.Series[0].Points[i].AxisLabel = Estado[i];
            }

        }

        public void GraficoFormaPago()
        {
            //Arreglo con las formas de pago
           
            string[] FormaPago = { "Mensual.", "Quincenal", "Semanal" };

            _chartReportes_FormaPago.Series[0].Points.Clear();
            _chartReportes_FormaPago.Series[0].Name = "Forma Pago";

            for (int i = 0; i <= 2; i++)
            {
                decimal cant = 0;

                if (i == 0)
                {
                    var mesual = solicitudes.Where(s => s.IdEstadoPrestamo.Equals(2) && s.IdEstadoSolicitud.Equals(3) && s.IdFormaPago.Equals(1));

                    if (mesual.Count() > 0)
                    {
                        cant = mesual.Count();
                    }
                }

                if (i == 1)
                {
                    var quincenal = solicitudes.Where(s => s.IdEstadoPrestamo.Equals(2) && s.IdEstadoSolicitud.Equals(3) && s.IdFormaPago.Equals(2));

                    if (quincenal.Count() > 0)
                    {
                        cant = quincenal.Count();
                    }
                }

                if (i == 2)
                {
                    var semanal = solicitudes.Where(s => s.IdEstadoPrestamo.Equals(2) && s.IdEstadoSolicitud.Equals(3) && s.IdFormaPago.Equals(3));

                    if (semanal.Count() > 0)
                    {
                        cant = semanal.Count();
                    }
                }

                //Agregar los datos para el reporte
                _chartReportes_FormaPago.Series[0].Points.Add(Convert.ToDouble(cant));
                _chartReportes_FormaPago.Series[0].Points[i].AxisLabel = FormaPago[i];
            }

        }

    }
}
