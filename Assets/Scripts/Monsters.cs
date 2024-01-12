using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public Clicker clicker;
    private List<Monster> monsterList = new List<Monster>();

    public class Monster
    {
        public int id;
        public string name;
        public int maxHp;
        public int exp;
        public int respawnTime;
        public int droppingItem;
        public int chanceForDrop;

      
        public Monster(int id, string name, int maxHp, int exp, int respawnTime, int droppingItem, int chanceForDrop)
        {
            this.id = id;
            this.name = name;
            this.maxHp = maxHp;
            this.exp = exp;
            this.respawnTime = respawnTime;
            this.droppingItem = droppingItem;
            this.chanceForDrop = chanceForDrop;
        }
    }

    public Monster selectedMonster { get; private set; }

    private List<Boss> bossList = new List<Boss>();

    public class Boss
    {
        public int id;
        public string name;
        public int maxHp;
        public int minDmg;
        public int maxDmg;

      
        public Boss(int id, string name, int maxHp, int minDmg, int maxDmg)
        {
            this.id = id;
            this.name = name;
            this.maxHp = maxHp;
            this.minDmg = minDmg;
            this.maxDmg = maxDmg;
        }
    }

    public Boss selectedBoss { get; private set; }


        private void Start()
    {
        // Tworzymy liste bestii 
        // -id- -name- -maxHp- -exp- -respawnTime- -droppingItem- -chanceForDrop-
        monsterList.Add(new Monster(0, "Rat", 10, 1, 1, 501, 10));
        monsterList.Add(new Monster(1, "Spider", 30, 4, 1, 502, 25));
        monsterList.Add(new Monster(2, "Chulu", 200, 1000, 3, 502, 90));
        SetSelectedMonster(0);
        bossList.Add(new Boss(0, "Huge Rat", 20, 0, 2));
        bossList.Add(new Boss(1, "Huge Spprider", 100, 5, 10));
        bossList.Add(new Boss(2, "Huge xaz1" , 1000, 50, 60));
        SetSelectedBoss(0);

    }

    public void SetSelectedMonster(int id)
{
    selectedMonster = monsterList[id];


}

public void SetSelectedBoss(int id)
{

    selectedBoss = bossList[id];

}



}
