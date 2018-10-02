using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Graphic_Assigment5
{//Assigment 5 level 3 David Bartolomé 04-12-2017

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ManagerGraphicPoint theUserInput = new ManagerGraphicPoint();
        private const int margin = 40;


        /// <summary>
        /// Method MainWindow 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new Graphic();

            InitializeGUI();
        }


        /// <summary>
        /// Method to initialize the GUI
        /// </summary>
        public void InitializeGUI()
        {
            //Interval input
            txtAxis_X_Interval.MaxLength = 3;
            txtAxis_Y_Interval.MaxLength = 3;

            //Division input 
            txtAxis_X_Division.MaxLength = 2;
            txtAxis_Y_Division.MaxLength = 2;


            //Point divisionNumber 
            txtCoordinateY.MaxLength = 4;
            txtCoordinateX.MaxLength = 4;

            grpPoints.IsEnabled = false;

            //Tittle 
            txtTittle.MaxLength = 18;
        

            ////Lines 
            //PlotTheGraphLines();

            ////Dots 
            //Plot_X_axisDots();
            //Plot_Y_axisDots();

            ////Legend 
            //Plot_X_axisLegend(100);
            //Plot_Y_axisLegend(100);
        }


        /// <summary>
        /// Method to plot the x and y lines in the graph 
        /// </summary>
        public void PlotTheGraphLines()
        {
            // Create a red Brush
            SolidColorBrush redBrush = new SolidColorBrush();
            redBrush.Color = Colors.Red;

            Line x_Axis = new Line();
            Line y_Axis = new Line();

            //Start point X
            x_Axis.X1 = margin;
            x_Axis.Y1 = margin;


            //Start point X
            x_Axis.X1 = margin;
            x_Axis.Y1 = margin;

            //End point X
            x_Axis.X2 = margin;
            x_Axis.Y2 = canGraph.Height - margin;

            //Start point Y
            y_Axis.X1 = margin;
            y_Axis.Y1 = canGraph.Height - margin;

            //End point Y
            y_Axis.X2 = canGraph.Width - margin;
            y_Axis.Y2 = canGraph.Height - margin;



            // Set Line's width and color
            x_Axis.StrokeThickness = 2;
            x_Axis.Stroke = redBrush;

            y_Axis.StrokeThickness = 2;
            y_Axis.Stroke = redBrush;

            canGraph.Children.Add(x_Axis);
            canGraph.Children.Add(y_Axis);
        }

        /// <summary>
        /// Method to add dots to the X axis in the graph 
        /// </summary>
        public void Plot_X_axisDots(int division)
        {
            //X axis length 
            int xLength = ((int)canGraph.Width - 2* margin);

            //Steps from point 0,0
            int steps =  xLength / division;

          
            //First step in the X axis 
            int dX_P = steps + margin;

            for (int a = 0; a < division; a++)
            {

                Ellipse rY1 = new Ellipse();
                {
                    rY1.Fill = Brushes.Black;
                    rY1.Width = 4;
                    rY1.Height = 4;
                    rY1.HorizontalAlignment = HorizontalAlignment.Center;
                    rY1.VerticalAlignment = VerticalAlignment.Center;
                }

                canGraph.Children.Add(rY1);
                Canvas.SetTop(rY1, canGraph.Height - margin - 2); 
                Canvas.SetLeft(rY1, dX_P);

                //Increase steps 
                dX_P += steps;
            }
        }

        /// <summary>
        /// Method to add dots to the Y axis in the graph 
        /// </summary>
        public void Plot_Y_axisDots(int division)
        {

            //Y axis length 
            int yLength = ((int)canGraph.Height - 2 * margin);

            //Steps from point 0,0
            int steps = yLength / division;


            // Y Axis in the Graph 
            int dY_P = steps + margin;


            for (int a = 0; a < division; a++)
            {

                Ellipse rY1 = new Ellipse();
                {
                    rY1.Fill = Brushes.Black;
                    rY1.Width = 4;
                    rY1.Height = 4;

                }
                canGraph.Children.Add(rY1);
                Canvas.SetTop(rY1, canGraph.Height - dY_P);
                Canvas.SetLeft(rY1, margin - 2 );

                dY_P += steps;
            }

        }

        /// <summary>
        /// Method to drawn the X axis numbers 
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="division"></param>
        public void Plot_X_axisLegend(int interval, int division)
        {
            //X axis length 
            int xLength = ((int)canGraph.Width - 2 * margin);

            //Steps from point 0,0
            int steps = xLength / division;


            //First step in the X axis 
            int dX_Position = steps + margin;


            // X Legend Graph 
            int dX_Legend = interval;
            //int dX_Position = 68;

            for (int a = 0; a < division; a++)
            {
                TextBox numberY1 = new TextBox();
                numberY1.Text = dX_Legend.ToString();
                numberY1.Background = Brushes.Gray;
                numberY1.BorderBrush = Brushes.Gray;
                numberY1.VerticalAlignment = VerticalAlignment.Center;
                numberY1.HorizontalAlignment = HorizontalAlignment.Center;

                canGraph.Children.Add(numberY1);
                Canvas.SetTop(numberY1, canGraph.Height - margin + 2); // 2 extra margin so the number is not on top of the line
                Canvas.SetLeft(numberY1, dX_Position - 5); // 5 to center the number with the dot

                dX_Legend += interval;
                dX_Position += steps;
            }   
        }


        /// <summary>
        /// Method to drawn the Y axis numbers
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="division"></param>
        public void Plot_Y_axisLegend(int interval, int division)
        {

            //Y axis length 
            int yLength = ((int)canGraph.Height - 2 * margin);

            //Steps from point 0,0
            int steps = yLength / division;


            // Y Axis in the Graph 
            int dY_Position = steps + margin;


            // Y Legend Graph 
            int dY_Legend = interval;
            //int dY_Position = 68;

            for (int a = 0; a < division; a++)
            {

                TextBox numberY1 = new TextBox();
                numberY1.Text = dY_Legend.ToString();
                numberY1.Background = Brushes.Gray;
                numberY1.BorderBrush = Brushes.Gray;
                numberY1.VerticalAlignment = VerticalAlignment.Center;
                numberY1.HorizontalAlignment = HorizontalAlignment.Center;

                canGraph.Children.Add(numberY1);

                Canvas.SetTop(numberY1, canGraph.Height - dY_Position - 8);
                Canvas.SetLeft(numberY1, 6);

                dY_Legend += interval;
                dY_Position += steps;
            }
        }


        /// <summary>
        /// Method to delete all the drawings in the canvas
        /// </summary>
        public void DeleteTheGraph()
        {
            canGraph.Children.Clear();

        }



        /// <summary>
        /// Method to populate the listbox of points
        /// </summary>
        public void PopulateListOfPoints()
        {
            lsbPoints.Items.Clear();

            foreach (var a in theUserInput.Points)
            {
                lsbPoints.Items.Add(a);
            }
        }



        /// <summary>
        /// Event to not allow character in the textbox divisionNumber 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


     

        /// <summary>
        /// Method to add point to listbox and ManagerGraphicPoint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPoint_Click(object sender, RoutedEventArgs e)
        {

            if(CheckCoordinateInput())
            {
                double pointX = ((Convert.ToInt32(txtCoordinateX.Text) * ScalePointX()) + margin);

                double pointY = (int)canGraph.Height - ((Convert.ToInt32(txtCoordinateY.Text) * ScalePointY()) + margin);

                theUserInput.Points.Add(new Point(Convert.ToInt32(txtCoordinateX.Text), Convert.ToInt32(txtCoordinateY.Text)));

                PopulateListOfPoints();

                DrawInTheCavasThePolyline(pointX, pointY);

                UpdateGUI();
            }
        }


        /// <summary>
        /// Method to calculate the scale factor for the X axis 
        /// </summary>
        /// <returns></returns>
        private double ScalePointX()
        {
            int xInterval = Convert.ToInt32(txtAxis_X_Interval.Text);

            int xDivision = Convert.ToInt32(txtAxis_X_Division.Text);

            double scaleX = ((canGraph.Width - 2 * margin) / (xDivision * xInterval));

            return scaleX;
        }


        /// <summary>
        /// Method to calculate the scale factor for the Y axis 
        /// </summary>
        /// <returns></returns>
        private double ScalePointY()
        {
            int yInterval = Convert.ToInt32(txtAxis_Y_Interval.Text);

            int yDivision = Convert.ToInt32(txtAxis_Y_Division.Text);

            double scaleY = (canGraph.Width - 2 * margin) / (yDivision * yInterval);

            return scaleY;
        }


        /// <summary>
        /// Method to check the user input divisionNumber X and Y
        /// </summary>
        /// <returns></returns>
        public bool CheckCoordinateInput()
        {
            bool proceed = false;
            int xValue;
            int yValue;

            int minX = xLimitRange.MinValue -1; //Validation value >= minX
            int maxX = xLimitRange.MaxValue +1; //Validation value =< maxX the bool does not accept = that´s why +-1

            int minY = yLimitRange.MinValue - 1;
            int maxY = yLimitRange.MaxValue + 1;

            if (Int32.TryParse(txtCoordinateX.Text, out xValue))
                if (Int32.TryParse(txtCoordinateY.Text, out yValue))
                    if (yValue < maxY && xValue < maxX  && xValue > minX && yValue > minY)
                        proceed = true;

            return proceed;
        }



        /// <summary>
        /// Method to set GUI to defaul values after some actions
        /// </summary>
        public void UpdateGUI()
        {
            //Point divisionNumber 
            txtCoordinateX.Text = string.Empty;
            txtCoordinateY.Text = string.Empty;
        }



        /// <summary>
        /// Event to safe graph setting and enable points group 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Graphic theGraph = new Graphic();

            int x_Div;

            int y_Div;


            bool x_Division = Int32.TryParse(txtAxis_X_Division.Text, out x_Div);
            bool y_Division = Int32.TryParse(txtAxis_Y_Division.Text, out y_Div);

            if (Graphic.ValidationUserInput(txtAxis_X_Interval.Text))
            {
                if (Graphic.ValidationUserInput(txtAxis_Y_Interval.Text))
                {

                    int x = Convert.ToInt32(txtAxis_X_Interval.Text);

                    int y = Convert.ToInt32(txtAxis_Y_Interval.Text);


                    if (x_Division && y_Division && x_Div > 0 &&  x_Div < 13 && y_Div < 13 && y_Div > 0 )
                    {
                        ////Lines 
                        PlotTheGraphLines();

                        //Dots 
                        Plot_X_axisDots(x_Div);
                        Plot_Y_axisDots(y_Div);

                        //Legend 
                        Plot_X_axisLegend(x, x_Div);
                        Plot_Y_axisLegend(y, y_Div);

                        //Set low and high limit value to set textbox coordinate X
                        SetLimitTextBoxCoordinateX(x, x_Div);
                        SetLimitTextBoxCoordinateY(y, y_Div);

                        //Set GUI
                        UpdateGUI();
                        grpPoints.IsEnabled = true;
                        grpSettings.IsEnabled = false;

                        //Coordinate values are initialize
                        txtCoordinateX.Text = string.Empty;
                        txtCoordinateY.Text = string.Empty;
                    }
                }
            }
        }


        /// <summary>
        /// Method to set the low and high limit for the textbox validation coordinate X 
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="division"></param>
        public void SetLimitTextBoxCoordinateX(int interval, int division)
        {
           
            xLimitRange.MinValue = interval;

            xLimitRange.MaxValue = interval * division;

        }



        /// <summary>
        /// Method to set the low and high limit for the textbox validation coordinate X 
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="division"></param>
        public void SetLimitTextBoxCoordinateY(int interval, int division)
        {

            yLimitRange.MinValue = interval;

            yLimitRange.MaxValue = interval * division;

        }

        /// <summary>
        /// Event to clear graph and enable setting group 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearGraph_Click(object sender, RoutedEventArgs e)
        {
            grpPoints.IsEnabled = false;
            grpSettings.IsEnabled = true;

            //Tittle
            txtTittle.Text = string.Empty;

            //X and Y interval textboxes 
            txtAxis_X_Interval.Text = string.Empty;
            txtAxis_Y_Interval.Text = string.Empty;

            //X and Y division textboxes
            txtAxis_X_Division.Text = string.Empty;
            txtAxis_Y_Division.Text = string.Empty;

            //X and Y coordinate
            txtCoordinateX.Text = string.Empty;
            txtCoordinateY.Text = string.Empty;

            //Listbox clear 
            lsbPoints.Items.Clear();
            theUserInput.Points.Clear();
            theUserInput.PointsRelativeCoordinates.Clear();

            DeleteTheGraph();

           
        }

        /// <summary>
        /// Method to load window and trigger updatepropertychange - validation in the setting group 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //X and Y interval textboxes 
            txtAxis_X_Interval.Text = string.Empty;
            txtAxis_Y_Interval.Text = string.Empty;

            //X and Y division textboxes
            txtAxis_X_Division.Text = string.Empty;
            txtAxis_Y_Division.Text = string.Empty;

          

        }

        /// <summary>
        /// Method to reset the Setting group by using the event button ClearGraph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            btnCancel.Click += (o, s) => btnClearGraph_Click(o, s);
        }



        /// <summary>
        /// Method to drawn the polyline in the canvas 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void DrawInTheCavasThePolyline(double x, double y)
        {
            //Create a black brush
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;


            ///////////////////////////////////////
            // Create a polyline
            Polyline graphline = new Polyline();
            graphline.Stroke = blackBrush;
            graphline.StrokeThickness = 1;
            
            Point point1 = new Point(x, y);

            theUserInput.PointsRelativeCoordinates.Add(point1);

            graphline.Points = theUserInput.PointsRelativeCoordinates;

            canGraph.Children.Add(graphline);
            ///////////////////////////////////////

        }


        /// <summary>
        /// Event to close down the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Event to re-organize the points in the X direction and plot a new graph. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xDirection_Click(object sender, RoutedEventArgs e)
        {

            //Sort list
            var xDir = theUserInput.Points.OrderBy(x => x.X);

            lsbPoints.Items.Clear();

            //Add points to UI
            foreach (var a in xDir)
            {
                lsbPoints.Items.Add(a);
            }

            //ReDrawPolylineInTheCanvasDirectionChange("dirX");
            ReOrderListboxNumber();
        }

        /// <summary>
        /// Event to sort the the points in the Y direction and plot a new graph. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yDirection_Click(object sender, RoutedEventArgs e)
        {

            var yDir = theUserInput.Points.OrderBy(y => y.Y);

            //Listbox clear 
            lsbPoints.Items.Clear();


            //Add points to UI
            foreach (var a in yDir)
            {
                lsbPoints.Items.Add(a);
            }

            //ReDrawPolylineInTheCanvasDirectionChange("dirY");
            ReOrderListboxNumber();
        }

        /// <summary>
        /// Method to reorder Listbox in the GUI 
        /// </summary>
        public void ReOrderListboxNumber()
        {
            DeleteTheGraph();
            PlotTheGraphLines();
            Plot_X_axisDots(Convert.ToInt32(txtAxis_X_Division.Text));
            Plot_Y_axisDots(Convert.ToInt32(txtAxis_Y_Division.Text));
            Plot_X_axisLegend(Convert.ToInt32(txtAxis_X_Interval.Text), Convert.ToInt32(txtAxis_X_Division.Text));
            Plot_Y_axisLegend(Convert.ToInt32(txtAxis_X_Interval.Text), Convert.ToInt32(txtAxis_Y_Division.Text));

            theUserInput.Points.Clear();
            theUserInput.PointsRelativeCoordinates.Clear();


            for (int a = 0; a < lsbPoints.Items.Count; a++)
            {
                Point dPoint = (Point)lsbPoints.Items.GetItemAt(a);
                theUserInput.Points.Add(dPoint);

                double pointX = (dPoint.X * ScalePointX()) + margin;

                double pointY = (int)canGraph.Height - ((dPoint.Y * ScalePointY()) + margin);

                DrawInTheCavasThePolyline(pointX, pointY);
            }


        }

        /// <summary>
        /// Mehtod to draw the polyline if the user select x or y direction increment
        /// </summary>
        /// <param name="axis"></param>
        private void ReDrawPolylineInTheCanvasDirectionChange(string axis)
        {
            DeleteTheGraph();
            PlotTheGraphLines();
            Plot_X_axisDots(Convert.ToInt32(txtAxis_X_Division.Text));
            Plot_Y_axisDots(Convert.ToInt32(txtAxis_Y_Division.Text));
            Plot_X_axisLegend(Convert.ToInt32(txtAxis_X_Interval.Text), Convert.ToInt32(txtAxis_X_Division.Text));
            Plot_Y_axisLegend(Convert.ToInt32(txtAxis_X_Interval.Text), Convert.ToInt32(txtAxis_Y_Division.Text));



            PointCollection thelist = new PointCollection();

            //thelist = ReOrderListboxNumber();


            if (axis.Contains("dirX"))
            {

                thelist.Clear();

                theUserInput.PointsRelativeCoordinates.Clear();

                var xDirGraph = theUserInput.PointsRelativeCoordinates.OrderBy(x => x.X);


                foreach (var a in xDirGraph)
                {

                    Point newP = new Point(a.X, a.Y);

                    thelist.Add(newP);

                    xDirectionPolyline.Points = thelist;
                    canGraph.Children.Add(xDirectionPolyline);

                }
            }

            if (axis.Contains("dirY"))
            {

                var yDirGraph = theUserInput.PointsRelativeCoordinates.OrderBy(y => y.Y);

                foreach (var a in yDirGraph)
                {
                    DrawInTheCavasThePolyline(a.X, a.Y);
                }
            }

        }


        //////////////FFFFFFFFFFF

       
       
    }
}
