using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Canvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDrawing = false;
        private Point previousPoint;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cnv_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDrawing = true;
            previousPoint = e.GetPosition(cnv);
            cnv.CaptureMouse();
        }


        private void cnv_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDrawing = false;
            cnv.ReleaseMouseCapture();
        }

        private void cnv_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing)
                return;

            var currentPoint = e.GetPosition(cnv);
            var line = new Line
            {
                X1 = previousPoint.X,
                Y1 = previousPoint.Y,
                X2 = currentPoint.X,
                Y2 = currentPoint.Y,

                StrokeThickness = 2,
                Stroke = Brushes.Brown
            };

            cnv.Children.Add(line);
            previousPoint = currentPoint;
        }
    }
}