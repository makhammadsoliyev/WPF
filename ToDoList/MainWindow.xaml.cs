using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ToDoList
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

        private void txbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txbInput.Text))
            {
                btnAdd.IsEnabled = true;

                if (e.Key == Key.Enter)
                {
                    addToListBox(txbInput.Text);
                }
            }
        }

        private void addToListBox(string text)
        {
            lbxTasks.Items.Add(text);
            txbInput.Clear();
            btnAdd.IsEnabled = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            addToListBox(txbInput.Text);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            lbxTasks.Items.Remove(lbxTasks.SelectedItem);
            btnDelete.IsEnabled = false;
        }

        private void lbxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = true;
        }
    }
}