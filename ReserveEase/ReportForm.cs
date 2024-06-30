using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ReserveEase
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // Handle any initialization tasks here.
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            string selectedReport = reportTypeComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedReport))
            {
                MessageBox.Show("Please select a report type.");
                return;
            }

            DataTable reportData = FetchReportData(selectedReport);

            reportDataGridView.DataSource = reportData;
            PopulateChart(reportData, selectedReport);
        }

        private DataTable FetchReportData(string reportType)
        {
            DataTable dataTable = new DataTable();

            // Fetch data based on the report type.
            // This is just a placeholder. Replace it with actual data fetching logic.
            switch (reportType)
            {
                case "Occupancy Rates":
                    dataTable = GetOccupancyRatesData();
                    break;
                case "Revenue":
                    dataTable = GetRevenueData();
                    break;
                case "Guest Demographics":
                    dataTable = GetGuestDemographicsData();
                    break;
            }

            return dataTable;
        }

        private void PopulateChart(DataTable data, string reportType)
        {
            reportChart.Series.Clear();
            Series series = new Series(reportType)
            {
                ChartType = SeriesChartType.Column
            };

            // Populate the chart series with data.
            foreach (DataRow row in data.Rows)
            {
                series.Points.AddXY(row["Category"], row["Value"]);
            }

            reportChart.Series.Add(series);
        }

        private DataTable GetOccupancyRatesData()
        {
            // Replace this with actual data fetching logic.
            DataTable table = new DataTable();
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("Value", typeof(int));

            table.Rows.Add("January", 80);
            table.Rows.Add("February", 75);
            table.Rows.Add("March", 85);

            return table;
        }

        private DataTable GetRevenueData()
        {
            // Replace this with actual data fetching logic.
            DataTable table = new DataTable();
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("Value", typeof(decimal));

            table.Rows.Add("January", 5000.00m);
            table.Rows.Add("February", 4500.00m);
            table.Rows.Add("March", 6000.00m);

            return table;
        }

        private DataTable GetGuestDemographicsData()
        {
            // Replace this with actual data fetching logic.
            DataTable table = new DataTable();
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("Value", typeof(int));

            table.Rows.Add("18-25", 50);
            table.Rows.Add("26-35", 70);
            table.Rows.Add("36-45", 60);

            return table;
        }

        private void btnHmreserve_Click(object sender, EventArgs e)
        {
            WELCOME_PAGE wELCOME_PAGE = new WELCOME_PAGE();
            this.Hide();
            wELCOME_PAGE.Show();
        }
    }
}
