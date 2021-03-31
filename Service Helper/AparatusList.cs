using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Helper
{
    class AparatusList
    {
        private List<string> aparatusList = new List<string>{
            "Разное",
            "Смартфоны",
            "Телевизоры"
        };
        public List<string> GetList() => aparatusList;
    }
}
