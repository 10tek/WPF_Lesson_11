using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace FixedDocumentLesson
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

        private void UploadXpsClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var isProcessed = openFileDialog.ShowDialog();

            if (isProcessed.Value)
            {
                var xpsFileName = openFileDialog.FileName;
                using (XpsDocument xpsDocument = new XpsDocument(xpsFileName, FileAccess.ReadWrite))
                {
                    documentViewer.Document = xpsDocument.GetFixedDocumentSequence();
                }
            }
        }

        private void SaveXps(object sender, RoutedEventArgs e)
        {
        }

        private void SaveXps(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            var hasResult = saveFileDialog.ShowDialog();

            if (hasResult.Value)
            {
                var xpsFileName = saveFileDialog.FileName;
                using (var xpsDocument = new XpsDocument(xpsFileName, FileAccess.ReadWrite))
                {
                    XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
                    writer.Write(fixedDocument.DocumentPaginator);
                }
            }
        }

    }
}
