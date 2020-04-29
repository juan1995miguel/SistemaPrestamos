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
    public class SeguimientoSolicitudVM : Conexion
    {
        private string _accion = "insert";
        private int _idES = 0, codigoSolicitud = 0;
        private DataGridView _dataGridViewListaSolicitudes;
        private ComboBox _cbbLS_EstadoSolicitud;
        private TextBox _txtLS_CodigoSilicitud;
        private TextBox _txtLS_NombreCliente; 
        private TextBox _txtLS_Mensaje;
        private DataGridView _dataGridViewLS_Notas;
        private RadioButton _rbLS_Todas;
        private RadioButton _rbLS_PA;
        private RadioButton _rbLS_PC;
        private RadioButton _rbLS_A;
        private RadioButton _rbLS_R;

        public SeguimientoSolicitudVM(object[] objectos)
        {
            _dataGridViewListaSolicitudes = (DataGridView)objectos[0];
            _cbbLS_EstadoSolicitud = (ComboBox)objectos[1];
            _txtLS_CodigoSilicitud = (TextBox)objectos[2];
            _txtLS_NombreCliente = (TextBox)objectos[3];
            _txtLS_Mensaje = (TextBox)objectos[4];
            _dataGridViewLS_Notas = (DataGridView)objectos[5];
            _rbLS_Todas = (RadioButton)objectos[6];
            _rbLS_PA = (RadioButton)objectos[7];
            _rbLS_PC = (RadioButton)objectos[8];
            _rbLS_A = (RadioButton)objectos[9];
            _rbLS_R = (RadioButton)objectos[10];

        }

       
        public void GetSolicitudes()
        {
            //SP= Solicitudes Pendiente

            try
            {
                ValorRadioButton();
                switch (_idES)
                {
                    case 0:
                        var todas = from s in solicitudes
                                    join c in clientes on s.CodigoCliente equals c.CodigoCliente
                                    join e in estadoSolicitudes on s.IdEstadoSolicitud equals e.IdEstadoSolicitud
                                    join f in formaPagos on s.IdFormaPago equals f.IdFormaPago
                                    where s.Estado == true
                                    select new
                                    {
                                        s.CodigoSolicitud,
                                        c.Nombre,
                                        c.Apellido,
                                        s.MontoTotal,
                                        s.CantidadCuotas,
                                        f.DescripcionFP,
                                        s.Fecha,
                                        s.IdEstadoSolicitud

                                    };
                        _dataGridViewListaSolicitudes.DataSource = todas.ToList();
                        break;

                    default:
                        var filtradas = from s in solicitudes
                                        join c in clientes on s.CodigoCliente equals c.CodigoCliente
                                        join e in estadoSolicitudes on s.IdEstadoSolicitud equals e.IdEstadoSolicitud
                                        join f in formaPagos on s.IdFormaPago equals f.IdFormaPago
                                        where s.Estado == true && s.IdEstadoSolicitud == _idES
                                        select new
                                        {
                                            s.CodigoSolicitud,
                                            c.Nombre,
                                            c.Apellido,
                                            s.MontoTotal,
                                            s.CantidadCuotas,
                                            f.DescripcionFP,
                                            s.Fecha,
                                            s.IdEstadoSolicitud

                                        };
                        _dataGridViewListaSolicitudes.DataSource = filtradas.ToList();
                        break;

                }

                _dataGridViewListaSolicitudes.Columns[0].HeaderText = "Solicitud";
                _dataGridViewListaSolicitudes.Columns[3].HeaderText = "Monto";
                _dataGridViewListaSolicitudes.Columns[4].HeaderText = "Plazo";
                _dataGridViewListaSolicitudes.Columns[5].HeaderText = "Forma De Pago";
                _dataGridViewListaSolicitudes.Columns[6].HeaderText = "Fecha";

                _dataGridViewListaSolicitudes.Columns[0].Width = 90;
                _dataGridViewListaSolicitudes.Columns[3].Width = 100;
                _dataGridViewListaSolicitudes.Columns[4].Width = 80;
                _dataGridViewListaSolicitudes.Columns[5].Width = 120;
                _dataGridViewListaSolicitudes.Columns[6].Width = 100;
                _dataGridViewListaSolicitudes.Columns[7].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lo sentimos ha ocurrido un error inesperado.\n\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string ValorRadioButton()
        {
            if (_rbLS_Todas.Checked)
            {
                _idES = 0;
            }
            else
            {
                if (_rbLS_PA.Checked)
                {
                    _idES = 1;
                }
                else
                {
                    if (_rbLS_PC.Checked)
                    {
                        _idES = 2;
                    }
                    else
                    {
                        if (_rbLS_A.Checked)
                        {
                            _idES = 3;
                        }
                        else
                        {
                            if (_rbLS_R.Checked)
                            {
                                _idES = 4;
                            }
                        }
                    }
                }
            }

            return _accion;
        }
        public void GetEstadoSolicitud()
        {
            try
            {
                _cbbLS_EstadoSolicitud.DataSource = estadoSolicitudes.ToList();
                _cbbLS_EstadoSolicitud.ValueMember = "IdEstadoSolicitud";
                _cbbLS_EstadoSolicitud.DisplayMember = "DescripcionES";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lo sentimos ha ocurrido un error inesperado.\n\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RestablecerListaSolicitudes()
        {
            _accion = "insert";
            _idES = 0;
            codigoSolicitud = 0;

            GetEstadoSolicitud();
            GetSolicitudes();

            _rbLS_Todas.Checked = true;
            _txtLS_CodigoSilicitud.Clear();
            _txtLS_NombreCliente.Clear();
            _txtLS_Mensaje.Clear();
            GetEstadoSolicitud();
            _dataGridViewLS_Notas.DataSource = null;
            _txtLS_Mensaje.Enabled = true;

        }

        public void GetDataGridViewLS()
        {
            _accion = "update";

            try
            {
                if (_dataGridViewListaSolicitudes.RowCount > 0)
                {
                    _txtLS_Mensaje.Clear();
                    _txtLS_Mensaje.Enabled = true;
                    _dataGridViewLS_Notas.DataSource = null;

                    //LS = Listado De Solicitudes
                    _txtLS_CodigoSilicitud.Text = Convert.ToString(_dataGridViewListaSolicitudes.CurrentRow.Cells[0].Value);
                    codigoSolicitud = Convert.ToInt32(_txtLS_CodigoSilicitud.Text);
                    _txtLS_NombreCliente.Text = Convert.ToString(_dataGridViewListaSolicitudes.CurrentRow.Cells[1].Value);
                    int idEstS = Convert.ToInt32(_dataGridViewListaSolicitudes.CurrentRow.Cells[7].Value);

                    if (idEstS > 0)
                    {
                        var query = estadoSolicitudes.Where(e => e.IdEstadoSolicitud.Equals(idEstS)).ToList();

                        _cbbLS_EstadoSolicitud.Text = query[0].DescripcionES;
                    }

                    var msj = from s in notasSolicitudes
                              where s.CodigoSolicitud == Convert.ToInt32(_txtLS_CodigoSilicitud.Text)
                              select new
                              {
                                  s.DescripcionNS
                              };

                    if (msj.Count() > 0)
                    {
                        _dataGridViewLS_Notas.DataSource = msj.ToList();
                        _dataGridViewLS_Notas.Columns[0].HeaderText = "Descripción";

                    }
                }
                else
                {
                    MessageBox.Show("No existen datos para visualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lo sentimos ha ocurrido un error inesperado.\n\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        public void GetMsjNotas()
        {
            try
            {
                if (_dataGridViewLS_Notas.RowCount > 0)
                {
                    _txtLS_Mensaje.Text = Convert.ToString(_dataGridViewLS_Notas.CurrentRow.Cells[0].Value);
                    _txtLS_Mensaje.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lo sentimos ha ocurrido un error inesperado.\n\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private  int idEstadoPrestamo = 0;
        public void SaveDataSolicitud()
        {
            try {
               
                if (_txtLS_CodigoSilicitud.Text != "") {

                    var estadoS = estadoSolicitudes.Where(e => e.DescripcionES.Equals(_cbbLS_EstadoSolicitud.Text)).ToList();
                   
                    if (estadoS.Count > 0) {

                        int _idES = estadoS[0].IdEstadoSolicitud;
                        int idESanterior = 0;
                        var query = solicitudes.Where(s => s.CodigoSolicitud.Equals(codigoSolicitud)).ToList();

                        if (_idES.Equals(3)) {
                            idEstadoPrestamo = 2;
                        }
                        else {
                            idEstadoPrestamo = 1;
                        }
                        

                        if (query.Count > 0) {
                             idESanterior = query[0].IdEstadoSolicitud;
                        }
                           
                        var nota = notasSolicitudes.Where(n => n.IdEstadoSolicitud.Equals(_idES) && n.CodigoSolicitud.Equals(codigoSolicitud)).ToList();

                        if (idESanterior == 1 && nota.Count == 0) {
                            _accion = "insert";
                        }
                        else {
                            _accion = "update";
                        }

                        /////
                        switch (_accion) {

                            case "insert":

                                string fechaAc = System.DateTime.Now.ToString("dd/MM/yyy");
                                DateTime Fecha = Convert.ToDateTime(fechaAc);

                                if (idESanterior == 3 || idESanterior == 4) {
                                    MessageBox.Show($"Lo sentimos, la solicitud esta {_cbbLS_EstadoSolicitud.Text} y no se debe modificar, por tanto no se realizara ninguna acción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else {
                                    int txtlength = 8;
                                    if (_txtLS_Mensaje.Text.Length < txtlength) {
                                        MessageBox.Show($"La Nota o Mensaje debe tener un minimo de {txtlength} Caracteres.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        _txtLS_Mensaje.Focus();
                                    }
                                    else {

                                        if (MessageBox.Show("Realmente desea guardar los cambios.\n\nNota: Las Solicitudes Aprobadas o Rechazadas No Permiten Cambios.", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                                            notasSolicitudes.Value(n => n.CodigoSolicitud, Convert.ToInt32(_txtLS_CodigoSilicitud.Text))
                                                            .Value(n => n.IdEstadoSolicitud, _idES)
                                                            .Value(n => n.DescripcionNS, _txtLS_Mensaje.Text)
                                                            .Value(n => n.FechaCreacion, Fecha)
                                                            .Insert();

                                            var queryValidate = solicitudes.Where(s => s.CodigoSolicitud.Equals(Convert.ToInt32(_txtLS_CodigoSilicitud.Text))).ToList();

                                            if (queryValidate.Count() > 0) {
                                                solicitudes.Where(s => s.CodigoSolicitud.Equals(codigoSolicitud))
                                                     .Set(s => s.IdEstadoSolicitud, _idES)
                                                     .Set(s => s.IdEstadoPrestamo, idEstadoPrestamo)
                                                     .Update();
                                            }
                                           


                                            RestablecerListaSolicitudes();
                                            MessageBox.Show("Datos guardados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }

                                }

                                break;
                                
                            case "update":

                                if (idESanterior == 3 || idESanterior == 4)
                                {
                                    MessageBox.Show("Lo sentimos, la solicitud esta " + _cbbLS_EstadoSolicitud.Text + " y no se debe modificar, por tanto no se realizara ninguna acción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    if (MessageBox.Show("Realmente desea guardar los cambios.\n\nNota: Las Solicitudes Aprobadas o Rechazadas No Permiten Cambios.", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        notasSolicitudes.Where(n => n.CodigoSolicitud.Equals(codigoSolicitud))
                                                        .Set(n => n.IdEstadoSolicitud, _idES)
                                                        .Update();


                                        var queryValidate = solicitudes.Where(s => s.CodigoSolicitud.Equals(Convert.ToInt32(_txtLS_CodigoSilicitud.Text))).ToList();

                                        if (queryValidate.Count() > 0)
                                        {
                                            solicitudes.Where(s => s.CodigoSolicitud.Equals(codigoSolicitud))
                                                 .Set(s => s.IdEstadoSolicitud, _idES)
                                                 .Set(s => s.IdEstadoPrestamo, idEstadoPrestamo)
                                                 .Update();
                                        }


                                        RestablecerListaSolicitudes();
                                        MessageBox.Show("Datos guardados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }

                                break;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("No existen datos para guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex) {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

    }
}
