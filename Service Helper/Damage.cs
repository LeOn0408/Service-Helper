using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Service_Helper
{
    class Damage
    {
        private List<string> damageList = new List<string>{
            
        };
        public List<string> GetList => damageList;

        public RadioButton GetCheck(string content, string group, int name)
        {
            RadioButton checkBox2 = new RadioButton
            {
                Tag = name,
                Content = content,
                GroupName = group,
            };
            return checkBox2;
        }
        

    }
}
