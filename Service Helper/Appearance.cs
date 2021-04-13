using System.Collections.Generic;


namespace Service_Helper
{
    class Appearance
    {
        private Dictionary<string,CheckList> appearance = new();
        
        public void SetList(string index, string content, string category)
        {
            appearance[index] = new CheckList() { Content = content, Category = category };
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
