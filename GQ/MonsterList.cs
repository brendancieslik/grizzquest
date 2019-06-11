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
        public int strength { get; set; }
        public int dexterity { get; set; }
        public int intelligence { get; set; }
        public int vitality { get; set; }
        public int maxHealth { get; set; }
        public int currentHealth { get; set; }
        public int ArmorRating { get; set; }
        public int damage { get; set; }
        public int threat { get; set; }
        public string description { get; set; }
        private static Ienumberable<Monster> MonsterList;

        public Monster()
        {
      
        }

        public Monster(int str, int dex, int intelli, int vit, int hp, int ar, int thr, string des)
        {
            strength = str;
            dexerity = dex;
            intelligence = intelli;
            vitality = vit;
            healthPoints = hp;
            ArmorRating = ar;
            threat = thr;
            description = des;
            maxHealth = vit * 10;
            currentHealth = maxHealth;
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

