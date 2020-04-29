using AccesoDatos.Conexion;
using AccesoDatos.Models;
using Dominio.Librerias;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dominio.ModelosVista
{
    public class ClienteVM : Conexion
    {
        private int idUsario = 0;
        private string fechaAc;
        private string horaAc;
       
        private TextBoxEvent evento;
        private string _accion = "insert";
        private int gCodigoCliente = 0;
        private int codigoCliente = 0;
        private List<TextBox> _textBoxCliente;
        private List<MaskedTextBox> _maskedTextBoxCliente;
        private List<Label> _labelCliente;

        //Objetos
        private ComboBox _comboBoxClientes_Sexo;
        private ComboBox _comboBoxClientes_EstadoCivil;
        private DateTimePicker _dateTimePickerClientes_FechaNacimiento;
        private CheckBox _checkBoxClientes_Estado;
        private ComboBox _comboBoxClientes_Tiempo;
        private ComboBox _comboBoxClientes_Parentesco;
        private DataGridView _dataGridViewClientes_Referencias;
        private DataGridView _dataGridViewClientes;
        private CheckBox _checkBoxClientes_VerInactivos;
        private GroupBox _groupBoxCliente_datosPersonales;
        private GroupBox _groupBoxCliente_datosLaborales;
        private GroupBox _groupBoxCliente_datosReferencias;
        private TabControl _tabControlClientes;
        private Random rnd = new Random();
        private decimal sueldoNeto = 0;

        public ClienteVM(object[] objectos, List<TextBox> textBoxCliente, List<Label> labelCliente, List<MaskedTextBox> maskedTextBoxCliente)
        {
            _textBoxCliente = textBoxCliente;
            _labelCliente = labelCliente;
            _maskedTextBoxCliente = maskedTextBoxCliente;

            _comboBoxClientes_Sexo = (ComboBox)objectos[0];
            _comboBoxClientes_EstadoCivil = (ComboBox)objectos[1];
            _dateTimePickerClientes_FechaNacimiento = (DateTimePicker)objectos[2];
            _checkBoxClientes_Estado = (CheckBox)objectos[3];
            _comboBoxClientes_Tiempo = (ComboBox)objectos[4];
            _comboBoxClientes_Parentesco = (ComboBox)objectos[5];
            _dataGridViewClientes_Referencias = (DataGridView)objectos[6];
            _dataGridViewClientes = (DataGridView)objectos[7];
            _checkBoxClientes_VerInactivos = (CheckBox)objectos[8];
            _tabControlClientes = (TabControl)objectos[9];
            _groupBoxCliente_datosPersonales = (GroupBox)objectos[10];
            _groupBoxCliente_datosLaborales = (GroupBox)objectos[11];
            _groupBoxCliente_datosReferencias = (GroupBox)objectos[12];
            evento = new TextBoxEvent();
        }


        //CODIGO DE CLIENTES//
        public void generarCodigoCliente()
        {
            _groupBoxCliente_datosPersonales.Enabled = true;
            _groupBoxCliente_datosLaborales.Enabled = true;
            _groupBoxCliente_datosReferencias.Enabled = true;
            _maskedTextBoxCliente[0].Focus();

            gCodigoCliente = rnd.Next(100000, 999999);

            var queryCodigoCliente = clientes.Where(c => c.CodigoCliente.Equals(gCodigoCliente)).ToList();

            if (queryCodigoCliente.Count > 0) {
                gCodigoCliente++;
            }
        }
        public void guardarClientes()
        {
            _groupBoxCliente_datosPersonales.Enabled = true;
            _groupBoxCliente_datosLaborales.Enabled = true;
            _groupBoxCliente_datosReferencias.Enabled = true;

            if (_maskedTextBoxCliente[0].Text.Equals("") || _maskedTextBoxCliente[0].Text.Equals("   -       -")) {
                
                _tabControlClientes.SelectedIndex = 0;
                _labelCliente[0].Text = "El campo Número De Documento es obligatorio.";
                _labelCliente[0].ForeColor = Color.Red;
                _maskedTextBoxCliente[0].Focus();
            }
            else {
                    if (validarNoDocumento(_maskedTextBoxCliente[0], _labelCliente[0]) == true)  {

                        if (_textBoxCliente[0].Text.Equals("")) {
                            _tabControlClientes.SelectedIndex = 0;
                            _labelCliente[1].Text = "El campo Nombre es obligatorio.";
                            _labelCliente[1].ForeColor = Color.Red;
                            _textBoxCliente[0].Focus();
                        }
                        else {
                            _labelCliente[1].Text = "Nombre";
                            _labelCliente[1].ForeColor = Color.LightSlateGray;

                            if (_textBoxCliente[1].Text.Equals("")) {
                                _tabControlClientes.SelectedIndex = 0;
                                _labelCliente[2].Text = "El campo Apellidos es obligatorio.";
                                _labelCliente[2].ForeColor = Color.Red;
                                _textBoxCliente[1].Focus();
                            }
                            else {
                                _labelCliente[2].Text = "Apellido";
                                _labelCliente[2].ForeColor = Color.LightSlateGray;

                                if (_comboBoxClientes_Sexo.Text.Equals("") || _comboBoxClientes_Sexo.Text.Equals("ELEGIR")) {
                                    _tabControlClientes.SelectedIndex = 0;
                                    _labelCliente[4].Text = "El campo Sexo es obligatorio.";
                                    _labelCliente[4].ForeColor = Color.Red;
                                }
                                else {
                                    _labelCliente[4].Text = "Sexo";
                                    _labelCliente[4].ForeColor = Color.LightSlateGray;

                                    if (_comboBoxClientes_EstadoCivil.Text.Equals("") || _comboBoxClientes_EstadoCivil.Text.Equals("ELEGIR")) {
                                        _tabControlClientes.SelectedIndex = 0;
                                        _labelCliente[5].Text = "El campo Estado Civil es obligatorio.";
                                        _labelCliente[5].ForeColor = Color.Red;
                                    }
                                    else {
                                        _labelCliente[5].Text = "Estado Civil";
                                        _labelCliente[5].ForeColor = Color.LightSlateGray;

                                        if (_maskedTextBoxCliente[1].Text.Equals("") || _maskedTextBoxCliente[1].Text.Equals("(   )   -")) {                                       
                                            _tabControlClientes.SelectedIndex = 0;
                                            _labelCliente[7].Text = "El campo Celular es obligatorio.";
                                            _labelCliente[7].ForeColor = Color.Red;
                                            _maskedTextBoxCliente[1].Focus();
                                        }
                                        else {
                                            _labelCliente[7].Text = "Celular";
                                            _labelCliente[7].ForeColor = Color.LightSlateGray;

                                            if (_textBoxCliente[4].Text.Equals("")) {
                                                _tabControlClientes.SelectedIndex = 0;
                                                _labelCliente[10].Text = "El campo Dirección es obligatorio.";
                                                _labelCliente[10].ForeColor = Color.Red;
                                                _textBoxCliente[4].Focus();
                                            }
                                            else {
                                                _labelCliente[10].Text = "Dirección";
                                                _labelCliente[10].ForeColor = Color.LightSlateGray;

                                                if (_textBoxCliente[5].Text.Equals("")) {
                                                    _tabControlClientes.SelectedIndex = 1;
                                                    _labelCliente[12].Text = "El campo Empresa es obligatorio.";
                                                    _labelCliente[12].ForeColor = Color.Red;
                                                    _textBoxCliente[5].Focus();
                                                }
                                                else {
                                                    _labelCliente[12].Text = "Empresa";
                                                    _labelCliente[12].ForeColor = Color.LightSlateGray;

                                                    if (_textBoxCliente[7].Text.Equals("")) {
                                                        _tabControlClientes.SelectedIndex = 1;
                                                        _labelCliente[15].Text = "El campo Cargo es obligatorio.";
                                                        _labelCliente[15].ForeColor = Color.Red;
                                                        _textBoxCliente[7].Focus();
                                                    }
                                                    else {
                                                        _labelCliente[15].Text = "Cargo";
                                                        _labelCliente[15].ForeColor = Color.LightSlateGray;

                                                        if (_comboBoxClientes_Tiempo.Text.Equals("") ||  _comboBoxClientes_Tiempo.Text.Equals("ELEGIR") ) {
                                                            _tabControlClientes.SelectedIndex = 1;
                                                            _labelCliente[16].Text = "El campo Tiempo Laborando es obligatorio.";
                                                            _labelCliente[16].ForeColor = Color.Red;

                                                        }
                                                        else {
                                                            _labelCliente[16].Text = "Tiempo Laborando";
                                                            _labelCliente[16].ForeColor = Color.LightSlateGray;

                                                            if (_textBoxCliente[8].Text.Equals("")) {
                                                                _tabControlClientes.SelectedIndex = 1;
                                                                _labelCliente[17].Text = "El campo Sueldo Base es obligatorio.";
                                                                _labelCliente[17].ForeColor = Color.Red;
                                                                _textBoxCliente[8].Focus();

                                                            }
                                                            else {
                                                                _labelCliente[17].Text = "Sueldo Base";
                                                                _labelCliente[17].ForeColor = Color.LightSlateGray;

                                                                switch (_accion)
                                                                {
                                                                    case "insert":
                                                                        var queryNoDocumento = clientes.Where(c => c.NoDocumento.Equals(_maskedTextBoxCliente[0].Text)).ToList();
                                                                        if (queryNoDocumento.Count.Equals(0)) {
                                                                            if (MessageBox.Show("Realmente desea guardar los datos", "GUARDAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                                                                                SaveCliente();
                                                                                //SaveReferencias();
                                                                            }
                                                                        }
                                                                        else {
                                                                            _tabControlClientes.SelectedIndex = 0;
                                                                            _labelCliente[0].Text = "El Número De Documento ya existe.";
                                                                            _labelCliente[0].ForeColor = Color.Red;
                                                                            _labelCliente[0].Focus();
                                                                        }
                                                                        break;

                                                                    case "update":

                                                                        if (MessageBox.Show("Realmente desea actualizar los datos", "ACTUALIZAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                                                                            SaveCliente();
                                                                        }
                                                                        break;
                                                                }

                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

            }
        }
        private void SaveCliente()
        {
            fechaAc = System.DateTime.Now.ToString("dd/MM/yyy");
            horaAc = System.DateTime.Now.ToString("HH:mm:ss");

           // BeginTransactionAsync();

            try {

                calcularIngresos();

                switch (_accion) {
                    case "insert":
                        clientes.Value(c => c.NoDocumento, _maskedTextBoxCliente[0].Text)
                                    .Value(c => c.Nombre, _textBoxCliente[0].Text)
                                    .Value(c => c.Apellido, _textBoxCliente[1].Text)
                                    .Value(c => c.Apodo, _textBoxCliente[2].Text)
                                    .Value(c => c.Sexo, _comboBoxClientes_Sexo.Text)
                                    .Value(c => c.EstadoCivil, _comboBoxClientes_EstadoCivil.Text)
                                    .Value(c => c.FechaNacimiento, _dateTimePickerClientes_FechaNacimiento.Value)
                                    .Value(c => c.Celular, _maskedTextBoxCliente[1].Text)
                                    .Value(c => c.Telefono, _maskedTextBoxCliente[2].Text)
                                    .Value(c => c.Email, _textBoxCliente[3].Text)
                                    .Value(c => c.Direccion, _textBoxCliente[4].Text)
                                    .Value(c => c.EstadoCliente, _checkBoxClientes_Estado.Checked)
                                    .Value(c => c.CodigoCliente, gCodigoCliente)
                                    .Value(c => c.IdUsuario, idUsario)
                                    .Value(c => c.Fecha, Convert.ToDateTime(fechaAc))
                                    .Value(c => c.Hora, horaAc + " Inserción")
                                    .Value(c => c.IdSucursal, 1) // por ahora, luego debo cambiar por la suculsar que se este registrando
                                    .Insert();

                            datosLaborables.Value(d => d.Empresa, _textBoxCliente[5].Text)
                                           .Value(d => d.TelefonoEmp, _maskedTextBoxCliente[3].Text)
                                           .Value(d => d.DireccionEmp, _textBoxCliente[6].Text)
                                           .Value(d => d.Cargo, _textBoxCliente[7].Text)
                                           .Value(d => d.TiempoLaborando, _comboBoxClientes_Tiempo.Text)
                                           .Value(d => d.Sueldo, Convert.ToDecimal(_textBoxCliente[8].Text))
                                           .Value(d => d.OtroIngresos, Convert.ToDecimal(_textBoxCliente[9].Text))
                                           .Value(d => d.DetalleOtroIngresos, _textBoxCliente[10].Text)
                                           .Value(d => d.UtilidadNeta, sueldoNeto)
                                           .Value(d => d.CodigoCliente, gCodigoCliente)
                                           .Value(d => d.Gastos, Convert.ToDecimal(_textBoxCliente[15].Text))
                                           .Insert();

                       SaveReferencias();

                        _groupBoxCliente_datosPersonales.Enabled = false;
                        _groupBoxCliente_datosLaborales.Enabled = false;
                        _groupBoxCliente_datosReferencias.Enabled = false;

                        MessageBox.Show("Guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "update":
                            clientes.Where(c => c.CodigoCliente.Equals(codigoCliente))
                                     .Set(c => c.NoDocumento, _maskedTextBoxCliente[0].Text)
                                     .Set(c => c.Nombre, _textBoxCliente[0].Text)
                                     .Set(c => c.Apellido, _textBoxCliente[1].Text)
                                     .Set(c => c.Apodo, _textBoxCliente[2].Text)
                                     .Set(c => c.Sexo, _comboBoxClientes_Sexo.Text)
                                     .Set(c => c.EstadoCivil, _comboBoxClientes_EstadoCivil.Text)
                                     .Set(c => c.FechaNacimiento, _dateTimePickerClientes_FechaNacimiento.Value)
                                     .Set(c => c.Celular, _maskedTextBoxCliente[1].Text)
                                     .Set(c => c.Telefono, _maskedTextBoxCliente[2].Text)
                                     .Set(c => c.Email, _textBoxCliente[3].Text)
                                     .Set(c => c.Direccion, _textBoxCliente[4].Text)
                                     .Set(c => c.EstadoCliente, _checkBoxClientes_Estado.Checked)
                                     .Set(c => c.IdUsuario, idUsario)
                                     .Set(c => c.Fecha, Convert.ToDateTime(fechaAc))
                                     .Set(c => c.Hora, horaAc + " Actualización")
                                     .Set(c => c.IdSucursal, 1) // por ahora, luego debo cambiar por la suculsar que se este registrando
                                     .Update();
                           
                            datosLaborables.Where(d => d.CodigoCliente.Equals(codigoCliente))
                                           .Set(d => d.Empresa, _textBoxCliente[5].Text)
                                           .Set(d => d.TelefonoEmp, _maskedTextBoxCliente[3].Text)
                                           .Set(d => d.DireccionEmp, _textBoxCliente[6].Text)
                                           .Set(d => d.Cargo, _textBoxCliente[7].Text)
                                           .Set(d => d.TiempoLaborando, _comboBoxClientes_Tiempo.Text)
                                           .Set(d => d.Sueldo, Convert.ToDecimal(_textBoxCliente[8].Text))
                                           .Set(d => d.OtroIngresos, Convert.ToDecimal(_textBoxCliente[9].Text))
                                           .Set(d => d.DetalleOtroIngresos, _textBoxCliente[10].Text)
                                           .Set(d => d.UtilidadNeta, sueldoNeto)
                                           .Set(d => d.Gastos, Convert.ToDecimal(_textBoxCliente[15].Text))
                                           .Update();

                        _groupBoxCliente_datosPersonales.Enabled = false;
                        _groupBoxCliente_datosLaborales.Enabled = false;
                        _groupBoxCliente_datosReferencias.Enabled = false;
                        MessageBox.Show("Guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                }

              //  CommitTransaction();
                restablecerClientes();

            }
            catch (Exception ex) {
              //  RollbackTransaction();
                MessageBox.Show( $"Error inesperado \n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool validarNoDocumento(MaskedTextBox maskedTextBox, Label label)
        {
            bool valor = false;

            if (maskedTextBox.Text != ("") && maskedTextBox.Text != ("   -       -")) {
                string maskara = maskedTextBox.Mask;
                string sinMaskara = maskedTextBox.Mask = "";
                int len = maskedTextBox.TextLength;

                if (len < 11) {
                    label.Text = "El Número De Documento esta incompleto.";
                    label.ForeColor = Color.Red;
                    maskedTextBox.Mask = maskara;
                    maskedTextBox.Focus();
                    valor = false;
                }
                else {
                    label.Text = "Número De Documento";
                    label.ForeColor = Color.LightSlateGray;
                    maskedTextBox.Mask = maskara;
                    valor = true;
                }
            }
            return valor;
        }

        public void calcularIngresos()
        {
            if (_textBoxCliente[8].Text == "") {
                _textBoxCliente[8].Text = "0.00";
            }
            else if (_textBoxCliente[9].Text == "") {
                _textBoxCliente[9].Text = "0.00";
            }
            else if (_textBoxCliente[11].Text == "") {
                _textBoxCliente[11].Text = "0.00";
            }
            else if (_textBoxCliente[15].Text == "") {
                _textBoxCliente[15].Text = "0.00";
            }

            decimal sueldoBase = Convert.ToDecimal(_textBoxCliente[8].Text);
            decimal otroIngresos = Convert.ToDecimal(_textBoxCliente[9].Text);
            decimal gastos = Convert.ToDecimal(_textBoxCliente[15].Text);

             sueldoNeto = sueldoBase + otroIngresos - gastos;
            _textBoxCliente[11].Text = sueldoNeto.ToString();
        }

        public void getClientes()
        {
            if (_textBoxCliente[14].Equals("")) {
                var queryCliente = from c in clientes
                                   join d in datosLaborables on c.CodigoCliente equals d.CodigoCliente
                                   select new
                                   {
                                       c.NoDocumento,
                                       c.Nombre,
                                       c.Apellido,
                                       d.Empresa,
                                       d.Cargo,
                                       d.TiempoLaborando,
                                       c.CodigoCliente,
                                   };
                _dataGridViewClientes.DataSource = queryCliente.ToList();
            }
            else {

                var queryCliente = from c in clientes
                                   join d in datosLaborables on c.CodigoCliente equals d.CodigoCliente
                                   where c.NoDocumento.Contains(_textBoxCliente[14].Text) || c.Nombre.Contains(_textBoxCliente[14].Text) || c.Apellido.Contains(_textBoxCliente[14].Text)
                                   select new
                                   {
                                       c.NoDocumento,
                                       c.Nombre,
                                       c.Apellido,
                                       d.Empresa,
                                       d.Cargo,
                                       d.TiempoLaborando,
                                       c.CodigoCliente,
                                   };
                _dataGridViewClientes.DataSource = queryCliente.ToList();
            }

            _dataGridViewClientes.Columns[0].HeaderText = "Núm. De Documento";
            _dataGridViewClientes.Columns[1].HeaderText = "Nombre";
            _dataGridViewClientes.Columns[2].HeaderText = "Apellidos";
            _dataGridViewClientes.Columns[3].HeaderText = "Lugar De Trabajo";
            _dataGridViewClientes.Columns[4].HeaderText = "Cargo";
            _dataGridViewClientes.Columns[5].HeaderText = "Tiempo Laborando";
            _dataGridViewClientes.Columns[6].Visible = false;

        }
        public void restablecerClientes()
        {
            _accion = "insert";
            codigoCliente = 0;
            gCodigoCliente = 0;
            sueldoNeto = 0;

            _textBoxCliente[0].Text = "";
            _textBoxCliente[1].Text = "";
            _textBoxCliente[2].Text = "";
            _textBoxCliente[3].Text = "";
            _textBoxCliente[4].Text = "";
            _textBoxCliente[5].Text = "";
            _textBoxCliente[6].Text = "";
            _textBoxCliente[7].Text = "";
            _textBoxCliente[8].Text = "0.00";
            _textBoxCliente[9].Text = "0.00";
            _textBoxCliente[10].Text = "";
            _textBoxCliente[11].Text = "0.00";
            _textBoxCliente[12].Text = "";
            _textBoxCliente[13].Text = "";
            _textBoxCliente[14].Text = "";
            _textBoxCliente[15].Text = "";

            _maskedTextBoxCliente[0].Enabled = true;
            _maskedTextBoxCliente[0].Text = "";
            _maskedTextBoxCliente[1].Text = "";
            _maskedTextBoxCliente[2].Text = "";
            _maskedTextBoxCliente[3].Text = "";
            _maskedTextBoxCliente[4].Text = "";

            _checkBoxClientes_Estado.Checked = false;
            _checkBoxClientes_VerInactivos.Checked = false;

            _dateTimePickerClientes_FechaNacimiento.ResetText();

            _comboBoxClientes_Sexo.Text = "ELEGIR";
            _comboBoxClientes_EstadoCivil.Text = "ELEGIR";
            _comboBoxClientes_Tiempo.Text = "ELEGIR";
            _comboBoxClientes_Parentesco.Text = "ELEGIR";

            _labelCliente[0].Text = "Número De Documento";
            _labelCliente[0].ForeColor = Color.LightSlateGray;

            _labelCliente[1].Text = "Nombre";
            _labelCliente[1].ForeColor = Color.LightSlateGray;

            _labelCliente[2].Text = "Apellido";
            _labelCliente[2].ForeColor = Color.LightSlateGray;

            _labelCliente[1].Text = "Nombre";
            _labelCliente[1].ForeColor = Color.LightSlateGray;

            _labelCliente[3].Text = "Apodo";
            _labelCliente[3].ForeColor = Color.LightSlateGray;

            _labelCliente[4].Text = "Sexo";
            _labelCliente[4].ForeColor = Color.LightSlateGray;

            _labelCliente[5].Text = "Estado Civil";
            _labelCliente[5].ForeColor = Color.LightSlateGray;

            _labelCliente[6].Text = "Fecha De Nacimiento";
            _labelCliente[6].ForeColor = Color.LightSlateGray;

            _labelCliente[7].Text = "Celular";
            _labelCliente[7].ForeColor = Color.LightSlateGray;

            _labelCliente[8].Text = "Teléfono";
            _labelCliente[8].ForeColor = Color.LightSlateGray;

            _labelCliente[9].Text = "Emial";
            _labelCliente[9].ForeColor = Color.LightSlateGray;

            _labelCliente[10].Text = "Dirección";
            _labelCliente[10].ForeColor = Color.LightSlateGray;

            _labelCliente[11].Text = "Estado";
            _labelCliente[11].ForeColor = Color.LightSlateGray;
            ///
            _labelCliente[12].Text = "Empresa En La Cual Labora";
            _labelCliente[12].ForeColor = Color.LightSlateGray;

            _labelCliente[13].Text = "Teléfono";
            _labelCliente[13].ForeColor = Color.LightSlateGray;

            _labelCliente[14].Text = "Dirección";
            _labelCliente[14].ForeColor = Color.LightSlateGray;

            _labelCliente[15].Text = "Cargo";
            _labelCliente[15].ForeColor = Color.LightSlateGray;

            _labelCliente[16].Text = "Tiempo Laborando";
            _labelCliente[16].ForeColor = Color.LightSlateGray;

            _labelCliente[17].Text = "Sueldo Base";
            _labelCliente[17].ForeColor = Color.LightSlateGray;

            _labelCliente[18].Text = "Otro Ingresos";
            _labelCliente[18].ForeColor = Color.LightSlateGray;

            _labelCliente[19].Text = "Detalle Otro Ingresos";
            _labelCliente[19].ForeColor = Color.LightSlateGray;

            _labelCliente[20].Text = "Sueldo Neto";
            _labelCliente[20].ForeColor = Color.LightSlateGray;
            ///

            _labelCliente[21].Text = "Nombre";
            _labelCliente[21].ForeColor = Color.LightSlateGray;

            _labelCliente[22].Text = "Parentesco";
            _labelCliente[22].ForeColor = Color.LightSlateGray;

            _labelCliente[23].Text = "Celular";
            _labelCliente[23].ForeColor = Color.LightSlateGray;

            _labelCliente[24].Text = "Dirección";
            _labelCliente[24].ForeColor = Color.LightSlateGray;

            _tabControlClientes.SelectedIndex = 0;
            _maskedTextBoxCliente[0].Focus();

            getClientes();
          //restablecerReferencias();
           
            _dataGridViewClientes_Referencias.DataSource = null;
            _dataGridViewClientes_Referencias.ColumnCount = 0;
            _groupBoxCliente_datosPersonales.Enabled = false;
            _groupBoxCliente_datosLaborales.Enabled = false;
            _groupBoxCliente_datosReferencias.Enabled = false;

        }
        public void EditCliente()
        {
            _accion = "update";

            _groupBoxCliente_datosPersonales.Enabled = true;
            _groupBoxCliente_datosLaborales.Enabled = true;
            _groupBoxCliente_datosReferencias.Enabled = true;

            _dataGridViewClientes_Referencias.DataSource = null;
            _dataGridViewClientes_Referencias.ColumnCount = 0;

            
            if (codigoCliente == 0) {
                codigoCliente = Convert.ToInt32(_dataGridViewClientes.CurrentRow.Cells[6].Value);
            }

            var datosCliente = from c in clientes
                               join d in datosLaborables on c.CodigoCliente equals d.CodigoCliente
                               where c.CodigoCliente.Equals(codigoCliente)
                               select new
                               {
                                   c.NoDocumento,//0
                                   c.Nombre,//1
                                   c.Apellido,//2
                                   c.Apodo,//3
                                   c.Sexo,//4
                                   c.EstadoCivil,//5
                                   c.FechaNacimiento,//6
                                   c.Celular,//7
                                   c.Telefono,//8
                                   c.Email,//9
                                   c.Direccion,//10
                                   c.EstadoCliente, //11

                                   d.Empresa, //12
                                   d.TelefonoEmp,//13
                                   d.DireccionEmp,//14
                                   d.Cargo,//15
                                   d.TiempoLaborando,//16
                                   d.Sueldo,//17
                                   d.OtroIngresos,//18
                                   d.DetalleOtroIngresos,//19
                                   d.UtilidadNeta,//20
                                   d.Gastos //21
                               };

            var data = datosCliente.ToList();

            if (data.Count > 0)
            {
                _dataGridViewClientes.DataSource = data.ToList();

                _maskedTextBoxCliente[0].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[0].Value);
                _textBoxCliente[0].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[1].Value);
                _textBoxCliente[1].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[2].Value);
                _textBoxCliente[2].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[3].Value);
                _comboBoxClientes_Sexo.Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[4].Value);
                _comboBoxClientes_EstadoCivil.Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[5].Value);
                _dateTimePickerClientes_FechaNacimiento.Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[6].Value);
                _maskedTextBoxCliente[1].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[7].Value);
                _maskedTextBoxCliente[2].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[8].Value);
                _textBoxCliente[3].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[9].Value);
                _textBoxCliente[4].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[10].Value);
                _checkBoxClientes_Estado.Checked = Convert.ToBoolean(_dataGridViewClientes.CurrentRow.Cells[11].Value);

                _textBoxCliente[5].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[12].Value);
                _maskedTextBoxCliente[3].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[13].Value);
                _textBoxCliente[6].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[14].Value);
                _textBoxCliente[7].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[15].Value);
                _comboBoxClientes_Tiempo.Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[16].Value);
                _textBoxCliente[8].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[17].Value);
                _textBoxCliente[9].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[18].Value);
                _textBoxCliente[10].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[19].Value);
                _textBoxCliente[11].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[20].Value);
                _textBoxCliente[15].Text = Convert.ToString(_dataGridViewClientes.CurrentRow.Cells[21].Value);
            }

            _dataGridViewClientes.Columns[3].Visible = false;
            _dataGridViewClientes.Columns[4].Visible = false;
            _dataGridViewClientes.Columns[6].Visible = false;
            _dataGridViewClientes.Columns[7].Visible = false;
            _dataGridViewClientes.Columns[8].Visible = false;
            _dataGridViewClientes.Columns[9].Visible = false;
            _dataGridViewClientes.Columns[10].Visible = false;
            _dataGridViewClientes.Columns[11].Visible = false;
            _dataGridViewClientes.Columns[13].Visible = false;
            _dataGridViewClientes.Columns[14].Visible = false;
            _dataGridViewClientes.Columns[17].Visible = false;
            _dataGridViewClientes.Columns[18].Visible = false;
            _dataGridViewClientes.Columns[19].Visible = false;
            _dataGridViewClientes.Columns[20].Visible = false;
            _dataGridViewClientes.Columns[21].Visible = false;

            _dataGridViewClientes.Columns[0].HeaderText = "Núm. De Documento";
            _dataGridViewClientes.Columns[1].HeaderText = "Nombre";
            _dataGridViewClientes.Columns[2].HeaderText = "Apellidos";
            _dataGridViewClientes.Columns[5].HeaderText = "Lugar De Trabajo";
            _dataGridViewClientes.Columns[4].HeaderText = "Cargo";
            _dataGridViewClientes.Columns[5].HeaderText = "Tiempo Laborando";

            //Referencias
            GetReferencias();

        }

        //CODIGO DE REFERENCIAS//
        public void SaveReferencias()
        {
            try
            {
                List<TReferencias> objectReferencias = new List<TReferencias>();

                foreach (DataGridViewRow dgvRow in _dataGridViewClientes_Referencias.Rows)
                {
                    var refe = new TReferencias()
                    {
                        NombreRef = Convert.ToString(dgvRow.Cells[0].Value),
                        Parentesco = Convert.ToString(dgvRow.Cells[1].Value),
                        Celular = Convert.ToString(dgvRow.Cells[2].Value),
                        Direccion = Convert.ToString(dgvRow.Cells[3].Value),
                        CodigoCliente = Convert.ToInt32(dgvRow.Cells[4].Value)
                    };

                    referencias.Value(r => r.NombreRef, refe.NombreRef)
                                    .Value(r => r.Parentesco, refe.Parentesco)
                                    .Value(r => r.Celular, refe.Celular)
                                    .Value(r => r.Direccion, refe.Direccion)
                                    .Value(r => r.CodigoCliente, refe.CodigoCliente)
                                    .Insert();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AddReferencias()
        {
            if (_textBoxCliente[12].Text.Equals(""))
            {
                _labelCliente[21].Text = "El campo Nombre es obligatorio.";
                _labelCliente[21].ForeColor = Color.Red;
                _textBoxCliente[12].Focus();
            }
            else
            {
                if (_comboBoxClientes_Parentesco.Text.Equals("") || _comboBoxClientes_Parentesco.Text.Equals("ELEGIR"))
                {
                    _labelCliente[22].Text = "El campo Parentesco es obligatorio.";
                    _labelCliente[22].ForeColor = Color.Red;
                    _comboBoxClientes_Parentesco.Focus();
                }
                else
                {
                    if (_maskedTextBoxCliente[4].Text.Equals("") || _maskedTextBoxCliente[4].Text.Equals("(   )   -"))
                    {
                        _labelCliente[23].Text = "El campo Celular es obligatorio.";
                        _labelCliente[23].ForeColor = Color.Red;
                        _maskedTextBoxCliente[4].Focus();
                    }
                    else
                    {
                        if (_textBoxCliente[13].Text.Equals(""))
                        {
                            _labelCliente[24].Text = "El campo Dirección es obligatorio.";
                            _labelCliente[24].ForeColor = Color.Red;
                            _textBoxCliente[13].Focus();
                        }
                        else
                        {
                            if (_dataGridViewClientes_Referencias.ColumnCount > 0)
                            {
                                _dataGridViewClientes_Referencias.DataSource = null;
                           
                            }

                            _dataGridViewClientes_Referencias.ColumnCount = 5;
                            _dataGridViewClientes_Referencias.Columns[0].Name = "Nombre";
                            _dataGridViewClientes_Referencias.Columns[1].Name = "Parentezco";
                            _dataGridViewClientes_Referencias.Columns[2].Name = "Celular";
                            _dataGridViewClientes_Referencias.Columns[3].Name = "Dirección";
                            _dataGridViewClientes_Referencias.Columns[4].Name = "Código";
                            _dataGridViewClientes_Referencias.Columns[4].Visible = false;
                            _dataGridViewClientes_Referencias.Rows.Add(_textBoxCliente[12].Text, _comboBoxClientes_Parentesco.Text, _maskedTextBoxCliente[4].Text, _textBoxCliente[13].Text, gCodigoCliente);
                            restablecerReferencias();
                        }
                    }
                }
            }
            
        }
        public void DeleteReferencias()
        {
            if (_dataGridViewClientes_Referencias.Rows.Count > 0)
            {
                if (_dataGridViewClientes_Referencias.ColumnCount > 0)
                {
                    int idRefe = Convert.ToInt32(_dataGridViewClientes_Referencias.CurrentRow.Cells[0].Value);
                    if (idRefe > 0)
                    {
                        var query = referencias.Where(r => r.IdReferencias.Equals(idRefe)).ToList();

                        if (query.Count() > 0)
                        {
                            if (MessageBox.Show("Realmente desea eliminar los datos.", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                referencias.Where(r => r.IdReferencias.Equals(query[0].IdReferencias)).Delete();
                                GetReferencias();
                                MessageBox.Show("Datos eliminados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            int fila = Convert.ToInt32(_dataGridViewClientes_Referencias.CurrentRow.Index);
                            _dataGridViewClientes_Referencias.Rows.RemoveAt(fila);
                        }
                       
                    }
                }
            }
        }
        public void RemoveReferencias()
        {
            try
            {
                if (_dataGridViewClientes_Referencias.Rows.Count > 0)
                {
                    int fila = Convert.ToInt32(_dataGridViewClientes_Referencias.CurrentRow.Index);
                    _dataGridViewClientes_Referencias.Rows.RemoveAt(fila);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Solo se pueden eliminar con doble clic los registros que aún no has sido guardado directamente en la base de datos, si desea eliminar un registro que ya está guardado en la base de datos utilice el botón eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        public void GetReferencias()
        {
            var refer = referencias.Where(r => r.CodigoCliente.Equals(codigoCliente)).ToList();

            if (refer.Count > 0)
            {
                _dataGridViewClientes_Referencias.DataSource = refer.ToList();
                _dataGridViewClientes_Referencias.Columns[1].HeaderText = "Nombre";
                _dataGridViewClientes_Referencias.Columns[2].HeaderText = "Parentesco";
                _dataGridViewClientes_Referencias.Columns[3].HeaderText = "Celular";
                _dataGridViewClientes_Referencias.Columns[4].HeaderText = "Dirección";

                _dataGridViewClientes_Referencias.Columns[0].Visible = false;
                _dataGridViewClientes_Referencias.Columns[5].Visible = false;

            }
         
        }
        private void restablecerReferencias()
        {

            _textBoxCliente[12].Text = "";
            _comboBoxClientes_Parentesco.Text = "ELEGIR";
            _maskedTextBoxCliente[4].Text = "(   )   -";
            _textBoxCliente[13].Text = "";

            _labelCliente[21].Text = "Nombre";
            _labelCliente[21].ForeColor = Color.LightSlateGray;

            _labelCliente[22].Text = "Parentesco";
            _labelCliente[22].ForeColor = Color.LightSlateGray;

            _labelCliente[23].Text = "Celular";
            _labelCliente[23].ForeColor = Color.LightSlateGray;

            _labelCliente[24].Text = "Direción";
            _labelCliente[24].ForeColor = Color.LightSlateGray;

        }
        public void EditReferencias()
        {

            int idReferencia = Convert.ToInt32(_dataGridViewClientes_Referencias.CurrentRow.Cells[0].Value);
            var queryReferencias = referencias.Where(r => r.IdReferencias.Equals(idReferencia)).ToList();

            if (queryReferencias.Count > 0)
            {
                _textBoxCliente[12].Text = Convert.ToString(_dataGridViewClientes_Referencias.CurrentRow.Cells[1].Value);
                _comboBoxClientes_Parentesco.Text = Convert.ToString(_dataGridViewClientes_Referencias.CurrentRow.Cells[2].Value);
                _maskedTextBoxCliente[4].Text = Convert.ToString(_dataGridViewClientes_Referencias.CurrentRow.Cells[3].Value);
                _textBoxCliente[13].Text = Convert.ToString(_dataGridViewClientes_Referencias.CurrentRow.Cells[4].Value);
            }
            _dataGridViewClientes_Referencias.Columns[1].HeaderText = "Nombre";
            _dataGridViewClientes_Referencias.Columns[2].HeaderText = "Parentesco";
            _dataGridViewClientes_Referencias.Columns[3].HeaderText = "Celular";
            _dataGridViewClientes_Referencias.Columns[4].HeaderText = "Dirección";

            _dataGridViewClientes_Referencias.Columns[0].Visible = false;
            _dataGridViewClientes_Referencias.Columns[5].Visible = false;
        }
        public void updateReferencias()
        {

            try
            {
                int idRe = Convert.ToInt32(_dataGridViewClientes_Referencias.CurrentRow.Cells[0].Value);

                if (idRe > 0)
                {
                    referencias.Where(r => r.IdReferencias.Equals(idRe))
                           .Set(r => r.NombreRef, _textBoxCliente[12].Text)
                           .Set(r => r.Parentesco, _comboBoxClientes_Parentesco.Text)
                           .Set(r => r.Celular, _maskedTextBoxCliente[4].Text)
                           .Set(r => r.Direccion, _textBoxCliente[13].Text)
                           .Update();

                    restablecerReferencias();

                    MessageBox.Show("Guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _dataGridViewClientes_Referencias.DataSource = referencias.Where(r => r.CodigoCliente.Equals(codigoCliente)).ToList();
                }

                _dataGridViewClientes_Referencias.Columns[1].HeaderText = "Nombre";
                _dataGridViewClientes_Referencias.Columns[2].HeaderText = "Parentesco";
                _dataGridViewClientes_Referencias.Columns[3].HeaderText = "Celular";
                _dataGridViewClientes_Referencias.Columns[4].HeaderText = "Dirección";

                _dataGridViewClientes_Referencias.Columns[0].Visible = false;
                _dataGridViewClientes_Referencias.Columns[5].Visible = false;

                restablecerClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
