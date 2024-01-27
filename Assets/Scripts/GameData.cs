using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{

    //The most important game datas


    //Balances

    public int coinsBalance = 0; 
    public int gemsBalance = 0;

    //Player Stats

    public int playerLevel = 0;
    public int playerHealth = 10;
    public int playerMinDmg = 1;
    public int playerMaxDmg = 1;
    public int playerExp = 0;
    public int playerMaxExp = 1;
    public int playerLearningPoints = 0;
    public int playerCostsStats = 1;
    public int playerDeffence = 0;
    public int playerPrimaryPower = 0;
    public int playerPower = 0;
    public int playerPrimaryVitality = 0;
    public int playerVitality = 0;
    public int playerPrimaryLucky = 0;
    public int playerLucky = 0;
    public int playerCriticalChance = 0;

    // Equipment

    public int equippedWand = 0;
    public int equippedRobe = 0;
    public int[] slotsEq = new int [16];

    // Spells

    public int playerSkillLearningPoints = 0;
    public int[] usingSpell = new int [6];
    public int[] skillLevel = new int [21];

    // Tutorial

    public int storyTextNumber = 0;

    public int GetBalance(string resourceName)
    {
        switch(resourceName)
        {
            case "Coins":
                return coinsBalance;
            case "Gems":
                return gemsBalance;
            default:
                return 0;
        }
    }

    public void SetBalance(string resourceName, int amount)
    {
        switch (resourceName)
        {
            case "Coins":
                coinsBalance = amount;
                break;
            case "Gems":
                gemsBalance = amount;
                break;
            default:
                break;
        }
    }

   /* public void GetEquipment()
    {
        for(int i = 1; i < 16; i++)
        {
            slotsEq[i] 
        }
    } */

}
