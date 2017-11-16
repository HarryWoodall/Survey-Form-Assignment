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

            return chart;
        }
    }
}
