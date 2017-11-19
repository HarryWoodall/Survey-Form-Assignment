using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1 {
    public class Value {

        public static readonly string TYPE_EDUCATION = "Education";
        public static readonly string TYPE_ETHNISITY = "Ethnisity";
        public static readonly string TYPE_EMPLOYMENT = "Employment";
        public static readonly string TYPE_GENDER = "Gender";

        private string[] educationValues = { "Primary", "Secondary", "Advanced", "Higher", "Other" };
        private string[] employmentValues = { "Employed", "Self Employed", "Unemployed", "Looking for work", "Student", "Retired", "Other" };
        private string[] ethnisityValues = { "White / White British", "Mixed", "Asian / Asian British", "Black / Black British", "Other" };
        private string[] genderValues = { "Male", "Female" };

        private int value1;
        private int value2;
        private string type;

        public Value(int[] values, string type) {
            this.value1 = values[0];
            this.value2 = values[1];
            this.type = type;
        }

        public string getValue() {
            if (type == TYPE_EDUCATION) {
                return educationValues[value1];
            }
            else if (type == TYPE_EMPLOYMENT) {
                return employmentValues[value1];
            }
            else if (type == TYPE_ETHNISITY) {
                return ethnisityValues[value1];
            } else{
                return genderValues[value1];
            } 
        }

        public int getPercentage() {
            return value2;
        }
    }
}
