using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    

namespace VoiceVandalDataVolley
{


    public class PlayerNumbers
    {
        private List<string> numbers = new List<string>
        {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
            "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen",
            "nineteen", "twenty", "twenty-one", "twenty-two", "twenty-three", "twenty-four",
            "twenty-five", "twenty-six", "twenty-seven", "twenty-eight",
        };

        public List<string> GetAllPlayerNumbers()
        {
            return numbers;
        }
    }
}
