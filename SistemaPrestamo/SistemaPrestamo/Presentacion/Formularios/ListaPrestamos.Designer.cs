namespace Presentacion.Formularios
{
    partial class ListaPrestamos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCP_Ayuda = new FontAwesome.Sharp.IconButton();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewPrest = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrest)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(130)))), ((int)(((byte)(240)))));
            this.groupBox1.Controls.Add(this.btnCP_Ayuda);
            this.groupBox1.Controls.Add(this.txtFiltrar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1055, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnCP_Ayuda
            // 
            this.btnCP_Ayuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(130)))), ((int)(((byte)(240)))));
            this.btnCP_Ayuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCP_Ayuda.FlatAppearance.BorderSize = 0;
            this.btnCP_Ayuda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(222)))), ((int)(((byte)(2)))));
            this.btnCP_Ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCP_Ayuda.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCP_Ayuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCP_Ayuda.ForeColor = System.Drawing.Color.White;
            this.btnCP_Ayuda.IconChar = FontAwesome.Sharp.IconChar.Question;
            this.btnCP_Ayuda.IconColor = System.Drawing.Color.White;
            this.btnCP_Ayuda.IconSize = 25;
            this.btnCP_Ayuda.Location = new System.Drawing.Point(560, 18);
            this.btnCP_Ayuda.Name = "btnCP_Ayuda";
            this.btnCP_Ayuda.Rotation = 0D;
            this.btnCP_Ayuda.Size = new System.Drawing.Size(30, 31);
            this.btnCP_Ayuda.TabIndex = 14;
            this.btnCP_Ayuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCP_Ayuda.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCP_Ayuda.UseVisualStyleBackColor = false;
            this.btnCP_Ayuda.Click += new System.EventHandler(this.btnCP_Ayuda_Click);
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltrar.Location = new System.Drawing.Point(107, 20);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(447, 26);
            this.txtFiltrar.TabIndex = 1;
            this.txtFiltrar.TextChanged += new System.EventHandler(this.txtFiltrar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar";
            // 
            // dataGridViewPrest
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewPrest.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPrest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPrest.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPrest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewPrest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPrest.Location = new System.Drawing.Point(0, 55);
            this.dataGridViewPrest.Name = "dataGridViewPrest";
            this.dataGridViewPrest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrest.Size = new System.Drawing.Size(1055, 444);
            this.dataGridViewPrest.TabIndex = 2;
            this.dataGridViewPrest.DoubleClick += new System.EventHandler(this.dataGridViewPrest_DoubleClick);
            // 
            // ListaPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 499);
            this.Controls.Add(this.dataGridViewPrest);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListaPrestamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Préstamos";
            this.Load += new System.EventHandler(this.ConsultaPrestamos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFiltrar;
        private FontAwesome.Sharp.IconButton btnCP_Ayuda;
        public System.Windows.Forms.DataGridView dataGridViewPrest;
    }
}