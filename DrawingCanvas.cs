using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp.Views
{
    public class DrawingCanvas : Canvas
    {
        List<Visual> visuals = new List<Visual>();


        protected override int VisualChildrenCount => visuals.Count;
        protected override Visual GetVisualChild(int index)
        {
            return visuals[index];
        }

        public void AddVisual(Visual visual)
        {
            visuals.Add(visual);

            AddVisualChild(visual);
            AddLogicalChild(visual);
        }

        public void RemoveVisual(Visual visual)
        {
            visuals.Remove(visual);

            RemoveVisualChild(visual);
            RemoveLogicalChild(visual);
        }

        public DrawingVisual GetVisual(Point point)
        {
            HitTestResult hitResult = VisualTreeHelper.HitTest(this, point);
            return hitResult.VisualHit as DrawingVisual;
        }

        public SolidColorBrush MyBackground
        {
            get { return (SolidColorBrush)GetValue(MyBackgroundProperty); }
            set { SetValue(MyBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyBackgroundProperty =
            DependencyProperty.Register("MyBackground", typeof(SolidColorBrush), typeof(DrawingCanvas), new PropertyMetadata(new SolidColorBrush(Colors.Black)));


    }
}
