using Dominio.Librerias;
using Dominio.ModelosVista;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Formularios;

namespace Presentacion.Formularios
{
    public partial class FormPrincipal : Form
    {
        
        private Panel topBorderBtn;
        private IconButton currentBtnTitulo;
        private IconButton currentBtnMenu;
        private Form  formularioHijoActual;

        private TextBoxEvent txtEvent = new TextBoxEvent();
        private TextBoxEvent textBoxEvent = new TextBoxEvent();
        
        private ReportePagoVM reportePago = new ReportePagoVM();
        private GetReporteVM reporte = new GetReporteVM();

        private ClienteVM cliente;
        private SolicitudeVM solicitud;
        private SeguimientoSolicitudVM seguimientoSolicitud;
        private ReportePrestamoVM reportePrestamo;
        private CobroVM cobro;
        private GeneraleVM generar;

        /// <summary>
        /// Método constructor del formulario principal.
        /// </summary>
        public FormPrincipal()
        {
            InitializeComponent();

            //Inciaando Objectos
            objectosCobros();
            objetosIncio();

            //Formulario
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
           
            topBorderBtn = new Panel();
            topBorderBtn.Size = new Size(0, 0);
            panelMenu_Contenedor.Controls.Add(topBorderBtn);

            //Activar Boton Inicio
            ActivateButtonBarraTitulo(iconButtonTitulo_Inicio, RGBColors.color1);

            objetosReportePrestamos();
            reportePrestamo.UpdateEstadoCuotas();

            cobro.GetTipoPago();
            cobro.GetDistribucionPago();
        }

        /// <summary>
        /// La función de este método es permitir 
        /// abrir un formulario dentro de un panel.
        /// </summary>
        /// <param name="formHijo"></param>
        private void AbrirFormularioHijo(Form formHijo)
        {
            if (formularioHijoActual != null) {
                formularioHijoActual.Close();
            }

            formularioHijoActual = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelContenedorForm.Controls.Add(formHijo);
            panelContenedorForm.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
            label_TituloFormularioHijo.Text = formHijo.Text;
        }

        /// <summary>
        /// Este bloque de código está compuesto por un conjunto de métodos 
        /// que pertenecen a la barra de título del formulario principal.
        /// </summary>
        #region //CODIGO BARRA DE TITULO//
        private void iconButtonTitulo_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButtonTitulo_Maximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) {
                WindowState = FormWindowState.Maximized;
                iconButtonTitulo_Maximizar.Visible = false;
                iconButtonTitulo_Restaurar.Visible = true;
            }
        }

        private void iconButtonTitulo_Restaurar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized) {
                WindowState = FormWindowState.Normal;
                iconButtonTitulo_Maximizar.Visible = true;
                iconButtonTitulo_Restaurar.Visible = false;
            }
        }

        private void iconButtonTitulo_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Librerias para arrastrar Formularios principal
        /// </summary>
      
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Structura de Colores de tipo RGB
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(132, 222, 2);
            public static Color color2 = Color.FromArgb(9, 130, 240);
            public static Color color3 = Color.FromArgb(225, 191, 0);
            public static Color color4 = Color.FromArgb(229, 43, 80);
            public static Color color5 = Color.FromArgb(89, 184, 131);
            public static Color color6 = Color.FromArgb(139, 130, 148);
            public static Color color7 = Color.FromArgb(253, 138, 114);

        }

        private void ActivateButtonBarraTitulo(object senderBtn, Color color)
        {
            if (senderBtn != null) {

                DisableButtonBarraTitulo();

                //Icono y Color Button
                currentBtnTitulo= (IconButton)senderBtn;
                currentBtnTitulo.ForeColor = color;
                currentBtnTitulo.IconColor = color;
                
                //AlineBorder Button
                topBorderBtn.BackColor = color;
                //  topBorderBtn.Location = new Point(currentBtnTitulo.Location.X, 0);
                topBorderBtn.Location = new Point(currentBtnTitulo.Location.X, currentBtnTitulo.Location.Y);
                topBorderBtn.Visible = true;
                topBorderBtn.BringToFront();
               
            }
        }

        private void DisableButtonBarraTitulo()
        {
            if (currentBtnTitulo != null) {
                currentBtnTitulo.BackColor = Color.FromArgb(9, 102, 240);
                currentBtnTitulo.ForeColor = Color.White;
                currentBtnTitulo.IconColor = Color.White;
            }
        }

        //BARRA DE MENU
        private void ActivateButtonBarraMenu(object senderBtn, Color color)
        {
            if (senderBtn != null) {

                DisableButtonBarraMenu();

                //Icono and Color Button
                currentBtnMenu = (IconButton)senderBtn;
                currentBtnMenu.ForeColor = color;
                currentBtnMenu.IconColor = color;
            }
        }

        private void DisableButtonBarraMenu()
        {
            if (currentBtnMenu != null) {

                //Button
                currentBtnMenu.BackColor = Color.FromArgb(9, 130, 240);
                currentBtnMenu.ForeColor = Color.White;
                currentBtnMenu.IconColor = Color.White;
            }
        }

        private void iconButtonTitulo_Inicio_Click(object sender, EventArgs e)
        {
            ActivateButtonBarraTitulo(sender, RGBColors.color1);
            tabControl_Contenedor.SelectedTab = tabPage_Inicio;
            panelMenu_Contenedor.Visible = false;
            panelMenu_Procesos.Visible = false;
            panelMenu_Consultas.Visible = false;
        }

        private void iconButtonTitulo_Procesos_Click(object sender, EventArgs e)
        {
            ActivateButtonBarraTitulo(sender, RGBColors.color1);
            panelMenu_Contenedor.Visible = true;
            panelMenu_Procesos.Visible = true;
            panelMenu_Consultas.Visible = false;
            tabControl_Contenedor.SelectedTab = tabPage_Inicio;

        }

        private void iconButtonTitulo_Consultas_Click(object sender, EventArgs e)
        {
            ActivateButtonBarraTitulo(sender, RGBColors.color1);
            panelMenu_Contenedor.Visible = true;
            panelMenu_Consultas.Visible = true;
            panelMenu_Procesos.Visible = false;
            tabControl_Contenedor.SelectedTab = tabPage_Inicio;
            // tabControl_Contenedor.SelectedTab = tabPage_Reportes;
        }
        #endregion

        /// <summary>
        /// Este bloque de código está compuesto por un conjunto
        /// de métodos que pertenecen al CÓDIGO DE INICIO.
        /// </summary>
        #region//CÓDIGO INICIO//
        private void timerFechaHora_Tick(object sender, EventArgs e)
        {
            reportePago.DiasSinPagar();
            reportePrestamo.UpdateEstadoCuotas();
            reportePrestamo.SubtotalMoraAtrasoCalc();
           
            generar.GetCountSolPend();
            generar.GetCountPrestVig();
            generar.GetCountCuotasVen();
            generar.GetCapitalInvertido();
            generar.GetCapitalVencido();
            generar.GetReporteCobrosDiario();

            generar.GraficoPrestamosPorMes();
            generar.GraficoPrestamosVigentesVsVencidos();
            generar.GraficoFormaPago();

            textBoxFecha.Text = DateTime.Now.ToLongDateString();
            textBoxHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void objetosIncio()
        {
            object[] objetos = {

                iconButtonIncio_NoSolicitudes,
                iconButtonIncio_NoPrest,
                iconButtonIncio_NoCuotasV,
                iconButtonIncio_CapitalInvertido,
                chartReportes_PrestamosPorMes,
                chartReportes_VigentesVsVencidas,
                chartReportes_FormaPago,
                iconButtonIncio_CapitalVencido,
                iconButtonIncio_ReporteCobros

            };

            generar = new GeneraleVM(objetos);

        }

        #endregion

        /// <summary>
        /// Este bloque de código está compuesto por un conjunto
        /// de métodos que pertenecen al CÓDIGO DE INICIO.
        /// </summary>
        #region //CÓDIGO CLIENTE//
        private void iconButtonMenu_Clientes_Click(object sender, EventArgs e)
        {

            //Lista De TextBox
            var textBoxCliente = new List<TextBox>();
            //Datos Personales
            textBoxCliente.Add(textBoxClientes_Nombre); //POSICION = 0
            textBoxCliente.Add(textBoxClientes_Apellidos);//POSICION = 1
            textBoxCliente.Add(textBoxClientes_Apodo);//POSICION = 2
            textBoxCliente.Add(textBoxClientes_Email);//POSICION = 3
            textBoxCliente.Add(textBoxClientes_Direccion);//POSICION = 4
            //Datos De Labor
            textBoxCliente.Add(textBoxClientes_Empresa); //POSICION = 5
            textBoxCliente.Add(textBoxClientes_DireccionEmpresa);//POSICION = 6
            textBoxCliente.Add(textBoxClientes_Cargo);//POSICION = 7
            textBoxCliente.Add(textBoxClientes_SueldoBase);//POSICION = 8
            textBoxCliente.Add(textBoxClientes_OtroIngresos);//POSICION = 9
            textBoxCliente.Add(textBoxClientes_DetalleOtroIngresos);//POSICION = 10
            textBoxCliente.Add(textBoxClientes_SueldoNeto);//POSICION = 11
            //Referencias Personales
            textBoxCliente.Add(textBoxClientes_NombreReferencias);//POSICION = 12
            textBoxCliente.Add(textBoxClientes_DireccionReferencias);//POSICION = 13
            //Otros
            textBoxCliente.Add(textBoxClientes_Buscar);//POSICION = 14
            textBoxCliente.Add(textBoxClientes_Gastos);//POSICION = 15

            //Lista De MaskeTexBox
            var maskedTextBoxCliente = new List<MaskedTextBox>();
            //Datos Personales
            maskedTextBoxCliente.Add(textBoxClientes_NoDocumento);//POSICION = 0
            maskedTextBoxCliente.Add(textBoxClientes_Celular);//POSICION = 1
            maskedTextBoxCliente.Add(textBoxClientes_Telefono);//POSICION = 2
            //Datos De Labor
            maskedTextBoxCliente.Add(textBoxClientes_TelefonoEmpresa);//POSICION = 3
            //Referencias Personales
            maskedTextBoxCliente.Add(textBoxClientes_CelularReferencias);//POSICION = 4

            //Lista De Label
            var labelCliente = new List<Label>();
            //Datos Personales
            labelCliente.Add(labelClientes_NoDocumento);//POSICION = 0
            labelCliente.Add(labelClientes_Nombre);//POSICION = 1
            labelCliente.Add(labelClientes_Apellidos);//POSICION = 2
            labelCliente.Add(labelClientes_Apodo);//POSICION = 3
            labelCliente.Add(labelClientes_Sexo);//POSICION = 4
            labelCliente.Add(labelClientes_EstadoCivil);//POSICION = 5
            labelCliente.Add(labelClientes_FechaNacimiento);//POSICION = 6
            labelCliente.Add(labelClientes_Celular);//POSICION = 7
            labelCliente.Add(labelClientes_Telefono);//POSICION = 8
            labelCliente.Add(labelClientes_Email);//POSICION = 9
            labelCliente.Add(labelClientes_Direccion);//POSICION = 10
            labelCliente.Add(labelClientes_Estado);//POSICION = 11
            //Datos De Labor
            labelCliente.Add(labelClientes_Empresa);//POSICION =12
            labelCliente.Add(labelClientes_TelefonoEmpresa);//POSICION = 13
            labelCliente.Add(labelClientes_DireccionEmpresa);//POSICION = 14
            labelCliente.Add(labelClientes_Cargo);//POSICION = 15
            labelCliente.Add(labelClientes_TiempoLaborando);//POSICION = 16
            labelCliente.Add(labelClientes_SueldoBase);//POSICION = 17
            labelCliente.Add(labelClientes_OtrosIngresos);//POSICION = 18
            labelCliente.Add(labelClientes_DetalleOtroIngresos);//POSICION = 19
            labelCliente.Add(labelClientes_SueldoNeto);//POSICION = 20
            //Referencias Personales
            labelCliente.Add(labelClientes_NombreFerencia);//POSICION = 21
            labelCliente.Add(labelClientes_Parentesco);//POSICION = 22
            labelCliente.Add(labelClientes_CelularReferencia);//POSICION = 23
            labelCliente.Add(labelClientes_DireccionReferencia);//POSICION = 24

            //Lista De Objetos
            object[] objectos = {

                //Datos Personales
                comboBoxClientes_Sexo, //POSICION = 0
                comboBoxClientes_EstadoCivil,//POSICION = 1
                dateTimePickerClientes_FechaNacimiento, //POSICION = 2
                checkBoxClientes_Estado, //POSICION = 3
                //Datos De Labor
                comboBoxClientes_Tiempo,//POSICION = 4
               
                //Referencias Personales
                comboBoxClientes_Parentesco,//POSICION = 5
                dataGridViewClientes_Referencias,//POSICION = 6
                //Otros
                dataGridViewClientes,//POSICION = 7
                checkBoxClientes_VerInactivos, //POSICION = 8

                tabControlClientes, //POSICION = 9

                groupBoxCliente_datosPersonales, //POSICION = 10
                groupBoxCliente_datosLaborales, //POSICION = 11
                groupBoxCliente_datosReferencias, //POSICION = 12
            };

            cliente = new ClienteVM(objectos, textBoxCliente, labelCliente, maskedTextBoxCliente);

            ActivateButtonBarraMenu(sender, RGBColors.color1);
            tabControl_Contenedor.SelectedTab = tabPage_Clientes;
            cliente.restablecerClientes();
        }

        private void iconButtonClientes_Nuevo_Click(object sender, EventArgs e)
        {
            cliente.restablecerClientes();
            cliente.generarCodigoCliente();
        }

        private void iconButtonClientes_Editar_Click(object sender, EventArgs e)
        {
            cliente.EditCliente();
        }

        private void iconButtonClientes_Cancelar_Click(object sender, EventArgs e)
        {
            cliente.restablecerClientes();
        }

        private void iconButtonClientes_Guardar_Click(object sender, EventArgs e)
        {
            cliente.guardarClientes();
        }

        private void iconButtonClientes_AgregarReferencia_Click(object sender, EventArgs e)
        {
            cliente.AddReferencias();
        }
        private void iconButtonClientes_EliminarReferencia_Click(object sender, EventArgs e)
        {
            cliente.DeleteReferencias();
        }

        private void textBoxClientes_Buscar_TextChanged(object sender, EventArgs e)
        {
            cliente.getClientes();
        }

        private void textBoxClientes_SueldoBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxEvent.soloNumeroDecimale(textBoxClientes_SueldoBase, e);
        }

        private void textBoxClientes_OtroIngresos_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxEvent.soloNumeroDecimale(textBoxClientes_OtroIngresos, e);
        }

        private void textBoxClientes_SueldoNeto_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxEvent.soloNumeroDecimale(textBoxClientes_SueldoNeto, e);
        }
        private void textBoxClientes_SueldoBase_TextChanged(object sender, EventArgs e)
        {
            cliente.calcularIngresos();
        }
        private void textBoxClientes_OtroIngresos_TextChanged(object sender, EventArgs e)
        {
            cliente.calcularIngresos();
        }
        private void textBoxClientes_Gastos_TextChanged(object sender, EventArgs e)
        {
            cliente.calcularIngresos();
        }
        private void dataGridViewClientes_Referencias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cliente.EditReferencias();
        }

        private void dataGridViewClientes_Referencias_KeyUp(object sender, KeyEventArgs e)
        {
            cliente.EditReferencias();
        }
        private void iconButtonClientes_UpdateRef_Click(object sender, EventArgs e)
        {
            cliente.updateReferencias();
        }

        private void dataGridViewClientes_Referencias_DoubleClick(object sender, EventArgs e)
        {
            cliente.RemoveReferencias();
        }
        #endregion

        /// <summary>
        /// Este bloque de código está compuesto por un conjunto
        /// de métodos que pertenecen al CÓDIGO DE SOLICITUD.
        /// </summary>
        #region //CÓDIGO DE SOLICITUD//
        private void iconButtonMenu_CrearSolicitud_Click(object sender, EventArgs e)
        {
            object[] objectos = {

                comboBoxSolicitud_TipoPrestamo, //POSICION = 0
                comboBoxSolicitud_FormaPago, //POSICION = 1
                comboBoxSolicitud_ClasePrestamo, //POSICION = 2
                comboBoxSolicitud_TipoGarantia, //POSICION = 3
                comboBoxSolicitud_Ruta, //POSICION = 4
                comboBoxSolicitud_Zona, //POSICION = 5
                comboBoxSolicitud_Gestor, //POSICION = 6
                mtbSolicitud_NoDocumentoDeudor, //POSICION = 7
                txtSolicitud_NombreDeudor, //POSICION = 8
                txtSolicitud_ApellidosDeudor, //POSICION = 9
                mtbSolicitud_NoDocumentoCoDeudor, //POSICION = 10
                txtSolicitud_NombreCoDeudor, //POSICION = 11
                txtSolicitud_ApellidosCoDeudor, //POSICION = 12
                dtpSolicitud_FechaPago, //POSICION = 13
                txtSolicitud_MontoSolicitado, //POSICION = 14
                txtSolicitud_GastosLegales, //POSICION = 15
                txtSolicitud_MontoTotal, //POSICION = 16
                txtSolicitud_CantidadCuotas, //POSICION = 17
                txtSolicitud_TasaInteres, //POSICION = 18
                txtSolicitud_TasaComision, //POSICION = 19
                txtSolicitud_TasaSeguro, //POSICION = 20
                txtSolicitud_MontoCuotas, //POSICION = 21
                dataGridViewSolicitud,//POSICION = 22
                txtSolicitud_DescripcionInversion, //POSICION = 23
                txtCodigoSolicitud, //POSICION = 24
                lblSolicitud_NoDocumentoDeudor, //POSICION = 25
                lblSolicitud_NoDocumentoCoDeudor, //POSICION = 26 

                lblSolicitud_DescipcionInversion, //POSICION = 27
                lblSolicitud_MontoSolicitado, //POSICION = 28 
                lblSolicitud_CatidadCuotas, //POSICION = 29 
                lblSolicitud_TasaInteresAnual, //POSICION = 30
                panelSolicitud_Deudores, //POSICION = 31

               mtbSolicitud_CodigoObjeto, //POSICION = 32
               txtSolicitud_NombreObjecto,//POSICION = 33

            };

            solicitud = new SolicitudeVM(objectos);

            solicitud.RestablecerSolicitud();

            ActivateButtonBarraMenu(sender, RGBColors.color1);
            tabControl_Contenedor.SelectedTab = tabPage_Solicitud;

        }

        private void iconButtonSolicitud_BuscarDeudor_Click(object sender, EventArgs e)
        {
            solicitud.GetDeudor();
        }

        private void iconButtonSolicitud_BuscarCoDeudor_Click(object sender, EventArgs e)
        {
            solicitud.GetCoDeudor();
        }

        private void iconButtonSolicitud_Calcular_Click(object sender, EventArgs e)
        {
            solicitud.calcularPrestamo();
        }

        private void txtSolicitud_MontoSolicitado_TextChanged(object sender, EventArgs e)
        {
            solicitud.TotalPrestamo();
        }

        private void txtSolicitud_GastosLegales_TextChanged(object sender, EventArgs e)
        {
            solicitud.TotalPrestamo();
        }
        private void txtSolicitud_MontoSolicitado_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxEvent.soloNumeroEntero(e);
        }

        private void txtSolicitud_GastosLegales_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxEvent.soloNumeroEntero(e);
        }

        private void txtSolicitud_CantidadCuotas_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxEvent.soloNumeroEntero(e);
        }
        private void txtSolicitud_TasaInteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxEvent.soloNumeroDecimale(txtSolicitud_TasaInteres, e);
        }

        private void txtSolicitud_TasaComision_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxEvent.soloNumeroDecimale(txtSolicitud_TasaComision, e);
        }

        private void txtSolicitud_TasaSeguro_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxEvent.soloNumeroDecimale(txtSolicitud_TasaSeguro, e);
        }

        private void iconButtonSolicitud_Nuevo_Click(object sender, EventArgs e)
        {
            solicitud.RestablecerSolicitud();
            solicitud.generarCodigoSolicitud();
            iconButtonSolicitud_BuscarCodigoSolicitud.Visible = false;
            txtCodigoSolicitud.Enabled = false;
        }

        private void iconButtonSolicitud_Editar_Click(object sender, EventArgs e)
        {
            iconButtonSolicitud_BuscarCodigoSolicitud.Visible = true;
            txtCodigoSolicitud.Enabled = true;
        }

        private void iconButtonSolicitud_Cancelar_Click(object sender, EventArgs e)
        {
            solicitud.RestablecerSolicitud();
            iconButtonSolicitud_BuscarCodigoSolicitud.Visible = false;
            txtCodigoSolicitud.Enabled = false;
        }
               
        private void iconButtonSolicitud_Guardar_Click(object sender, EventArgs e)
        {
            try {

                if (txtCodigoSolicitud.Text != "") {

                    int codigoSol = Convert.ToInt32(txtCodigoSolicitud.Text);
                    bool save = solicitud.SaveSolicitud();

                    if (save) {
                        reporte.Reporte(codigoSol);
                        ObtenerReportes(codigoSol);
                    }

                    iconButtonSolicitud_BuscarCodigoSolicitud.Visible = false;
                    txtCodigoSolicitud.Enabled = false;
                }

            }
            catch (Exception ex) {

                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ObtenerReportes(int codigoSol)
        {
            switch (reporte.Valuereturn) {

                case "CON CODEUDOR":
                    ReporteSolicitudConCodeudor objFormCO = new ReporteSolicitudConCodeudor();
                    objFormCO.csCO = codigoSol;
                    objFormCO.ShowDialog();
                    break;

                case "CON GARANTIA":
                    ReporteSolicitudConGarantiaEco objFormGE = new ReporteSolicitudConGarantiaEco();
                    objFormGE.csGE = codigoSol;
                    objFormGE.ShowDialog();
                    break;

                case "CODEUDOR Y GARANTIA":
                    ReporteSolicitudConCodeudorGarantiaE objFormCOGE = new ReporteSolicitudConCodeudorGarantiaE();
                    objFormCOGE.csCOGE = codigoSol;
                    objFormCOGE.ShowDialog();
                    break;

                case "SOLO FIRMA":
                    ReporteSolicitudSoloFirma objFormSF = new ReporteSolicitudSoloFirma();
                    objFormSF.csSF = codigoSol;
                    objFormSF.ShowDialog();
                    break;

            }

        }

        private void iconButtonSolicitud_BuscarCodigo_Click(object sender, EventArgs e)
        {
            solicitud.GetGarantia();
        }
        private void iconButtonSolicitud_Resumen_Click(object sender, EventArgs e)
        {
            solicitud.VerResumen();
        }
        private void mtbSolicitud_CodigoObjeto_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxEvent.soloNumeroEntero(e);
        }

        private void iconButtonSolicitud_BuscarCodigoSolicitud_Click(object sender, EventArgs e)
        {
            solicitud.GetSolicitud();
            panelSolicitud_Deudores.Enabled = true;
            txtCodigoSolicitud.Enabled = false;
        }

        private void txtCodigoSolicitud_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxEvent.soloNumeroEntero(e);
        }

        private void iconButtonSolicitud_Imprimir_Click(object sender, EventArgs e)
        {
            try {

                if (txtCodigoSolicitud.Text != "") {

                    int codigoSol = Convert.ToInt32(txtCodigoSolicitud.Text);
                    reporte.Reporte(codigoSol);
                    ObtenerReportes(codigoSol);
                    solicitud.RestablecerSolicitud();
                }
                else {

                    MessageBox.Show("No existen datos para iprimir. \n\nNota: Primero debe cargar los datos de la solicitud que desea ipmprimir.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex) {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        #endregion

        /// <summary>
        /// Este bloque de código está compuesto por un conjunto
        /// de métodos que pertenecen al CÓDIGO DE COBRO.
        /// </summary>
        #region //CÓDIGO COBRO//
        private void iconButtonMenu_RegistarCobro_Click(object sender, EventArgs e)
        {
            objectosCobros();
            ActivateButtonBarraMenu(sender, RGBColors.color1);
            tabControl_Contenedor.SelectedTab = tabPage_Cobros;
        }

        private void objectosCobros()
        {
            object[] objectos = {

               txtCobrosCodigoPrestamo,
                txtCobrosCodigoCliente,
                txtCobrosNombreCliente,
                txtCobrosTotalDeAtraso,
                txtCobrosMontoAPagar,
                txtCobrosConcepto,
                txtCobrosDevuelta,
                comboBoxCobrosFormaPago,
                comboBoxCobrosDistribucionPago,
                dtpCobrosDesde,
                dtpCobrosHasta,
                dataGridViewCobrosReportePrestamo,
                dataGridViewCobros_FiltroCobros,
                txtCobrosPagoCon
            };

            cobro = new CobroVM(objectos);
        }

        private void iconButtonCobros_BuscarCliente_Click(object sender, EventArgs e)
        {
            ListaPrestamos objForm = new ListaPrestamos();
            objForm.ShowDialog();

            if (objForm.DialogResult == DialogResult.OK) {

                txtCobrosCodigoCliente.Text = objForm.dataGridViewPrest.Rows[objForm.dataGridViewPrest.CurrentRow.Index].Cells[0].Value.ToString().Trim();
                txtCobrosNombreCliente.Text = objForm.dataGridViewPrest.Rows[objForm.dataGridViewPrest.CurrentRow.Index].Cells[1].Value.ToString().Trim();
                txtCobrosCodigoPrestamo.Text = objForm.dataGridViewPrest.Rows[objForm.dataGridViewPrest.CurrentRow.Index].Cells[4].Value.ToString().Trim();

                cobro.GetReportePrestamo();
            }
        }


        private void iconButtonCobros_VerSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCobrosCodigoPrestamo.Text != "")
                {

                    int codigoSol = Convert.ToInt32(txtCobrosCodigoPrestamo.Text);
                    reporte.Reporte(codigoSol);
                    ObtenerReportes(codigoSol);
                }
                else
                {
                    MessageBox.Show("No existen datos para ver. \n\nNota: Primero debe cargar los datos de la préstamos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconButtonMenu_ListaCobros_Click(object sender, EventArgs e)
        {
            ActivateButtonBarraMenu(sender, RGBColors.color1);
        }

        private void iconButtonCobros_AplicarValores_Click(object sender, EventArgs e)
        {
            cobro.AplicarCobor();
            generar.GetCountCuotasVen();
        }

        private void txtCobrosPagoCon_TextChanged(object sender, EventArgs e)
        {
            cobro.ValidarTxtVacio(txtCobrosPagoCon);
            cobro.Devolucion();
        }
        private void txtCobrosMontoAPagar_TextChanged(object sender, EventArgs e)
        {
           cobro.ValidarTxtVacio(txtCobrosMontoAPagar);
           cobro.Devolucion();
        }

        private void txtCobrosTotalDeAtraso_TextChanged(object sender, EventArgs e)
        {
            cobro.ValidarTxtVacio(txtCobrosTotalDeAtraso);
        }

        private void txtCobrosDevuelta_TextChanged(object sender, EventArgs e)
        {
            cobro.ValidarTxtVacio(txtCobrosDevuelta);
        }

        private void txtCobrosMontoAPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEvent.soloNumeroDecimale(txtCobrosMontoAPagar, e);
        }

        private void txtCobrosTotalDeAtraso_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEvent.soloNumeroDecimale(txtCobrosTotalDeAtraso, e);
        }

        private void txtCobrosPagoCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEvent.soloNumeroDecimale(txtCobrosPagoCon, e);
        }

        private void txtCobrosDevuelta_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEvent.soloNumeroDecimale(txtCobrosDevuelta, e);
        }

        private void iconButtonCobrosCancelar_Click(object sender, EventArgs e)
        {
            cobro.RestablecerCobros();
        }

        #endregion

        /// <summary>
        /// Este bloque de código está compuesto por un conjunto
        /// de métodos que pertenecen al CÓDIGO DE SEGUIMIENTO DE SOLICITUD.
        /// </summary>
        #region //CÓDIGO DE SEGUIMIENTO DE SOLICITUD//     
        private void iconButtonMenu_ListaSolicitud_Click(object sender, EventArgs e)
        {
            object[] objectos = {

                dataGridViewListaSolicitudes, //POSICION = 0
                cbbLS_EstadoSolicitud, //POSICION = 1
                txtLS_CodigoSilicitud, //POSICION = 2
                txtLS_NombreCliente, //POSICION = 3
                txtLS_Mensaje, //POSICION = 4 
                dataGridViewLS_Notas, //POSICION = 5
                rbLS_Todas, //POSICION = 6
                rbLS_PA, //POSICION = 7
                rbLS_PC, //POSICION = 8
                rbLS_A, //POSICION = 9
                rbLS_R, //POSICION = 10

            };

            seguimientoSolicitud = new SeguimientoSolicitudVM(objectos);

            ActivateButtonBarraMenu(sender, RGBColors.color1);
            tabControl_Contenedor.SelectedTab = tabPage_SeguimientoSolictud;
            seguimientoSolicitud.RestablecerListaSolicitudes();
        }

        private void dataGridViewListaSolicitudes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seguimientoSolicitud.GetDataGridViewLS();
        }

        private void dataGridViewListaSolicitudes_KeyUp(object sender, KeyEventArgs e)
        {
            seguimientoSolicitud.GetDataGridViewLS();
        }
        private void iconButtonLS_Guardar_Click(object sender, EventArgs e)
        {
            seguimientoSolicitud.SaveDataSolicitud();
        }
        private void iconButtonLS_Cancelar_Click(object sender, EventArgs e)
        {
            seguimientoSolicitud.RestablecerListaSolicitudes();
        }
        private void dataGridViewLS_Notas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seguimientoSolicitud.GetMsjNotas();
        }

        private void dataGridViewLS_Notas_KeyUp(object sender, KeyEventArgs e)
        {
            seguimientoSolicitud.GetMsjNotas();
        }

        private void rbLS_Todas_CheckedChanged(object sender, EventArgs e)
        {
            seguimientoSolicitud.GetSolicitudes();
        }

        private void rbLS_PA_CheckedChanged(object sender, EventArgs e)
        {
            seguimientoSolicitud.GetSolicitudes();
        }

        private void rbLS_PC_CheckedChanged(object sender, EventArgs e)
        {
            seguimientoSolicitud.GetSolicitudes();
        }

        private void rbLS_A_CheckedChanged(object sender, EventArgs e)
        {
            seguimientoSolicitud.GetSolicitudes();
        }

        private void rbLS_R_CheckedChanged(object sender, EventArgs e)
        {
            seguimientoSolicitud.GetSolicitudes();
        }
        private void dataGridViewListaSolicitudes_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            seguimientoSolicitud.GetDataGridViewLS();
        }

        private void dataGridViewListaSolicitudes_KeyUp_1(object sender, KeyEventArgs e)
        {
            seguimientoSolicitud.GetDataGridViewLS();
        }
        #endregion

        /// <summary>
        /// Este bloque de código está compuesto por un conjunto
        /// de métodos que pertenecen al CÓDIGO DE REPORTE.
        /// </summary>
        #region //CÓDIGO REPORTE//
        private void objetosReportePrestamos()
        {
            object[] objetos = {

                //dataGridViewPrestamos, //POSICION = 0
            };

            reportePrestamo = new ReportePrestamoVM(objetos);
        }

        private void iconButtonMenu_ListaPrestamos_Click(object sender, EventArgs e)
        {
            ActivateButtonBarraMenu(sender, RGBColors.color1);
            tabControl_Contenedor.SelectedTab = tabPage_Reportes;
           
            if (MessageBox.Show("Realmente desea generar el Reporte", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                try{
                    AbrirFormularioHijo(new ReporteCuentasVencidas());
                }
                catch (Exception ex){
                    MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

        }

        private void iconButtonMenu_ListPrestamos_Click(object sender, EventArgs e)
        {
            ActivateButtonBarraMenu(sender, RGBColors.color1);
            tabControl_Contenedor.SelectedTab = tabPage_Reportes;

            if (MessageBox.Show("Realmente desea generar el Reporte", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                try {
                    AbrirFormularioHijo(new ReporteListadoDePrestamos());
                }
                catch (Exception ex) {
                    MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void iconButtonReporte_Cerrar_Click(object sender, EventArgs e)
        {
            try
            {
                formularioHijoActual.Close();
                DisableButtonBarraMenu();
                label_TituloFormularioHijo.Text = "Reportes";
            }
            catch (Exception)
            {
                MessageBox.Show($"No exite reporte para cerrar.\n\n{null}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

       
        }
        #endregion

        /// <summary>
        /// Este bloque de código está compuesto por un conjunto
        /// de métodos que pertenecen al CÓDIGO GARANTÍA ECONÓMICA.
        /// /// </summary>
        #region //CÓDIGO GARANTÍA ECONÓMICA //
        private void iconButtonMenu_GarantiaEconomica_Click(object sender, EventArgs e)
        {
            ActivateButtonBarraMenu(sender, RGBColors.color1);
            tabControl_Contenedor.SelectedTab = tabPage_GarantiaEconomica;
          
        }
        #endregion

        /// <summary>
        /// Este bloque de código está compuesto por un conjunto
        /// de métodos que pertenecen al CÓDIGO CONFIGURACIÓN.
        /// </summary>
        #region //CÓDIGO CONFIGURACIÓN//
        private void iconButtonMenu_Configuracion_Click(object sender, EventArgs e)
        {
            ActivateButtonBarraTitulo(sender, RGBColors.color1);
            panelMenu_Contenedor.Visible = false;
            panelMenu_Procesos.Visible = false;
            panelMenu_Consultas.Visible = false;
            tabControl_Contenedor.SelectedTab = tabPage_Configuracion;
        }

        #endregion
    }
}
