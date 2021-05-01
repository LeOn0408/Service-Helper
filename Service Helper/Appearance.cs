using System.Collections.Generic;


namespace Service_Helper
{
    class Appearance
    {
        private Dictionary<string,CheckList> appearance = new();
        DisplayingLists displayingLists = new();

        public void SetList(string index, string content, string category)
        {
            List<CheckList> list = displayingLists.GetCheckLists;
            CheckList found = list.Find(item => item.Name == index);
            string desc = found.Description ?? found.Content;
            appearance[index] = new CheckList() { Content = desc, Category = category };
        }
        public void DelList(string index) 
        {
          appearance.Remove(index);
        }
        public void delAll()
        {
            appearance.Clear();
        }
        public Dictionary<string, CheckList> GetLists => appearance;
    }
}
