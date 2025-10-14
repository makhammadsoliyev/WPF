using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var first = Convert.ToDouble(txbFirstNumber.Text);
            var second = Convert.ToDouble(txbSecondNumber.Text);

            lblSumResult.Content = first + " + " + second + " = " + (first + second);
            lblMinResult.Content = first + " - " + second + " = " + (first - second);
            lblMulResult.Content = first + " * " + second + " = " + (first * second);
            lblDivResult.Content = first + " / " + second + " = " + (first / second);
        }
    }
}