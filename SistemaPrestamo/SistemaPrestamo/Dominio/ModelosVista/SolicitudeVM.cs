using AccesoDatos.Conexion;
using AccesoDatos.Models;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dominio.ModelosVista
{
    public class SolicitudeVM : Conexion
    {
        private ComboBox _comboBoxSolicitud_TipoPrestamo;
        private ComboBox _comboBoxSolicitud_FormaPago;
        private ComboBox _comboBoxSolicitud_ClasePrestamo;
        private ComboBox _comboBoxSolicitud_TipoGarantia;
        private ComboBox _comboBoxSolicitud_Ruta;
        private ComboBox _comboBoxSolicitud_Zona;
        private ComboBox _comboBoxSolicitud_Gestor;
        private MaskedTextBox _mtbSolicitud_NoDocumentoDeudor;
        private TextBox _txtSolicitud_NombreDeudor;
        private TextBox _txtSolicitud_ApellidosDeudor;
        private MaskedTextBox _mtbSolicitud_NoDocumentoCoDeudor;
        private TextBox _txtSolicitud_NombreCoDeudor;
        private TextBox _txtSolicitud_ApellidosCoDeudor;
        private DateTimePicker _dtpSolicitud_FechaPago;
        private TextBox _txtSolicitud_MontoSolicitado;
        private TextBox _txtSolicitud_GastosLegales;
        private TextBox _txtSolicitud_MontoTotal;
        private TextBox _txtSolicitud_CantidadCuotas;
        private TextBox _txtSolicitud_TasaInteres;
        private TextBox _txtSolicitud_TasaComision;
        private TextBox _txtSolicitud_TasaSeguro;
        private TextBox _txtSolicitud_MontoCuotas;
        private DataGridView _dataGridViewSolicitud;
        private TextBox _txtSolicitud_DescripcionInversion;
        private TextBox _txtCodigoSolicitud;
        private Label _lblSolicitud_NoDocumentoDeudor;
        private Label _lblSolicitud_NoDocumentoCoDeudor;
        private Label _lblSolicitud_DescipcionInversion;
        private Label _lblSolicitud_MontoSolicitado;
        private Label _lblSolicitud_CatidadCuotas;
        private Label _lblSolicitud_TasaInteresAnual;
        private Panel _panelSolicitud_Deudores;
        private MaskedTextBox _mtbSolicitud_CodigoObjeto;
        private TextBox _txtSolicitud_NombreObjecto;
        private Random rnd = new Random();

        private double MontoSolicitado = 0;
        private double GastosLegales = 0;
        private double MontoTotal = 0;
        private int CantidadCuotas = 0;
        private double TasaComision = 0;
        private double TasaSeguro = 0;
        private DateTime FECHA = new DateTime();
        private string _accion = "insert";
        private string _formaPago = "MENSUAL";
        private int codigoSolicitud = 0;
        private int idUsario = 0;
        private string fechaAc;
        private string horaAc;

        private int idTipoPrestamo = 0;
        private int idFormaPago = 0;
        private int idClasePrestamo = 0;
        private int idTipoGarantia = 0;
        private int idRuta = 0;
        private int idZona = 0;
        private int idGestor = 0;

        public SolicitudeVM(object[] objectos)
        {
            _comboBoxSolicitud_TipoPrestamo = (ComboBox)objectos[0];
            _comboBoxSolicitud_FormaPago = (ComboBox)objectos[1];
            _comboBoxSolicitud_ClasePrestamo = (ComboBox)objectos[2];
            _comboBoxSolicitud_TipoGarantia = (ComboBox)objectos[3];
            _comboBoxSolicitud_Ruta = (ComboBox)objectos[4];
            _comboBoxSolicitud_Zona = (ComboBox)objectos[5];
            _comboBoxSolicitud_Gestor = (ComboBox)objectos[6];

            _mtbSolicitud_NoDocumentoDeudor = (MaskedTextBox)objectos[7];
            _txtSolicitud_NombreDeudor = (TextBox)objectos[8];
            _txtSolicitud_ApellidosDeudor = (TextBox)objectos[9];
            _mtbSolicitud_NoDocumentoCoDeudor = (MaskedTextBox)objectos[10];
            _txtSolicitud_NombreCoDeudor = (TextBox)objectos[11];
            _txtSolicitud_ApellidosCoDeudor = (TextBox)objectos[12];
            _dtpSolicitud_FechaPago = (DateTimePicker)objectos[13];

            _txtSolicitud_MontoSolicitado = (TextBox)objectos[14];
            _txtSolicitud_GastosLegales = (TextBox)objectos[15];
            _txtSolicitud_MontoTotal = (TextBox)objectos[16];
            _txtSolicitud_CantidadCuotas = (TextBox)objectos[17];
            _txtSolicitud_TasaInteres= (TextBox)objectos[18];
            _txtSolicitud_TasaComision = (TextBox)objectos[19];
            _txtSolicitud_TasaSeguro = (TextBox)objectos[20];
            _txtSolicitud_MontoCuotas = (TextBox)objectos[21];
            _dataGridViewSolicitud = (DataGridView)objectos[22];
            _txtSolicitud_DescripcionInversion = (TextBox)objectos[23];
            _txtCodigoSolicitud = (TextBox)objectos[24];

            _lblSolicitud_NoDocumentoDeudor = (Label)objectos[25];
            _lblSolicitud_NoDocumentoCoDeudor = (Label)objectos[26];

            _lblSolicitud_DescipcionInversion = (Label)objectos[27];
            _lblSolicitud_MontoSolicitado = (Label)objectos[28];
            _lblSolicitud_CatidadCuotas = (Label)objectos[29];
            _lblSolicitud_TasaInteresAnual = (Label)objectos[30];

            _panelSolicitud_Deudores = (Panel)objectos[31];

            _mtbSolicitud_CodigoObjeto = (MaskedTextBox)objectos[32];
            _txtSolicitud_NombreObjecto = (TextBox)objectos[33];

        }

        public void generarCodigoSolicitud()
        {
            _panelSolicitud_Deudores.Enabled = true;
            _mtbSolicitud_NoDocumentoDeudor.Focus();

            codigoSolicitud = rnd.Next(100000, 999999);

            var queryCodigoSolicitud = solicitudes.Where(c => c.CodigoSolicitud.Equals(codigoSolicitud)).ToList();

            if (queryCodigoSolicitud.Count > 0)
            {
                codigoSolicitud++;
            }
            _txtCodigoSolicitud.Text = codigoSolicitud.ToString();
        }

        public bool SaveSolicitud()
        {
            bool save = false;

            if (_txtSolicitud_NombreDeudor.Text == "")
            {
                GetDeudor();
            }
            else
            {
                bool valor = ValidarCampos();

                if (valor == true)
                {
                    if (_dataGridViewSolicitud.Rows.Count > 0)
                    {
                        getIdentificadores();
                        save = guadarSolicitud();
                    }
                    else
                    {
                        MessageBox.Show("Debe dar clic en el botón calcular para terminar el proceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            return save;
        }

        private bool guadarSolicitud()
        {
            bool valor = false;
          // BeginTransactionAsync();
          
            try
            {
                switch (_accion)
                {
                    case "insert":

                        fechaAc = System.DateTime.Now.ToString("dd/MM/yyy");
                        horaAc = System.DateTime.Now.ToString("HH:mm:ss");
                        string mont = System.DateTime.Now.ToString("MM");
                        string mes = mont.Replace("0", "");
                        string year = System.DateTime.Now.ToString("yyy");

                        int deudor = 0, codeudor = 0, codigo = 0;

                        if (_mtbSolicitud_NoDocumentoDeudor.Text != "" && _mtbSolicitud_NoDocumentoDeudor.Text != ("   -       -"))
                        {
                            var codigoDeudor = clientes.Where(c => c.NoDocumento.Equals(_mtbSolicitud_NoDocumentoDeudor.Text)).ToList();
                            deudor = codigoDeudor[0].CodigoCliente;
                        }

                        if (_mtbSolicitud_NoDocumentoCoDeudor.Text != "" && _mtbSolicitud_NoDocumentoCoDeudor.Text != ("   -       -"))
                        {
                            var codigoCoDeudor = clientes.Where(c => c.NoDocumento.Equals(_mtbSolicitud_NoDocumentoCoDeudor.Text)).ToList();
                            codeudor = codigoCoDeudor[0].CodigoCliente;
                        }

                        if (_mtbSolicitud_CodigoObjeto.Text != "")
                        {
                            var codigoObjetoV = garantiaEconomicas.Where(c => c.CodigoGarantia.Equals(_mtbSolicitud_CodigoObjeto.Text)).ToList();
                            codigo = codigoObjetoV[0].CodigoGarantia;
                        }

                        solicitudes.Value(s => s.CodigoSolicitud, codigoSolicitud)
                                   .Value(s => s.CodigoCliente, deudor)
                                   .Value(s => s.CodigoCoDeudor, codeudor)
                                   .Value(s => s.CodigoGarantia, codigo)
                                   .Value(s => s.IdTipoPrestamo, idTipoPrestamo)
                                   .Value(s => s.IdFormaPago, idFormaPago)
                                   .Value(s => s.IdClasePrestamo, idClasePrestamo)
                                   .Value(s => s.IdTipoGarantia, idTipoGarantia)
                                   .Value(s => s.IdRuta, idRuta)
                                   .Value(s => s.IdZona, idZona)
                                   .Value(s => s.IdGestor, idGestor)
                                   .Value(s => s.FechaPago, Convert.ToDateTime(_dtpSolicitud_FechaPago.Value))
                                   .Value(s => s.DescripcionInversion, _txtSolicitud_DescripcionInversion.Text)
                                   .Value(s => s.MontoSolicitado, Convert.ToInt32(_txtSolicitud_MontoSolicitado.Text))
                                   .Value(s => s.GastosLegales, Convert.ToInt32(_txtSolicitud_GastosLegales.Text))
                                   .Value(s => s.MontoTotal, Convert.ToInt32(_txtSolicitud_MontoTotal.Text))
                                   .Value(s => s.CantidadCuotas, Convert.ToInt32(_txtSolicitud_CantidadCuotas.Text))
                                   .Value(s => s.TasaInteresAnual, Convert.ToDecimal(_txtSolicitud_TasaInteres.Text))
                                   .Value(s => s.TasaComisionAnual, Convert.ToDecimal(_txtSolicitud_TasaComision.Text))
                                   .Value(s => s.TasaSeguroAnual, Convert.ToDecimal(_txtSolicitud_TasaSeguro.Text))
                                   .Value(s => s.MontoCuota, Convert.ToInt32(_txtSolicitud_MontoCuotas.Text))
                                   .Value(s => s.IdEstadoSolicitud, 1)
                                   .Value(s => s.Estado, true)
                                   .Value(s => s.Fecha, Convert.ToDateTime(fechaAc))
                                   .Value(s => s.Hora, horaAc + " Inserción")
                                   .Value(s => s.IdUsuario, idUsario)
                                   .Value(s => s.IdSucursal, 1) // por ahora, lego debo cambiar por la suculsar que se este logiando
                                   .Value(s => s.IdEstadoPrestamo, 1)
                                   .Value(s => s.Mes, mes)
                                   .Value(s => s.Year, year)
                                   .Insert();

                        atraso.Value(a => a.CodigoSolicitud, codigoSolicitud)
                              .Value(a => a.Capital, 0)
                              .Value(a => a.Intere, 0)
                              .Value(a => a.Comision, 0)
                              .Value(a => a.Seguro, 0)
                              .Value(a => a.Mora, 0)
                              .Value(a => a.Cargos, 0)
                              .Insert();

                        reportePagos.Value(p => p.CodigoSolicitud, codigoSolicitud)
                                    .Value(p => p.MontoPrestamo, Convert.ToInt32(_txtSolicitud_MontoTotal.Text))
                                    .Value(p => p.CapitalPagado, 0)
                                    .Value(p => p.InteresPagado, 0)
                                    .Value(p => p.ComisionPagado, 0)
                                    .Value(p => p.SeguroPagado, 0)
                                    .Value(p => p.MoraPagada, 0)
                                    .Value(p => p.CargosPagado, 0)
                                    .Value(p => p.SaldoActual, Convert.ToInt32(_txtSolicitud_MontoTotal.Text))
                                    .Value(p => p.FechaUltimoPago, "")
                                    .Value(p => p.DiasSinPagar, 0)
                                    .Value(p => p.Estado, true)
                                    .Insert();

                        List<TDetalleSolicitudes> objectDetalleSolicitud = new List<TDetalleSolicitudes>();

                        foreach (DataGridViewRow dgvRow in _dataGridViewSolicitud.Rows)
                        {
                            var detalle = new TDetalleSolicitudes()
                            {
                                NoCuota = Convert.ToInt32(dgvRow.Cells[0].Value),
                                FechaPago = Convert.ToDateTime(dgvRow.Cells[1].Value),
                                Capital = Convert.ToInt32(dgvRow.Cells[2].Value),
                                Interes = Convert.ToDecimal(dgvRow.Cells[3].Value),
                                Comision = Convert.ToDecimal(dgvRow.Cells[4].Value),
                                Seguro = Convert.ToDecimal(dgvRow.Cells[5].Value),
                                ValorCuota = Convert.ToInt32(dgvRow.Cells[6].Value),
                            };

                            detalleSolicitudes.Value(d => d.CodigoSolicitud, codigoSolicitud)
                                              .Value(d => d.NoCuota, detalle.NoCuota)
                                              .Value(d => d.FechaPago, detalle.FechaPago)
                                              .Value(d => d.Capital, detalle.Capital)
                                              .Value(d => d.Interes, detalle.Interes)
                                              .Value(d => d.Comision, detalle.Comision)
                                              .Value(d => d.Seguro, detalle.Seguro)
                                              .Value(d => d.ValorCuota, detalle.ValorCuota)
                                              .Insert();

                            reportePrestamos.Value(d => d.CodigoSolicitud, codigoSolicitud)
                                            .Value(d => d.NoCuota, detalle.NoCuota)
                                            .Value(d => d.FechaPago, detalle.FechaPago)
                                            .Value(d => d.Capital, detalle.Capital)
                                            .Value(d => d.Interes, detalle.Interes)
                                            .Value(d => d.Comision, detalle.Comision)
                                            .Value(d => d.Seguro, detalle.Seguro)
                                            .Value(d => d.Mora, 0)
                                            .Value(d => d.Cargos, 0)
                                            .Value(d => d.SubTotal, detalle.Capital + detalle.Interes + detalle.Comision + detalle.Seguro)
                                            .Value(d => d.IdEstadoCuota, 1)
                                            .Value(d => d.EstadoFecha, true)
                                            .Insert();

                           
                        }
                        valor = true;
                        MessageBox.Show("Solicitud creada correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "update":

                        if (_txtCodigoSolicitud.Text != "")
                        {
                            var estadoS = solicitudes.Where(s => s.CodigoSolicitud.Equals(_txtCodigoSolicitud.Text)).ToList();

                            if (estadoS.Count > 0)
                            {
                                int ESTADO = estadoS[0].IdEstadoSolicitud;

                                if (ESTADO == 1)
                                {
                                    fechaAc = System.DateTime.Now.ToString("dd/MM/yyy");
                                    horaAc = System.DateTime.Now.ToString("HH:mm:ss");
                                    string montUp = System.DateTime.Now.ToString("MM");
                                    string mesUp = montUp.Replace("0", "");
                                    string yearUp = System.DateTime.Now.ToString("yyy");
                                    int deudorUp = 0, codeudorUP = 0, codigoUp = 0;

                                   
                                    if (_mtbSolicitud_NoDocumentoDeudor.Text != "" && _mtbSolicitud_NoDocumentoDeudor.Text != ("   -       -"))
                                    {
                                        var codigoDeudor = clientes.Where(c => c.NoDocumento.Equals(_mtbSolicitud_NoDocumentoDeudor.Text)).ToList();
                                        deudorUp = codigoDeudor[0].CodigoCliente;
                                    }

                                    if (_mtbSolicitud_NoDocumentoCoDeudor.Text != "" && _mtbSolicitud_NoDocumentoCoDeudor.Text != ("   -       -"))
                                    {
                                        var codigoCoDeudor = clientes.Where(c => c.NoDocumento.Equals(_mtbSolicitud_NoDocumentoCoDeudor.Text)).ToList();
                                        codeudorUP = codigoCoDeudor[0].CodigoCliente;
                                    }

                                    if (_mtbSolicitud_CodigoObjeto.Text != "")
                                    {
                                        var codigoObjetoV = garantiaEconomicas.Where(c => c.CodigoGarantia.Equals(_mtbSolicitud_CodigoObjeto.Text)).ToList();
                                        codigoUp = codigoObjetoV[0].CodigoGarantia;
                                    }
                                   

                                    solicitudes.Where(s => s.CodigoSolicitud.Equals(estadoS[0].CodigoSolicitud))
                                               .Set(s => s.CodigoCliente, deudorUp)
                                               .Set(s => s.CodigoCoDeudor, codeudorUP)
                                               .Set(s => s.CodigoGarantia, codigoUp)
                                               .Set(s => s.IdTipoPrestamo, idTipoPrestamo)
                                               .Set(s => s.IdFormaPago, idFormaPago)
                                               .Set(s => s.IdClasePrestamo, idClasePrestamo)
                                               .Set(s => s.IdTipoGarantia, idTipoGarantia)
                                               .Set(s => s.IdRuta, idRuta)
                                               .Set(s => s.IdZona, idZona)
                                               .Set(s => s.IdGestor, idGestor)
                                               .Set(s => s.FechaPago, Convert.ToDateTime(_dtpSolicitud_FechaPago.Value))
                                               .Set(s => s.DescripcionInversion, _txtSolicitud_DescripcionInversion.Text)
                                               .Set(s => s.MontoSolicitado, Convert.ToInt32(_txtSolicitud_MontoSolicitado.Text))
                                               .Set(s => s.GastosLegales, Convert.ToInt32(_txtSolicitud_GastosLegales.Text))
                                               .Set(s => s.MontoTotal, Convert.ToInt32(_txtSolicitud_MontoTotal.Text))
                                               .Set(s => s.CantidadCuotas, Convert.ToInt32(_txtSolicitud_CantidadCuotas.Text))
                                               .Set(s => s.TasaInteresAnual, Convert.ToDecimal(_txtSolicitud_TasaInteres.Text))
                                               .Set(s => s.TasaComisionAnual, Convert.ToDecimal(_txtSolicitud_TasaComision.Text))
                                               .Set(s => s.TasaSeguroAnual, Convert.ToDecimal(_txtSolicitud_TasaSeguro.Text))
                                               .Set(s => s.MontoCuota, Convert.ToInt32(_txtSolicitud_MontoCuotas.Text))
                                               .Set(s => s.IdEstadoSolicitud, 1)
                                               .Set(s => s.Estado, true)
                                               .Set(s => s.Fecha, Convert.ToDateTime(fechaAc))
                                               .Set(s => s.Hora, horaAc + " Actualización")
                                               .Set(s => s.IdUsuario, idUsario)
                                                 //.Set(s => s.IdSucursal, 1) // por ahora, lego debo cambiar por la suculsar que se este logiando
                                                .Set(s => s.Mes, mesUp)
                                                .Set(s => s.Year, yearUp)
                                               .Update();

                                          reportePagos.Where(p => p.CodigoSolicitud.Equals(codigoSolicitud))
                                                      .Set(p => p.MontoPrestamo, Convert.ToInt32(_txtSolicitud_MontoTotal.Text))
                                                      .Set(p => p.SaldoActual, Convert.ToInt32(_txtSolicitud_MontoTotal.Text))
                                                      .Update();

                                    //ELIMINA LOS REGISTRO PARA LUEGO CREARLO
                                    detalleSolicitudes.Where(d => d.CodigoSolicitud.Equals(estadoS[0].CodigoSolicitud)).Delete();
                                    reportePrestamos.Where(d => d.CodigoSolicitud.Equals(estadoS[0].CodigoSolicitud)).Delete();

                                    List<TDetalleSolicitudes> objectDetalleSolicitudUp = new List<TDetalleSolicitudes>();
                                    foreach (DataGridViewRow dgvRowUp in _dataGridViewSolicitud.Rows)
                                    {
                                        var detalleUp = new TDetalleSolicitudes()
                                        {
                                            NoCuota = Convert.ToInt32(dgvRowUp.Cells[0].Value),
                                            FechaPago = Convert.ToDateTime(dgvRowUp.Cells[1].Value),
                                            Capital = Convert.ToInt32(dgvRowUp.Cells[2].Value),
                                            Interes = Convert.ToDecimal(dgvRowUp.Cells[3].Value),
                                            Comision = Convert.ToDecimal(dgvRowUp.Cells[4].Value),
                                            Seguro = Convert.ToDecimal(dgvRowUp.Cells[5].Value),
                                            ValorCuota = Convert.ToInt32(dgvRowUp.Cells[6].Value),
                                        };

                                        detalleSolicitudes.Value(d => d.CodigoSolicitud, estadoS[0].CodigoSolicitud)
                                               .Value(d => d.NoCuota, detalleUp.NoCuota)
                                               .Value(d => d.FechaPago, detalleUp.FechaPago)
                                               .Value(d => d.Capital, detalleUp.Capital)
                                               .Value(d => d.Interes, detalleUp.Interes)
                                               .Value(d => d.Comision, detalleUp.Comision)
                                               .Value(d => d.Seguro, detalleUp.Seguro)
                                               .Value(d => d.ValorCuota, detalleUp.ValorCuota)
                                               .Insert();

                                        reportePrestamos.Value(d => d.CodigoSolicitud, estadoS[0].CodigoSolicitud)
                                                        .Value(d => d.NoCuota, detalleUp.NoCuota)
                                                        .Value(d => d.FechaPago, detalleUp.FechaPago)
                                                        .Value(d => d.Capital, detalleUp.Capital)
                                                        .Value(d => d.Interes, detalleUp.Interes)
                                                        .Value(d => d.Comision, detalleUp.Comision)
                                                        .Value(d => d.Seguro, detalleUp.Seguro)
                                                        .Value(d => d.Mora, 0)
                                                        .Value(d => d.Cargos, 0)
                                                        .Value(d => d.SubTotal, detalleUp.Capital + detalleUp.Interes + detalleUp.Comision + detalleUp.Seguro)
                                                        .Value(d => d.IdEstadoCuota, 1)
                                                        .Value(d => d.EstadoFecha, true)
                                                        .Insert();
                                    }

                                    valor = true;
                                    MessageBox.Show("Solicitud actualizada correctamente.", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("La Solicitud Se Encuentra En Un Estado Que No Se Puede Modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                        }
                        break;
                }

              //  CommitTransaction();
                RestablecerSolicitud();
            }
            catch (Exception ex)
            {
                //RollbackTransaction();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return valor;

        }

        public void RestablecerSolicitud()
        {
            _accion = "insert";
            
            getTipoPrestamo();
            getFormaPago();
            getClasePrestamo();
            getTipoGarantia();
            getRuta();
            getZona();
            getGestor();

            _mtbSolicitud_NoDocumentoDeudor.Clear();
            _txtSolicitud_NombreDeudor.Clear();
            _txtSolicitud_ApellidosDeudor.Clear();
            _mtbSolicitud_NoDocumentoCoDeudor.Clear();
            _txtSolicitud_NombreCoDeudor.Clear();
            _txtSolicitud_ApellidosCoDeudor.Clear();
            _dtpSolicitud_FechaPago.ResetText();
            _txtSolicitud_NombreObjecto.Clear();
            _mtbSolicitud_CodigoObjeto.Clear();

            _txtSolicitud_MontoSolicitado.Text = "0";
            _txtSolicitud_GastosLegales.Text = "0";
            _txtSolicitud_MontoTotal.Text = "0";
            _txtSolicitud_CantidadCuotas.Text = "0";
            _txtSolicitud_TasaInteres.Text = "0";
            _txtSolicitud_TasaComision.Text = "0";
            _txtSolicitud_TasaSeguro.Text = "0";
            _txtSolicitud_MontoCuotas.Text = "0";
            

            _txtSolicitud_DescripcionInversion.Clear();
            _txtCodigoSolicitud.Clear();

             _lblSolicitud_NoDocumentoDeudor.ForeColor = Color.LightSlateGray;
            _lblSolicitud_NoDocumentoCoDeudor.ForeColor = Color.LightSlateGray;
            _lblSolicitud_DescipcionInversion.ForeColor = Color.LightSlateGray;
            _lblSolicitud_MontoSolicitado.ForeColor = Color.LightSlateGray;
            _lblSolicitud_CatidadCuotas.ForeColor = Color.LightSlateGray;
            _lblSolicitud_TasaInteresAnual.ForeColor = Color.LightSlateGray;

            _dtpSolicitud_FechaPago.ResetText();
            _dataGridViewSolicitud.Rows.Clear();
            _panelSolicitud_Deudores.Enabled = false;

        }

        public void GetSolicitud()
        {
            try
            {
                _accion = "update";

                if (_txtCodigoSolicitud.Text != (""))
                {
                    var data = from s in solicitudes
                               join d in detalleSolicitudes on s.CodigoSolicitud equals d.CodigoSolicitud
                               where s.CodigoSolicitud == Convert.ToInt32(_txtCodigoSolicitud.Text)
                               select new
                               {
                                   s.CodigoSolicitud,
                                   s.CodigoCliente,
                                   s.CodigoCoDeudor,
                                   s.CodigoGarantia,
                                   s.IdTipoPrestamo,
                                   s.IdFormaPago,
                                   s.IdClasePrestamo,
                                   s.IdTipoGarantia,
                                   s.IdRuta,
                                   s.IdZona,
                                   s.IdGestor,
                                   s.FechaPago,
                                   s.DescripcionInversion,
                                   s.MontoSolicitado,
                                   s.GastosLegales,
                                   s.MontoTotal,
                                   s.CantidadCuotas,
                                   s.TasaInteresAnual,
                                   s.TasaComisionAnual,
                                   s.TasaSeguroAnual,
                                   s.MontoCuota,
                                   s.IdEstadoSolicitud,
                                   s.Estado,
                                   s.Fecha,
                                   s.Hora,
                                   s.IdUsuario
                               };

                    var item = data.ToList();

                    if (item.Count() > 0)
                    {

                        var deudor = clientes.Where(c => c.CodigoCliente.Equals(item[0].CodigoCliente)).ToList();
                        var codeudor = clientes.Where(c => c.CodigoCliente.Equals(item[0].CodigoCoDeudor) && item[0].CodigoCoDeudor > 0).ToList();
                        var objetovalor = garantiaEconomicas.Where(g => g.CodigoGarantia.Equals(item[0].CodigoGarantia) && item[0].CodigoGarantia > 0).ToList();
                      
                        

                        _txtCodigoSolicitud.Text = item[0].CodigoSolicitud.ToString();

                        _mtbSolicitud_NoDocumentoDeudor.Text = deudor[0].NoDocumento.ToString();
                        _txtSolicitud_NombreDeudor.Text = deudor[0].Nombre.ToString();
                        _txtSolicitud_ApellidosDeudor.Text = deudor[0].Apellido.ToString();

                        if (codeudor.Count > 0)
                        {
                            _mtbSolicitud_NoDocumentoCoDeudor.Text = codeudor[0].NoDocumento.ToString();
                            _txtSolicitud_NombreCoDeudor.Text = codeudor[0].Nombre.ToString();
                            _txtSolicitud_ApellidosCoDeudor.Text = codeudor[0].Apellido.ToString();
                        }

                        if (objetovalor.Count > 0)
                        {
                            _mtbSolicitud_CodigoObjeto.Text = objetovalor[0].CodigoGarantia.ToString();
                            _txtSolicitud_NombreObjecto.Text = objetovalor[0].NombreGE.ToString();
                        }

                        var tipoPrestamo = tipoPrestamos.Where(t => t.IdTipoPrestamo.Equals(item[0].IdTipoPrestamo)).ToList();
                        var formaPago = formaPagos.Where(f => f.IdFormaPago.Equals(item[0].IdFormaPago)).ToList();
                        var calsePrestamo = clasePrestamos.Where(c => c.IdClasePrestamo.Equals(item[0].IdClasePrestamo)).ToList();
                        var tipoGarantia = tipoGarantias.Where(t => t.IdTipoGarantia.Equals(item[0].IdTipoGarantia)).ToList();
                        var ruta = rutas.Where(r => r.IdRuta.Equals(item[0].IdRuta)).ToList();
                        var zona = zonas.Where(z => z.IdZona.Equals(item[0].IdZona)).ToList();
                        var gestor = gestores.Where(g => g.IdGestor.Equals(item[0].IdGestor)).ToList();

                        _comboBoxSolicitud_TipoPrestamo.Text = tipoPrestamo[0].Descripcion;
                        _comboBoxSolicitud_FormaPago.Text = formaPago[0].DescripcionFP;
                        _comboBoxSolicitud_ClasePrestamo.Text = calsePrestamo[0].Descripcion;
                        _comboBoxSolicitud_TipoGarantia.Text = tipoGarantia[0].Descripcion;
                        _comboBoxSolicitud_Ruta.Text = ruta[0].Descripcion;
                        _comboBoxSolicitud_Zona.Text = zona[0].Descripcion;
                        _comboBoxSolicitud_Gestor.Text = gestor[0].Nombre;
                        _dtpSolicitud_FechaPago.Text = item[0].FechaPago.ToString();

                        _txtSolicitud_DescripcionInversion.Text = item[0].DescripcionInversion.ToString();
                        _txtSolicitud_MontoSolicitado.Text = item[0].MontoSolicitado.ToString();
                        _txtSolicitud_GastosLegales.Text = item[0].GastosLegales.ToString();
                        _txtSolicitud_MontoTotal.Text = item[0].MontoTotal.ToString();
                        _txtSolicitud_CantidadCuotas.Text = item[0].CantidadCuotas.ToString();
                        _txtSolicitud_TasaInteres.Text = item[0].TasaInteresAnual.ToString();
                        _txtSolicitud_TasaComision.Text = item[0].TasaComisionAnual.ToString();
                        _txtSolicitud_TasaSeguro.Text = item[0].TasaSeguroAnual.ToString();
                        _txtSolicitud_MontoCuotas.Text = item[0].MontoCuota.ToString();

                        _dataGridViewSolicitud.Rows.Clear();
                        calcularPrestamo();

                        _txtCodigoSolicitud.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("El Código De Solicitud No Existe.", "Advertencia ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _txtCodigoSolicitud.Text = "";
                        _txtCodigoSolicitud.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("El Código De Solicitud Es Obligatorio.", "Advertencia ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _txtCodigoSolicitud.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetDeudor()
        {
            try
            {
                if (_mtbSolicitud_NoDocumentoDeudor.Text != ("") && _mtbSolicitud_NoDocumentoDeudor.Text != ("   -       -"))
                {
                    bool valor = validarNoDocumento(_mtbSolicitud_NoDocumentoDeudor, _lblSolicitud_NoDocumentoDeudor);

                    if (valor == true)
                    {
                        var deudor = from c in clientes
                                     where c.NoDocumento == _mtbSolicitud_NoDocumentoDeudor.Text
                                     select new
                                     {
                                         c.NoDocumento,
                                         c.Nombre,
                                         c.Apellido
                                     };

                        var item = deudor.ToList();

                        if (item.Count() > 0)
                        {
                            if (item[0].NoDocumento.ToString() == _mtbSolicitud_NoDocumentoCoDeudor.Text)
                            {
                                MessageBox.Show("El Número De Documento ya existe en el contexto actual.", "Advertencia ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _mtbSolicitud_NoDocumentoDeudor.Text = "";
                                _txtSolicitud_NombreDeudor.Text = "";
                                _txtSolicitud_ApellidosDeudor.Text = "";
                                _mtbSolicitud_NoDocumentoDeudor.Focus();
                            }
                            else
                            {
                                _mtbSolicitud_NoDocumentoDeudor.Text = item[0].NoDocumento.ToString();
                                _txtSolicitud_NombreDeudor.Text = item[0].Nombre.ToString();
                                _txtSolicitud_ApellidosDeudor.Text = item[0].Apellido.ToString();
                            }

                        }
                        else
                        {
                            MessageBox.Show("El Número De Documento No Existe.", "Advertencia ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _mtbSolicitud_NoDocumentoDeudor.Text = "";
                            _txtSolicitud_NombreDeudor.Text = "";
                            _txtSolicitud_ApellidosDeudor.Text = "";
                            _mtbSolicitud_NoDocumentoDeudor.Focus();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("El campo Número De Documento es obligatorio.", "Advertencia ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _mtbSolicitud_NoDocumentoDeudor.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        public void GetCoDeudor()
        {
            try
            {
                if (_mtbSolicitud_NoDocumentoCoDeudor.Text != ("") && _mtbSolicitud_NoDocumentoCoDeudor.Text != ("   -       -"))
                {
                    bool valor = validarNoDocumento(_mtbSolicitud_NoDocumentoCoDeudor, _lblSolicitud_NoDocumentoCoDeudor);

                    if (valor == true)
                    {
                        var deudor = from c in clientes
                                     where c.NoDocumento == _mtbSolicitud_NoDocumentoCoDeudor.Text
                                     select new
                                     {
                                         c.NoDocumento,
                                         c.Nombre,
                                         c.Apellido
                                     };

                        var item = deudor.ToList();

                        if (item.Count() > 0)
                        {
                            if (item[0].NoDocumento.ToString() == _mtbSolicitud_NoDocumentoDeudor.Text)
                            {
                                MessageBox.Show("El Número De Documento ya existe en el contexto actual.", "Advertencia ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _mtbSolicitud_NoDocumentoCoDeudor.Text = "";
                                _txtSolicitud_NombreCoDeudor.Text = "";
                                _txtSolicitud_ApellidosCoDeudor.Text = "";
                                _mtbSolicitud_NoDocumentoCoDeudor.Focus();
                            }
                            else
                            {
                                _mtbSolicitud_NoDocumentoCoDeudor.Text = item[0].NoDocumento.ToString();
                                _txtSolicitud_NombreCoDeudor.Text = item[0].Nombre.ToString();
                                _txtSolicitud_ApellidosCoDeudor.Text = item[0].Apellido.ToString();
                            }

                        }
                        else
                        {
                            MessageBox.Show("El Número De Documento No Existe.", "Advertencia ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _mtbSolicitud_NoDocumentoCoDeudor.Text = "";
                            _txtSolicitud_NombreCoDeudor.Text = "";
                            _txtSolicitud_ApellidosCoDeudor.Text = "";
                        }
                    }

                }
                else
                {
                    MessageBox.Show("El campo Número De Documento es obligatorio.", "Advertencia ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _mtbSolicitud_NoDocumentoCoDeudor.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void GetGarantia()
        {
            try
            {

                if (_mtbSolicitud_CodigoObjeto.Text != (""))
                {
                    var objeto = from g in garantiaEconomicas
                                 where g.CodigoGarantia == Convert.ToUInt32(_mtbSolicitud_CodigoObjeto.Text)
                                 select new
                                 {
                                     g.CodigoGarantia,
                                     g.NombreGE
                                 };

                    var item = objeto.ToList();

                    if (item.Count() > 0)
                    {
                        _mtbSolicitud_CodigoObjeto.Text = item[0].CodigoGarantia.ToString();
                        _txtSolicitud_NombreObjecto.Text = item[0].NombreGE.ToString();
                    }
                    else
                    {
                        MessageBox.Show("El Código Del Objeto De Valor No Existe.", "Advertencia ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _mtbSolicitud_CodigoObjeto.Text = "";
                        _txtSolicitud_NombreObjecto.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("El campo Código Del Objeto De Valor Es Obligatorio.", "Advertencia ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _mtbSolicitud_CodigoObjeto.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public  bool validarNoDocumento(MaskedTextBox maskedTextBox, Label label)
        {
            bool valor = false;

            try
            {
                if (maskedTextBox.Text != ("") && maskedTextBox.Text != ("   -       -"))
                {
                    string maskara = maskedTextBox.Mask;
                    string sinMaskara = maskedTextBox.Mask = "";
                    int len = maskedTextBox.TextLength;

                    if (len < 11)
                    {
                        label.Text = "El Número De Documento esta incompleto.";
                        label.ForeColor = Color.Red;
                        maskedTextBox.Mask = maskara;
                        maskedTextBox.Focus();
                        valor = false;
                    }
                    else
                    {
                        label.Text = "Número De Documento";
                        label.ForeColor = Color.LightSlateGray;
                        maskedTextBox.Mask = maskara;
                        valor = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return valor;

        }

        public void calcularPrestamo()
        {

            switch (_comboBoxSolicitud_TipoPrestamo.Text)
            {
                case "SALDO INSOLUTO":
                    CalcularSaldoInsoluto();
                    break;

                case "PAGO DE INTERES A VENCIMIENTO":
                    CalcularSaldoInteres();
                    break;
            }
        }

        private void CalcularSaldoInsoluto()
        {
            try
            {

                DateTime fecha = _dtpSolicitud_FechaPago.Value;

                if (_txtSolicitud_TasaComision.Text == "")
                {
                    _txtSolicitud_TasaComision.Text = "0";
                }

                if (_txtSolicitud_TasaSeguro.Text == "")
                {
                    _txtSolicitud_TasaSeguro.Text = "0";
                }


                bool valor = ValidarCampos();

                if (valor == true)
                {
                    _dataGridViewSolicitud.Rows.Clear();

                    TotalPrestamo();

                    TasaComision = Convert.ToDouble(_txtSolicitud_TasaComision.Text);
                    TasaSeguro = Convert.ToDouble(_txtSolicitud_TasaSeguro.Text);

                    double interes_total = 0, capital_total = 0, cuota_total = 0, comision_total = 0, seguro_total = 0;
                    MontoTotal = MontoSolicitado + GastosLegales;
                    CantidadCuotas = Convert.ToInt32(_txtSolicitud_CantidadCuotas.Text);
                    double IntereAnual = Convert.ToDouble(_txtSolicitud_TasaInteres.Text);

                    IntereAnual = IntereAnual / 100 / 12;
                    TasaComision = TasaComision / 100 / 12;
                    TasaSeguro = TasaSeguro / 100 / 12;

                    double compocision = IntereAnual + TasaComision + TasaSeguro;

                    double Resultado = (1 - Math.Pow(1 + compocision, CantidadCuotas * -1)) / compocision;

                    double CUOTA = Math.Round(MontoTotal / Resultado, 0);
                    _txtSolicitud_MontoCuotas.Text = CUOTA.ToString(); String.Format("{0:#,###,###,##0.00####}", CUOTA);

                    double INTERES = 0;
                    double TINTERES = 0;
                    double CAPITAL = 0;
                    double TAMORTIZADO = 0;
                    double TCUOTA = 0;
                    double SALDOINICIAL = 0;
                    double ACUMULADO = 0;
                    double SALDOFINAL = MontoTotal;
                    double CAPITALAPAGAR = 0;
                    double COMISION = 0;
                    double SEGURO = 0;

                    _formaPago = _comboBoxSolicitud_FormaPago.Text;

                    for (int NoCuota = 1; NoCuota < CantidadCuotas + 1; NoCuota++)
                    {
                        COMISION = Math.Round(SALDOFINAL * TasaComision, 0);
                        SEGURO = Math.Round(SALDOFINAL * TasaSeguro, 0);
                        INTERES = Math.Round(SALDOFINAL * IntereAnual, 0);// interes aplica mes
                        CAPITALAPAGAR = Math.Round(CUOTA - INTERES - COMISION - SEGURO, 0);
                        TINTERES += INTERES; // ACUMULA LOS INTERES
                        ACUMULADO += INTERES; //
                        SALDOINICIAL = SALDOFINAL;
                        CAPITAL = Math.Round(CUOTA - INTERES - COMISION - SEGURO, 0);//DIFERENCIA LA CUOTA DE LOS INTERES DEL MES
                        TAMORTIZADO += CAPITAL; //ACUMULA TODA LA CUOTA
                        SALDOFINAL -= CAPITAL;// REBAJA LA CUOTA AMORTIZADA  DE CADA MES
                        TCUOTA += CUOTA;

                        interes_total += INTERES;
                        capital_total += CAPITALAPAGAR;
                        cuota_total += CUOTA;
                        comision_total += COMISION;
                        seguro_total += SEGURO;

                        if (capital_total > MontoTotal)
                        {
                            double reciduo = capital_total - MontoTotal;

                            capital_total = capital_total - reciduo;

                            CAPITALAPAGAR += -reciduo;
                            INTERES += reciduo;
                            interes_total += reciduo;
                            SALDOFINAL += reciduo;
                        }
                        else if (NoCuota == CantidadCuotas && capital_total < MontoTotal)
                        {
                            double reciduo = (capital_total - MontoTotal) * -1;

                            capital_total += reciduo;

                            CAPITALAPAGAR += reciduo;
                            INTERES += -reciduo;
                            interes_total += -reciduo;
                            SALDOFINAL += -reciduo;
                        }

                        DateTime dias = new DateTime();
                        switch (_formaPago)
                        {
                            case "MENSUAL":
                                DateTime FFecha = Convert.ToDateTime(_dtpSolicitud_FechaPago.Value.ToString());
                                FECHA = DateTime.Parse(FFecha.ToString());
                                _dataGridViewSolicitud.Rows.Add(NoCuota, FECHA.AddMonths(NoCuota).ToShortDateString(), CAPITALAPAGAR, INTERES, COMISION, SEGURO, CUOTA, SALDOFINAL, ACUMULADO);
                                break;

                            case "QUINCENAL":
                                dias = fecha.AddDays(15);
                                fecha = dias;
                                _dataGridViewSolicitud.Rows.Add(NoCuota, dias, CAPITALAPAGAR, INTERES, COMISION, SEGURO, CUOTA, SALDOFINAL, ACUMULADO);
                                break;

                            case "SEMANAL":
                                dias = fecha.AddDays(7);
                                fecha = dias;
                                _dataGridViewSolicitud.Rows.Add(NoCuota, dias, CAPITALAPAGAR, INTERES, COMISION, SEGURO, CUOTA, SALDOFINAL, ACUMULADO);
                                break;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void VerResumen()
        {
            //_dataGridViewSolicitud.Rows.Add("", "", String.Format("{0:#,###,###,##0.00####}", capital_total), String.Format("{0:#,###,###,##0.00####}", interes_total), String.Format("{0:#,###,###,##0.00####}", comision_total), String.Format("{0:#,###,###,##0.00####}", seguro_total), String.Format("{0:#,###,###,##0.00####}", cuota_total), "", "");

            double interes_total = 0, comision_total = 0, seguro_total = 0 , capital_total = 0, cuota_total = 0;

            try
            {

                if (_dataGridViewSolicitud.RowCount > 0)
                {
                    List<TDetalleSolicitudes> objectDetalleSolicitud = new List<TDetalleSolicitudes>();

                    foreach (DataGridViewRow dgvRow in _dataGridViewSolicitud.Rows)
                    {
                        var detalle = new TDetalleSolicitudes()
                        {
                            Capital = Convert.ToInt32(dgvRow.Cells[2].Value),
                            Interes = Convert.ToDecimal(dgvRow.Cells[3].Value),
                            Comision = Convert.ToDecimal(dgvRow.Cells[4].Value),
                            Seguro = Convert.ToDecimal(dgvRow.Cells[5].Value),
                            ValorCuota = Convert.ToInt32(dgvRow.Cells[6].Value),

                        };

                        capital_total += Convert.ToDouble(detalle.Capital);
                        interes_total += Convert.ToDouble(detalle.Interes);
                        comision_total += Convert.ToDouble(detalle.Comision);
                        seguro_total += Convert.ToDouble(detalle.Seguro);
                        cuota_total += Convert.ToDouble(detalle.ValorCuota);
                    }


                    MessageBox.Show($"Capital A Pagar : {_txtSolicitud_MontoTotal.Text } \nIntereses A Pagar : " + Math.Round(interes_total, 2) + "\nComisiones A Pagar : " + Math.Round(comision_total, 2) + "\nSeguro A Pagar : " + Math.Round(seguro_total, 2) + "\n\nTotal A Pagar : " + Math.Round(cuota_total, 2), "RESUMEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No existen datos para visiualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void CalcularSaldoInteres()
        {
            try
            {
                DateTime fecha = _dtpSolicitud_FechaPago.Value;

                if (_txtSolicitud_TasaComision.Text == "")
                {
                    _txtSolicitud_TasaComision.Text = "0";
                }

                if (_txtSolicitud_TasaSeguro.Text == "")
                {
                    _txtSolicitud_TasaSeguro.Text = "0";
                }


                bool valor = ValidarCampos();

                if (valor == true)
                {
                    _dataGridViewSolicitud.Rows.Clear();

                    TotalPrestamo();

                    TasaComision = Convert.ToDouble(_txtSolicitud_TasaComision.Text);
                    TasaSeguro = Convert.ToDouble(_txtSolicitud_TasaSeguro.Text);

                    double interes_total = 0, capital_total = 0, cuota_total = 0, comision_total = 0, seguro_total = 0;
                    MontoTotal = MontoSolicitado + GastosLegales;
                    CantidadCuotas = Convert.ToInt32(_txtSolicitud_CantidadCuotas.Text);
                    double IntereAnual = Convert.ToDouble(_txtSolicitud_TasaInteres.Text);

                    IntereAnual = IntereAnual / 100 / 12;
                    TasaComision = TasaComision / 100 / 12;
                    TasaSeguro = TasaSeguro / 100 / 12;

                    double compocision = IntereAnual + TasaComision + TasaSeguro;
                    double Resultado = (1 - Math.Pow(1 + compocision, CantidadCuotas * -1)) / compocision;
                    double CUOTA = Math.Round(MontoTotal / Resultado, 0);

                    double INTERES = 0;
                    double TINTERES = 0;
                    double CAPITAL = 0;
                    double TCUOTA = 0;
                    double SALDOINICIAL = 0;
                    double ACUMULADO = 0;
                    double SALDOFINAL = MontoTotal;
                    double CAPITALAPAGAR = 0;
                    double COMISION = 0;
                    double SEGURO = 0;

                    _formaPago = _comboBoxSolicitud_FormaPago.Text;

                    for (int NoCuota = 1; NoCuota < CantidadCuotas + 1; NoCuota++)
                    {
                        COMISION = Math.Round(SALDOFINAL * TasaComision, 0);
                        SEGURO = Math.Round(SALDOFINAL * TasaSeguro, 0);
                        INTERES = Math.Round(SALDOFINAL * IntereAnual, 0);// interes aplica mes
                        TINTERES += Math.Round(INTERES, 0); // ACUMULA LOS INTERES
                        SALDOINICIAL = Math.Round(SALDOFINAL, 0);
                        CUOTA = Convert.ToInt32(INTERES + COMISION + SEGURO);

                        TCUOTA += Math.Round(CUOTA, 0);
                        _txtSolicitud_MontoCuotas.Text = CUOTA.ToString(); // String.Format("{0:#,###,###,##0.00####}", CUOTA);

                        DateTime dias = new DateTime();
                        switch (_formaPago)
                        {
                            case "MENSUAL":
                                DateTime FFecha = Convert.ToDateTime(_dtpSolicitud_FechaPago.Value.ToString());
                                FECHA = DateTime.Parse(FFecha.ToString());

                                if (NoCuota == CantidadCuotas)
                                {
                                    CUOTA += Convert.ToInt32(SALDOFINAL);
                                    CAPITAL = SALDOFINAL;
                                    SALDOFINAL = 0;
                                    _dataGridViewSolicitud.Rows.Add(NoCuota, FECHA.AddMonths(NoCuota).ToShortDateString(), MontoTotal, INTERES, COMISION, SEGURO, CUOTA, SALDOFINAL, ACUMULADO);
                                }
                                else
                                {
                                    _dataGridViewSolicitud.Rows.Add(NoCuota, FECHA.AddMonths(NoCuota).ToShortDateString(), CAPITALAPAGAR, INTERES, COMISION, SEGURO, CUOTA, SALDOFINAL, ACUMULADO);
                                }

                                break;

                            case "QUINCENAL":
                                dias = fecha.AddDays(15);
                                fecha = dias;


                                if (NoCuota == CantidadCuotas)
                                {
                                    CUOTA += Convert.ToInt32(SALDOFINAL);
                                    CAPITAL = SALDOFINAL;
                                    SALDOFINAL = 0;
                                    _dataGridViewSolicitud.Rows.Add(NoCuota, dias, MontoTotal, INTERES, COMISION, SEGURO, CUOTA, SALDOFINAL, ACUMULADO);
                                }
                                else
                                {
                                    _dataGridViewSolicitud.Rows.Add(NoCuota, dias, CAPITALAPAGAR, INTERES, COMISION, SEGURO, CUOTA, SALDOFINAL, ACUMULADO);
                                }

                                break;

                            case "SEMANAL":
                                dias = fecha.AddDays(7);
                                fecha = dias;
                                if (NoCuota == CantidadCuotas)
                                {
                                    CUOTA += Convert.ToInt32(SALDOFINAL);
                                    CAPITAL = SALDOFINAL;
                                    SALDOFINAL = 0;
                                    _dataGridViewSolicitud.Rows.Add(NoCuota, dias, MontoTotal, INTERES, COMISION, SEGURO, CUOTA, SALDOFINAL, ACUMULADO);
                                }
                                else
                                {
                                    _dataGridViewSolicitud.Rows.Add(NoCuota, dias, CAPITALAPAGAR, INTERES, COMISION, SEGURO, CUOTA, SALDOFINAL, ACUMULADO);
                                }
                                break;
                        }

                        interes_total += INTERES;
                        comision_total += COMISION;
                        seguro_total += SEGURO;
                        capital_total += Math.Round(CAPITAL, 0);
                        cuota_total += CUOTA;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void TotalPrestamo()
        {
            try
            {
                if (_txtSolicitud_MontoSolicitado.Text == "")
                {
                    _txtSolicitud_MontoSolicitado.Text = "0";
                }
                else if (_txtSolicitud_GastosLegales.Text == "")
                {
                    _txtSolicitud_GastosLegales.Text = "0";
                }
                else if (_txtSolicitud_MontoTotal.Text == "")
                {
                    _txtSolicitud_MontoTotal.Text = "0";
                }

                MontoSolicitado = Convert.ToDouble(_txtSolicitud_MontoSolicitado.Text);
                GastosLegales = Convert.ToDouble(_txtSolicitud_GastosLegales.Text);
                MontoTotal = Convert.ToDouble(_txtSolicitud_MontoTotal.Text);

                MontoTotal = MontoSolicitado + GastosLegales;
                _txtSolicitud_MontoTotal.Text = MontoTotal.ToString(); //String.Format("{0:#,###,###,##0.00####}", MontoTotal);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool ValidarCampos()
        {
            bool valor = true;

            try
            {
                //
                if (_txtSolicitud_DescripcionInversion.Text == "")
                {
                    _lblSolicitud_DescipcionInversion.ForeColor = Color.Red;
                    valor = false;
                }
                else
                {
                    _lblSolicitud_DescipcionInversion.ForeColor = Color.LightSlateGray;
                }

                //
                if (_txtSolicitud_MontoSolicitado.Text == "" || Convert.ToInt32(_txtSolicitud_MontoSolicitado.Text) < 1000)
                {
                    _lblSolicitud_MontoSolicitado.ForeColor = Color.Red;
                    valor = false;
                }
                else
                {
                    _lblSolicitud_MontoSolicitado.ForeColor = Color.LightSlateGray;
                }

                //
                if (_txtSolicitud_CantidadCuotas.Text == "" || Convert.ToInt32(_txtSolicitud_CantidadCuotas.Text) < 1)
                {
                    _lblSolicitud_CatidadCuotas.ForeColor = Color.Red;
                    valor = false;
                }
                else
                {
                    _lblSolicitud_CatidadCuotas.ForeColor = Color.LightSlateGray;
                }

                //
                if (_txtSolicitud_TasaInteres.Text == "" || Convert.ToDecimal(_txtSolicitud_TasaInteres.Text) <= 0)
                {
                    _lblSolicitud_TasaInteresAnual.ForeColor = Color.Red;
                    valor = false;
                }
                else
                {
                    _lblSolicitud_TasaInteresAnual.ForeColor = Color.LightSlateGray;
                }

                if (valor == false)
                {
                    MessageBox.Show("Los campos marcados con  *  son obligatorios por tanto no pueden estar  vacío, por favor complete los datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

    
            return valor;
        }

        public void getIdentificadores()
        {
            try
            {
                var queryTipoPrestamo = tipoPrestamos.Where(i => i.Descripcion.Equals(_comboBoxSolicitud_TipoPrestamo.Text)).ToList();
                idTipoPrestamo = queryTipoPrestamo[0].IdTipoPrestamo;

                var queryFormaPago = formaPagos.Where(i => i.DescripcionFP.Equals(_comboBoxSolicitud_FormaPago.Text)).ToList();
                idFormaPago = queryFormaPago[0].IdFormaPago;

                var queryClasePrestamo = clasePrestamos.Where(i => i.Descripcion.Equals(_comboBoxSolicitud_ClasePrestamo.Text)).ToList();
                idClasePrestamo = queryClasePrestamo[0].IdClasePrestamo;

                var queryTipoGarantia = tipoGarantias.Where(i => i.Descripcion.Equals(_comboBoxSolicitud_TipoGarantia.Text)).ToList();
                idTipoGarantia = queryTipoGarantia[0].IdTipoGarantia;

                var queryRuta = rutas.Where(i => i.Descripcion.Equals(_comboBoxSolicitud_Ruta.Text)).ToList();
                idRuta = queryRuta[0].IdRuta;

                var queryZona = zonas.Where(i => i.Descripcion.Equals(_comboBoxSolicitud_Zona.Text)).ToList();
                idZona = queryZona[0].IdZona;

                var queryGestor = gestores.Where(i => i.Nombre.Equals(_comboBoxSolicitud_Gestor.Text)).ToList();
                idGestor = queryGestor[0].IdGestor;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
     
        }

        #region /*OBTENIENDO DATOS DE LOS COMBOBOX*/
        public void getTipoPrestamo()
        {
            try
            {
                _comboBoxSolicitud_TipoPrestamo.DataSource = tipoPrestamos.ToList();
                _comboBoxSolicitud_TipoPrestamo.ValueMember = "IdTipoPrestamo";
                _comboBoxSolicitud_TipoPrestamo.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getFormaPago()
        {
            
            try
            {
                _comboBoxSolicitud_FormaPago.DataSource = formaPagos.ToList();
                _comboBoxSolicitud_FormaPago.ValueMember = "IdFormaPago";
                _comboBoxSolicitud_FormaPago.DisplayMember = "DescripcionFP";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public void getClasePrestamo()
        {
            try
            {
                _comboBoxSolicitud_ClasePrestamo.DataSource = clasePrestamos.ToList();
                _comboBoxSolicitud_ClasePrestamo.ValueMember = "IdClasePrestamo";
                _comboBoxSolicitud_ClasePrestamo.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getTipoGarantia()
        {
            try
            {
                _comboBoxSolicitud_TipoGarantia.DataSource = tipoGarantias.ToList();
                _comboBoxSolicitud_TipoGarantia.ValueMember = "IdTipoGarantia";
                _comboBoxSolicitud_TipoGarantia.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getRuta()
        {
            try
            {
                _comboBoxSolicitud_Ruta.DataSource = rutas.ToList();
                _comboBoxSolicitud_Ruta.ValueMember = "IdRuta";
                _comboBoxSolicitud_Ruta.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getZona()
        {
            try
            {
                _comboBoxSolicitud_Zona.DataSource = zonas.ToList();
                _comboBoxSolicitud_Zona.ValueMember = "IdZona";
                _comboBoxSolicitud_Zona.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getGestor()
        {
            try
            {
                _comboBoxSolicitud_Gestor.DataSource = gestores.ToList();
                _comboBoxSolicitud_Gestor.ValueMember = "IdGestor";
                _comboBoxSolicitud_Gestor.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
