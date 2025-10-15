using System.Windows;
using System.Windows.Controls;

namespace AdvancedCalculator
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

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            tbxInput.Text += btn.Content;
        }

        private void OnComputeButtonClick(object sender, RoutedEventArgs e)
        {
            var input = tbxInput.Text;
            var number = 0;
            var firstNumber = 0;
            var operation = ' ';

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] is >= '0' and <= '9')
                {
                    number *= 10;
                    number += (input[i] - '0');
                }
                else if (input[i] is '+' or '-' or '*' or '/')
                {
                    switch (operation)
                    {
                        case '+':
                            number += firstNumber;
                            break;
                        case '-':
                            number -= firstNumber;
                            break;
                        case '*':
                            number *= firstNumber;
                            break;
                        case '/':
                            number /= firstNumber;
                            break;
                    }

                    operation = input[i];
                    firstNumber = number;
                    number = 0;
                }
            }

            switch (operation)
            {
                case '+':
                    number += firstNumber;
                    break;
                case '-':
                    number -= firstNumber;
                    break;
                case '*':
                    number *= firstNumber;
                    break;
                case '/':
                    number /= firstNumber;
                    break;
            }

            tbxInput.Text = number.ToString();
        }
    }
}