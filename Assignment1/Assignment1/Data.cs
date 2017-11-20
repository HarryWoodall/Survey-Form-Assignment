﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1 {
    public class Data {

        private int ammount;

        private List<String> fornames;
        private List<String> surnames;
        private List<int> ages;

        private List<int> ageValues;
        private List<int> genderValues;
        private List<int> ethnicityValues;
        private List<int> educationValues;
        private List<int> employmentValues;
        private List<int> q1Values;
        private List<int> q2Values;
        private List<int> q3Values;

        public Data() {
            ammount = 0;
            fornames = new List<string>();
            surnames = new List<string>();
            ages = new List<int>();
            ageValues = new List<int>();
            genderValues = new List<int>();
            ethnicityValues = new List<int>();
            educationValues = new List<int>();
            employmentValues = new List<int>();
            q1Values = new List<int>();
            q2Values = new List<int>();
            q3Values = new List<int>();
        }

        public int getAmmount() {
            return ammount;
        }

        public List<String> getFornames() {
            return fornames;
        }

        public List<String> getSurnames() {
            return surnames;
        }

        public List<int> getAges() {
            return ages;
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

        public List<int> getSubValues(List<int> questionList, List<int> comparisonList, int score) {
            List<int> ageList = new List<int>();
            for (int i = 0; i < questionList.Count; i++) {
                if (questionList[i] == score) {
                    ageList.Add(comparisonList[i]);
                }
            }
            return ageList;
        }

        public void addPerson(Person person) {
            fornames.Add(person.getForname());
            surnames.Add(person.getSurname());
            ages.Add(person.getAge());
            ageValues.Add(person.getAgeValue());
            genderValues.Add(person.getGenderValue());
            ethnicityValues.Add(person.getEthnicityValue());
            educationValues.Add(person.getEducationValue());
            employmentValues.Add(person.getEmploymentValue());
            q1Values.Add(person.getQ1Value());
            q2Values.Add(person.getQ2Value());
            q3Values.Add(person.getQ3Value());

            ammount++;
        }

        #region dataGeneration

        public int getMeanValue(List<int> questionValues, int value) {
            List<int> meanValues = new List<int>();
            for (int i = 0; i < questionValues.Count; i++) {
                if (questionValues[i] == value) {
                    meanValues.Add(ages[i]);
                }
            }
            return Convert.ToInt32(meanValues.Average());
        }

        public int[] getMode(List<int> list) {
            int current = -1;
            int repeatValue = 0;
            double maxValue = 0;
            int mode = 0;
            List<int> previousNumbers = new List<int>();

            foreach (int number in list) {
                if (!previousNumbers.Contains(number)) {
                    current = number;
                    previousNumbers.Add(current);
                    for (int i = list.IndexOf(number); i < list.Count; i++) {
                        if (list[i] == current) {
                            repeatValue++;
                        }
                    }
                    if (maxValue < repeatValue) {
                        maxValue = repeatValue;
                        mode = current;
                    }
                    repeatValue = 0;
                }
            }

            int[] result = { mode, Convert.ToInt32(maxValue / list.Count * 100) };
            return result;
        }

        public Value getModalValues(List<int> questionValues, int value, string type) {
            List<int> modalValues = new List<int>();
            for (int i = 0; i < questionValues.Count; i++) {
                if (questionValues[i] == value) {
                    if (type == Value.TYPE_EDUCATION) {
                        modalValues.Add(educationValues[i]);
                    }
                    else if (type == Value.TYPE_EMPLOYMENT){
                        modalValues.Add(employmentValues[i]);
                    }
                    else if (type == Value.TYPE_ETHNISITY) {
                        modalValues.Add(ethnicityValues[i]);
                    }
                    else if (type == Value.TYPE_GENDER) {
                        modalValues.Add(genderValues[i]);
                    }
                }
            }

            return new Value(getMode(modalValues), type);
        }
        
        #endregion
    }
}
