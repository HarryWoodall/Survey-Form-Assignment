using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Person
    {
        string foreName;
        string surName;
        int[] questionvalues;

        public Person(string foreName, string surName, int[] values)
        {
            this.foreName = foreName;
            this.surName = surName;
            this.questionvalues = values;
        }
    }
}
