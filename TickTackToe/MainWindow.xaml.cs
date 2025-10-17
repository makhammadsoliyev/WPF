using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TickTackToe;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private static bool isCross = true;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var cnv = (Canvas)sender;
        if (cnv.Children.Count > 0)
            return;

        if (isCross)
        {
            DrawCross(cnv);
        }
        else
        {
            DrawCircle(cnv);
        }

        isCross = !isCross;
    }

    private static void DrawCircle(Canvas cnv)
    {
        var el = new Ellipse
        {
            Width = 80,
            Height = 80,
            Fill = Brushes.Transparent,
            Stroke = Brushes.Red,
            StrokeThickness = 10,
        };

        cnv.Children.Add(el);

        Canvas.SetLeft(el, 10);
        Canvas.SetTop(el, 10);
    }

    private static void DrawCross(Canvas cnv)
    {
        var padding = 15;

        var line1 = new Line
        {
            X1 = padding,
            Y1 = padding,
            X2 = cnv.Width - padding,
            Y2 = cnv.Height - padding,
            Stroke = Brushes.Blue,
            StrokeThickness = 10,
        };
        cnv.Children.Add(line1);

        var line2 = new Line
        {
            X1 = padding,
            Y1 = cnv.Height - padding,
            X2 = cnv.Width - padding,
            Y2 = padding,
            Stroke = Brushes.Blue,
            StrokeThickness = 10,
        };
        cnv.Children.Add(line2);
    }
}