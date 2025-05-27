/*namespace mosu
{
    using FastReport.DataVisualization.Charting;

*/
using System;
using System.Windows.Forms;
using FastReport.DataVisualization.Charting;
using mosu.mosu.HydraulicSystem;

namespace mosu
{
    public partial class MainForm : Form
    {
        private HydraulicSystemModel model;
        private Timer timer;
        private Chart chart;

        public MainForm(HydraulicSystemModel sharedModel)
        {
            model = sharedModel;
            InitializeChart();
            InitializeTimer();
        }

        private void InitializeChart()
        {
            chart = new Chart { Dock = DockStyle.Fill };
            var area = new ChartArea("Main");
            chart.ChartAreas.Add(area);

            var z1Series = new Series("z1") { ChartType = SeriesChartType.Line };
            var z2Series = new Series("z2") { ChartType = SeriesChartType.Line };

            chart.Series.Add(z1Series);
            chart.Series.Add(z2Series);

            Controls.Add(chart);
        }

        private void InitializeTimer()
        {
            timer = new Timer { Interval = 100 };
            timer.Tick += (s, e) => UpdateChart();
            timer.Start();
        }

        private void UpdateChart()
        {
            chart.Series["z1"].Points.AddY(model.z1);
            chart.Series["z2"].Points.AddY(model.z2);

            if (chart.Series["z1"].Points.Count > 100)
            {
                chart.Series["z1"].Points.RemoveAt(0);
                chart.Series["z2"].Points.RemoveAt(0);
            }

            chart.ChartAreas[0].RecalculateAxesScale();
            chart.Invalidate();
        }
    }

}
