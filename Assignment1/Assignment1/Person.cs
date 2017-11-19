using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Person
    {
        string forename;
        string surname;
        int age;
        int[] questionvalues;

        public Person(string forename, string surname, int age,  int[] values)
        {
            this.forename = forename;
            this.surname = surname;
            this.age = age;
            this.questionvalues = values;
        }

        public string getForname() {
            return forename;
        }

        public string getSurname() {
            return surname;
        }

        public int getAge() {
            return age;
        }

        public int getQ1Value() {
            return questionvalues[0];
        }

        public int getQ2Value() {
            return questionvalues[1];
        }

        public int getQ3Value() {
            return questionvalues[2];
        }

        public int getAgeValue() {
            return questionvalues[3];
        }

        public int getGenderValue() {
            return questionvalues[4];
        }

        public int getEthnicityValue() {
            return questionvalues[5];
        }

        public int getEducationValue() {
            return questionvalues[6];
        }

        public int getEmploymentValue() {
            return questionvalues[7];
        }
    }
}
