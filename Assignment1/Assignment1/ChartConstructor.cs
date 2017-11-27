using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace Assignment1 {
    public class ChartConstructor {

        private Data data;
        private Panel container;
        private FlowLayoutPanel statPanel;
        private FlowLayoutPanel tabLayoutPanel;

        private int mainCurrentIndex;
        private int currentTab = -1;
        private int question;
        private int graphIndex;

        public ChartConstructor(Data data, Panel panel, int question, int graphIndex) {
            this.data = data;
            this.container = panel;
            this.question = question;
            this.graphIndex = graphIndex;
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

                if (values[i] == 0) {
                    series.Points[i]["PieLabelStyle"] = "Disabled";
                }
            }

            return series;
        }

        //TODO change chartLabels to memeber variable.

        public Chart totalAge() {
            Chart chart = initializeChart("Age");
            string[] chartLabels = { "< 10", "10 - 19", "20 - 29", "30 - 39", "40 - 49", "50 - 59", "60+" };
            chart.Series.Add(getChartSeries(chart, data.getAgeValues(), chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart totalGender() {
            Chart chart = initializeChart("Gender");
            string[] chartLabels = { "Male", "Female" };
            chart.Series.Add(getChartSeries(chart, data.getGenderValues(), chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart totalEthnicity() {
            Chart chart = initializeChart("Ethnicity");
            string[] chartLabels = { "White / White British", "Mixed", "Asian / Asian British", "Black / Black British", "Other" };
            chart.Series.Add(getChartSeries(chart, data.getEthnicityValues(), chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart totalEducation() {
            Chart chart = initializeChart("Education");
            string[] chartLabels = { "Primary", "Secondary", "Advanced", "Higher", "Other" };
            chart.Series.Add(getChartSeries(chart, data.getEducationValues(), chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart totalEmployment() {
            Chart chart = initializeChart("Employment");
            string[] chartLabels = { "Employed", "Self Employed", "Unemployed", "Looking for work", "Student", "Retired", "Other" };
            chart.Series.Add(getChartSeries(chart, data.getEmploymentValues(), chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart chartAge(int question, int score) {
            Chart chart = initializeChart("Age");
            string[] chartLabels = { "< 10", "10 - 19", "20 - 29", "30 - 39", "40 - 49", "50 - 59", "60+" };
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getAgeValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart chartGender(int question, int score) {
            Chart chart = initializeChart("Gender");
            string[] chartLabels = { "Male", "Female" };
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getGenderValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart chartEthnicity(int question, int score) {
            Chart chart = initializeChart("Ethnicity");
            string[] chartLabels = { "White / White British", "Mixed", "Asian / Asian British", "Black / Black British", "Other" };
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getEthnicityValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart chartEducation(int question, int score) {
            Chart chart = initializeChart("Education");
            string[] chartLabels = { "Primary", "Secondary", "Advanced", "Higher", "Other" };
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getEducationValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        public Chart chartEmployment(int question, int score) {
            Chart chart = initializeChart("Employment");
            string[] chartLabels = { "Employed", "Self Employed", "Unemployed", "Looking for work", "Student", "Retired", "Other" };
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getEmploymentValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, chartLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

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

                chart.Location = new Point(200, (container.Height - chart.Height) / 2);

                if (question > 0 && currentTab < 1) {
                    mainCurrentIndex = results.PointIndex;
                }

                if (question > 0) {
                    if (tabLayoutPanel == null) {
                        generateTabs(container);
                    }
                };

                generateStatistics(chart, results.PointIndex);
            }
            // This is causing issues.
            else if (results.ChartElementType == ChartElementType.PlottingArea) {
                foreach (DataPoint point in chart.Series[0].Points) {
                    point["Exploded"] = "false";
                    point.BorderWidth = 0;
                }

                if (statPanel != null) {
                    statPanel.Dispose();
                }

                if (tabLayoutPanel != null) {
                    //tabLayoutPanel.Dispose();
                    //tabLayoutPanel = null;
                    //currentTab = -1;
                }

                chart.Location = new Point((container.Width - chart.Width) / 2, (container.Height - chart.Height) / 2);
            }
        }

        public void chartTab_onClick(object sender, EventArgs e) {
            Chart chart;
            Label label = (Label)sender;

            for (int i = 0; i < tabLayoutPanel.Controls.Count; i++) {

                tabLayoutPanel.Controls[i].Size = new Size(150, 100);
                tabLayoutPanel.Controls[i].Font = new Font(label.Font, FontStyle.Regular);

                if (tabLayoutPanel.Controls[i] as Label == label) {
                    switch (i) {
                        case 0:
                            chart = chartQuestion(question, mainCurrentIndex);
                            break;
                        case 1:
                            chart = chartAge(question, mainCurrentIndex);
                            break;
                        case 2:
                            chart = chartGender(question, mainCurrentIndex);
                            break;
                        case 3:
                            chart = chartEthnicity(question, mainCurrentIndex);
                            break;
                        case 4:
                            chart = chart = chartEducation(question, mainCurrentIndex);
                            break;
                        default:
                            chart = chartEmployment(question, mainCurrentIndex);
                            break;
                    }
                    currentTab = i;
                    reDrawChart(chart, container);

                    if (i > 0) {
                        statPanel.Dispose();
                    }
                }
            }
            label.Size = new Size(200, 100);
            label.Font = new Font(label.Font, FontStyle.Bold);
        }

        public void generateStatistics(Chart chart, int chartIndex) {
            statPanel = new FlowLayoutPanel();
            container.Controls.Add(statPanel);

            statPanel.Size = new Size(450, container.Height);
            statPanel.Dock = DockStyle.Right;
            statPanel.FlowDirection = FlowDirection.TopDown;
            statPanel.BackColor = Color.FromArgb(255, 100, 100, 100);
            statPanel.Padding = new Padding(0);

            if (question > 0 && currentTab < 1) {
                generateQuestionStats(chart, chartIndex);

            } else {
                generateDemographStats(chart, chartIndex);
            }
        }

        private void generateDemographStats(Chart chart, int chartIndex) {
            if (question > 0) {
                string[] headerText = { "STRONGLY AGREE", "AGREE", "NEITHER AGREE", "DISAGREE", "STRONGLY DISAGREE" };
                Label header = new Label();
                header.Text = headerText[mainCurrentIndex];
                generateLabel(header);
                header.Height = 200;
                header.Margin = new Padding(0, 50, 0, 0);
                header.TextAlign = ContentAlignment.MiddleCenter;
                header.Font = new Font("Calibri", 38, FontStyle.Bold);
            }

            Label titleLabel = new Label();
            titleLabel.Text = chart.Series[0].Points[chartIndex].AxisLabel;
            generateLabel(titleLabel);
            titleLabel.Height = 200;
            titleLabel.Margin = new Padding(0, (statPanel.Height - (4 * titleLabel.Height)) / 2, 0, 0);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Font = new Font("Calibri", 36, FontStyle.Underline);

            Label percentLabel = new Label();
            percentLabel.Text = Convert.ToInt32((chart.Series[0].Points[chartIndex].YValues[0] / getChartSize(chart)) * 100) + "%";
            generateLabel(percentLabel);
            percentLabel.Height = 200;
            percentLabel.Font = new Font("Calibri", 48, FontStyle.Bold);
            percentLabel.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void generateQuestionStats(Chart chart, int chartIndex) {
            Label titleLabel = new Label();
            titleLabel.Text = chart.Series[0].Points[chartIndex].AxisLabel;
            generateLabel(titleLabel);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Font = new Font("Calibri", 36, FontStyle.Underline);

            Label ageLabel = new Label();
            ageLabel.Text = "Average age: " + data.getMeanValue(getQuestion(question), chartIndex).ToString();
            generateLabel(ageLabel);

            Label genderLabel = new Label();
            Value genderValue = data.getModalValues(getQuestion(question), chartIndex, Value.TYPE_GENDER);
            genderLabel.Text = genderValue.getPercentage() + "% are " + genderValue.getValue();
            generateLabel(genderLabel);

            Label educationLabel = new Label();
            Value educationValue = data.getModalValues(getQuestion(question), chartIndex, Value.TYPE_EDUCATION);
            educationLabel.Text = educationValue.getPercentage() + "% have " + educationValue.getValue() + " education";
            generateLabel(educationLabel);

            Label ethnicityLabel = new Label();
            Value ethnicityValue = data.getModalValues(getQuestion(question), chartIndex, Value.TYPE_ETHNISITY);
            ethnicityLabel.Text = ethnicityValue.getPercentage() + "% are of " + ethnicityValue.getValue() + " ethnicity";
            generateLabel(ethnicityLabel);

            Label employmentLabel = new Label();
            Value employmentValue = data.getModalValues(getQuestion(question), chartIndex, Value.TYPE_EMPLOYMENT);
            employmentLabel.Text = employmentValue.getPercentage() + "% are " + employmentValue.getValue();
            generateLabel(employmentLabel);
        }

        public void generateLabel(Label label) {
            Font font = new Font("Calibri", 18, FontStyle.Bold);

            statPanel.Controls.Add(label);
            label.ForeColor = Color.White;
            label.Font = font;
            label.AutoSize = false;
            label.Size = new Size(statPanel.Width, 100);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Padding = new Padding(10, 0, 0, 0);
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
                tabLabel.Click += new EventHandler(chartTab_onClick);

                if (i == 0) {
                    tabLabel.Margin = new Padding(0, (tabLayoutPanel.Height - 600) / 2, 0, 0);
                    tabLabel.BackColor = Color.FromArgb(255, 204, 102, 0);
                } else {
                    tabLabel.Margin = new Padding(0, 0, 0, 0);
                }

                if (currentTab == -1) {
                    tabLabel.Size = new Size(200, 100);
                    tabLabel.Font = new Font(tabLabel.Font, FontStyle.Bold);
                } 
                else if (i == currentTab) {
                    tabLabel.Size = new Size(200, 100);
                    tabLabel.Font = new Font(tabLabel.Font, FontStyle.Bold);
                }
            }
        }
        
        public int getChartSize(Chart chart) {
            int result = 0;
            foreach (DataPoint point in chart.Series[0].Points) {
                result += Convert.ToInt32(point.YValues[0]);
            }
            return result;
        }

        public void reDrawChart(Chart newChart, Panel panel) {
            Chart chart = newChart;
            foreach (Control control in container.Controls) {
                if (control is Chart) {
                    Chart oldChart = (Chart)control;
                    chart.Size = oldChart.Size;
                    if (currentTab != 0) {
                        chart.Location = new Point((container.Width - chart.Width) / 2, oldChart.Location.Y);
                    } else {
                        chart.Location = oldChart.Location;
                    }
                    container.Controls.Remove(control);
                    container.Controls.Add(newChart);
                }
            }
        }
    }
}
