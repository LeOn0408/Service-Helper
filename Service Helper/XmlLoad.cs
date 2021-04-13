using System.Xml.Linq;

namespace Service_Helper
{
    class XmlLoad
    {
        public XmlLoad()
        {
            xdoc = XDocument.Load(xmlPath);
            root = xdoc.Element("list");
        }

        string xmlPath = "xml/CheckBoxList.xml";
        XElement root;
        XDocument xdoc;
        DisplayingLists displayingLists = new();

        public void xmlLoad()
        {
            int count = 1;
            foreach (var xe in root.Elements("Category"))
            {
                displayingLists.checkLists.Add( new CheckList  { Name = xe.Attribute("id").Value.ToString() + count, Category = xe.Attribute("id").Value.ToString(), Content =xe.Element("Content").Value.ToString()});
                count++;
            }

        }
        
    }
}
