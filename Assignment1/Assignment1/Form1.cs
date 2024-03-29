﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

/*
 * Background Banner Art
 * http://verdewall.com/music-wallpaper-6hc.html/music-wallpaper-6hc
 * 
 * Background Music
 * https://freesound.org/people/frankum/sounds/393520/
 * 
 */

namespace Assignment1 {

    public partial class Form1 : Form {

        // Field Variables
        public Data data = Data.getInstance();

        private Question question1;
        private Question question2;
        private Question question3;
        private List<Question> questionList = new List<Question>();
        private List<Label> sideBarTabs;
        private List<Label> subBarTabs;

        private Panel frontPage;
        private Panel statsContainer;
        private Panel sideBarContainer;
        private Panel subBarContainer;
        private Label createNew;

        private int introCounter;
        private int sideBarIndex;
        private int subBarIndex;

        private float xScale = 1;
        private float yScale = 1;

        private bool chartViewed = false;

        public Form1() {
            InitializeComponent();

            // Maximise form on startup
            this.WindowState = FormWindowState.Maximized;
            initializeQuestions();
            data.loadFile();
            inflateFrontPage();
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

            // Change the alpha levels in the panel below the one you are hovering over.
            if (question.getAlphas()[index] <= question.getCurrentPanel().BackColor.A - question.getCurrentPanel().BackColor.A / 10) {
                question.setAlpha(index, question.getAlphas()[index] += question.getCurrentPanel().BackColor.A / 10);
                question.getToolTipList()[index].BackColor = Color.FromArgb(question.getAlphas()[index], question.getToolTipList()[index].BackColor);
            } else {

                // If the alpha on the main panel and tool tip are equal, don't change them.
                question.getToolTipList()[index].BackColor = Color.FromArgb(question.getCurrentPanel().BackColor.A, question.getToolTipList()[index].BackColor);
            }
        }

        public void fadeOut(int index, Question question) {
            if (question.getAlphas()[index] >= question.getCurrentPanel().BackColor.A / 10) {
                question.setAlpha(index, question.getAlphas()[index] -= question.getCurrentPanel().BackColor.A / 10);
                question.getToolTipList()[index].BackColor = Color.FromArgb(question.getAlphas()[index], question.getToolTipList()[index].BackColor);
            } else {

                // If the alpha levels are 1/10 of the main panel, set alpha to 0 and make invisible. 
                question.getAlphas()[index] = 0;
                question.getToolTipList()[index].BackColor = Color.FromArgb(question.getAlphas()[index], question.getToolTipList()[index].BackColor);
                question.getToolTipList()[index].Visible = false;
            }
        }

        public void introFadeOut() {

            // Increase RGB values until BackColor is white, then hide it.
            if (frontPage.BackColor.R < 230) {
                frontPage.BackColor = Color.FromArgb(255, frontPage.BackColor.R + 2, frontPage.BackColor.B + 2, frontPage.BackColor.G + 2);
            } else {
                frontPage.Hide();
            }
        }

        public void introFadeIn() {

            // Decrease RGB values until BackColor is light grey.
            if (frontPage.BackColor.R > 50) {
                frontPage.BackColor = Color.FromArgb(255, frontPage.BackColor.R - 2, frontPage.BackColor.B - 2, frontPage.BackColor.G - 2);
            } else {

                // Wait 200 'ticks', then change state. 
                introCounter++;
                if (introCounter > 200) {
                    frontPage.Tag = "1";
                }
            }
        }

        private void subBarMoveIn() {

            // Move subBar until it reaches its destination.
            if (subBarContainer.Location.X < 235) {
                subBarContainer.Left += 15;
            } else {
                subBarContainer.Left = 250;
            }
        }

        private void subBarMoveOut() {

            // Move subBar until it is out of view, then hide it.
            if (subBarContainer.Location.X > 15) {
                subBarContainer.Left -= 15;
            } else {
                subBarContainer.Left = 0;
                subBarContainer.Visible = false;
            }
        }

        public void createNewFadeIn() {

            // Move createNew tab until text is visible.
            if (createNew.Top > 760) {
                createNew.Top -= 10;
            } else {
                createNew.Top = 750;
            }
        }

        public void createNewFadeOut() {

            // Move createNew tab until text is hidden.
            if (createNew.Top < 810) {
                createNew.Top += 10;
            } else {
                createNew.Top = 820;
            }
        }

        #endregion

        #region Event Handlers

        private void timer1_Tick(object sender, EventArgs e) {

            // Aniimation for Likert scale
            // Loops through each panel in each question, animating if need be
            foreach (Question question in questionList) {
                foreach (Panel panel in question.getToolTipList()) {

                    // Check to see what state each panel is in
                    if (panel.Visible && panel.Tag.ToString() == "0") {
                        fadeIn(question.getToolTipList().IndexOf(panel), question);
                    }
                    else if (panel.Visible && panel.Tag.ToString() == "1") {
                        fadeOut(question.getToolTipList().IndexOf(panel), question);
                    }
                }
            }

            // Anination for stats page sub bar
            if (subBarContainer != null) {
                if (subBarContainer.Visible && subBarContainer.Tag.ToString() == "0") {
                    subBarMoveIn();
                } else if (subBarContainer.Visible && subBarContainer.Tag.ToString() == "1") {
                    subBarMoveOut();
                }
            }

            // Animation for intro page
            if (frontPage != null) {
                if (frontPage.Tag.ToString() == "0") {
                    introFadeIn();
                } else {
                    introFadeOut();
                }
            }

            if (createNew != null) {
                if (createNew.Tag.ToString() == "0") {
                    createNewFadeOut();
                } else {
                    createNewFadeIn();
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
                    if (index != question.getAnswer()) {

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


        private void Form1_SizeChanged(object sender, EventArgs e) {

            // Scale frontPage
            frontPage.Size = new Size(ClientRectangle.Width, ClientRectangle.Height);
            frontPage.Controls[0].Size = new Size(frontPage.Width / 2, frontPage.Height / 2);
            frontPage.Controls[0].Location = new Point((frontPage.Width - frontPage.Controls[0].Width) / 2, (frontPage.Height - frontPage.Controls[0].Height) / 2);

            // Revert Scale to default
            section1.Scale(new SizeF(1 / xScale, 1 / yScale));
            section2.Scale(new SizeF(1 / xScale, 1 / yScale));
            titleBanner.Scale(new SizeF(1 / xScale, 1 / yScale));
            titleBanner.Controls[0].Font = new Font("Calibri", titleBanner.Controls[0].Font.Size / xScale);

            // Calculate new Scale
            xScale = (float)ClientRectangle.Width / 1920;
            yScale = (float)ClientRectangle.Height / 1080;

            // Apply Scale
            section1.Scale(new SizeF(xScale, yScale));
            section2.Scale(new SizeF(xScale, yScale));
            titleBanner.Scale(new SizeF(xScale, yScale));
            titleBanner.Controls[0].Font = new Font("Calibri", titleBanner.Controls[0].Font.Size * xScale);

            // Fix Offset
            section1.Location = new Point(12, 25);
            section2.Location = new Point(section1.Location.X + section1.Width + 20, section1.Location.Y);
            titleBanner.Controls[0].Location = new Point(titleBanner.Controls[0].Location.X, (titleBanner.Height - titleBanner.Controls[1].Height) - titleBanner.Controls[0].Height);
            if (statsContainer != null) {
                statsContainer.Location = new Point(0, titleBanner.Height);
            }
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
                answers[3] = getAgeValue();
                answers[4] = genderBox.SelectedIndex;
                answers[5] = ethnicityBox.SelectedIndex;
                answers[6] = educationBox.SelectedIndex;
                answers[7] = employmentBox.SelectedIndex;
                Person person = new Person(forenameBox.Text, surnameBox.Text, getAge(), answers);
                data.addPerson(person);
                data.saveToFile(person);

                resetMainContainer();
                mainContainer.Hide();
                inflateStatsPage();
            } else {
                MessageBox.Show("Form is incomplete or contains errors");
            }
        }

        public void sideBarTab_onEnter(object sender, EventArgs e) {
            Label label = (Label)sender;
            label.BackColor = Color.FromArgb(255, 217, 128, 38);
            sideBarIndex = sideBarTabs.IndexOf(label);

            // If 'TOTAL' tab is selected, create the sub bar.
            if (sideBarTabs[0] == label) {
                inflateSubBar();
                sideBarContainer.BringToFront();
                subBarContainer.Tag = "0";
            } else {

                // If 'TOTAL' tab is not selected, remove the sub bar.
                if (subBarContainer != null && subBarContainer.Visible) {
                    subBarContainer.Tag = "1";
                }
            }
        }

        // Revert the tab to its previous state.
        public void sideBarTab_onLeave(object sender, EventArgs e) {
            Label label = (Label)sender;
            if (label.Tag.ToString() == "0") {
                label.BackColor = Color.Transparent;
            }
        }

        public void subBarTab_onEnter(object sender, EventArgs e) {
            Label label = (Label)sender;

            // Keep the 'TOTAL' tab selected
            sideBarTabs[0].BackColor = Color.FromArgb(255, 217, 128, 38);
            if (label.Tag.ToString() == "0") {
                label.BackColor = Color.White;
                label.ForeColor = Color.Black;
            }

            // Track the index of the sub bar
            subBarIndex = subBarTabs.IndexOf(label);
        }

        // Revert the tab to its previous state
        public void subBarTab_onLeave(object sender, EventArgs e) {
            Label label = (Label)sender;
            if (sideBarTabs[0].Tag.ToString() == "0") {
                sideBarTabs[0].BackColor = Color.Transparent;
            }
            if (label.Tag.ToString() == "0") {
                label.BackColor = Color.Transparent;
                label.ForeColor = Color.White;
            }
        }

        // Check to see if mouse has left sidebar
        public void sideBar_onMouseMove(object sender, MouseEventArgs e) {
            if (e.Y < 140) {
                if (subBarContainer != null && subBarContainer.Visible) {
                    subBarContainer.Tag = "1";
                }
            }
        }

        public void tab_onClick(object sender, EventArgs e) {
            Label label = (Label)sender;
            if (label.Tag.ToString() == "0") {

                // Search for the old graphic panel and remove it.
                foreach (Control control in statsContainer.Controls) {
                    if (control.Tag == "Graphic") {
                        control.Dispose();
                    }
                }

                // Create the new graphic
                chartViewed = true;
                inflateGraphic();

                // Reset the state of the tabs.
                foreach (Label item in sideBarTabs) {
                    item.BackColor = Color.Transparent;
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    item.Tag = "0";
                }

                if (subBarTabs != null) {
                    foreach (Label item in subBarTabs) {
                        item.BackColor = Color.Transparent;
                        item.ForeColor = Color.White;
                        item.Font = new Font(item.Font, FontStyle.Regular);
                        item.Tag = "0";
                    }
                }

                // Check to see if you clicked a side bar or sub bar tab, then change its state.
                if (sideBarTabs.Contains(label)) {
                    label.BackColor = Color.FromArgb(255, 217, 128, 38);
                    label.Font = new Font(label.Font, FontStyle.Bold);

                } else {
                    label.BackColor = Color.White;
                    label.ForeColor = Color.Black;
                    label.Font = new Font(label.Font, FontStyle.Bold);
                    label.Tag = "1";

                    sideBarTabs[0].BackColor = Color.FromArgb(255, 217, 128, 38);
                    sideBarTabs[0].Tag = "1";
                }
                label.Tag = "1";
            }
        }


        // Check to see if your mouse has left the sub bar.
        public void graphic_onEnter(object sender, EventArgs e) {
            if (subBarContainer != null && subBarContainer.Visible) {
                subBarContainer.Tag = "1";
            }
        }

        // Create a new Survey
        public void createNew_onClick(object sender, EventArgs e) {
            chartViewed = false;
            statsContainer.Hide();
            mainContainer.Show();
        }

        public void createNew_onEnter(object sender, EventArgs e) {
            Label label = (Label)sender;
            label.Tag = "1";
        }

        public void createNew_onLeave(object sender, EventArgs e) {
            Label label = (Label)sender;
            label.Tag = "0";
        }

        // Play ambient sound in the background.
        public void playSound(object sender, EventArgs e) {
            if (!frontPage.Visible) {
                SoundPlayer sound = new SoundPlayer(Properties.Resources._393520_frankum_ambient_guitar_x1_loop_mode);
                sound.PlayLooping();
            }
        }

        #endregion

        public bool isComplete() {

            // Loop through each control object, checking if empty.
            foreach (Control control in section1.Controls) {
                if (control is ComboBox) {
                    ComboBox box = (ComboBox)control;
                    if (box.SelectedIndex == -1) {
                        return false;
                    }
                } else if (control is TextBox) {
                    if (control.Tag != null && control.Tag.ToString() == "0") {
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

            // Extra date validation
            return checkDate();
        }

        public bool checkDate() {
            DateTime date = DateTime.Today;
            int day = Convert.ToInt32(dayBox.Text);
            int month = Convert.ToInt32(monthBox.Text);
            int year = Convert.ToInt32(yearBox.Text);

            string inputDate = yearBox.Text + "-" + monthBox.Text + "-" + dayBox.Text;

            if (date.Year < year || year < 1900) {
                validDateLabel.Show();
                return false;

            } else if (!DateTime.TryParse(inputDate, out date)) {
                validDateLabel.Show();
                return false;

            } else {

                if (validDateLabel.Visible) {
                    validDateLabel.Hide();
                }
                return true;
            }

        }

        public int getAgeValue() {
            int age = getAge();

            // Convert age into a numerical representation.
            if (age < 10) {
                return 0;
            } else if (age < 20) {
                return 1;
            } else if (age < 30) {
                return 2;
            } else if (age < 40) {
                return 3;
            } else if (age < 50) {
                return 4;
            } else if (age < 60) {
                return 5;
            } else {
                return 6;
            }
        }

        private int getAge() {
            int age;
            int year = Convert.ToInt32(yearBox.Text);
            int month = Convert.ToInt32(monthBox.Text);
            int day = Convert.ToInt32(dayBox.Text);

            // Compare DOB with todays date to get age.
            DateTime date = DateTime.Today;
            age = date.Year - year;

            if (month > date.Month) {
                age--;
            } else if (month == date.Month) {
                if (day > date.Day) {
                    age--;
                }
            }

            return age;
        }

        // Set up main page for a new survey.
        public void resetMainContainer() {

            // Reset each control to default state.
            foreach (Control control in section1.Controls) {
                if (control is TextBox) {
                    TextBox box = (TextBox)control;
                    box.Text = "";
                }
                else if (control is ComboBox) {
                    ComboBox box = (ComboBox)control;
                    box.SelectedIndex = -1;
                }
            }

            foreach (Question question in questionList) {
                foreach (Panel selected in question.getSelectedList()) {
                    selected.Visible = false;
                }

                foreach (Panel main in question.getMainList()) {
                    Label lb = (Label)main.Controls[0];
                    lb.Font = new Font("Calibri", 22);
                    lb.Location = new Point((main.Width - lb.Width) / 2, (main.Height - lb.Height) / 2);
                }
            }

            dayBox.ForeColor = Color.Gray;
            dayBox.Text = "DD";
            dayBox.Tag = "0";

            monthBox.ForeColor = Color.Gray;
            monthBox.Text = "MM";
            monthBox.Tag = "0";

            yearBox.ForeColor = Color.Gray;
            yearBox.Text = "YYYY";
            yearBox.Tag = "0";
        }

        #region Inflators

        // Create intro page and add it to controls.
        private void inflateFrontPage() {
            frontPage = new Panel();
            this.Controls.Add(frontPage);
            frontPage.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            frontPage.Location = new Point(0, 0);
            frontPage.BackColor = Color.White;
            frontPage.Tag = "0";
            frontPage.BringToFront();
            frontPage.VisibleChanged += new EventHandler(playSound);

            Label title = new Label();
            frontPage.Controls.Add(title);
            title.Text = "Singing Sculpture Survey";
            title.AutoSize = false;
            title.Size = new Size(frontPage.Width / 2, frontPage.Height / 2);
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.BackColor = Color.Transparent;
            title.ForeColor = Color.White;
            title.Font = new Font("Calibri", 88, FontStyle.Italic);
            title.Location = new Point((frontPage.Width - title.Width) / 2, (frontPage.Height - title.Height) / 2);
        }

        // Create stats page and add it to main controls.
        public void inflateStatsPage() {

            // If not null, just make visible. Else create new.
            if (statsContainer == null) {
                statsContainer = new Panel();
                this.Controls.Add(statsContainer);

                statsContainer.Size = new Size(this.Width, mainContainer.Height);
                statsContainer.Location = new Point(0, titleBanner.Height);
                statsContainer.Margin = new Padding(0);

                inflateSidebar();
                inflateGraphic();
            } else {
                statsContainer.Show();
            }
        }

        // Create Sidebar and add it to main controls.
        public void inflateSidebar() {
            sideBarTabs = new List<Label>();

            if (sideBarContainer == null) {
                sideBarContainer = new Panel();
                statsContainer.Controls.Add(sideBarContainer);

                sideBarContainer.Size = new Size(250, mainContainer.Height);
                sideBarContainer.Location = new Point(0, 0);
                sideBarContainer.Margin = new Padding(0);
                sideBarContainer.BackColor = Color.FromArgb(225, 225, 128, 0);
                sideBarContainer.MouseMove += new MouseEventHandler(sideBar_onMouseMove);

                string[] tabNames = { "TOTAL", "I ENJOYED THE SCULPTURE", "I AM CURIOUS AS TO HOW IT WORKS", "I WANT TO KNOW MORE ABOUT SCIENCE AS A RESULT" };

                // Add tab labels and delegate event handelers.
                for (int i = 0; i < tabNames.Length; i++) {
                    Label tab = new Label();
                    sideBarContainer.Controls.Add(tab);

                    tab.AutoSize = false;
                    tab.Text = tabNames[i];
                    tab.Font = new Font("Calibri", 18);
                    tab.TextAlign = ContentAlignment.MiddleCenter;
                    tab.Size = new Size(sideBarContainer.Width, 150);
                    tab.Padding = new Padding(0);
                    tab.Location = new Point(0, ((sideBarContainer.Height - tab.Height * tabNames.Length - 40) / 2) + (tab.Height * i));
                    tab.Tag = "0";
                    tab.BackColor = Color.Transparent;
                    tab.ForeColor = Color.White;
                    tab.MouseEnter += new EventHandler(sideBarTab_onEnter);
                    tab.MouseLeave += new EventHandler(sideBarTab_onLeave);

                    if (i > 0) {
                        tab.Click += new EventHandler(tab_onClick);
                    }

                    sideBarTabs.Add(tab);
                }
            } else {
                sideBarContainer.Visible = true;
            }
        }

        // Create sub bar and add it to controls.
        public void inflateSubBar() {
            if (subBarContainer == null) {
                subBarTabs = new List<Label>();

                subBarContainer = new Panel();
                statsContainer.Controls.Add(subBarContainer);
                subBarContainer.BringToFront();
                titleBanner.BringToFront();


                subBarContainer.Size = new Size(150, mainContainer.Height);
                subBarContainer.Location = new Point(0, 0);
                subBarContainer.Margin = new Padding(0);
                subBarContainer.BackColor = Color.FromArgb(255, 217, 128, 38);

                string[] tabNames = { "Age", "Gender", "Ethnicity", "Education", "Employment" };

                // Add tab labels and delegate event handelers.
                for (int i = 0; i < tabNames.Length; i++) {
                    Label tab = new Label();
                    subBarContainer.Controls.Add(tab);

                    tab.AutoSize = false;
                    tab.Text = tabNames[i];
                    tab.TextAlign = ContentAlignment.MiddleCenter;
                    tab.Size = new Size(150, 100);
                    tab.Font = new Font("Calibri", 16);
                    tab.Padding = new Padding(0);
                    tab.Location = new Point(0, ((subBarContainer.Height - tab.Height * tabNames.Length - 40) / 2) + (tab.Height * i));
                    tab.Tag = "0";
                    tab.BackColor = Color.Transparent;
                    tab.ForeColor = Color.White;
                    tab.MouseEnter += new EventHandler(subBarTab_onEnter);
                    tab.MouseLeave += new EventHandler(subBarTab_onLeave);
                    tab.Click += new EventHandler(tab_onClick);
                    subBarTabs.Add(tab);
                }
            } else {
                subBarContainer.Visible = true;
            }
        }

        // Create chart graphic and add it to controls.
        public void inflateGraphic() {
            Panel graphic = new Panel();
            graphic.SendToBack();
            statsContainer.Controls.Add(graphic);
            graphic.Size = new Size(mainContainer.Width - 250, mainContainer.Height);
            graphic.Location = new Point(sideBarContainer.Width,0);
            graphic.Margin = new Padding(0);
            graphic.Tag = "Graphic";
            graphic.MouseEnter += new EventHandler(graphic_onEnter);
            Chart chart;

            // Create the chart.
            chart = getChart(graphic);

            // Add it to the container.
            graphic.Controls.Add(chart);
            chart.Size = new Size(800, 800);
            chart.Location = new Point((graphic.Width - chart.Width) / 2, (graphic.Height - chart.Height) / 2);

            createNew = new Label();
            graphic.Controls.Add(createNew);

            // Add the createNew button.
            createNew.Text = "CREATE NEW";
            createNew.Size = new Size(150, 200);
            createNew.Location = new Point(0, 810);
            createNew.BackColor = Color.FromArgb(190,76,0);
            createNew.ForeColor = Color.White;
            createNew.TextAlign = ContentAlignment.TopCenter;
            createNew.Padding = new Padding(20,50,20,0);
            createNew.Font = new Font("Calibri", 16, FontStyle.Bold);
            createNew.Tag = "0";
            createNew.Click += new EventHandler(createNew_onClick);
            createNew.MouseEnter += new EventHandler(createNew_onEnter);
            createNew.MouseLeave += new EventHandler(createNew_onLeave);

            // Create Helper
            if (!chartViewed) {
                chart.Hide();
                getHelper(graphic);
                createNew.BringToFront();
            }
        }

        #endregion

        public void getHelper(Panel panel) {
            Panel overview = new Panel();
            panel.Controls.Add(overview);
            overview.Size = panel.Size;
            overview.Location = new Point(0, 0);
            overview.BackColor = Color.FromArgb(150, 255, 128, 0);
            overview.MouseEnter += new EventHandler(graphic_onEnter);

            Label label = new Label();
            overview.Controls.Add(label);
            label.Font = new Font("Calibri", 52, FontStyle.Bold);
            label.ForeColor = Color.White;
            label.BackColor = Color.Transparent;
            label.Text = "< SELECT A GRAPH";
            label.Size = new Size(panel.Width / 2, panel.Height);
            label.Location = new Point(160,0);
            label.TextAlign = ContentAlignment.MiddleLeft;
        }

        // Generate the correct chart using the ChartConstructor class.
        public Chart getChart(Panel panel) {
            ChartConstructor constructor = new ChartConstructor(panel, sideBarIndex, subBarIndex);
            if (sideBarIndex == 0) {
                Chart[] chartArray = new Chart[] {
                    constructor.chartAge(), constructor.chartGender(), constructor.chartEthnicity(), constructor.chartEducation(), constructor.chartEmployment()
                };
                return chartArray[subBarIndex];
            } else {
                return constructor.chartQuestion(sideBarIndex - 1);
            }
        }

        // Genertate 100 random pieces of data to show off graphs -- THIS WILL OVEWRITE ALL DATA.
        public void getData() {

            Random rand = new Random();
            for (int i = 0; i < 100; i++) {
                string forname = "Joe";
                string surname = "Bloggs";
                int age = rand.Next(10, 90);
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
                Person person = new Person(forname, surname, age, values);
                data.addPerson(person);
            }
            data.saveToFile();
        }
    }
}
