using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graph
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point prevoiusPoint;
        private Point originPoint;
        private bool isInitialized = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawLine(Point point1, Point point2)
        {
            var line = new Line
            {
                X1 = point1.X,
                Y1 = point1.Y,
                X2 = point2.X,
                Y2 = point2.Y,
                StrokeThickness = 2,
                Stroke = Brushes.White,
            };

            cnv.Children.Add(line);
        }

        private void AddLabel(Point point, string content)
        {
            var label = new Label
            {
                Content = content,
                Foreground = Brushes.White,
                FontSize = 10
            };

            cnv.Children.Add(label);
            Canvas.SetLeft(label, point.X);
            Canvas.SetTop(label, point.Y);
        }

        private void cnv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isInitialized)
            {
                var currentPoint = e.GetPosition(cnv);

                DrawLine(prevoiusPoint, currentPoint);
                DrawLine(new Point(originPoint.X, prevoiusPoint.Y), new Point(originPoint.X, currentPoint.Y));
                DrawLine(new Point(prevoiusPoint.X, originPoint.Y), new Point(currentPoint.X, originPoint.Y));

                AddLabel(new Point(currentPoint.X, originPoint.Y + 10), (currentPoint.X - originPoint.X).ToString("F2"));
                AddLabel(new Point(originPoint.X - 50, currentPoint.Y), (originPoint.Y - currentPoint.Y).ToString("F2"));

                prevoiusPoint = currentPoint;
            }
            else
            {
                isInitialized = true;
                prevoiusPoint = e.GetPosition(cnv);
                originPoint = e.GetPosition(cnv);
            }
        }
    }
}