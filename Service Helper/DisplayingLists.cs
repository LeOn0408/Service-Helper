using System.Collections.Generic;

namespace Service_Helper
{
    class DisplayingLists
    {
        public List<CheckList> checkLists { get; set; }
        public DisplayingLists()
        {
            checkLists = new List<CheckList>
            {
                //Временно так. 
                //Первый столбец с незначительными
                new CheckList  { Name = "testminor1", Category = "Minor", Content ="Потертости"},
                new CheckList  { Name = "testminor2", Category = "Minor", Content ="Царапины"},
                new CheckList  { Name = "testminor3", Category = "Minor", Content ="Трещины"},
                new CheckList  { Name = "testminor4", Category = "Minor", Content ="Сколы"},
                new CheckList  { Name = "testminor5", Category = "Minor", Content ="Вмятины"},
                new CheckList  { Name = "testminor6", Category = "Minor", Content ="Наклеено защитное стекло"},
                new CheckList  { Name = "testminor6", Category = "Minor", Content ="Следы эксплуатации"},
                
                //Второй столбец с серьезными
                //Третий столбец с комплектацией
                new CheckList  { Name = "testkit1", Category = "Kit", Content ="Упаковка"},
                new CheckList  { Name = "testkit2", Category = "Kit", Content ="Аппарат"},
                new CheckList  { Name = "testkit3", Category = "Kit", Content ="Зврядное устройство"},
                new CheckList  { Name = "testkit4", Category = "Kit", Content ="USB-кабель"},
                new CheckList  { Name = "testkit5", Category = "Kit", Content ="Документы"},
                new CheckList  { Name = "testkit6", Category = "Kit", Content ="Защитное стекло"},
                new CheckList  { Name = "testkit7", Category = "Kit", Content ="Ключ слота сим"},
            };
        }
        public List<CheckList> GetCheckLists => checkLists;
    }
}
