using System.Collections.Generic;


namespace Service_Helper
{
    class Appearance
    {
        private Dictionary<int, CheckList> appearance = new();
        Database database = new ();
        public void SetList(int index)
        {
            List<CheckList> list = database.GetCheckLists();
            CheckList found = list.Find(item => item.ID == index);
            string desc = found.Description ?? found.Content;
            appearance[index] = new CheckList() { Content = desc, Category = found.Category };
        }
        public void DelList(int index)
        {
            appearance.Remove(index);
        }
        public void DelAll()
        {
            appearance.Clear();
        }
        public Dictionary<int, CheckList> GetLists => appearance;
    }
}
