using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;

namespace Graphic_Assigment5
{
    public class DivisionValidator : ValidationRule
    {//Assigment 5 level 3 David Bartolomé 04-12-2017

        int divisionNumber;


        /// <summary>
        /// Method to validate the user input textbox divisions 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
      {
            string str = value as string;


            if (string.IsNullOrEmpty(str))
                return new ValidationResult(false, "Coordinate cannot be empty.");

            else
            {
                if (Int32.TryParse((string)value, out divisionNumber))
                    if (divisionNumber == 0)
                        return new ValidationResult(false, "Coordinate > 0");
                if (divisionNumber < 0)
                    return new ValidationResult(false, "Coordinate > 0");
                else if (divisionNumber > 12)
                    return new ValidationResult(false, "Coordinate < 13");
            }
            return ValidationResult.ValidResult;
        }
    }
}
