using System.Collections.Generic;


namespace Service_Helper
{
    class Appearance
    {
        Dictionary<int, string> appearance = new Dictionary<int, string>();
        public Dictionary<int, string> GetList => appearance;

        public void setChBox(int index, string content)
        {
            appearance[index] = content;
        }
        public void delChBox(int index)
        {
            appearance.Remove(index);
        }
        public void delAll()
        {
            appearance.Clear();
        }

    }
}
