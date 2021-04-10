using System.Collections.Generic;


namespace Service_Helper
{
    class CopyPaste
    {
        Dictionary<int, string> copyPaste = new Dictionary<int, string>();
        public Dictionary<int, string> GetList => copyPaste;
        
        public void setChBox(int index,string content)
        {
            copyPaste[index] = content;
        }
        public void delChBox(int index)
        {
            copyPaste.Remove(index);
        }
        public string getChBox(int index) => copyPaste[index];
        
        
    }
}
