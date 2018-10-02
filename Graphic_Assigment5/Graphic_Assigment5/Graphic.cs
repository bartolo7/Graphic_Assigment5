using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Assigment5
{
    public class Graphic
    {//Assigment 5 level 3 David Bartolomé 04-12-2017


        /// <summary>
        /// Constructor 
        /// </summary>
        public Graphic()
        {

        }


        /// <summary>
        /// Property coordiante x 
        /// </summary>
        public int PointX { get; set; }

        /// <summary>
        /// Property coordinate y 
        /// </summary>
        public int PointY { get; set; }


        /// <summary>
        /// Property interval X 
        /// </summary>
        public int IntervalX { get; set; }


        /// <summary>
        /// Property interval Y
        /// </summary>
        public int IntervalY { get; set; }


        /// <summary>
        /// Property division X
        /// </summary>
        public int DivisionX { get; set; }


        /// <summary>
        /// Property division Y
        /// </summary>
        public int DivisionY { get; set; }


        /// <summary>
        /// Methed to validate user input 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ValidationUserInput(string input)
        {
            bool proceed = true;
            int number;

            if (String.IsNullOrEmpty(input))
                proceed = false;

            if (!Int32.TryParse(input, out number))
            {
                return proceed = false;
            }
            else if (number == 0)
            {
                return proceed = false;
            }
            else if(number < 0)
            {
                return proceed = false;
            }
            else if(number > 101)
            {
                return proceed = false;
            }
                
            return proceed;
        }



    }
}
