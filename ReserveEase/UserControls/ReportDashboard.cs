using ReserveEase.DB;
using ReserveEase.DB.ORMs;
using ReserveEase.DB.ORMs.Non_ORM;
using ScottPlot.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace ReserveEase.UserControls {
    public partial class ReportDashboard : UserControl {
        private List<DateTime> dateTimes = new List<DateTime>();
        private List<double> dateValues = new List<double>();
        private List<PrintReserve> reservations = new List<PrintReserve>();

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

        private void button1_Click(object sender, EventArgs e) {
            reservations.Clear();
            v.DataSource = null;
            foreach (Reservation rv in Database.conn.Table<Reservation>()) {
                try {
                    Room r = Database.conn.Table<Room>().FirstOrDefault(rx => rx.RoomNumber == rv.RoomNumber);

                    Payment p = Database.conn.Table<Payment>().FirstOrDefault(px => px.GuestID.Equals(rv.GuestID));
                    if (p == null || r == null) continue;
                    PrintReserve pr = new PrintReserve();
                    pr.RoomNumber = rv.RoomNumber;
                    pr.RoomType = r.RoomType;
                    pr.Duration = rv.Rate;
                    pr.Date = rv.DateOccurred;
                    pr.TotalAmount = p.PaymentAmount;
                    reservations.Add(pr);
                } catch {

                }
            }

            v.DataSource = reservations;
            v.Refresh();
            v.Columns[0].HeaderText = "Date";
            v.Columns[1].HeaderText = "Room Number";
            v.Columns[2].HeaderText = "Type";
            v.Columns[3].HeaderText = "Duration";
            v.Columns[4].HeaderText = "Amount";
            v.Refresh();

            PrintPreviewDialog diag = new PrintPreviewDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            diag.Document = doc;
            diag.ShowDialog();
        }

        private int pageIndex = 0;
        private void Doc_PrintPage(object sender, PrintPageEventArgs e) {
            System.Drawing.Font f = new System.Drawing.Font("Arial", 12);
            System.Drawing.Font boldF = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            Brush b = new SolidBrush(Color.Black);

            int x = 50;
            int y = 50;
            int lineHeight = 20;

            string title = "ReserveEase";
            System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 18, FontStyle.Bold);
            SizeF titleSize = e.Graphics.MeasureString(title, titleFont);

            e.Graphics.DrawString(title, titleFont, b, (e.PageBounds.Width - titleSize.Width) / 2, y);

            y += (int)titleSize.Height + 15;

            int amountLine = y + 5;
            Pen boldPen = new Pen(Color.Black, 2);
            e.Graphics.DrawLine(boldPen, x, amountLine, e.MarginBounds.Right, amountLine);

            y += lineHeight * 2;

            // Calculate column widths based on content
            int[] columnWidths = new int[v.Columns.Count];
            for (int i = 0; i < v.Columns.Count; i++) {
                int maxContentWidth = 0;
                for (int rowIndex = pageIndex * 40; rowIndex <= Math.Min((pageIndex + 1) * 40 - 1, v.Rows.Count - 1); rowIndex++) {
                    string cellValue = v.Rows[rowIndex].Cells[i].FormattedValue.ToString();
                    SizeF cellSize = e.Graphics.MeasureString(cellValue, f);
                    maxContentWidth = Math.Max(maxContentWidth, (int)cellSize.Width);
                }
                SizeF headerSize = e.Graphics.MeasureString(v.Columns[i].HeaderText, boldF);
                int columnWidth = Math.Max(maxContentWidth, (int)headerSize.Width) + 20; // Add padding
                columnWidths[i] = columnWidth;
            }

            // Calculate total width of all columns
            int totalColumnWidth = columnWidths.Sum();

            // Calculate the starting x-coordinate for drawing the DataGridView
            int dataGridViewX = (e.PageBounds.Width - totalColumnWidth) / 2;

            // Draw DataGridView headers
            int headerX = dataGridViewX;
            for (int i = 0; i < v.Columns.Count; i++) {
                int columnWidth = columnWidths[i];
                e.Graphics.DrawString(v.Columns[i].HeaderText, boldF, b, new RectangleF(headerX, y, columnWidth, lineHeight), StringFormat.GenericTypographic);
                headerX += columnWidth;
            }
            y += lineHeight + 10; // Add spacing after headers

            // Draw DataGridView content
            int itemsPrinted = 0;
            for (int rowIndex = pageIndex * 40; rowIndex <= Math.Min((pageIndex + 1) * 40 - 1, v.Rows.Count - 1); rowIndex++) {
                DataGridViewRow row = v.Rows[rowIndex];
                if (!row.IsNewRow) {
                    int contentX = dataGridViewX;
                    int rowHeight = row.Height;
                    for (int i = 0; i < v.Columns.Count; i++) {
                        int columnWidth = columnWidths[i];
                        string cellValue = row.Cells[i].FormattedValue.ToString();
                        StringFormat format = new StringFormat(StringFormatFlags.LineLimit | StringFormatFlags.NoClip) {
                            Alignment = StringAlignment.Near, // Align content to the left
                            LineAlignment = StringAlignment.Center
                        };
                        e.Graphics.DrawString(cellValue, f, b, new RectangleF(contentX, y, columnWidth, lineHeight), format);
                        contentX += columnWidth;
                    }
                    y += lineHeight;
                    itemsPrinted += 1;
                }
            }

            // Check if there are remaining items to print on the next page
            if (v.Rows.Count > (pageIndex + 1) * 40) {
                e.HasMorePages = true;
                pageIndex += 1; // Move to the next page
            } else {
                e.HasMorePages = false;
                pageIndex = 0; // Reset page index for next print
            }

        }
    }
}
