using CustomBehaviorsLibrary1;
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
using System.Windows.Shapes;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for CanvasView.xaml
    /// </summary>
    public partial class CanvasView : Window
    {
        public CanvasView()
        {
            InitializeComponent();

            DrawGrid(10, 7, 60, 60);
        }

        public void DrawGrid(int cols, int rows, int colWidth, int rowHeight)
        {
            mainCanvas.Width = (cols - 1) * colWidth;
            //backgroundCanvas.Width = mainCanvas.Width;

            mainCanvas.Height = (rows - 1) * rowHeight;
            //backgroundCanvas.Height = mainCanvas.Height;


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
                var brush = new SolidColorBrush(Colors.Green);
                double elementWidth = 3;
                double elementHeight= 3;

                for (int i = 0; i < cols; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        var element = new Rect(
                            new Point(i * colWidth - elementWidth / 2, j * rowHeight - elementHeight / 2),
                            new Size(elementWidth, elementHeight));


                        GeometryGroup group = new GeometryGroup();
                        //group.Children.Add(new LineGeometry(new Point(0, 1), new Point(3, 1)));
                        //group.Children.Add(new LineGeometry(new Point(1, 0), new Point(1, 3)));
                        group.Children.Add(Geometry.Parse("M0 5 5 5 5 0 10 0 10 5 15 5 15 10 10 10 10 15 5 15 5 10 0 10 0 5Z"));

                        GeometryDrawing geometryDrawing = new GeometryDrawing();
                        geometryDrawing.Brush = Brushes.Blue;
                        geometryDrawing.Pen = new Pen(Brushes.Red, 1);
                        geometryDrawing.Geometry = group;

                        ImageSource imageSource = new DrawingImage(geometryDrawing);
                        dc.DrawImage(imageSource, element);
                    }
                }

            }

            backgroundCanvas.AddVisual(visual);

        }


    }
}
