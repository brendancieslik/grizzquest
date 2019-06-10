using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;


namespace SophProj
{
    class Monster
    {
        public string name { get; set; }
        public int hp { get; set; }
        public int dmg { get; set; }
        public int threat { get; set; }
        public string description { get; set; }
        private static Ienumberable<Monster> MonsterList;

        public Monster()
        {
      
        }

        public Monster(int health, int damage, string descript)
        {
            hp = health;
            dmg = damage;
            description = descript;
        }

        public static void CreateMonsterList()
        {
            string filename = "Monsters.xml";
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
            string xmlPath = Path.Combine(projectDirectory, filename);
            Console.WriteLine(xmlPath);
            XDocument doc = XDocument.load(xmlPath);

            MonsterList = from mo in doc.Descendants("Monster")
                          select new Monster()
                          {
                              name = (int)mo.Attribute("name"),
                              dmg = (int)mo.Attribute("damage"),
                              description = (string)mo.Attribute("description"),
                              therat = (int)mo.Attribute("threat")


                          };
        }
        public static Monster getRandomMonster(int difficulty)
        {
            do
            {
                System.Random r = new System.Random();
                int count = Monsterlist.Count() - 1;
                int monsterIndex = r.Next(0, count);
                Monster m = MonsterList.ElementAt(monsterIndex);
            }
            while (m.getthreat() != difficulty);
            return m;
        }
    }
}

