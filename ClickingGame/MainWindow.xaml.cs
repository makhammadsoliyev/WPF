using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClickingGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int score = 0;
        private static int time = 10;
        private static readonly Random random = new();
        private static readonly DispatcherTimer timer = new();

        public MainWindow()
        {
            InitializeComponent();

            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            time--;
            txbTime.Text = "Time: " + time;

            if (time == 0)
            {
                timer.Stop();
                cnvGame.Children.Clear();

                MessageBox.Show("Game is over\nYour score: " + score);
            }
        }

        private void AddRectangle()
        {
            var rectangle = new Rectangle
            {
                Width = 50,
                Height = 50,
                Fill = Brushes.Black,
            };

            var left = random.Next((int)(cnvGame.ActualWidth - rectangle.Width));
            var top = random.Next((int)(cnvGame.Height - rectangle.Height));

            Canvas.SetLeft(rectangle, left);
            Canvas.SetTop(rectangle, top);

            rectangle.MouseDown += Rectangle_MouseDown;
            cnvGame.Children.Add(rectangle);
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cnvGame.Children.Remove((Rectangle)sender);
            score++;

            txbScore.Text = "Score = " + score;
            AddRectangle();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            cnvGame.Children.Clear();

            score = 0;
            time = 10;

            txbScore.Text = "Score: 0";
            txbTime.Text = "Time: 10";

            AddRectangle();
            timer.Start();
        }
    }
}