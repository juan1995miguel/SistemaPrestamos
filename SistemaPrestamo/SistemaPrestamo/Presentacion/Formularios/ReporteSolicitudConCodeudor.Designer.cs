namespace Presentacion.Formularios
{
    partial class ReporteSolicitudConCodeudor
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
            this.crystalReportViewerReportSolicitud = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerReportSolicitud
            // 
            this.crystalReportViewerReportSolicitud.ActiveViewIndex = 0;
            this.crystalReportViewerReportSolicitud.AutoSize = true;
            this.crystalReportViewerReportSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerReportSolicitud.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerReportSolicitud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerReportSolicitud.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerReportSolicitud.Name = "crystalReportViewerReportSolicitud";
            this.crystalReportViewerReportSolicitud.ReportSource = "D:\\SistemaPrestamo\\SistemaPrestamo\\Presentacion\\CrystalReports\\RP_SolicitudConCod" +
    "eudor.rpt";
            this.crystalReportViewerReportSolicitud.ReuseParameterValuesOnRefresh = true;
            this.crystalReportViewerReportSolicitud.Size = new System.Drawing.Size(894, 511);
            this.crystalReportViewerReportSolicitud.TabIndex = 0;
            this.crystalReportViewerReportSolicitud.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Reporte_SolicitudConCodeudor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 511);
            this.Controls.Add(this.crystalReportViewerReportSolicitud);
            this.Name = "Reporte_SolicitudConCodeudor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Solicitud";
            this.Load += new System.EventHandler(this.Reporte_SolicitudConCodeudor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerReportSolicitud;
    }
}