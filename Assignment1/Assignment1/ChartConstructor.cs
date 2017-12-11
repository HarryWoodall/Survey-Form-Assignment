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

        // Field variables.

        private Data data;
        private Panel container;
        private FlowLayoutPanel statPanel;
        private FlowLayoutPanel tabLayoutPanel;

        private int mainCurrentIndex;
        private int currentTab = -1;
        private int question;
        private int graphIndex;

        private string[] ageLabels = { "< 10", "10 - 19", "20 - 29", "30 - 39", "40 - 49", "50 - 59", "60+" };
        private string[] genderLabels = { "Male", "Female" };
        private string[] ethnicityLabels = { "White / White British", "Mixed", "Asian / Asian British", "Black / Black British", "Other" };
        private string[] educationLabels = { "Primary", "Secondary", "Advanced", "Higher", "Other" };
        private string[] employmentLabels = { "Employed", "Self Employed", "Unemployed", "Looking for work", "Student", "Retired", "Other" };

        public ChartConstructor(Panel panel, int question, int graphIndex) {
            data = Data.getInstance();
            this.container = panel;
            this.question = question;
            this.graphIndex = graphIndex;
        }

        // returns a chart with these attributes
        public Chart initializeChart(string name) {
            Chart chart = new Chart();
            chart.Palette = ChartColorPalette.Pastel;
            chart.Titles.Add(name);
            chart.Titles[0].Font = new Font("Calibri", 32, FontStyle.Bold);
            ChartArea area = new ChartArea();

            Legend legend = new Legend();

            chart.ChartAreas.Add(area);
            chart.Legends.Add(legend);
            return chart;
        }

        // Returnes a series given a list and chart labels.
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
                series.Points[i].Font = new Font("Calibri", 12, FontStyle.Italic);

                if (values[i] == 0) {
                    series.Points[i]["PieLabelStyle"] = "Disabled";
                }
            }

            return series;
        }

        #region Charts

        // Returns the chart that gives age values.
        public Chart chartAge() {
            Chart chart = initializeChart("Age");
            chart.Series.Add(getChartSeries(chart, data.getAgeValues(), ageLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        // An overide of the chartAge function.
        public Chart chartAge(int question, int score) {
            Chart chart = initializeChart("Age");
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getAgeValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, ageLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }


        // Returns the chart that gives gender values. 
        public Chart chartGender() {
            Chart chart = initializeChart("Gender");
            chart.Series.Add(getChartSeries(chart, data.getGenderValues(), genderLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        // An overide of the chartGender function.
        public Chart chartGender(int question, int score) {
            Chart chart = initializeChart("Gender");
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getGenderValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, genderLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }


        // Returns the chart that gives ethnicity values.
        public Chart chartEthnicity() {
            Chart chart = initializeChart("Ethnicity");
            chart.Series.Add(getChartSeries(chart, data.getEthnicityValues(), ethnicityLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        // An overide of the chartEthnicity function.
        public Chart chartEthnicity(int question, int score) {
            Chart chart = initializeChart("Ethnicity");
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getEthnicityValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, ethnicityLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }


        // Returns the chart that gives the education values.
        public Chart chartEducation() {
            Chart chart = initializeChart("Education");
            chart.Series.Add(getChartSeries(chart, data.getEducationValues(), educationLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        // An overide of the chartEducation function.
        public Chart chartEducation(int question, int score) {
            Chart chart = initializeChart("Education");
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getEducationValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, educationLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }


        // Returns the chart that gives the employment values.
        public Chart chartEmployment() {
            Chart chart = initializeChart("Employment");
            chart.Series.Add(getChartSeries(chart, data.getEmploymentValues(), employmentLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }

        // An overide of the chartEmployment function.
        public Chart chartEmployment(int question, int score) {
            Chart chart = initializeChart("Employment");
            List<int> questionValues = getQuestion(question);
            List<int> valueList = data.getSubValues(questionValues, data.getEmploymentValues(), score);
            chart.Series.Add(getChartSeries(chart, valueList, employmentLabels));
            chart.MouseClick += new MouseEventHandler(chart_onClick);

            return chart;
        }


        // Returns a list depending on which question is active.
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

        // Returns the chart that give the question values.
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

        // An overide of the question fuction.
        public Chart chartQuestion(int number, int score) {
            Chart chart = chartQuestion(number);
            chart.Series[0].Points[score]["Exploded"] = "true";
            chart.Series[0].Points[score].BorderWidth = 3;
            chart.Series[0].Points[score].BorderColor = Color.Black;

            return chart;
        }

        #endregion

        public void chart_onClick(object sender, MouseEventArgs e) {
            Chart chart = (Chart)sender;
            HitTestResult results = chart.HitTest(e.X, e.Y);

            // Check to see if you clicked the chart itself.
            if (results.ChartElementType == ChartElementType.DataPoint) {

                // Reset each chart peice to default value.
                foreach (DataPoint point in chart.Series[0].Points) {
                    point["Exploded"] = "false";
                    point.BorderWidth = 0;
                }

                // 'Explode' the chart piece.
                // https://forums.asp.net/t/1549781.aspx?Explode+a+slice+of+a+pie+chart+microsoft+chart+controls+
                chart.Series[0].Points[results.PointIndex]["Exploded"] = "true";
                chart.Series[0].Points[results.PointIndex].BorderWidth = 3;
                chart.Series[0].Points[results.PointIndex].BorderColor = Color.Black;

                if (statPanel != null) {
                    statPanel.Dispose();
                }

                // re-center the chart.
                chart.Location = new Point(200, (container.Height - chart.Height) / 2);

                if (question > 0 && currentTab < 1) {
                    mainCurrentIndex = results.PointIndex;
                }

                // Generate tabs if chart values arn't total.
                if (question > 0) {
                    if (tabLayoutPanel == null) {
                        generateTabs(container);
                    }
                };

                generateStatistics(chart, results.PointIndex);
            }

            // Check to see if you clicked outside of the chart. 
            else if (results.ChartElementType == ChartElementType.PlottingArea) {

                // Reset the chart's position and state.
                foreach (DataPoint point in chart.Series[0].Points) {
                    point["Exploded"] = "false";
                    point.BorderWidth = 0;
                }

                if (statPanel != null) {
                    statPanel.Dispose();
                }

                chart.Location = new Point((container.Width - chart.Width) / 2, (container.Height - chart.Height) / 2);
            }
        }

        public void chartTab_onClick(object sender, EventArgs e) {
            Chart chart;
            Label label = (Label)sender;

            for (int i = 0; i < tabLayoutPanel.Controls.Count; i++) {

                // Reset the state of the tab.
                tabLayoutPanel.Controls[i].Size = new Size(150, 100);
                tabLayoutPanel.Controls[i].Font = new Font(label.Font, FontStyle.Regular);

                // Check which tab was clicked and draw the corresponding graph.
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

            // Increase the tab size.
            label.Size = new Size(175, 100);
            label.Font = new Font(label.Font, FontStyle.Bold);
        }

        public void generateStatistics(Chart chart, int chartIndex) {

            // Create a new FlowLayoutPanel and add it to container.
            statPanel = new FlowLayoutPanel();
            container.Controls.Add(statPanel);


            statPanel.Size = new Size(450, container.Height);
            statPanel.Dock = DockStyle.Right;
            statPanel.FlowDirection = FlowDirection.TopDown;
            statPanel.BackColor = Color.FromArgb(255, 100, 100, 100);
            statPanel.Padding = new Padding(0);

            // Generate different stats depending on tabIndex.
            if (question > 0 && currentTab < 1) {
                generateQuestionStats(chart, chartIndex);

            } else {
                generateDemographStats(chart, chartIndex);
            }
        }

        // Data generated from demographic answers.
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

        // Data generated from question answers.
        private void generateQuestionStats(Chart chart, int chartIndex) {
            Label titleLabel = new Label();
            titleLabel.Text = chart.Series[0].Points[chartIndex].AxisLabel;
            generateLabel(titleLabel);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Font = new Font("Calibri", 36, FontStyle.Underline);

            Label ageLabel = new Label();
            ageLabel.Text = "Average age: " + data.getMeanValue(getQuestion(question), chartIndex).ToString();
            generateLabel(ageLabel);
            ageLabel.Font = new Font("Calibri", 28, FontStyle.Bold);

            Label subTitleLabel = new Label();
            subTitleLabel.Text = "Modal values";
            generateLabel(subTitleLabel);
            subTitleLabel.Font = new Font("Calibri", 24, FontStyle.Underline);
            subTitleLabel.Margin = new Padding(0, 15, 0, 0);

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

        // Create and add a label to the statPanel Controls.
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

        // Generate and add the Tabs to the container.
        public void generateTabs(Panel container) {
            tabLayoutPanel = new FlowLayoutPanel();
            container.Controls.Add(tabLayoutPanel);
            tabLayoutPanel.Size = new Size(200, 100);
            tabLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
            tabLayoutPanel.Dock = DockStyle.Right;

            string[] labelText = { "TOTAL", "AGE", "GENDER", "ETHNICITY", "EDUCATION", "EMPLOYMENT" };

            // Create each tab.
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

                // Create bigger labels depending on what is selected.
                if (currentTab == -1) {
                    if (i == 0) {
                        tabLabel.Size = new Size(175, 100);
                        tabLabel.Font = new Font(tabLabel.Font, FontStyle.Bold);
                    }
                } 
                else if (i == currentTab) {
                    tabLabel.Size = new Size(175, 100);
                    tabLabel.Font = new Font(tabLabel.Font, FontStyle.Bold);
                }
            }
        }
        
        // Return the number of slices in a chart.
        public int getChartSize(Chart chart) {
            int result = 0;
            foreach (DataPoint point in chart.Series[0].Points) {
                result += Convert.ToInt32(point.YValues[0]);
            }
            return result;
        }

        // Replace an old chart with a new chart.
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
