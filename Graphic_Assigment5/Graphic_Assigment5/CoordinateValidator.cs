using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Graphic_Assigment5
{//Assigment 5 level 3 David Bartolomé 04-12-2017
    public class CoordinateValidator : ValidationRule
    {
       
    
        /// <summary>
        /// Method to validate the coordinate x and y 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;

            double coordinate;

            if (string.IsNullOrEmpty(str))
                return new ValidationResult(false, "Coordinate cannot be empty.");

            else
            {
                if (Double.TryParse((string)value, out coordinate))
                    if (coordinate == 0)
                        return new ValidationResult(false, "Coordinate > 0");
                if (coordinate < 0)
                    return new ValidationResult(false, "Coordinate > 0");
                else if (coordinate > 100)
                    return new ValidationResult(false, "Coordinate < 100");
            }
            return ValidationResult.ValidResult;
        }
    }
}
