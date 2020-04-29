using Dominio.ModelosVista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios
{
    public partial class ListaPrestamos : Form
    {

        private ListaPrestamosCobroVM prestamoList;

        public ListaPrestamos()
        {
            InitializeComponent();

            objetosListaP();
        }

        private void objetosListaP()
        {
            object[] objetos = {
                txtFiltrar,
                dataGridViewPrest,
            };

            prestamoList = new ListaPrestamosCobroVM(objetos);
        }

        private void ConsultaPrestamos_Load(object sender, EventArgs e)
        {
            prestamoList.GetPrestamos();
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            prestamoList.GetPrestamos();
        }

        private void btnCP_Ayuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para filtrar solo debe escribir en el campo el Nombre del cliente, el Apellido, el Número de Cedula o el Apodo. \n\nNOTA: Solo una de las obciones mencionadas a la vez.", "Informacióon", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridViewPrest_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

      
    }
}
