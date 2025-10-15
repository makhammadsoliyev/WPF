using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace TextEditor
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

        private void OnOpenFileClick(object sender, RoutedEventArgs e)
        {
            var fd = new OpenFileDialog();
            if (fd.ShowDialog() is true)
            {
                using var reader = new StreamReader(fd.FileName);
                txtBox.Document.Blocks.Clear();
                txtBox.AppendText(reader.ReadToEnd());
            }

        }

        private void OnSaveFileClick(object sender, RoutedEventArgs e)
        {
            var sf = new SaveFileDialog();
            if (sf.ShowDialog() is true)
            {
                using var writer = new StreamWriter(sf.FileName);
                var text = new TextRange(txtBox.Document.ContentStart, txtBox.Document.ContentEnd).Text;
                writer.Write(text);
            }
        }

        private void OnNewFileClick(object senser, RoutedEventArgs e)
        {
            txtBox.Document.Blocks.Clear();
        }

        private void OnCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}