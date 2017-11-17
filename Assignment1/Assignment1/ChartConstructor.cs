using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace Assignment1 {
    class ChartConstructor {

        Data data;
        Panel container;
        FlowLayoutPanel statPanel;

        public ChartConstructor(Data data, Panel panel) {
            this.data = data;
            this.container = panel;
        }

        public Chart initializeChart(string name) {
            Chart chart = new Chart();
            chart.Name = name;
            ChartArea area = new ChartArea();
            //area.Area3DStyle.Enable3D = true;

            Legend legend = new Legend();

            chart.ChartAreas.Add(area);
            chart.Legends.Add(legend);
            return chart;
        }

        public Series getChartSeries(Chart chart, List<int> list, string[] labels) {
            Series series = new Series();
            series.ChartType = SeriesChartType.Pie;
            int[] values = new int[labels.Length];

            for (int i = 0; i < values.Length; i++) {
                foreach (int item in list) {
                    if (item == i) {
                        values[i]++;
                    }
                }
                series.Points.AddXY(labels[i], values[i]);
            }

            return series;
        }

        public Chart chartAge() {
            Chart chart = initializeChart("Age");
            string[] chartLabels = { "< 10", "10 - 19", "20 - 29", "30 - 39", "40 - 49", "50 - 59", "60+" };
            chart.Series.Add(getChartSeries(chart, data.getAgeValues(), chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart chartGender() {
            Chart chart = initializeChart("Gender");
            string[] chartLabels = { "Male", "Female" };
            chart.Series.Add(getChartSeries(chart, data.getGenderValues(), chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart chartEthnicity() {
            Chart chart = initializeChart("Ethnicity");
            string[] chartLabels = { "White / White British", "Mixed", "Asian / Asian British", "Black / Black British", "Other" };
            chart.Series.Add(getChartSeries(chart, data.getEthnicityValues(), chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart chartEducation() {
            Chart chart = initializeChart("Education");
            string[] chartLabels = { "Primary", "Secondary", "Advanced", "Higher", "Other" };
            chart.Series.Add(getChartSeries(chart, data.getEducationValues(), chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart chartEmployment() {
            Chart chart = initializeChart("Employment");
            string[] chartLabels = { "Employed", "Self Employed", "Unemployed", "Looking for work", "Student", "Retired", "Other" };
            chart.Series.Add(getChartSeries(chart, data.getEmploymentValues(), chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart chartQuestion(int number) {
            Chart chart;
            string[] chartLabels = { "Strongly Agree", "Agree", "Neither Agree", "Dissagree", "Strongly Dissagree" };

            switch (number) {
                case 0:
                    chart = initializeChart("I Enjoyed the Sculpture");
                    chart.Series.Add(getChartSeries(chart, data.getQ1Values(), chartLabels));
                    break;
                case 1:
                    chart = initializeChart("I am curious as to how it works");
                    chart.Series.Add(getChartSeries(chart, data.getQ2Values(), chartLabels));
                    break;
                default:
                    chart = initializeChart("I want to know more about science as a result");
                    chart.Series.Add(getChartSeries(chart, data.getQ3Values(), chartLabels));
                    break;
            }
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public void chart_onClick(object sender, MouseEventArgs e) {
            Chart chart = (Chart)sender;
            HitTestResult results = chart.HitTest(e.X, e.Y);

            if (results.ChartElementType == ChartElementType.DataPoint) {
                foreach (DataPoint point in chart.Series[0].Points) {
                    point["Exploded"] = "false";
                    point.BorderWidth = 0;
                }
                // https://forums.asp.net/t/1549781.aspx?Explode+a+slice+of+a+pie+chart+microsoft+chart+controls+
                chart.Series[0].Points[results.PointIndex]["Exploded"] = "true";
                chart.Series[0].Points[results.PointIndex].BorderWidth = 3;
                chart.Series[0].Points[results.PointIndex].BorderColor = Color.Black;

                if (statPanel != null) {
                    statPanel.Dispose();
                }
                generateStatistics(1, chart);
            }

            //Console.WriteLine(results.ChartArea.InnerPlotPosition.ToString());
        }

        public void generateStatistics(int question, Chart chart) {
            statPanel = new FlowLayoutPanel();
            statPanel.Size = new Size(500, container.Height);
            statPanel.Location = new Point(chart.Location.X + chart.Width + 100, 50);
            statPanel.BackColor = Color.Black;
            statPanel.Padding = new Padding(0);
            container.Controls.Add(statPanel);
        }
    }
}
