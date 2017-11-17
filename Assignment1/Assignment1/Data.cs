using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1 {
    public class Data {

        private List<String> fornames;
        private List<String> surnames;

        private List<int> ageValues;
        private List<int> genderValues;
        private List<int> ethnicityValues;
        private List<int> educationValues;
        private List<int> employmentValues;
        private List<int> q1Values;
        private List<int> q2Values;
        private List<int> q3Values;

        public Data() {
            fornames = new List<string>();
            surnames = new List<string>();
            ageValues = new List<int>();
            genderValues = new List<int>();
            ethnicityValues = new List<int>();
            educationValues = new List<int>();
            employmentValues = new List<int>();
            q1Values = new List<int>();
            q2Values = new List<int>();
            q3Values = new List<int>();
        }

        public List<String> getFornames() {
            return fornames;
        }

        public List<String> getSurnames() {
            return surnames;
        }

        public List<int> getAgeValues() {
            return ageValues;
        }

        public List<int> getGenderValues() {
            return genderValues;
        }

        public List<int> getEthnicityValues() {
            return ethnicityValues;
        }

        public List<int> getEducationValues() {
            return educationValues;
        }

        public List<int> getEmploymentValues() {
            return employmentValues;
        }

        public List<int> getQ1Values() {
            return q1Values;
        }

        public List<int> getQ2Values() {
            return q2Values;
        }

        public List<int> getQ3Values() {
            return q3Values;
        }

        public void addPerson(Person person) {
            fornames.Add(person.getForname());
            surnames.Add(person.getSurname());
            ageValues.Add(person.getAgeValue());
            genderValues.Add(person.getGenderValue());
            ethnicityValues.Add(person.getEthnicityValue());
            educationValues.Add(person.getEducationValue());
            employmentValues.Add(person.getEmploymentValue());
            q1Values.Add(person.getQ1Value());
            q2Values.Add(person.getQ2Value());
            q3Values.Add(person.getQ3Value());
        }

        public int getMeanAge(List<int> questionValues, int value) {
            List<int> meanAgeValues = new List<int>();
            foreach (int qValue in questionValues) {
                if (qValue == value) {
                    meanAgeValues.Add(ageValues[questionValues.IndexOf(qValue)]);
                }
            }

            return meanAgeValues.Sum() / meanAgeValues.Count;
        }
    }
}
