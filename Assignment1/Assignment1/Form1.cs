using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Assignment1 {

    public partial class Form1 : Form {

        // Field Variables
        public Data data = new Data();

        private Question question1;
        private Question question2;
        private Question question3;
        private List<Question> questionList = new List<Question>();
        private List<Label> sideBar;

        private float xScale = 1;
        private float yScale = 1;

        public Form1() {
            InitializeComponent();

            // Maximise form on startup
            this.WindowState = FormWindowState.Maximized;
            initializeQuestions();
            getData();
            inflateSidebar();
            inflateGraphic(0);
            timer1.Start();
        }

        public void initializeQuestions() {
            question1 = new Question();
            question2 = new Question();
            question3 = new Question();

            questionList.Add(question1);
            questionList.Add(question2);
            questionList.Add(question3);

            question1.addToolTip(q1ToolTip1);
            question1.addToolTip(q1ToolTip2);
            question1.addToolTip(q1toolTip3);
            question1.addToolTip(q1ToolTip4);
            question1.addToolTip(q1ToolTip5);

            question1.addMainPanel(q1Option1);
            question1.addMainPanel(q1Option2);
            question1.addMainPanel(q1Option3);
            question1.addMainPanel(q1Option4);
            question1.addMainPanel(q1Option5);

            question1.addSelectedPanel(q1Selected1);
            question1.addSelectedPanel(q1Selected2);
            question1.addSelectedPanel(q1Selected3);
            question1.addSelectedPanel(q1Selected4);
            question1.addSelectedPanel(q1Selected5);


            question2.addToolTip(q2ToolTip1);
            question2.addToolTip(q2ToolTip2);
            question2.addToolTip(q2ToolTip3);
            question2.addToolTip(q2ToolTip4);
            question2.addToolTip(q2ToolTip5);

            question2.addMainPanel(q2Option1);
            question2.addMainPanel(q2Option2);
            question2.addMainPanel(q2Option3);
            question2.addMainPanel(q2Option4);
            question2.addMainPanel(q2Option5);

            question2.addSelectedPanel(q2Selected1);
            question2.addSelectedPanel(q2Selected2);
            question2.addSelectedPanel(q2Selected3);
            question2.addSelectedPanel(q2Selected4);
            question2.addSelectedPanel(q2Selected5);


            question3.addToolTip(q3ToolTip1);
            question3.addToolTip(q3ToolTip2);
            question3.addToolTip(q3ToolTip3);
            question3.addToolTip(q3ToolTip4);
            question3.addToolTip(q3ToolTip5);

            question3.addMainPanel(q3Option1);
            question3.addMainPanel(q3Option2);
            question3.addMainPanel(q3Option3);
            question3.addMainPanel(q3Option4);
            question3.addMainPanel(q3Option5);

            question3.addSelectedPanel(q3Selected1);
            question3.addSelectedPanel(q3Selected2);
            question3.addSelectedPanel(q3Selected3);
            question3.addSelectedPanel(q3Selected4);
            question3.addSelectedPanel(q3Selected5);


            genderBox.Items.Add("MALE");
            genderBox.Items.Add("FEMALE");

            ethnicityBox.Items.Add("WHITE / WHITE BRITISH");
            ethnicityBox.Items.Add("MIXED");
            ethnicityBox.Items.Add("ASIAN / ASIAN BRITISH");
            ethnicityBox.Items.Add("BLACK / BLACK BRITISH");
            ethnicityBox.Items.Add("OTHER");

            educationBox.Items.Add("PRIMARY");
            educationBox.Items.Add("SECONDARY");
            educationBox.Items.Add("ADVANCED");
            educationBox.Items.Add("HIGHER");
            educationBox.Items.Add("OTHER");

            employmentBox.Items.Add("EMPLOYED");
            employmentBox.Items.Add("SELF EMPLOYED");
            employmentBox.Items.Add("UNEMPLOYED");
            employmentBox.Items.Add("LOOKING FOR WORK");
            employmentBox.Items.Add("STUDENT");
            employmentBox.Items.Add("RETIRED");
            employmentBox.Items.Add("OTHER");
        }

        #region Animation

        public void fadeIn(int index, Question question) {

            if (question.getAlphas()[index] <= question.getCurrentPanel().BackColor.A - question.getCurrentPanel().BackColor.A / 10) {
                question.setAlpha(index, question.getAlphas()[index] += question.getCurrentPanel().BackColor.A / 10);
                question.getToolTipList()[index].BackColor = Color.FromArgb(question.getAlphas()[index], question.getToolTipList()[index].BackColor);
            } else {
                question.getToolTipList()[index].BackColor = Color.FromArgb(question.getCurrentPanel().BackColor.A, question.getToolTipList()[index].BackColor);
            }
        }

        public void fadeOut(int index, Question question) {
            if (question.getAlphas()[index] >= question.getCurrentPanel().BackColor.A / 10) {
                question.setAlpha(index, question.getAlphas()[index] -= question.getCurrentPanel().BackColor.A / 10);
                question.getToolTipList()[index].BackColor = Color.FromArgb(question.getAlphas()[index], question.getToolTipList()[index].BackColor);
            } else {
                question.getAlphas()[index] = 0;
                question.getToolTipList()[index].BackColor = Color.FromArgb(question.getAlphas()[index], question.getToolTipList()[index].BackColor);
                question.getToolTipList()[index].Visible = false;
            }
        }

        #endregion

        #region Event Handlers

        private void timer1_Tick(object sender, EventArgs e) {

            // Loops through each panel in each question, animating if need be
            foreach (Question question in questionList) {
                foreach (Panel panel in question.getToolTipList()) {

                    // Check to see what state each panel is in
                    if (panel.Visible && panel.Tag.ToString() == "0") {
                        fadeIn(question.getToolTipList().IndexOf(panel), question);
                    } else if (panel.Visible && panel.Tag.ToString() == "1") {
                        fadeOut(question.getToolTipList().IndexOf(panel), question);
                    }
                }
            }
        }

        public void questionPanel_onEnter(object sender, EventArgs e) {
            Panel panel = (Panel)sender;

            foreach (Question question in questionList) {

                // Find panel in MainPanelList
                if (question.getMainList().Contains(panel)) {
                    question.setCurrentPanel(panel);

                    // Set the corresponding tool tip panel to visible and change its state.
                    int index = Convert.ToInt32(panel.Tag);
                    question.getToolTipList()[index].Tag = "0";
                    question.getToolTipList()[index].Visible = true;
                }
            }
        }

        public void questionPanel_onLeave(object sender, EventArgs e) {
            Panel panel = (Panel)sender;

            foreach (Question question in questionList) {

                //Find panel in MainPanelList
                if (question.getMainList().Contains(panel)) {

                    // Change the state of the corresponding tool tip panel.
                    int index = Convert.ToInt32(panel.Tag);
                    question.getToolTipList()[index].Tag = "1";
                }
            }
        }

        public void questionPanel_onClick(object sender, EventArgs e) {
            Panel panel = (Panel)sender;

            // Find the only control object inside the label.
            Label label = (Label)panel.Controls[0];

            foreach (Question question in questionList) {

                // Find the panel in MainPanelList.
                if (question.getMainList().Contains(panel)) {
                    int index = Convert.ToInt32(panel.Tag);

                    // Set all panels in SelectedPanelsList to invisible.
                    foreach (Panel selected in question.getSelectedList()) {
                        selected.Visible = false;
                    }

                    // Set all labels in MainPanelList to default font size.
                    foreach (Panel main in question.getMainList()) {
                        Label lb = (Label)main.Controls[0];
                        lb.Font = new Font("Calibri", 22);
                        lb.Location = new Point((panel.Width - label.Width) / 2, (panel.Height - label.Height) / 2);
                    }

                    // Set coresponding selected panel to visible and store index.
                    question.getSelectedList()[index].Visible = true;
                    question.setAnswer(index);
                }
            }

            // Increase font size of clicked panel and re-center it.
            label.Font = new Font("Calibri", 42);
            label.Location = new Point((panel.Width - label.Width) / 2, (panel.Height - label.Height) / 2);
        }

        private void date_Enter(object sender, EventArgs e) {
            TextBox box = (TextBox)sender;

            // Check to see if box contains hint text. If so, delete it.
            if (box.Tag.ToString() == "0") {
                box.ForeColor = Color.Black;
                box.Text = "";
                box.Tag = "1";
            }
        }

        private void date_Leave(object sender, EventArgs e) {
            TextBox box = (TextBox)sender;

            // Check to see if box contains empty string value.
            if (box.Text == "") {
                box.ForeColor = Color.Gray;

                // Add hint text to corresponding boxes.
                if (box == dayBox) {
                    box.Text = "DD";
                } else if (box == monthBox) {
                    box.Text = "MM";
                } else if (box == yearBox) {
                    box.Text = "YYYY";
                }
                box.Tag = "0";
            }
        }

        private void date_Change(object sender, EventArgs e) {
            TextBox box = (TextBox)sender;

            // Check if you have selected box and isn't empty.
            if (box.Text.Length > 0 && box.Focused) {
                int n;

                // If input is non numerical, replace text with what was previously inserted.
                if (!int.TryParse(box.Text, out n)) {
                    box.Text = box.Text.Substring(0, box.Text.Length - 1);
                }
            }
        }


        // TODO FIX THIS SHIT!
        private void Form1_SizeChanged(object sender, EventArgs e) {

            // Revert Scale to default
            section1.Scale(new SizeF(1 / xScale, 1 / yScale));
            section2.Scale(new SizeF(1 / xScale, 1 / yScale));
            titleBanner.Scale(new SizeF(1 / xScale, 1 / yScale));


            // Calculate new Scale
            xScale = (float)ClientRectangle.Width / 1920;
            yScale = (float)ClientRectangle.Height / 1080;

            // Apply Scale
            section1.Scale(new SizeF(xScale, yScale));
            section2.Scale(new SizeF(xScale, yScale));
            titleBanner.Scale(new SizeF(xScale, yScale));

            // Fix Offset
            section1.Location = new Point(12, 25);
            section2.Location = new Point(section1.Location.X + section1.Width + 20, section1.Location.Y);
            forenameLabel.Location = new Point(27, forenameLabel.Location.Y);
            forenameBox.Location = new Point(215, forenameBox.Location.Y);
            surnameLabel.Location = new Point(44, surnameLabel.Location.Y);
            surnameBox.Location = new Point(215, surnameBox.Location.Y);
            dayBox.Location = new Point(215, dayBox.Location.Y);
            dateSlash1.Location = new Point(286, dateSlash1.Location.Y);
            monthBox.Location = new Point(323, monthBox.Location.Y);
            dateSlash2.Location = new Point(394, dateSlash2.Location.Y);
            yearBox.Location = new Point(431, yearBox.Location.Y);
        }

        public void submit_onClick(object sender, EventArgs e) {

            // Check if form has been completed.
            if (isComplete()) {

                // Create Person Object and hand it arguments.
                int[] answers = new int[8];

                answers[0] = question1.getAnswer();
                answers[1] = question2.getAnswer();
                answers[2] = question3.getAnswer();
                answers[3] = getAge();
                answers[4] = genderBox.SelectedIndex;
                answers[5] = ethnicityBox.SelectedIndex;
                answers[6] = educationBox.SelectedIndex;
                answers[7] = employmentBox.SelectedIndex;
                Person person = new Person(forenameBox.Text, surnameBox.Text, answers);
                data.addPerson(person);

                mainContainer.Hide();
                // TODO reset the mainContainer.
                //inflateGraphic1();
            }
        }

        public void tabPanel_onEnter(object sender, EventArgs e) {
            Label label = (Label)sender;
            if (label.Tag.ToString() == "0") {
                label.ForeColor = Color.Black;
                label.BackColor = Color.White;
            }
        }

        public void tabPanel_onLeave(object sender, EventArgs e) {
            Label label = (Label)sender;
            if (label.Tag.ToString() == "0") {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }
        }

        public void tabPanel_onClick(object sender, EventArgs e) {
            Label label = (Label)sender;
            if (label.Tag.ToString() == "0") {
                foreach (Control control in this.Controls) {
                    if (control.Tag == "Graphic") {
                        control.Dispose();
                    }
                }
                inflateGraphic(sideBar.IndexOf(label));

                foreach(Label item in sideBar) {
                    item.ForeColor = Color.White;
                    item.BackColor = Color.Transparent;
                    item.Tag = "0";
                }
                label.ForeColor = Color.Black;
                label.BackColor = Color.White;
                label.Tag = "1";
            }
        }

        #endregion

        public bool isComplete() {

            // Loop through each control object, checking if empty.
            foreach (Control control in this.Controls) {
                if (control is ComboBox) {
                    ComboBox box = (ComboBox)control;
                    if (box.SelectedIndex == -1) {
                        return false;
                    }
                } else if (control is TextBox) {
                    if (control.Tag.ToString() == "0") {
                        return false;
                    } else {
                        TextBox box = (TextBox)control;
                        if (box.Text == "") {
                            return false;
                        }
                    }
                }
            }

            // Loop through each question, checking if answered.
            foreach (Question question in questionList) {
                if (question.getAnswer() == -1) {
                    return false;
                }
            }

            return true;
        }

        public int getAge() {
            int age;
            int year = Convert.ToInt32(yearBox.Text);
            int month = Convert.ToInt32(monthBox.Text);
            int day = Convert.ToInt32(dayBox.Text);

            // Compare DOB with todays date to get age.
            DateTime date = DateTime.Today;
            age = date.Year - year;

            if (month > date.Month) {
                age--;
            }
            else if (month == date.Month) {
                if (day > date.Day) {
                    age--;
                }
            }

            // Convert age into a numerical representation.
            if (age < 10) {
                return 0;
            } 
            else if (age < 20) {
                return 1;
            } 
            else if (age < 30) {
                return 2;
            } 
            else if (age < 40) {
                return 3;
            }
            else if (age < 50) {
                return 4;
            }
            else if (age < 60) {
                return 5;
            } else {
                return 6;
            }
        }

        public void inflateSidebar() {
            mainContainer.Hide();
            sideBar = new List<Label>();

            Panel panel = new Panel();
            this.Controls.Add(panel);

            panel.Size = new Size(200, mainContainer.Height);
            panel.Location = new Point(0, 150);
            panel.Margin = new Padding(0);
            panel.BackColor = Color.FromArgb(225, 225, 128, 0);

            string[] tabNames = { "Age", "Gender", "Ethnisity", "Education", "Employment", "Q1", "Q2", "Q3" };

            for (int i = 0; i < 8; i++) {
                Label tab = new Label();
                panel.Controls.Add(tab);

                tab.AutoSize = false;
                tab.Text = tabNames[i];
                tab.TextAlign = ContentAlignment.MiddleCenter;
                tab.Size = new Size(200, 75);
                tab.Padding = new Padding(0);
                tab.Location = new Point(0, ((panel.Height - 75*8 - 40) / 2) + (75 * i));
                tab.Tag = "0";
                tab.BackColor = Color.Transparent;
                tab.ForeColor = Color.White;
                tab.MouseEnter += new EventHandler(tabPanel_onEnter);
                tab.MouseLeave += new EventHandler(tabPanel_onLeave);
                tab.Click += new EventHandler(tabPanel_onClick);
                sideBar.Add(tab);
            }
            sideBar[0].BackColor = Color.White;
            sideBar[0].ForeColor = Color.Black;
            sideBar[0].Tag = "1";
        }

        public void inflateGraphic(int index) {
            Panel graphic = new Panel();
            this.Controls.Add(graphic);
            graphic.Size = new Size(mainContainer.Width - 200, mainContainer.Height);
            graphic.Location = new Point(200,150);
            graphic.Margin = new Padding(0);
            graphic.Tag = "Graphic";

            ChartConstructor constructor = new ChartConstructor(data, graphic);
            Chart chart;

            switch (index) {
                case 0:
                    chart = constructor.chartAge();
                    break;
                case 1:
                    chart = constructor.chartGender();
                    break;
                case 2:
                    chart = constructor.chartEthnicity();
                    break;
                case 3:
                    chart = constructor.chartEducation();
                    break;
                case 4:
                    chart = constructor.chartEmployment();
                    break;
                case 5:
                    chart = constructor.chartQuestion(0);
                    break;
                case 6:
                    chart = constructor.chartQuestion(1);
                    break;
                case 7:
                    chart = constructor.chartQuestion(2); ;
                    break;
                default:
                    chart = chart = constructor.chartAge();
                    break;
            }

            graphic.Controls.Add(chart);
            chart.Size = new Size(800, 800);
            chart.Location = new Point(50, (graphic.Height - chart.Height) / 2);
        }

        public void getData() {

            Random rand = new Random();
            for (int i = 0; i < 100; i++) {
                string forname = "Billy";
                string surname = "Boy";
                int[] values = new int[8];
                for (int j = 0; j < 8; j++) {
                    if (j < 3) {
                        values[j] = rand.Next(0, 5);
                    }
                    else if (j == 3) {
                        values[j] = rand.Next(0, 7);
                    }
                    else if (j == 4) {
                        values[j] = rand.Next(0, 2);
                    }
                    else if (j == 5) {
                        values[j] = rand.Next(0, 5);
                    }
                    else if (j == 6) {
                        values[j] = rand.Next(0, 5);
                    } 
                    else if (j == 7) {
                        values[j] = rand.Next(0, 7);
                    }
                }
                Person person = new Person(forname, surname, values);
                data.addPerson(person);
            }
        }
    }
}
