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

        private Data data;
        private Panel container;
        private FlowLayoutPanel statPanel;
        private FlowLayoutPanel tabLayoutPanel;

        private int currentScore;
        private int question;

        public ChartConstructor(Data data, Panel panel, int question) {
            this.data = data;
            this.container = panel;
        }

        public Chart initializeChart(string name) {
            Chart chart = new Chart();
            chart.Titles.Add(name);
            chart.Titles[0].Font = new Font("Calibri", 32, FontStyle.Bold);
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

        //TODO change chartLabels to memeber variable.

        public Chart totalAge() {
            Chart chart = initializeChart("Age");
            string[] chartLabels = { "< 10", "10 - 19", "20 - 29", "30 - 39", "40 - 49", "50 - 59", "60+" };
            chart.Series.Add(getChartSeries(chart, data.getAgeValues(), chartLabels));
            //chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart totalGender() {
            Chart chart = initializeChart("Gender");
            string[] chartLabels = { "Male", "Female" };
            chart.Series.Add(getChartSeries(chart, data.getGenderValues(), chartLabels));
            //chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart totalEthnicity() {
            Chart chart = initializeChart("Ethnicity");
            string[] chartLabels = { "White / White British", "Mixed", "Asian / Asian British", "Black / Black British", "Other" };
            chart.Series.Add(getChartSeries(chart, data.getEthnicityValues(), chartLabels));
            //chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart totalEducation() {
            Chart chart = initializeChart("Education");
            string[] chartLabels = { "Primary", "Secondary", "Advanced", "Higher", "Other" };
            chart.Series.Add(getChartSeries(chart, data.getEducationValues(), chartLabels));
            //chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart totalEmployment() {
            Chart chart = initializeChart("Employment");
            string[] chartLabels = { "Employed", "Self Employed", "Unemployed", "Looking for work", "Student", "Retired", "Other" };
            chart.Series.Add(getChartSeries(chart, data.getEmploymentValues(), chartLabels));
            //chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart chartAge(int question, int score) {
            Chart chart = initializeChart("Age");
            string[] chartLabels = { "< 10", "10 - 19", "20 - 29", "30 - 39", "40 - 49", "50 - 59", "60+" };
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getAgeValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, chartLabels));

            return chart;
        }

        public Chart chartGender(int question, int score) {
            Chart chart = initializeChart("Gender");
            string[] chartLabels = { "Male", "Female" };
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getGenderValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, chartLabels));

            return chart;
        }

        public Chart chartEthnicity(int question, int score) {
            Chart chart = initializeChart("Ethnicity");
            string[] chartLabels = { "White / White British", "Mixed", "Asian / Asian British", "Black / Black British", "Other" };
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getEthnicityValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, chartLabels));

            return chart;
        }

        public Chart chartEducation(int question, int score) {
            Chart chart = initializeChart("Education");
            string[] chartLabels = { "Primary", "Secondary", "Advanced", "Higher", "Other" };
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getEducationValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, chartLabels));

            return chart;
        }

        public Chart chartEmployment(int question, int score) {
            Chart chart = initializeChart("Employment");
            string[] chartLabels = { "Employed", "Self Employed", "Unemployed", "Looking for work", "Student", "Retired", "Other" };
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getEmploymentValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, chartLabels));

            return chart;
        }

        public List<int> getQuestion(int question) {
            List<int> result;
            switch (question) {
                case 1:
                    result = data.getQ1Values();
                    break;
                case 2:
                    result = data.getQ2Values();
                    break;
                default:
                    result = data.getQ3Values();
                    break;
            }
            return result;
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

        public Chart chartQuestion(int number, int score) {
            Chart chart = chartQuestion(number);
            chart.Series[0].Points[score]["Exploded"] = "true";
            chart.Series[0].Points[score].BorderWidth = 3;
            chart.Series[0].Points[score].BorderColor = Color.Black;

            return chart;
        }

        public void chart_onClick(object sender, MouseEventArgs e) {
            Chart chart = (Chart)sender;
            HitTestResult results = chart.HitTest(e.X, e.Y);

            currentScore = results.PointIndex;

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

                if (tabLayoutPanel != null) {
                    tabLayoutPanel.Dispose();
                }

                chart.Location = new Point(200, (container.Height - chart.Height) / 2);
                generateTabs(container);
                generateStatistics(1, chart, results.PointIndex);
            }
            else if (results.ChartElementType == ChartElementType.PlottingArea) {
                foreach (DataPoint point in chart.Series[0].Points) {
                    point["Exploded"] = "false";
                    point.BorderWidth = 0;
                }
                statPanel.Dispose();
                chart.Location = new Point((container.Width - chart.Width) / 2, (container.Height - chart.Height) / 2);
            }
        }

        public void tab_onClick(object sender, EventArgs e) {
            Chart chart;
            Label label = (Label)sender;

            for (int i = 0; i < tabLayoutPanel.Controls.Count; i++) {

                tabLayoutPanel.Controls[i].Size = new Size(150, 100);
                tabLayoutPanel.Controls[i].Font = new Font(label.Font, FontStyle.Regular);

                if (tabLayoutPanel.Controls[i] as Label == label) {
                    switch (i) {
                        case 0:
                            chart = chartQuestion(question, currentScore);
                            break;
                        case 1:
                            chart = chartAge(question, currentScore);
                            break;
                        case 2:
                            chart = chartGender(question, currentScore);
                            break;
                        case 3:
                            chart = chartEthnicity(question, currentScore);
                            break;
                        case 4:
                            chart = chart = chartEducation(question, currentScore);
                            break;
                        default:
                            chart = chartEmployment(question, currentScore);
                            break;
                    }
                    reDrawChart(chart);
                }
            }
            label.Size = new Size(200, 100);
            label.Font = new Font(label.Font, FontStyle.Bold);
        }

        public void generateStatistics(int question, Chart chart, int chartIndex) {
            statPanel = new FlowLayoutPanel();
            container.Controls.Add(statPanel);

            statPanel.Size = new Size(450, container.Height);
            statPanel.Dock = DockStyle.Right;
            statPanel.FlowDirection = FlowDirection.TopDown;
            statPanel.BackColor = Color.FromArgb(255, 100, 100, 100);
            statPanel.Padding = new Padding(0);

            Label ageLabel = new Label();
            ageLabel.Text = "Average age: " + data.getMeanValue(data.getQ1Values(), chartIndex).ToString();
            ageLabel.ForeColor = Color.White;
            generateLabel(ageLabel);

            Label genderLabel = new Label();
            Value genderValue = data.getModalValues(data.getQ1Values(), chartIndex, Value.TYPE_GENDER);
            genderLabel.Text = genderValue.getPercentage() + "% are " + genderValue.getValue();
            genderLabel.ForeColor = Color.White;
            generateLabel(genderLabel);

            Label educationLabel = new Label();
            Value educationValue = data.getModalValues(data.getQ1Values(), chartIndex, Value.TYPE_EDUCATION);
            educationLabel.Text = educationValue.getPercentage() + "% have " + educationValue.getValue() + " education";
            educationLabel.ForeColor = Color.White;
            generateLabel(educationLabel);

            Label ethnicityLabel = new Label();
            Value ethnicityValue = data.getModalValues(data.getQ1Values(), chartIndex, Value.TYPE_ETHNISITY);
            ethnicityLabel.Text = ethnicityValue.getPercentage() + "% are of " + ethnicityValue.getValue() + " ethnicity";
            ethnicityLabel.ForeColor = Color.White;
            generateLabel(ethnicityLabel);

            Label employmentLabel = new Label();
            Value employmentValue = data.getModalValues(data.getQ1Values(), chartIndex, Value.TYPE_EMPLOYMENT);
            employmentLabel.Text = employmentValue.getPercentage() + "% are " + employmentValue.getValue();
            employmentLabel.ForeColor = Color.White; 
            generateLabel(employmentLabel);
        }

        public void generateLabel(Label label) {
            Font font = new Font("Calibri", 18, FontStyle.Bold);

            statPanel.Controls.Add(label);
            label.Font = font;
            label.AutoSize = false;
            label.Size = new Size(statPanel.Width, 100);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Margin = new Padding(0);
        }

        public void generateTabs(Panel container) {
            tabLayoutPanel = new FlowLayoutPanel();
            container.Controls.Add(tabLayoutPanel);
            tabLayoutPanel.Size = new Size(200, 100);
            tabLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
            tabLayoutPanel.Dock = DockStyle.Right;

            string[] labelText = { "TOTAL", "AGE", "GENDER", "ETHNICITY", "EDUCATION", "EMPLOYMENT" };

            for (int i = 0; i < labelText.Length; i++) {
                Label tabLabel = new Label();
                tabLayoutPanel.Controls.Add(tabLabel);
                tabLabel.AutoSize = false;
                tabLabel.Size = new Size(150, 100);
                tabLabel.Text = labelText[i];
                tabLabel.ForeColor = Color.White;
                tabLabel.BackColor = Color.FromArgb(255, 255, 128, 0);
                tabLabel.TextAlign = ContentAlignment.MiddleCenter;
                tabLabel.Click += new EventHandler(tab_onClick);

                if (i == 0) {
                    tabLabel.Margin = new Padding(0, (tabLayoutPanel.Height - 600) / 2, 0, 0);
                } else {
                    tabLabel.Margin = new Padding(0, 0, 0, 0);
                }
            }
        }

        public void reDrawChart(Chart newChart) {
            Chart chart = newChart;
            foreach (Control control in container.Controls) {
                if (control is Chart) {
                    Chart oldChart = (Chart)control;
                    chart.Size = oldChart.Size;
                    chart.Location = oldChart.Location;
                    container.Controls.Remove(control);
                    container.Controls.Add(newChart);
                }
            }
        }
    }
}
