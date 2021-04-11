using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;



namespace Service_Helper
{
    public partial class MainWindow : Window
    {
        AparatusList aparatusList = new();
        CheckList checkList = new();
        Appearance appearance = new();
        
        public MainWindow()
        {
            InitializeComponent();
            createCheckBox();
            copyToClipboard.Click += CopyToClipboard_Click;
            apparatus.ItemsSource = aparatusList.GetList;
            apparatus.SelectedIndex = 0;
            EngineerWarning.AppendText("Проверьте состояние дисплея и корпуса!!!");
        }

        private void CopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            FillTextBox();
            string richText = new TextRange(copyPasteString.Document.ContentStart, copyPasteString.Document.ContentEnd).Text;
            Clipboard.SetText(richText);
        }
        
        
        
        private void createCheckBox()
        {
            List<string> list = checkList.GetList;
            int countCheck = list.Count;
            for (int i = 0; i< countCheck;i++) 
            {
                string content = list[i];
                CheckBox checkBox = new();
                checkBox = checkList.GetCheck(content, i);
                checkBox.Checked += checkBox_Checked;
                checkBox.Unchecked += checkBox_Unchecked;
                checkBoxList.Items.Add(checkBox);
            }

        }
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            int index = Convert.ToInt32(chBox.Tag);
            appearance.setChBox(index, chBox.Content.ToString());
            FillTextBox();
        }
        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            int index = Convert.ToInt32(chBox.Tag);
            appearance.delChBox(index);
            FillTextBox();
        }

        private void FillTextBox()
        {
            Dictionary<int, string> appearanceText = appearance.GetList;
            string richText="";
            copyPasteString.Document.Blocks.Clear();
            foreach (string element in appearanceText.Values)
            {
                richText = richText + ", " + element.ToLower();
            }
            // Сломатый трехногий костыль, пока сам код в проработке
            richText = richText + Damage() + ". ";
            //
            
            copyPasteString.AppendText("Б/У" + richText);
        }
        private string Damage()
        {
            string str="";
            if (@case.IsChecked == true)
                str = str + ", погнут корпус";
            if(screen.IsChecked == true)
                str = str + ", разбит дисплей";
            if(connector.IsChecked == true)
                str = str + ", сломан разъем";
            return str;
            
        }

        private void resetApp_Click(object sender, RoutedEventArgs e)
        {
            appearance.delAll();
            checkBoxList.Items.Clear();
            createCheckBox();
            FillTextBox();
        }
    }
        
}
