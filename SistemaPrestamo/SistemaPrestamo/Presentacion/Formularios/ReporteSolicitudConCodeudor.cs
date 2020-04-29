using Presentacion.CrystalReports;
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
    public partial class ReporteSolicitudConCodeudor : Form
    {
        FormPrincipal llamar = new FormPrincipal();
       
        public ReporteSolicitudConCodeudor()
        {
            InitializeComponent();
            
        }

        public int csCO = 0;
        private void Reporte_SolicitudConCodeudor_Load(object sender, EventArgs e)
        {
            try
            {
                RP_SolicitudConCodeudor objReporte = new RP_SolicitudConCodeudor();
                objReporte.SetParameterValue("@CODIGO_SOLICITUD", csCO);
                crystalReportViewerReportSolicitud.ReportSource = objReporte;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
