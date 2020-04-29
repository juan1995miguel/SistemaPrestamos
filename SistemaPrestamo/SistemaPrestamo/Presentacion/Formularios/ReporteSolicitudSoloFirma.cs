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
    public partial class ReporteSolicitudSoloFirma : Form
    {
        public ReporteSolicitudSoloFirma()
        {
            InitializeComponent();
        }

        public int csSF = 0;
        private void Reporte_SolicitudSoloFirma_Load(object sender, EventArgs e)
        {
            try
            {
                RP_SolicitudsSoloFirma objReporte = new RP_SolicitudsSoloFirma();
                objReporte.SetParameterValue("@CODIGO_SOLICITUD", csSF);
                crystalReportViewerRS.ReportSource = objReporte;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
