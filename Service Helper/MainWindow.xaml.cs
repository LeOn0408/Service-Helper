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
        DisplayingLists displayingLists = new();
        Appearance appearance = new();
        XmlLoad xmlLoad = new();
        public MainWindow()
        {
            InitializeComponent();
            xmlLoad.xmlLoad();
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
            List<CheckList> list = displayingLists.GetCheckLists;
            foreach (CheckList element in list)
            {
                if (element.Category == "Minor")
                {
                    CheckBox checkBox = new CheckBox
                    {
                        Name = element.Name,
                        Content = element.Content,
                        Tag = element.Category
                    };
                    checkBox.Checked += checkBox_Checked;
                    checkBox.Unchecked += checkBox_Unchecked;
                    checkBoxList.Items.Add(checkBox);
                }
                else if (element.Category == "Kit")
                {
                    CheckBox checkBox = new CheckBox
                    {
                        Name = element.Name,
                        Content = element.Content,
                        Tag = element.Category
                    };
                    checkBox.Checked += checkBox_Checked;
                    checkBox.Unchecked += checkBox_Unchecked;
                    kitBoxList.Items.Add(checkBox);
                }
            }

        }
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            string index = chBox.Name.ToString();
            string content = chBox.Content.ToString();//формирует нижнюю строку. Будет дальше расширятся и использоваться
            //string category = chBox.Tag.ToString();
            string category = chBox.Tag.ToString();
            appearance.SetList(index, content, category);
            FillTextBox();
        }
        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            string index = chBox.Name.ToString();
            appearance.DelList(index);
            FillTextBox();
        }

        private void FillTextBox()
        {
            Dictionary<string, CheckList> list = appearance.GetLists;
            string minor = "";
            string kit= "";
            copyPasteString.Document.Blocks.Clear();
            foreach (CheckList element in list.Values)
            {
                if (element.Category == "Minor")
                {
                    minor = minor + ", " + element.Content.ToLower();
                }
                if (element.Category == "Kit")
                {
                    kit = kit + ", " + element.Content.ToLower();
                }
            }
            copyPasteString.AppendText("Б/У" + minor + Damage()+ kit);
            
        }
        
        private string Damage()//костыль. Создать обьект
        {
            string str="";
            if (@case.IsChecked == true)
                str = str + ", погнут корпус";
            if(screen.IsChecked == true)
                str = str + ", разбит дисплей";
            if (screen.IsChecked == false && screenNotDamaged.IsChecked == false)
                str = str + ", состояние дисплея неизвестно";
            if(connector.IsChecked == true)
                str = str + ", сломан разъем";
            return str;
            
        }

        private void resetApp_Click(object sender, RoutedEventArgs e)
        {
            appearance.delAll();
            checkBoxList.Items.Clear();
            kitBoxList.Items.Clear();
            createCheckBox();
            FillTextBox();
        }
    }
        
}
