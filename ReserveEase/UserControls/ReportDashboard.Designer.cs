namespace ReserveEase.UserControls {
    partial class ReportDashboard {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.reportTypeComboBox = new System.Windows.Forms.ComboBox();
            this.reportDataGridView = new System.Windows.Forms.DataGridView();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // reportTypeComboBox
            // 
            this.reportTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reportTypeComboBox.Items.AddRange(new object[] {
            "Occupancy Rates",
            "Revenue"});
            this.reportTypeComboBox.Location = new System.Drawing.Point(19, 26);
            this.reportTypeComboBox.Name = "reportTypeComboBox";
            this.reportTypeComboBox.Size = new System.Drawing.Size(200, 24);
            this.reportTypeComboBox.TabIndex = 4;
            // 
            // reportDataGridView
            // 
            this.reportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportDataGridView.Location = new System.Drawing.Point(19, 66);
            this.reportDataGridView.Name = "reportDataGridView";
            this.reportDataGridView.RowHeadersWidth = 51;
            this.reportDataGridView.Size = new System.Drawing.Size(743, 200);
            this.reportDataGridView.TabIndex = 5;
            // 
            // generateReportButton
            // 
            this.generateReportButton.BackColor = System.Drawing.Color.Transparent;
            this.generateReportButton.Location = new System.Drawing.Point(225, 27);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(100, 23);
            this.generateReportButton.TabIndex = 7;
            this.generateReportButton.Text = "Generate Report";
            this.generateReportButton.UseVisualStyleBackColor = false;
            this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click);
            // 
            // formsPlot1
            // 
            this.formsPlot1.Location = new System.Drawing.Point(19, 272);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(743, 285);
            this.formsPlot1.TabIndex = 8;
            // 
            // ReportDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.reportTypeComboBox);
            this.Controls.Add(this.reportDataGridView);
            this.Controls.Add(this.generateReportButton);
            this.Name = "ReportDashboard";
            this.Size = new System.Drawing.Size(783, 602);
            this.Load += new System.EventHandler(this.ReportDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox reportTypeComboBox;
        private System.Windows.Forms.DataGridView reportDataGridView;
        private System.Windows.Forms.Button generateReportButton;
        private ScottPlot.FormsPlot formsPlot1;
    }
}
