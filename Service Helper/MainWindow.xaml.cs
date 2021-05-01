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
        public MainWindow()
        {
            InitializeComponent();
            CreateCheckBox();
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

        private void CreateCheckBox()
        {
            List<CheckList> list = displayingLists.GetCheckLists;
            foreach (CheckList element in list)
            {
                CheckBox checkBox = new ()
                {
                    Name = element.Name,
                    Content = element.Content,
                    Tag = element.Category
                };
                checkBox.Checked += CheckBox_Checked;
                checkBox.Unchecked += CheckBox_Unchecked;

                if (element.Category == "Minor")
                    minorDamageList.Items.Add(checkBox);
                if (element.Category == "Kit")
                    kitList.Items.Add(checkBox);
            }
            List<CheckList> nameRadio = list.FindAll(item => item.Category == "NameRadio");
            foreach (CheckList element in nameRadio)
            {
                ListView damage = new (){ BorderThickness = new Thickness(0) };
                RichTextBox text = new ()
                {
                    Height = 20,
                    Width = 200,
                    IsEnabled = false,
                    IsReadOnly = true,
                    BorderThickness = new Thickness(0),
                };
                text.AppendText(element.Content);
                damage.Items.Add(text);
                damageList.Items.Add(damage);

                List<CheckList> groupList = list.FindAll(item => item.GroupName == element.Name);
                foreach (CheckList el in groupList)
                {
                    RadioButton radio = new ()
                    {
                        Name = el.Name,
                        Content = el.Content,
                        Tag = el.Category,
                        GroupName = el.GroupName
                    };
                    radio.Checked += Radio_Checked;
                    radio.Unchecked += Radio_Unchecked;
                    damage.Items.Add(radio);
                }
            }



        }

        private void Radio_Unchecked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            string index = radio.Name.ToString();
            appearance.DelList(index);
            FillTextBox();
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            string index = radio.Name.ToString();
            appearance.SetList(index);
            FillTextBox();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            string index = chBox.Name.ToString();
            appearance.SetList(index);
            FillTextBox();
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
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
            string kit = "";
            copyPasteString.Document.Blocks.Clear();
            foreach (CheckList element in list.Values)
            {
                if (element.Category == "Minor")
                {
                    minor = minor + ", " + element.Content.ToLower();
                }
                if (element.Category == "Damage" && element.Content != String.Empty)
                {
                    minor = minor + ", " + element.Content.ToLower();
                }
                if (element.Category == "Kit")
                {
                    kit = kit + ", " + element.Content.ToLower();
                }
            }
            copyPasteString.AppendText("Б/У" + minor + kit);

        }
        private void ResetApp_Click(object sender, RoutedEventArgs e)
        {
            appearance.DelAll();
            minorDamageList.Items.Clear();
            kitList.Items.Clear();
            damageList.Items.Clear();
            CreateCheckBox();
            FillTextBox();
        }
    }

}
