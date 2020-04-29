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
    public partial class ReporteSolicitudConCodeudorGarantiaE : Form
    {
        public ReporteSolicitudConCodeudorGarantiaE()
        {
            InitializeComponent();
        }

        public int csCOGE = 0;
        private void Reporte_SolicitudConCodeudorGarantiaE_Load(object sender, EventArgs e)
        {
            try
            {
                RP_SolicitudConCodeudorGarantia objReporte = new RP_SolicitudConCodeudorGarantia();
                objReporte.SetParameterValue("@CODIGO_SOLICITUD", csCOGE);
                crystalReportViewerRS.ReportSource = objReporte;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lo sentimos ha ocurrido un error inesperado.\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
