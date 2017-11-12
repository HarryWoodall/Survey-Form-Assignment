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

        public Form1() {
            InitializeComponent();

            // Maximise form on startup
            this.WindowState = FormWindowState.Maximized;
            initializeQuestions();
            timer1.Start();
        }

        public void initializeQuestions() {
            question1 = new Question();
            questionList.Add(question1);

            question1.addToolTip(toolTip1);
            question1.addToolTip(toolTip2);
            question1.addToolTip(toolTip3);
            question1.addToolTip(toolTip4);
            question1.addToolTip(toolTip5);

            question1.addMainPanel(option1);
            question1.addMainPanel(option2);
            question1.addMainPanel(option3);
            question1.addMainPanel(option4);
            question1.addMainPanel(option5);

            question1.addSelectedPanel(selected1);
            question1.addSelectedPanel(selected2);
            question1.addSelectedPanel(selected3);
            question1.addSelectedPanel(selected4);
            question1.addSelectedPanel(selected5);
        }

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

        public void testBox() {
            if (dayBox.Focus()) {
                Console.WriteLine("Awesome");
            }
        }

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

            if (question1.getMainList().Contains(panel)) {
                question1.setCurrentPanel(panel);
                int index = Convert.ToInt32(panel.Tag);
                question1.getToolTipList()[index].Tag = "0";
                question1.getToolTipList()[index].Visible = true;
            }
        }

        public void panel_onLeave(object sender, EventArgs e) {
            Panel panel = (Panel)sender;

            if (question1.getMainList().Contains(panel)) {
                int index = Convert.ToInt32(panel.Tag);
                question1.getToolTipList()[index].Tag = "1";
            }
        }

        public void panel_onClick(object sender, EventArgs e) {
            Panel panel = (Panel)sender;

            if (question1.getMainList().Contains(panel)) {
                int index = Convert.ToInt32(panel.Tag);

                foreach (Panel selected in question1.getSelectedList()) {
                    selected.Visible = false;
                }
                question1.getSelectedList()[index].Visible = true;
                question1.setAnswer(index);
                Console.WriteLine(question1.getAnswer().ToString());
            }
        }

        private void dateEnter(object sender, EventArgs e) {
            TextBox box = (TextBox)sender;
            if (box.Tag.ToString() == "0") {
                box.ForeColor = Color.Black;
                box.Text = "";
                box.Tag = "1";
            }
        }

        private void dateLeave(object sender, EventArgs e) {
            TextBox box = (TextBox)sender;
            if (box.Text == "") {
                if (box == dayBox) {
                    box.ForeColor = Color.Gray;
                    box.Text = "DD";
                } else if (box == monthBox) {
                    box.ForeColor = Color.Gray;
                    box.Text = "MM";
                } else if (box == yearBox) {
                    box.ForeColor = Color.Gray;
                    box.Text = "YYYY";
                }
                box.Tag = "0";
            }
        }

        #endregion
    }
}
