using System;
using System.Collections.Generic;
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

namespace Service_Helper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string scuffs, stringToOneS;
        AparatusList aparatusList = new();
        public MainWindow()
        {
            InitializeComponent();
            CopyPaste();

            

            copyToClipboard.Click += CopyToClipboard_Click;

            apparatus.ItemsSource = aparatusList.GetList();
            apparatus.SelectedIndex = 0;
            
            
            EngineerWarning.AppendText("Проверьте состояние дисплея и корпуса!!!");
            
        }

        private void CopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(copyPaste.Document.ContentStart, copyPaste.Document.ContentEnd).Text;
            Clipboard.SetText(richText);
        }
        
        private void CopyPaste()
        {
            stringToOneS = "Б/У, " + scuffs;
            copyPaste.Document.Blocks.Clear();
            copyPaste.AppendText(stringToOneS);
        }
        
        private void scuffs_Checked(object sender, RoutedEventArgs e)
        {
            scuffs = "потертости ";
            CopyPaste();
        }
        private void scuffs_Unchecked(object sender, RoutedEventArgs e)
        {
            scuffs = "";
            CopyPaste();
        }
    }
}
