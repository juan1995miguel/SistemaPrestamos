namespace Presentacion.Formularios
{
    partial class ReporteSolicitudConGarantiaEco
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalReportViewerRS = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerRS
            // 
            this.crystalReportViewerRS.ActiveViewIndex = 0;
            this.crystalReportViewerRS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerRS.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerRS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerRS.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerRS.Name = "crystalReportViewerRS";
            this.crystalReportViewerRS.ReportSource = "D:\\SistemaPrestamo\\SistemaPrestamo\\Presentacion\\CrystalReports\\RP_SolicitudConGar" +
    "antiaEco.rpt";
            this.crystalReportViewerRS.Size = new System.Drawing.Size(894, 511);
            this.crystalReportViewerRS.TabIndex = 0;
            this.crystalReportViewerRS.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Reporte_SolicitudConGarantiaEco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 511);
            this.Controls.Add(this.crystalReportViewerRS);
            this.Name = "Reporte_SolicitudConGarantiaEco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Solicitud";
            this.Load += new System.EventHandler(this.Reporte_SolicitudConGarantiaEco_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerRS;
    }
}