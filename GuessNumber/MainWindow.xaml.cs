using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace GuessNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int lives = 10;
        private int random;
        private readonly Random rdn = new Random();
        private bool isGameOver = false;

        public MainWindow()
        {
            InitializeComponent();
            RestartGame();
        }

        private void txbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            if (isGameOver)
            {
                lblStatus.Content = "Game Over! Click Restart.";

                return;
            }

            if (lives == 0)
            {
                lblFrom.Content = "You";
                lblTo.Content = "loose!";

                return;
            }

            if (!int.TryParse(txbInput.Text, out var userGuess))
            {
                lblStatus.Content = "Please enter valid number.";
                lblStatus.Foreground = new SolidColorBrush(Colors.Orange);

                return;
            }

            lives--;
            lblStatus.Content = "Remaining Lives: " + lives;
            if (lives <= 3)
                lblStatus.Foreground = new SolidColorBrush(Colors.Red);
            else
                lblStatus.Foreground = new SolidColorBrush(Colors.Green);

            if (userGuess == random)
            {
                lblFrom.Content = "You ";
                lblTo.Content = "win!";
                lblStatus.Content = "Congratulations 🎉";
                lblStatus.Foreground = new SolidColorBrush(Colors.Green);
                isGameOver = true;

                return;
            }

            if (userGuess < random)
                lblFrom.Content = userGuess;
            else
                lblTo.Content = userGuess;

            if (lives <= 0)
            {
                lblFrom.Content = "You ";
                lblTo.Content = "lose!";
                lblStatus.Content = "The number was " + random;
                isGameOver = true;
            }
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }

        private void RestartGame()
        {
            lblFrom.Content = 0;
            lblTo.Content = 100;
            lives = 10;
            lblStatus.Content = "Remaining Lives: " + lives;
            random = rdn.Next(0, 100);
            txbInput.Clear();
            lblStatus.Foreground = new SolidColorBrush(Colors.Green);
            isGameOver = false;
        }
    }
}