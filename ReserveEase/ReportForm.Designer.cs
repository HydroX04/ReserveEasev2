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
            this.reportTypeComboBox = new System.Windows.Forms.ComboBox();
            this.reportDataGridView = new System.Windows.Forms.DataGridView();
            this.reportChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.generateReportButton = new System.Windows.Forms.Button();
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
            this.reportTypeComboBox.Size = new System.Drawing.Size(200, 21);

            // 
            // reportDataGridView
            // 
            this.reportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportDataGridView.Location = new System.Drawing.Point(10, 40);
            this.reportDataGridView.Name = "reportDataGridView";
            this.reportDataGridView.Size = new System.Drawing.Size(600, 200);

            // 
            // reportChart
            // 
            this.reportChart.Location = new System.Drawing.Point(10, 250);
            this.reportChart.Name = "reportChart";
            this.reportChart.Size = new System.Drawing.Size(600, 300);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.reportChart.ChartAreas.Add(chartArea);

            // 
            // generateReportButton
            // 
            this.generateReportButton.Location = new System.Drawing.Point(220, 10);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(100, 23);
            this.generateReportButton.Text = "Generate Report";
            this.generateReportButton.Click += new System.EventHandler(this.GenerateReportButton_Click);

            // 
            // ReportForm
            // 
            this.ClientSize = new System.Drawing.Size(620, 560);
            this.Controls.Add(this.reportTypeComboBox);
            this.Controls.Add(this.reportDataGridView);
            this.Controls.Add(this.reportChart);
            this.Controls.Add(this.generateReportButton);
            this.Name = "ReportForm";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportChart)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox reportTypeComboBox;
        private System.Windows.Forms.DataGridView reportDataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart reportChart;
        private System.Windows.Forms.Button generateReportButton;
    }
}
