using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1 {

    public partial class Form1 : Form {

        private Question question1;
        private Question question2;
        private Question question3;
        private List<Question> questionList = new List<Question>();

        // Scaling 
        private float xScale = 1;
        private float yScale = 1;

        public Form1() {
            InitializeComponent();

            // Maximise form on startup
            this.WindowState = FormWindowState.Maximized;
            initializeQuestions();
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

        #region Event Handelers

        private void timer1_Tick(object sender, EventArgs e) {

            // Loops through each panel in each question, animating if need be
            foreach (Question question in questionList) {
                foreach (Panel panel in question.getToolTipList()) {
                    if (panel.Visible && panel.Tag.ToString() == "0") {
                        fadeIn(question.getToolTipList().IndexOf(panel), question);
                    } else if (panel.Visible && panel.Tag.ToString() == "1") {
                        fadeOut(question.getToolTipList().IndexOf(panel), question);
                    }
                }
            }
        }

        public void panel_onEnter(object sender, EventArgs e) {
            Panel panel = (Panel)sender;

            foreach (Question question in questionList) {
                if (question.getMainList().Contains(panel)) {
                    question.setCurrentPanel(panel);
                    int index = Convert.ToInt32(panel.Tag);
                    question.getToolTipList()[index].Tag = "0";
                    question.getToolTipList()[index].Visible = true;
                }
            }
        }

        public void panel_onLeave(object sender, EventArgs e) {
            Panel panel = (Panel)sender;

            foreach (Question question in questionList) {
                if (question.getMainList().Contains(panel)) {
                    int index = Convert.ToInt32(panel.Tag);
                    question.getToolTipList()[index].Tag = "1";
                }
            }
        }

        public void panel_onClick(object sender, EventArgs e) {
            Panel panel = (Panel)sender;
            Label label = (Label)panel.Controls[0];

            foreach (Question question in questionList) {
                if (question.getMainList().Contains(panel)) {
                    int index = Convert.ToInt32(panel.Tag);

                    foreach (Panel selected in question.getSelectedList()) {
                        selected.Visible = false;
                    }

                    foreach (Panel main in question.getMainList()) {
                        Label lb = (Label)main.Controls[0];
                        lb.Font = new Font("Calibri", 22);
                        lb.Location = new Point((panel.Width - label.Width) / 2, (panel.Height - label.Height) / 2);
                    }
                    question.getSelectedList()[index].Visible = true;
                    question.setAnswer(index);
                }
            }
            label.Font = new Font("Calibri", 42);
            label.Location = new Point((panel.Width - label.Width) / 2, (panel.Height - label.Height) / 2);
        }

        private void date_Enter(object sender, EventArgs e) {
            TextBox box = (TextBox)sender;
            if (box.Tag.ToString() == "0") {
                box.ForeColor = Color.Black;
                box.Text = "";
                box.Tag = "1";
            }
        }

        private void date_Leave(object sender, EventArgs e) {
            TextBox box = (TextBox)sender;
            if (box.Text == "") {
                box.ForeColor = Color.Gray;

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
            if (box.Text.Length > 0 && box.Focused) {
                int n;
                if (!int.TryParse(box.Text, out n)) {
                    box.Text = box.Text.Substring(0, box.Text.Length - 1);
                }
            }
        }

        #endregion

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

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
            section1.Location = new Point(12, 177);
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
    }
}
