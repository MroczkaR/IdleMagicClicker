using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private List<Wands> wandsList = new List<Wands>();

    public class Wands
    {
        public int id;
        public string name;
        public int requaredLevel;
        public int minDmgWand;
        public int maxDmgWand;
        public int sellPrice;
        /*public int stats1Wand;
        public int stats2Wand;
        public int stats3Wand;*/

      
        public Wands(int id, string name, int requaredLevel, int minDmgWand, int maxDmgWand, int sellPrice)
        {
            this.id = id;
            this.name = name;
            this.requaredLevel = requaredLevel;
            this.minDmgWand = minDmgWand;
            this.maxDmgWand = maxDmgWand;
            this.sellPrice = sellPrice;
            /*this.stats1Wand = stats1Wand;
            this.stats2Wand = stats2Wand;
            this.stats3Wand = stats3Wand;*/

        }
    }

    public Wands selectedWand { get; private set; }

    private List<Robes> robesList = new List<Robes>();

    public class Robes
    {
        public int id;
        public string name;
        public int requaredLevel;
        public int vitalityRobe;
        public int deffence;
        public int sellPrice;
 
        public Robes(int id, string name, int requaredLevel, int vitalityRobe, int deffence, int sellPrice)
        {
            this.id = id;
            this.name = name;
            this.requaredLevel = requaredLevel;
            this.vitalityRobe = vitalityRobe;
            this.deffence = deffence;
            this.sellPrice = sellPrice;
        }
    }

    public Robes selectedRobe { get; private set; }

    private List<Loots> lootsList = new List<Loots>();

    public class Loots
    {
        public int id;
        public string name;
        public string description;
        public int sellPrice;

        public Loots(int id, string name, string description, int sellPrice)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.sellPrice = sellPrice;
        }
    }

    public Loots selectedLoot { get; private set; }

    private void Start()
    {
        //Creating Wands, Robes, and Items List

        //Wands -id- -name- -requiredLevel- -minDmgWand- -maxDmgWand- -sellPrice-
        wandsList.Add(new Wands(0, "Empty", 2, 2, 6, 0)); // Pusty
        wandsList.Add(new Wands(1, "Poplar Wand", 0, 1, 1, 0)); //Topola

        //Robes
        robesList.Add(new Robes(101, "Rag", 2, 5, 1, 1)); // Szmata

        //Items -id- -name- -description- -sellPrice-
        lootsList.Add(new Loots(501, "Rat Fur", "Used to make potions", 1)); // Siersc szczura
        lootsList.Add(new Loots(502, "Spider Eye", "Used to make potions", 3)); // Oko pajaka


        ChangeSelectedItem(0);
    }

    public void ChangeSelectedItem(int index)
    {
        if(index > 0 && index < 101)
        {
            selectedWand = wandsList[index];
        }
        else if(index > 100 && index < 201)
        {
            selectedRobe = robesList[index - 101];
        }
        else if(index > 500 && index < 1001)
        {
            selectedLoot = lootsList[index - 501];
        }
        
    }
}
