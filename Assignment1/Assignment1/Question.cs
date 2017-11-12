using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1 {
    public class Question {

        private int answer;
        private List<Panel> toolTipPanelList = new List<Panel>();
        private List<Panel> mainPanelList = new List<Panel>();
        private List<Panel> selectedPanelList = new List<Panel>();
        private int[] currentAlphas = new int[5];
        private Panel currentPanel;

        public Question() {
            answer = -1;
        }

        #region Getters and Setters

        public int getAnswer() {
            return answer;
        }

        public void setAnswer(int value) {
            answer = value;
        }


        public List<Panel> getToolTipList() {
            return toolTipPanelList;
        }

        public void addToolTip(Panel panel) {
            toolTipPanelList.Add(panel);
        }


        public List<Panel> getMainList() {
            return mainPanelList;
        }

        public void addMainPanel(Panel panel) {
            mainPanelList.Add(panel);
        }


        public List<Panel> getSelectedList() {
            return selectedPanelList;
        }

        public void addSelectedPanel(Panel panel) {
            selectedPanelList.Add(panel);
        }


        public int[] getAlphas() {
            return currentAlphas;
        }

        public void setAlpha(int index, int value) {
            currentAlphas[index] = value;
        }


        public Panel getCurrentPanel() {
            return currentPanel;
        }

        public void setCurrentPanel(Panel panel) {
            currentPanel = panel;
        }

        #endregion
    }
}
