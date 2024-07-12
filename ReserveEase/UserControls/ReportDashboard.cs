using ReserveEase.DB;
using ReserveEase.DB.ORMs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReserveEase.UserControls {
    public partial class ReportDashboard : UserControl {
        private List<DateTime> dateTimes = new List<DateTime>();
        private List<double> dateValues = new List<double>();

        public ReportDashboard() {
            InitializeComponent();
        }

        private void ReportDashboard_Load(object sender, EventArgs e) {
            reportTypeComboBox.SelectedIndex = 0;
        }

        private void generateReportButton_Click(object sender, EventArgs e) {
            dateTimes.Clear();
            dateValues.Clear();
            if (reportTypeComboBox.SelectedIndex == 0) {
                reportDataGridView.DataSource = Database.conn.Table<Reservation>().ToList();

                DateTime? dt = null;
                foreach (Reservation r in Database.conn.Table<Reservation>().ToList()) {
                    if (!dt.HasValue || dt.Value.Date != r.DateOccurred.Date) {
                        dt = r.DateOccurred;
                        dateTimes.Add(dt.Value);
                        dateValues.Add(0);
                    }
                    dateValues[dateValues.Count - 1]++;
                }

                List<string> date = new List<string>();
                foreach (DateTime dtx in dateTimes) {
                    date.Add(dtx.ToString("dd/MM/yyyy"));
                }
                RefreshPlot(new double[][] { dateValues.ToArray() }, date.ToArray(), reportTypeComboBox.SelectedItem.ToString(), "Date", "n of Occupation.");
                return;
            } else if (reportTypeComboBox.SelectedIndex == 1) {
                reportDataGridView.DataSource = Database.conn.Table<Payment>().ToList();

                DateTime? dt = null;
                foreach (Payment r in Database.conn.Table<Payment>().ToList()) {
                    if (!dt.HasValue || dt.Value.Date != r.DateOccurred.Date) {
                        dt = r.DateOccurred;
                        dateTimes.Add(dt.Value);
                        dateValues.Add(0);
                    }
                    dateValues[dateValues.Count - 1] += r.PaymentAmount;
                }

                List<string> date = new List<string>();
                foreach (DateTime dtx in dateTimes) {
                    date.Add(dtx.ToString("dd/MM/yyyy"));
                }
                RefreshPlot(new double[][] { dateValues.ToArray() }, date.ToArray(), reportTypeComboBox.SelectedItem.ToString(), "Date", "Amount");
                return;

            }
        }

        private void RefreshPlot(double[][] values, string[] xLabelArr, string title, string xLabel, string yLabel) {
            formsPlot1.Plot.Clear();
            formsPlot1.Refresh();

            List<double> pos = new List<double>();
            for (int i = 0; i < xLabelArr.Length; i++)
                pos.Add(i);

            if (values[0].Length == 0) return;
            formsPlot1.Plot.AddBar(values[0], pos.ToArray());

            formsPlot1.Plot.XTicks(pos.ToArray(), xLabelArr);
            formsPlot1.Plot.SetAxisLimits(yMin: 0);
            formsPlot1.Plot.Title(title);
            formsPlot1.Plot.Grid(enable: false);
            formsPlot1.Plot.XLabel(xLabel);
            formsPlot1.Plot.YLabel(yLabel);

            formsPlot1.Refresh();
        }
    }
}
