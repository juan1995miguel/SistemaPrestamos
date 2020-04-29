using AccesoDatos.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dominio.ModelosVista
{
    public class ListaPrestamosCobroVM : Conexion
    {
        private TextBox txtFiltrar;
        private DataGridView dataGridViewPrest;
     
        public ListaPrestamosCobroVM(object[] objetos)
        {
            this.txtFiltrar = (TextBox)objetos[0];
            this.dataGridViewPrest = (DataGridView)objetos[1];
        }

        public void GetPrestamos()
        {
            if (txtFiltrar.Text.Equals(""))
            {
                var query = from s in solicitudes
                            join c in clientes on s.CodigoCliente equals c.CodigoCliente
                            join a in atraso on s.CodigoSolicitud equals a.CodigoSolicitud
                            where s.IdEstadoSolicitud.Equals(3) && s.IdEstadoPrestamo.Equals(2)
                            select new
                            {
                                CODIGO_CLIENTE = c.CodigoCliente,
                                NOMBRE_CLIENTE = c.Nombre + " " + c.Apellido,
                                CEDULA = c.NoDocumento,
                                APODO = c.Apodo,
                                CODIGO_PRESTAMO = s.CodigoSolicitud,
                                MONTO = s.MontoSolicitado + s.GastosLegales,
                                MONTO_ATRASADO = a.Capital + a.Intere + a.Comision + a.Seguro + a.Mora
                            };

                var list = query.ToList();

                if (list.Count > 0)
                {
                    dataGridViewPrest.DataSource = list.ToList();
                    dataGridViewListPrestamos();
                }

            }
            else
            {
                var query = from s in solicitudes
                            join c in clientes on s.CodigoCliente equals c.CodigoCliente
                            join a in atraso on s.CodigoSolicitud equals a.CodigoSolicitud

                            where s.IdEstadoSolicitud.Equals(3) && s.IdEstadoPrestamo.Equals(2) && (c.Nombre.Contains(txtFiltrar.Text) || c.Apellido.Contains(txtFiltrar.Text) || c.NoDocumento.StartsWith(txtFiltrar.Text) || c.Apodo.Contains(txtFiltrar.Text))

                            select new
                            {
                                CODIGO_CLIENTE = c.CodigoCliente,
                                NOMBRE_CLIENTE = c.Nombre + " " + c.Apellido,
                                CEDULA = c.NoDocumento,
                                APODO = c.Apodo,
                                CODIGO_PRESTAMO = s.CodigoSolicitud,
                                MONTO = s.MontoSolicitado + s.GastosLegales,
                                MONTO_ATRASADO = a.Capital + a.Intere + a.Comision + a.Seguro + a.Mora
                            };

                var list = query.ToList();

                if (list.Count > 0)
                {
                    dataGridViewPrest.DataSource = list.ToList();
                    dataGridViewListPrestamos();
                }

            }
        }
        

        
        private void dataGridViewListPrestamos()
        {
            dataGridViewPrest.Columns[0].HeaderText = "Código";
            dataGridViewPrest.Columns[1].HeaderText = "Nombre";
            dataGridViewPrest.Columns[2].HeaderText = "Cédula";
            dataGridViewPrest.Columns[3].HeaderText = "Apodo";
            dataGridViewPrest.Columns[4].HeaderText = "# Préstamo";
            dataGridViewPrest.Columns[5].HeaderText = "Monto";
            dataGridViewPrest.Columns[6].HeaderText = "Monto En Atraso";
            dataGridViewPrest.Columns[1].Width = 300;
        }

    }
}
