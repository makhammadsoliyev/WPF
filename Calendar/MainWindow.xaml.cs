using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Calendar
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

        private void SaveEvents()
        {
            try
            {
                using var sr = new StreamWriter(cldDate.SelectedDate!.Value.ToString("D"));

                foreach (var item in lbxEvents.Items)
                {
                    sr.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading events:\n" + ex.Message);
            }
        }

        private void cldDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cldDate.SelectedDate is null)
                return;

            lbxEvents.Items.Clear();
            try
            {
                using var sr = new StreamReader(cldDate.SelectedDate!.Value.ToString("D"));

                while (!sr.EndOfStream)
                {
                    lbxEvents.Items.Add(sr.ReadLine());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading events:\n" + ex.Message);
            }
        }

        private void lbxEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemove.IsEnabled = lbxEvents.SelectedItem is not null;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbTime.Text) || string.IsNullOrWhiteSpace(txbName.Text))
            {
                MessageBox.Show("Please enter both name and time");
                return;
            }

            var item = txbName.Text + " at " + txbTime.Text;
            lbxEvents.Items.Add(item);
            SaveEvents();

            txbName.Clear();
            txbTime.Clear();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (lbxEvents.SelectedItem is null)
                return;

            lbxEvents.Items.Remove(lbxEvents.SelectedItem);
            SaveEvents();
            btnRemove.IsEnabled = false;
        }
    }
}