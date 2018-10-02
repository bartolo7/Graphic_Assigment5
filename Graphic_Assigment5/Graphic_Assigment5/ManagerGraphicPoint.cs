using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Graphic_Assigment5
{
    public class ManagerGraphicPoint
    {//Assigment 5 level 3 David Bartolomé 04-12-2017


        PointCollection points = new PointCollection();


        PointCollection poinstRelativeCoordinates = new PointCollection();

        /// <summary>
        /// Constructor 
        /// </summary>
        public ManagerGraphicPoint()
        {

        }


        /// <summary>
        /// Property points stores the absolute value provided by the user 
        /// </summary>
        public PointCollection Points
        {
            get { return points; }
            set { points = value; }
        }


        /// <summary>
        /// Property PointsRelativeCoordiante stores the relative (abosulte * scale)
        /// </summary>
        public PointCollection PointsRelativeCoordinates
        {
            get { return poinstRelativeCoordinates; }
            set { points = poinstRelativeCoordinates; }
        }
    }
}
