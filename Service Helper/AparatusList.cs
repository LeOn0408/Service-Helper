using System.Collections.Generic;


namespace Service_Helper
{
    class AparatusList
    {
        private List<string> aparatusList = new List<string>{
            "Разное",
            "Смартфоны",
            "Телевизоры"
        };
        public List<string> GetList => aparatusList;
    }
}
