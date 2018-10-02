using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Graphic_Assigment5
{//Assigment 5 level 3 David Bartolomé 04-12-2017
    public class XCoordinateTextBoxValidatorcs : ValidationRule
    {

        private int minValue;
        private int maxValue;

        /// <summary>
        /// Constructor 
        /// </summary>
        public XCoordinateTextBoxValidatorcs()
        {
           
        }

        /// <summary>
        /// Property minimum value allow in the textbox 
        /// </summary>
        public int MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }


        /// <summary>
        /// Property maximum value allow in the textbox 
        /// </summary>
        public int MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

       
        /// <summary>
        /// Method to validate the user input in the x and y coordinate textboxes 
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
                    if (coordinate < MinValue)
                        return new ValidationResult(false, ErrorMinValue());
                    if (coordinate > MaxValue)
                    return new ValidationResult(false, ErrorMaxValue());
            
            return ValidationResult.ValidResult;
        }


        /// <summary>
        /// Method to set the tooltip message if the user does not reach the min value 
        /// </summary>
        /// <returns></returns>
        public string ErrorMinValue()
        {
            string minV = "Coordiante < " + Convert.ToString(MinValue);

            return minV;
        }


        /// <summary>
        /// Mehtod to set the tooltip message if the user exceed the max value 
        /// </summary>
        /// <returns></returns>
        public string ErrorMaxValue()
        {
            string maxV = "Coordiante > " + Convert.ToString(MaxValue);

            return maxV;
        }
    }
}
