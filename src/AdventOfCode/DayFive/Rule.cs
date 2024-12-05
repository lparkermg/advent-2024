using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayFive
{
    internal class Rule
    {
        public int FirstNumber { get; set; }

        public int SecondNumber { get; set; }

        public Rule(string rule) 
        {
            var splitRule = rule.Split("|");

            FirstNumber = int.Parse(splitRule[0]);
            SecondNumber = int.Parse(splitRule[1]);
        }
    }
}
