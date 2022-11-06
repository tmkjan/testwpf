using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CustomBehaviorsLibrary1
{
    public static class GridExtensions
    {
        public static void SnapToGrid(this Canvas canvas, FrameworkElement element, int colWidth, int rowHeight)
        {
            var elementPosition = new Point(Canvas.GetLeft(element), Canvas.GetTop(element));

            if(elementPosition.X < 0)
                elementPosition.X = 0;
            if (elementPosition.X > canvas.Width)
                elementPosition.X = canvas.Width;
            
            if (elementPosition.Y < 0)
                elementPosition.Y = 0;
            if(elementPosition.Y>canvas.Height)
                elementPosition.Y = canvas.Height;

            var elementOrigin = element.GetOrigin(elementPosition);

            double xSnap = elementOrigin.X % colWidth;
            double ySnap = elementOrigin.Y % rowHeight;

            if (xSnap <= colWidth / 2.0)
                xSnap *= -1;
            else
                xSnap = colWidth - xSnap;

            if (ySnap <= rowHeight / 2.0)
                ySnap *= -1;
            else
                ySnap = rowHeight - ySnap;

            xSnap += elementOrigin.X;
            ySnap += elementOrigin.Y;

            Canvas.SetLeft(element, xSnap - element.ActualWidth/2);
            Canvas.SetTop(element, ySnap - element.ActualHeight/2);
        }

        public static Point GetOrigin(this FrameworkElement element, Point position)
        {
            var x = element.ActualWidth / 2.0;
            var y = element.ActualHeight / 2.0;

            return new Point(position.X + x, position.Y + y);
        }

        public static void DrawGrid(this Canvas canvas, int cols, int rows, int colWidth, int rowHeight)
        {
            canvas.Width = (cols - 1) * colWidth;
            canvas.Height = (rows -1)  * rowHeight;

            //for (int i = 0; i < cols; i++)
            //{
            //    for (int j = 0; j < rows; j++)
            //    {
            //        var element = new Rectangle { Width = 3, Height = 3, Fill = new SolidColorBrush(Colors.Green) };
            //        canvas.Children.Add(element);
            //        Canvas.SetLeft(element, i * colWidth - element.Width / 2);
            //        Canvas.SetTop(element, j * rowHeight - element.Height / 2);
            //    }
            //}

            DrawingVisual visual = new DrawingVisual();
            using (DrawingContext dc = visual.RenderOpen())
            {
                dc.DrawLine(new Pen(new SolidColorBrush(Colors.Red), 1), new Point(10, 10), new Point(60, 60));
            }

        }
    }
}
