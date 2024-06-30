namespace ReserveEase
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.reportTypeComboBox = new System.Windows.Forms.ComboBox();
            this.reportDataGridView = new System.Windows.Forms.DataGridView();
            this.reportChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.btnHmreserve = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportChart)).BeginInit();
            this.SuspendLayout();
            // 
            // reportTypeComboBox
            // 
            this.reportTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reportTypeComboBox.Items.AddRange(new object[] {
            "Occupancy Rates",
            "Revenue",
            "Guest Demographics"});
            this.reportTypeComboBox.Location = new System.Drawing.Point(10, 10);
            this.reportTypeComboBox.Name = "reportTypeComboBox";
            this.reportTypeComboBox.Size = new System.Drawing.Size(200, 24);
            this.reportTypeComboBox.TabIndex = 0;
            // 
            // reportDataGridView
            // 
            this.reportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportDataGridView.Location = new System.Drawing.Point(10, 64);
            this.reportDataGridView.Name = "reportDataGridView";
            this.reportDataGridView.RowHeadersWidth = 51;
            this.reportDataGridView.Size = new System.Drawing.Size(771, 200);
            this.reportDataGridView.TabIndex = 1;
            // 
            // reportChart
            // 
            chartArea1.Name = "ChartArea1";
            this.reportChart.ChartAreas.Add(chartArea1);
            this.reportChart.Location = new System.Drawing.Point(10, 276);
            this.reportChart.Name = "reportChart";
            this.reportChart.Size = new System.Drawing.Size(771, 199);
            this.reportChart.TabIndex = 2;
            // 
            // generateReportButton
            // 
            this.generateReportButton.BackColor = System.Drawing.Color.Transparent;
            this.generateReportButton.Location = new System.Drawing.Point(220, 10);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(100, 23);
            this.generateReportButton.TabIndex = 3;
            this.generateReportButton.Text = "Generate Report";
            this.generateReportButton.UseVisualStyleBackColor = false;
            this.generateReportButton.Click += new System.EventHandler(this.GenerateReportButton_Click);
            // 
            // btnHmreserve
            // 
            this.btnHmreserve.Image = global::ReserveEase.Properties.Resources.icons8_home_24;
            this.btnHmreserve.Location = new System.Drawing.Point(595, 21);
            this.btnHmreserve.Name = "btnHmreserve";
            this.btnHmreserve.Size = new System.Drawing.Size(41, 33);
            this.btnHmreserve.TabIndex = 40;
            this.btnHmreserve.UseVisualStyleBackColor = true;
            this.btnHmreserve.Click += new System.EventHandler(this.btnHmreserve_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(643, 27);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(81, 27);
            this.label26.TabIndex = 41;
            this.label26.Text = "HOME";
            // 
            // ReportForm
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(799, 489);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.btnHmreserve);
            this.Controls.Add(this.reportTypeComboBox);
            this.Controls.Add(this.reportDataGridView);
            this.Controls.Add(this.reportChart);
            this.Controls.Add(this.generateReportButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox reportTypeComboBox;
        private System.Windows.Forms.DataGridView reportDataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart reportChart;
        private System.Windows.Forms.Button generateReportButton;
        private System.Windows.Forms.Button btnHmreserve;
        private System.Windows.Forms.Label label26;
    }
}
