namespace CourseProject
{
    partial class Form4
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.label1 = new System.Windows.Forms.Label();
            this.labelIncomes = new System.Windows.Forms.Label();
            this.labelIS = new System.Windows.Forms.Label();
            this.dgvReportInc = new System.Windows.Forms.DataGridView();
            this.labelOutlays = new System.Windows.Forms.Label();
            this.labelOI = new System.Windows.Forms.Label();
            this.dgvReportOut = new System.Windows.Forms.DataGridView();
            this.labelFMInc = new System.Windows.Forms.Label();
            this.labelFMOut = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportInc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportOut)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(172, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report";
            // 
            // labelIncomes
            // 
            this.labelIncomes.AutoSize = true;
            this.labelIncomes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIncomes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelIncomes.Location = new System.Drawing.Point(78, 55);
            this.labelIncomes.Name = "labelIncomes";
            this.labelIncomes.Size = new System.Drawing.Size(118, 29);
            this.labelIncomes.TabIndex = 1;
            this.labelIncomes.Text = "Incomes:";
            // 
            // labelIS
            // 
            this.labelIS.AutoSize = true;
            this.labelIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelIS.Location = new System.Drawing.Point(467, 58);
            this.labelIS.Name = "labelIS";
            this.labelIS.Size = new System.Drawing.Size(188, 29);
            this.labelIS.TabIndex = 2;
            this.labelIS.Text = "Income Sourse";
            // 
            // dgvReportInc
            // 
            this.dgvReportInc.AllowUserToAddRows = false;
            this.dgvReportInc.AllowUserToDeleteRows = false;
            this.dgvReportInc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReportInc.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvReportInc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReportInc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReportInc.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReportInc.Location = new System.Drawing.Point(86, 92);
            this.dgvReportInc.Name = "dgvReportInc";
            this.dgvReportInc.ReadOnly = true;
            this.dgvReportInc.RowHeadersVisible = false;
            this.dgvReportInc.RowTemplate.Height = 27;
            this.dgvReportInc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportInc.ShowCellToolTips = false;
            this.dgvReportInc.Size = new System.Drawing.Size(997, 197);
            this.dgvReportInc.TabIndex = 3;
            // 
            // labelOutlays
            // 
            this.labelOutlays.AutoSize = true;
            this.labelOutlays.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOutlays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelOutlays.Location = new System.Drawing.Point(78, 309);
            this.labelOutlays.Name = "labelOutlays";
            this.labelOutlays.Size = new System.Drawing.Size(107, 29);
            this.labelOutlays.TabIndex = 4;
            this.labelOutlays.Text = "Outlays:";
            // 
            // labelOI
            // 
            this.labelOI.AutoSize = true;
            this.labelOI.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelOI.Location = new System.Drawing.Point(467, 309);
            this.labelOI.Name = "labelOI";
            this.labelOI.Size = new System.Drawing.Size(144, 29);
            this.labelOI.TabIndex = 5;
            this.labelOI.Text = "Outlay Item";
            // 
            // dgvReportOut
            // 
            this.dgvReportOut.AllowUserToAddRows = false;
            this.dgvReportOut.AllowUserToDeleteRows = false;
            this.dgvReportOut.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReportOut.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvReportOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReportOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReportOut.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReportOut.Location = new System.Drawing.Point(86, 349);
            this.dgvReportOut.Name = "dgvReportOut";
            this.dgvReportOut.ReadOnly = true;
            this.dgvReportOut.RowHeadersVisible = false;
            this.dgvReportOut.RowTemplate.Height = 27;
            this.dgvReportOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportOut.ShowCellToolTips = false;
            this.dgvReportOut.Size = new System.Drawing.Size(997, 330);
            this.dgvReportOut.TabIndex = 6;
            // 
            // labelFMInc
            // 
            this.labelFMInc.AutoSize = true;
            this.labelFMInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFMInc.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelFMInc.Location = new System.Drawing.Point(246, 58);
            this.labelFMInc.Name = "labelFMInc";
            this.labelFMInc.Size = new System.Drawing.Size(193, 29);
            this.labelFMInc.TabIndex = 7;
            this.labelFMInc.Text = "Family Member";
            // 
            // labelFMOut
            // 
            this.labelFMOut.AutoSize = true;
            this.labelFMOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFMOut.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelFMOut.Location = new System.Drawing.Point(246, 312);
            this.labelFMOut.Name = "labelFMOut";
            this.labelFMOut.Size = new System.Drawing.Size(193, 29);
            this.labelFMOut.TabIndex = 8;
            this.labelFMOut.Text = "Family Member";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 694);
            this.Controls.Add(this.labelFMOut);
            this.Controls.Add(this.labelFMInc);
            this.Controls.Add(this.dgvReportOut);
            this.Controls.Add(this.labelOI);
            this.Controls.Add(this.labelOutlays);
            this.Controls.Add(this.dgvReportInc);
            this.Controls.Add(this.labelIS);
            this.Controls.Add(this.labelIncomes);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportInc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelIncomes;
        private System.Windows.Forms.Label labelIS;
        private System.Windows.Forms.DataGridView dgvReportInc;
        private System.Windows.Forms.Label labelOutlays;
        private System.Windows.Forms.Label labelOI;
        private System.Windows.Forms.DataGridView dgvReportOut;
        private System.Windows.Forms.Label labelFMInc;
        private System.Windows.Forms.Label labelFMOut;
    }
}