using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Assignment1 {
    class ChartConstructor {

        Data data;

        public ChartConstructor(Data data) {
            this.data = data;
        }

        public Chart chartAge() {
            Chart chart = new Chart();
            chart.Name = "Age";
            ChartArea area = new ChartArea();
            area.Area3DStyle.Enable3D = true;

            Legend legend = new Legend();

            chart.ChartAreas.Add(area);
            chart.Legends.Add(legend);
            Series series = new Series();
            series.ChartType = SeriesChartType.Pie;

            int[] chartValues = new int[7];
            string[] chartLabels = { "< 10", "10 - 19", "20 - 29", "30 - 39", "40 - 49", "50 - 59", "60+" };
            for (int i = 0; i < 7; i++) {
                foreach (int item in data.getAgeValues()) {
                    if (item == i) {
                        chartValues[i]++;
                    }
                }
                series.Points.AddXY(chartLabels[i], chartValues[i]);
            }

            chart.Series.Add(series);
            return chart;
        }
    }
}
