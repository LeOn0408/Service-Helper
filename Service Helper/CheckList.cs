using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Service_Helper
{
    class CheckList
    {
        public CheckList()
        {

        }
        private List<string> checkList = new List<string>{
            "Потертости",
            "Царапины",
            "Вмятины",
            "Следы эксплуатации"
        };
        public List<string> GetList => checkList;
        
        public CheckBox GetCheck(string content,int name)
        {
            CheckBox checkBox2 = new CheckBox
            {
                Tag = name,
                HorizontalContentAlignment = HorizontalAlignment.Left,
                VerticalContentAlignment = VerticalAlignment.Top,
                Content = content,
            };
            return checkBox2;
        }
    }
}
