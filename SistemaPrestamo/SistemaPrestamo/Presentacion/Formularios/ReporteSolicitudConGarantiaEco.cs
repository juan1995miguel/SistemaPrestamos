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
    public partial class ReporteSolicitudConGarantiaEco : Form
    {
        public ReporteSolicitudConGarantiaEco()
        {
            InitializeComponent();
        }

        public int csGE = 0;
        private void Reporte_SolicitudConGarantiaEco_Load(object sender, EventArgs e)
        {
            try
            {
                RP_SolicitudConGarantiaEco objReporte = new RP_SolicitudConGarantiaEco();
                objReporte.SetParameterValue("@CODIGO_SOLICITUD", csGE);
                crystalReportViewerRS.ReportSource = objReporte;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
