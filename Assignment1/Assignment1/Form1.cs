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

        private List<Panel> toolTipPanelList = new List<Panel>();
        private List<Panel> mainPanelList = new List<Panel>();
        private List<Panel> selectedPanelList = new List<Panel>();
        private int[] currentAlphas = new int[5];
        private Panel currentPanel;

        public Form1() {
            InitializeComponent();

            // Maximise form on startup
            this.WindowState = FormWindowState.Maximized;
            setColor();
            populateLists();
            addFunctionality();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            foreach (Panel panel in toolTipPanelList) {

                if (panel.Visible && panel.Tag.ToString() == "0") {
                    fadeIn(toolTipPanelList.IndexOf(panel));

                } else if (panel.Visible && panel.Tag.ToString() == "1") {
                    fadeOut(toolTipPanelList.IndexOf(panel));

                }
            }
        }

        // Obsolete Code
        public void setColor() {
            option1.BackColor = Color.FromArgb(255, option1.BackColor);
            selected1.BackColor = Color.FromArgb(255, option1.BackColor);

            option2.BackColor = Color.FromArgb(200, option1.BackColor);
            selected2.BackColor = Color.FromArgb(200, option1.BackColor);

            option3.BackColor = Color.FromArgb(150, option1.BackColor);
            selected3.BackColor = Color.FromArgb(150, option1.BackColor);

            option4.BackColor = Color.FromArgb(100, option1.BackColor);
            selected4.BackColor = Color.FromArgb(100, option1.BackColor);

            option5.BackColor = Color.FromArgb(50, option1.BackColor);
            selected5.BackColor = Color.FromArgb(50, option1.BackColor);
        }

        public void populateLists() {
            toolTipPanelList.Add(toolTip1);
            toolTipPanelList.Add(toolTip2);
            toolTipPanelList.Add(toolTip3);
            toolTipPanelList.Add(toolTip4);
            toolTipPanelList.Add(toolTip5);

            mainPanelList.Add(option1);
            mainPanelList.Add(option2);
            mainPanelList.Add(option3);
            mainPanelList.Add(option4);
            mainPanelList.Add(option5);

            selectedPanelList.Add(selected1);
            selectedPanelList.Add(selected2);
            selectedPanelList.Add(selected3);
            selectedPanelList.Add(selected4);
            selectedPanelList.Add(selected5);
        }


        // Obsolete Code
        public void addFunctionality() {
            option1.MouseEnter += new EventHandler(panel_onEnter);
            option1.MouseLeave += new EventHandler(panel_onLeave);
            option1.MouseClick += new MouseEventHandler(panel_onClick);

            option2.MouseEnter += new EventHandler(panel_onEnter);
            option2.MouseLeave += new EventHandler(panel_onLeave);
            option2.MouseClick += new MouseEventHandler(panel_onClick);

            option3.MouseEnter += new EventHandler(panel_onEnter);
            option3.MouseLeave += new EventHandler(panel_onLeave);
            option3.MouseClick += new MouseEventHandler(panel_onClick);

            option4.MouseEnter += new EventHandler(panel_onEnter);
            option4.MouseLeave += new EventHandler(panel_onLeave);
            option4.MouseClick += new MouseEventHandler(panel_onClick);

            option5.MouseEnter += new EventHandler(panel_onEnter);
            option5.MouseLeave += new EventHandler(panel_onLeave);
            option5.MouseClick += new MouseEventHandler(panel_onClick);
        }

        public void fadeIn(int index) {     

            if (currentAlphas[index] <= currentPanel.BackColor.A - currentPanel.BackColor.A / 10) {
                currentAlphas[index] += currentPanel.BackColor.A / 10;
                toolTipPanelList[index].BackColor = Color.FromArgb(currentAlphas[index], toolTipPanelList[index].BackColor);
            } else {
                toolTipPanelList[index].BackColor = Color.FromArgb(currentPanel.BackColor.A, toolTipPanelList[index].BackColor);
            }
        }

        public void fadeOut(int index) {
            if (currentAlphas[index] >= currentPanel.BackColor.A / 10) {
                currentAlphas[index] -= currentPanel.BackColor.A / 10;
                toolTipPanelList[index].BackColor = Color.FromArgb(currentAlphas[index], toolTipPanelList[index].BackColor);
            } else {
                currentAlphas[index] = 0;
                toolTipPanelList[index].BackColor = Color.FromArgb(currentAlphas[index], toolTipPanelList[index].BackColor);
                toolTipPanelList[index].Visible = false;
            }
        }

        public void panel_onEnter(object sender, EventArgs e) {
            Panel panel = (Panel)sender;
            currentPanel = panel;
            int index = Convert.ToInt32(panel.Tag);
            toolTipPanelList[index].Tag = "0";
            toolTipPanelList[index].Visible = true;
        }

        public void panel_onLeave(object sender, EventArgs e) {
            Panel panel = (Panel)sender;
            int index = Convert.ToInt32(panel.Tag);
            toolTipPanelList[index].Tag = "1";
        }

        public void panel_onClick(object sender, EventArgs e) {
            Panel panel = (Panel)sender;
            int index = Convert.ToInt32(panel.Tag);

            foreach (Panel selected in selectedPanelList) {
                selected.Visible = false;
            }
            selectedPanelList[index].Visible = true;
        }
    }
}
