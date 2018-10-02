using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Graphic_Assigment5
{
    public class YCoordinateTextBoxValidatorcs : ValidationRule
    {//Assigment 5 level 3 David Bartolomé 04-12-2017

        private int minValue;
        private int maxValue;

        /// <summary>
        /// Constructor 
        /// </summary>
        public YCoordinateTextBoxValidatorcs()
        {
           
        }

        /// <summary>
        /// Property minimum value allow 
        /// </summary>
        public int MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        /// <summary>
        /// Property maximum value allow 
        /// </summary>
        public int MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

       
        /// <summary>
        /// Method to validate user input Y coordinates 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;

            int coordinate;

            if (string.IsNullOrEmpty(str))
                return new ValidationResult(false, "Coordinate cannot be empty.");

           
            if (Int32.TryParse((string)value, out coordinate))
                    if (coordinate == 0)
                        return new ValidationResult(false, "Coordinate can not be 0");

            if (Int32.TryParse((string)value, out coordinate))
                    if (coordinate < MinValue)
                        return new ValidationResult(false, ErrorMinValue());
                    if (coordinate > MaxValue)
                    return new ValidationResult(false, ErrorMaxValue());
            
            return ValidationResult.ValidResult;
        }

        /// <summary>
        /// Mehtod to return string so tooltip can show message to user if values does not reach the min 
        /// </summary>
        /// <returns></returns>
        public string ErrorMinValue()
        {
            string minV = "Coordiante < " + Convert.ToString(MinValue);

            return minV;
        }

        /// <summary>
        /// Method to return string so tooltip can show message to user if values exceed the max value 
        /// </summary>
        /// <returns></returns>
        public string ErrorMaxValue()
        {
            string maxV = "Coordiante > " + Convert.ToString(MaxValue);

            return maxV;
        }
    }
}
