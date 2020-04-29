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
    public class CobroVM : Conexion
    {
        private Random rnd = new Random();
        private string codigoRecibo;

        private TextBox txtCobrosCodigoPrestamo;
        private TextBox txtCobrosCodigoCliente;
        private TextBox txtCobrosNombreCliente;
        private TextBox txtCobrosTotalDeAtraso;
        private TextBox txtCobrosMontoAPagar;
        private TextBox txtCobrosConcepto;
        private TextBox txtCobrosDevuelta;
        private ComboBox comboBoxCobrosFormaPago;
        private ComboBox comboBoxCobrosDistribucionPago;
        private TextBox txtCobrosPagoCon;
        private DateTimePicker dtpCobrosDesde;
        private DateTimePicker dtpCobrosHasta;
        private DataGridView dataGridViewCobrosReportePrestamo;
        private DataGridView dataGridViewCobrosFiltroCobros; 

        public CobroVM(object[] objectos)
        {
            this.txtCobrosCodigoPrestamo = (TextBox)objectos[0];
            this.txtCobrosCodigoCliente = (TextBox)objectos[1];
            this.txtCobrosNombreCliente = (TextBox)objectos[2];
            this.txtCobrosTotalDeAtraso= (TextBox)objectos[3];
            this.txtCobrosMontoAPagar = (TextBox)objectos[4];
            this.txtCobrosConcepto = (TextBox)objectos[5];
            this.txtCobrosDevuelta = (TextBox)objectos[6];
            this.comboBoxCobrosFormaPago = (ComboBox)objectos[7];
            this.comboBoxCobrosDistribucionPago = (ComboBox)objectos[8];
            this.dtpCobrosDesde = (DateTimePicker)objectos[9];
            this.dtpCobrosHasta = (DateTimePicker)objectos[10];
            this.dataGridViewCobrosReportePrestamo = (DataGridView)objectos[11];
            this.dataGridViewCobrosFiltroCobros = (DataGridView)objectos[12];
            this.txtCobrosPagoCon = (TextBox)objectos[13];
        }
       
        public void GenerarCodigoRecibo()
        {
           int  random = rnd.Next(100000, 999999);
        
           var query = cobros.Where(c => c.CodigoRecibo.Equals( "CR" + Convert.ToString(random))).ToList();

            if (query.Count > 0)
            {
                random++;
            }
            codigoRecibo = $"CR-{Convert.ToString(random)}";
        }
        public void GetReportePrestamo()
        {
            var query = from r in reportePrestamos
                        join e in estadoCuotas on r.IdEstadoCuota equals e.IdEstadoCuota
                        where r.CodigoSolicitud.Equals(Convert.ToInt32(txtCobrosCodigoPrestamo.Text)) && r.IdEstadoCuota != 3
                        select new
                        {
                            r.NoCuota,
                            r.FechaPago,
                            r.Capital,
                            r.Interes,
                            r.Comision,
                            r.Seguro,
                            r.Mora,
                            r.Cargos,
                            r.SubTotal,
                            e.DescripcionEC
                        };

            var list = query.ToList();

            if (list.Count > 0)
            {
                dataGridViewCobrosReportePrestamo.DataSource = list.ToList();

                CalcularAtraso();
            }

            dataGridViewCobrosReportePrestamo.Columns[0].HeaderText = "Cuota";
            dataGridViewCobrosReportePrestamo.Columns[1].HeaderText = "Fecha";
            dataGridViewCobrosReportePrestamo.Columns[2].HeaderText = "Capital";
            dataGridViewCobrosReportePrestamo.Columns[3].HeaderText = "Interés";
            dataGridViewCobrosReportePrestamo.Columns[4].HeaderText = "Comisión";
            dataGridViewCobrosReportePrestamo.Columns[5].HeaderText = "Seguro";
            dataGridViewCobrosReportePrestamo.Columns[6].HeaderText = "Mora";
            dataGridViewCobrosReportePrestamo.Columns[7].HeaderText = "Cargos";
            dataGridViewCobrosReportePrestamo.Columns[8].HeaderText = "Acumulado";
            dataGridViewCobrosReportePrestamo.Columns[9].HeaderText = "Estado";
            dataGridViewCobrosReportePrestamo.Columns[0].Width = 50;
        }

        public void GetTipoPago()
        {
            try
            {
                comboBoxCobrosFormaPago.DataSource = tipoPagos.ToList();
                comboBoxCobrosFormaPago.ValueMember = "IdTipoPago";
                comboBoxCobrosFormaPago.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetDistribucionPago()
        {
            try
            {
                comboBoxCobrosDistribucionPago.DataSource = distribucionPagos.ToList();
                comboBoxCobrosDistribucionPago.ValueMember = "IdDistribucion";
                comboBoxCobrosDistribucionPago.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CalcularAtraso()
        {
            int totalAtraso = 0;

            var query = reportePrestamos.Where(r => r.IdEstadoCuota.Equals(2) && r.CodigoSolicitud.Equals(Convert.ToInt32(txtCobrosCodigoPrestamo.Text))).ToList();

            if (query.Count > 0)
            {
                query.ForEach(item => {

                    totalAtraso += item.Capital + Convert.ToInt32(item.Interes) + Convert.ToInt32(item.Comision) + Convert.ToInt32(item.Seguro) + item.Mora + item.Cargos;

                });

                txtCobrosTotalDeAtraso.Text = totalAtraso.ToString();
            }
            else
            {
                txtCobrosTotalDeAtraso.Text = "0";
            }
         
            return totalAtraso;
        }

        public void AplicarCobor()
        {
            if (txtCobrosCodigoPrestamo.Text != "")
            {
                if (Convert.ToInt32(txtCobrosMontoAPagar.Text)  > 0)
                {
                    if (txtCobrosConcepto.Text != "")
                    {
                        if (MessageBox.Show($"Realmente desea aplicar el cobro a: {txtCobrosNombreCliente.Text}.", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DistribucionCobro();
                            RestablecerCobros();
                            MessageBox.Show("Cobro aplicado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar el concepto del pago.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCobrosConcepto.Focus();

                    }
                 
                }
                else
                {
                    MessageBox.Show("El monto a pagar debe ser mayor a 0.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCobrosMontoAPagar.Focus();
                }

            }
            else
            {
                MessageBox.Show("Debe ingresar los datos del cliente para poder aplicar el cobro.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void RestablecerCobros()
        {
            this.txtCobrosCodigoPrestamo.Clear();
            this.txtCobrosCodigoCliente.Clear();
            this.txtCobrosNombreCliente.Clear();
            this.txtCobrosTotalDeAtraso.Text = "0";
            this.txtCobrosMontoAPagar.Text = "0";
            this.txtCobrosConcepto.Clear();
            this.txtCobrosDevuelta.Text = "0";
            this.txtCobrosPagoCon.Text = "0";
            GetTipoPago();
            GetDistribucionPago();
            this.dtpCobrosDesde.ResetText();
            this.dtpCobrosHasta.ResetText();
            this.dataGridViewCobrosReportePrestamo.DataSource = null;
            this.dataGridViewCobrosFiltroCobros.DataSource = null;
        }

        private void DistribucionCobro()
        {
            string fechaActual = System.DateTime.Now.ToString("dd/MM/yyy");
            string horaActual = System.DateTime.Now.ToString("HH:mm:ss");
            int codigoSolicitud = Convert.ToInt32(txtCobrosCodigoPrestamo.Text);
            int montoAPagar = Convert.ToInt32(txtCobrosMontoAPagar.Text);
            int monotoEnAtraso = Convert.ToInt32(txtCobrosTotalDeAtraso.Text);

            if (montoAPagar > 0)
            {
                GenerarCodigoRecibo();

                var cuotasCliente = reportePrestamos.Where(r => r.CodigoSolicitud.Equals(codigoSolicitud) && r.IdEstadoCuota != 3).ToList();

                if (cuotasCliente.Count > 0)
                {
                    var formaDistribucion = distribucionPagos.Where(d => d.Descripcion.Equals(comboBoxCobrosDistribucionPago.Text)).ToList();

                    if (formaDistribucion.Count > 0)
                    {
                        if (formaDistribucion[0].IdDistribucion.Equals(1)) //DISTRIBUCION AUTOMATICA
                        {
                            int montoFinal = 0;
                            int montoDinamico = 0;
                            int montoSatico = 0;
                            int subTotal = 0;

                            int cargo = 0; //1
                            int mora = 0; //2
                            decimal segu = 0; //3
                            decimal comi = 0; //4
                            decimal inte = 0; //5
                            int capi = 0; //6

                            int cargoDT = 0; //1
                            int moraDT = 0; //2
                            decimal seguDT = 0; //3
                            decimal comiDT = 0; //4
                            decimal inteDT = 0; //5
                            int capiDT = 0; //6

                            var countCuotas = reportePrestamos.Where(r => r.CodigoSolicitud.Equals(codigoSolicitud) && r.IdReportePrestamos != 3).ToList();
                            var rpago = reportePagos.Where(p => p.CodigoSolicitud.Equals(codigoSolicitud)).ToList();

                            montoSatico = montoAPagar;
                            montoFinal = montoAPagar;

                            if (countCuotas.Count > 0) //POSEE 6 CUOTAS
                            {
                                countCuotas.ForEach(item => 
                                {
                                    if (montoFinal > 0)
                                    {
                                        var nCuota = reportePrestamos.Where(r => r.IdReportePrestamos.Equals(item.IdReportePrestamos) && r.NoCuota.Equals(item.NoCuota)).ToList();

                                        if (nCuota.Count > 0)
                                        {
                                            if (montoFinal > 0)
                                            {
                                                if (nCuota[0].Cargos > 0)
                                                {
                                                    if (montoFinal >= nCuota[0].Cargos)
                                                    {
                                                        montoDinamico = montoAPagar;
                                                        montoAPagar -= nCuota[0].Cargos;
                                                        montoFinal = montoAPagar;
                                                        cargo = montoDinamico - montoFinal;
                                                    }
                                                    else
                                                    {
                                                        cargo = montoFinal;
                                                        montoAPagar = 0;
                                                        montoFinal = 0;
                                                    }
                                                    cargoDT += cargo;
                                                }
                                                else
                                                {
                                                    cargo = 0;
                                                }
                                            }

                                            if (montoFinal > 0)
                                            {
                                                if (nCuota[0].Mora > 0)
                                                {
                                                    if (montoFinal >= nCuota[0].Mora)
                                                    {
                                                        montoDinamico = montoAPagar;
                                                        montoAPagar -= nCuota[0].Mora;
                                                        montoFinal = montoAPagar;
                                                        mora = montoDinamico - montoFinal;
                                                    }
                                                    else
                                                    {
                                                        mora = montoFinal;
                                                        montoAPagar = 0;
                                                        montoFinal = 0;
                                                    }
                                                    moraDT += mora;
                                                }
                                                else
                                                {
                                                    mora = 0;
                                                }
                                            }

                                            if (montoFinal > 0)
                                            {
                                                if (nCuota[0].Seguro > 0)
                                                {
                                                    if (montoFinal >= nCuota[0].Seguro)
                                                    {
                                                        montoDinamico = montoAPagar;
                                                        montoAPagar -= Convert.ToInt32(nCuota[0].Seguro);
                                                        montoFinal = montoAPagar;
                                                        segu = montoDinamico - montoFinal;
                                                    }
                                                    else
                                                    {
                                                        segu = montoFinal;
                                                        montoAPagar = 0;
                                                        montoFinal = 0;
                                                    }
                                                    seguDT += segu;
                                                }
                                                else
                                                {
                                                    segu = 0;
                                                }
                                            }

                                            if (montoFinal > 0)
                                            {
                                                if (nCuota[0].Comision > 0)
                                                {
                                                    if (montoFinal >= nCuota[0].Comision)
                                                    {
                                                        montoDinamico = montoAPagar;
                                                        montoAPagar -= Convert.ToInt32(nCuota[0].Comision);
                                                        montoFinal = montoAPagar;
                                                        comi = montoDinamico - montoFinal;
                                                    }
                                                    else
                                                    {
                                                        comi = montoFinal;
                                                        montoAPagar = 0;
                                                        montoFinal = 0;
                                                    }
                                                    comiDT += comi;
                                                }
                                                else
                                                {
                                                    comi = 0;
                                                }
                                            }

                                            if (montoFinal > 0)
                                            {
                                                if (nCuota[0].Interes > 0)
                                                {
                                                    if (montoFinal >= nCuota[0].Interes)
                                                    {
                                                        montoDinamico = montoAPagar;
                                                        montoAPagar -= Convert.ToInt32(nCuota[0].Interes);
                                                        montoFinal = montoAPagar;
                                                        inte = montoDinamico - montoFinal;
                                                    }
                                                    else
                                                    {
                                                        inte = montoFinal;
                                                        montoAPagar = 0;
                                                        montoFinal = 0;
                                                    }
                                                    inteDT += inte;
                                                }
                                                else
                                                {
                                                    inte = 0;
                                                }
                                            }

                                            if (montoFinal > 0)
                                            {
                                                if (nCuota[0].Capital > 0)
                                                {
                                                    if (montoFinal >= nCuota[0].Capital)
                                                    {
                                                        montoDinamico = montoAPagar;
                                                        montoAPagar -= Convert.ToInt32(nCuota[0].Capital);
                                                        montoFinal = montoAPagar;
                                                        capi = montoDinamico - montoFinal;

                                                        reportePrestamos.Where(r => r.IdReportePrestamos.Equals(nCuota[0].IdReportePrestamos))
                                                                   .Set(r => r.IdEstadoCuota, 3)
                                                                   .Update();
                                                    }
                                                    else
                                                    {
                                                        capi = montoFinal;
                                                        montoAPagar = 0;
                                                        montoFinal = 0;
                                                    }
                                                    capiDT += capi;
                                                }
                                                else
                                                {
                                                    capi = 0;
                                                }
                                            }

                                            subTotal = capi + Convert.ToInt32(inte) + Convert.ToInt32(comi) + Convert.ToInt32(segu) + mora + cargo;

                                            reportePrestamos.Where(r => r.IdReportePrestamos.Equals(item.IdReportePrestamos))
                                                            .Set(r => r.Capital, item.Capital - capi)
                                                            .Set(r => r.Interes, item.Interes - inte)
                                                            .Set(r => r.Comision, item.Comision - comi)
                                                            .Set(r => r.Seguro, item.Seguro - segu)
                                                            .Set(r => r.Mora, item.Mora - mora)
                                                            .Set(r => r.Cargos, item.Cargos - item.Cargos)
                                                            .Set(r => r.SubTotal, item.SubTotal - subTotal)
                                                            .Update();

                                            reportePagos.Where(p => p.CodigoSolicitud.Equals(item.CodigoSolicitud))
                                                     .Set(p => p.CapitalPagado, rpago[0].CapitalPagado + capi)
                                                     .Set(p => p.InteresPagado, rpago[0].InteresPagado + inte)
                                                     .Set(p => p.ComisionPagado, rpago[0].ComisionPagado + comi)
                                                     .Set(p => p.SeguroPagado, rpago[0].SeguroPagado + segu)
                                                     .Set(p => p.MoraPagada, rpago[0].MoraPagada + mora)
                                                     .Set(p => p.CargosPagado, rpago[0].CargosPagado + cargo)
                                                     .Set(p => p.SaldoActual, rpago[0].MontoPrestamo - capi)
                                                     .Set(p => p.FechaUltimoPago, fechaActual)
                                                     .Update();

                                        }
                                    }

                                   // MessageBox.Show($"Monto A Pagar: {montoAPagar}\nReciduo: {montoFinal}\n----------------\nCargos: {cargo}\nMora: {mora}\nSeguro: {segu}\nComision: {comi}\nInteres: {inte}\nCapital: {capi} \n\nTotal: {cargo + mora + segu + comi + inte + capi} ");

                                });

                               // MessageBox.Show($"Cargos: {cargoDT}\nMora: {moraDT}\nSeguro: {seguDT}\nComision: {comiDT}\nInteres: {inteDT}\nCapital: {capiDT} \n\nTotal: {cargoDT + moraDT + seguDT + comiDT + inteDT + capiDT} ");
                                cobros.Value(c => c.CodigoPrestamo, codigoSolicitud)
                                              .Value(c => c.FechaCobro, Convert.ToDateTime(fechaActual))
                                              .Value(c => c.HoraCobro, horaActual)
                                              .Value(c => c.CodigoRecibo, codigoRecibo)
                                              .Value(c => c.ConceptoCobro, txtCobrosConcepto.Text)
                                              .Value(c => c.IdUsuario, 0) //Pediente a modificacion
                                              .Value(c => c.IdSucursal, 1)//Pediente a modificacion
                                              .Value(c => c.EstadoCobro, true)
                                              .Value(c => c.IdDistribucion, formaDistribucion[0].IdDistribucion)
                                              .Insert();

                                detalleCobros.Value(d => d.CodigoRecibo, codigoRecibo)
                                             .Value(d => d.Capital, capiDT)
                                             .Value(d => d.Interes, inteDT)
                                             .Value(d => d.Comision, comiDT)
                                             .Value(d => d.Seguro, seguDT)
                                             .Value(d => d.Mora, moraDT)
                                             .Value(d => d.Cargo, cargoDT)
                                             .Insert();

                                var atras = atraso.Where(a => a.CodigoSolicitud.Equals(codigoSolicitud)).ToList();

                                if (atras.Count > 0)
                                {
                                    if (capiDT < 0)
                                    {
                                        capiDT = 0;
                                    }
                                    else
                                    {
                                        if (capiDT >= atras[0].Capital)
                                        {
                                            capiDT = 0;
                                        }
                                    }

                                    if (inteDT < 0)
                                    {
                                        inteDT = 0;
                                    }
                                    else
                                    {
                                        if (inteDT >= atras[0].Intere)
                                        {
                                            inteDT = 0;
                                        }
                                    }

                                    if (comiDT < 0)
                                    {
                                        comiDT = 0;
                                    }
                                    else
                                    {
                                        if (comiDT >= atras[0].Comision)
                                        {
                                            comiDT = 0;
                                        }
                                    }

                                    if (seguDT < 0)
                                    {
                                        seguDT = 0;
                                    }
                                    else
                                    {
                                        if (seguDT >= atras[0].Seguro)
                                        {
                                            seguDT = 0;
                                        }
                                    }

                                    if (moraDT < 0)
                                    {
                                        moraDT = 0;
                                    }
                                    else
                                    {
                                        if (moraDT >= atras[0].Mora)
                                        {
                                            moraDT = 0;
                                        }
                                    }

                                    if (cargoDT < 0)
                                    {
                                        cargoDT = 0;
                                    }
                                    else
                                    {
                                        if (cargoDT >= atras[0].Cargos)
                                        {
                                            cargoDT = 0;
                                        }
                                    }

                                    if (capiDT == 0 && inteDT == 0 && comiDT == 0 && seguDT == 0 && moraDT == 0 && cargoDT == 0)
                                    {
                                        atraso.Where(a => a.CodigoSolicitud.Equals(codigoSolicitud))
                                                .Set(a => a.Capital, 0)
                                                .Set(a => a.Intere, 0)
                                                .Set(a => a.Comision, 0)
                                                .Set(a => a.Seguro, 0)
                                                .Set(a => a.Mora, 0)
                                                .Set(a => a.Cargos, 0)
                                                .Update();
                                    }
                                    else
                                    {
                                        atraso.Where(a => a.CodigoSolicitud.Equals(codigoSolicitud))
                                                 .Set(a => a.Capital, atras[0].Capital - capiDT)
                                                 .Set(a => a.Intere, atras[0].Intere - inteDT)
                                                 .Set(a => a.Comision, atras[0].Comision - comiDT)
                                                 .Set(a => a.Seguro, atras[0].Seguro - seguDT)
                                                 .Set(a => a.Mora, atras[0].Mora - moraDT)
                                                 .Set(a => a.Cargos, atras[0].Cargos - cargoDT)
                                                 .Update();
                                    }

                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show($"El monto a pagar {montoAPagar} no es valido para procesar los datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        public void Devolucion()
        {
            decimal pagoCon = Convert.ToDecimal(txtCobrosPagoCon.Text);
            decimal montoAPagar = Convert.ToDecimal(txtCobrosMontoAPagar.Text);
            decimal devolu = 0;

            devolu = pagoCon - montoAPagar;

            if (devolu > 0)
            {
                txtCobrosDevuelta.Text = devolu.ToString();
            }
            else
            {
                txtCobrosDevuelta.Text = "0";
            }
        }

        public bool ValidarTxtVacio(TextBox textBox)
        {
            bool vacio = true;
            if (textBox.Text == "")
            {
                textBox.Text = "0";
                vacio = false;
            }

            return vacio;
        }

    }

}

