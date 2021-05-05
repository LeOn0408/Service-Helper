using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace Service_Helper
{
    class Database
    {
        public Database() 
        {
        }
        public void ConnectDatabase()
        {
            
        }
        public void WriteData() 
        { 
        
        }
        public void ReadData()
        {
            
        }
        public List<CheckList> GetCheckLists() 
        {
            using (var db = new DatabaseContext())
            {
                return db.CheckLists.ToList<CheckList>();
            }
        }
        public void DeleteData()
        {

        }
        public int CountLines() 
        {
            using (var db = new DatabaseContext())
            {
                return db.CheckLists.Count();
            }
        }
        
    }
}
