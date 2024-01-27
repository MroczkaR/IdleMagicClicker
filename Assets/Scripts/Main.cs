using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Main : MonoBehaviour
{
    public GameData gameData;
    public Monsters monsters;
    public Clicker clicker;
    public Items items;
    public PanelSystem panelSystem;
    public GenerateAttibutes generateAttibutes;
    public SelectingMonster selectingMonster;
    public TMPro.TMP_Text coinsBalanceText;
    public TMPro.TMP_Text gemsBalanceText;

    public TMPro.TMP_Text playerLevelText;

    public TMPro.TMP_Text monsterName;
    public TMPro.TMP_Text monsterHp;

    public TMPro.TMP_Text expProcentText;
    public Slider monsterBarHp;
    public Image expBar;

    private void Start()
    {
        ResetGame();
        UpdateBalance();
        UpdateHeroStats();
        MakeMonstersArray();
        if(panelSystem.GamePanel.activeSelf == true)
        {
            StartCoroutine(UpdateInventory());
            Debug.Log("XX1");
        }

    }

    public void UpdateBalance()
    {
        coinsBalanceText.text = gameData.coinsBalance.ToString();
        gemsBalanceText.text = gameData.gemsBalance.ToString();
        playerLevelText.text = "Level : " + gameData.playerLevel.ToString();

    }

    private IEnumerator UpdateInventory()
    {
        panelSystem.OpenHeroPanel();
        panelSystem.OpenEquipmentPanel();

        yield return null;

        panelSystem.CloseHeroPanel();
    }

    public void UpdateHeroStats()
    {
        if(gameData.equippedWand != 0)
        {
            items.ChangeSelectedItem(gameData.equippedWand);
            gameData.playerMinDmg = items.selectedWand.minDmgWand + ((gameData.playerPower / 2) * generateAttibutes.GeneratePowerRatio(gameData.playerLevel));
            gameData.playerMaxDmg = items.selectedWand.maxDmgWand + ((gameData.playerPower / 2) * generateAttibutes.GeneratePowerRatio(gameData.playerLevel));
        }
        else
        {
            gameData.playerMinDmg = 0;
            gameData.playerMaxDmg = 0;
        }
        if(gameData.equippedRobe != 0)
        {
            items.ChangeSelectedItem(gameData.equippedRobe);
            gameData.playerHealth = 10 + items.selectedRobe.vitalityRobe + (gameData.playerVitality * generateAttibutes.GenerateVitalityRatio(gameData.playerLevel));
            gameData.playerDeffence = items.selectedRobe.deffence;
        }
        else
        {
            gameData.playerHealth = 10 + (gameData.playerVitality * 5);
            gameData.playerDeffence = 0;
        }

        gameData.playerCriticalChance = gameData.playerLucky;
    }


    public void UpdateMonsterHp(int monsterActualHp, int monsterMaxHp)
    {
        monsterName.text = monsters.selectedMonster.name;
        monsterHp.text = (monsterActualHp + " / " + monsterMaxHp).ToString();
        monsterBarHp.value = (float)monsterActualHp / monsterMaxHp;
    }

    public void CheckExpierience()
    {
        if(gameData.playerExp >= gameData.playerMaxExp)
        {
            gameData.playerLevel ++;
            gameData.playerLearningPoints += 2;
            gameData.playerMaxExp += generateAttibutes.GenerateMaxExpierience(gameData.playerLevel);
            gameData.playerExp = 0;
            //clicker.MonsterInfo("Level Up !");
            UpdateBalance();
        }
        expBar.fillAmount = (float)gameData.playerExp / gameData.playerMaxExp;
        expProcentText.text = Math.Round(((float)gameData.playerExp / gameData.playerMaxExp) * 100, 2).ToString() + " %";
    }

    private void MakeMonstersArray()
    {
        int id = 0;
        for(int i = 0; i < 20; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                selectingMonster.monstersArray[i, j] = id;
            }
        }
    }

        public void ResetGame()
    {
        //gameData.
        //Balances

        gameData.coinsBalance = 0; // 0
        gameData.gemsBalance = 0;

        gameData.storyTextNumber = 0;


        //Player

        gameData.playerLevel = 0;
        gameData.playerHealth = 10;
        gameData.playerMinDmg = 0; // 0
        gameData.playerMaxDmg = 0; // 0
        gameData.playerExp = 0;
        gameData.playerMaxExp = 1;
        gameData.playerLearningPoints = 0;
        gameData.playerCostsStats = 1;
        gameData.playerPrimaryPower = 0;
        gameData.playerPower = 0;
        gameData.playerPrimaryVitality = 0;
        gameData.playerVitality = 0;
        gameData.playerPrimaryLucky = 0;
        gameData.playerLucky = 0;

        //Equipment

        for(int i=0; i<16; i++)
        {
            gameData.slotsEq[i] = 0;
        }
        gameData.equippedWand = 0;
        gameData.equippedRobe = 0;

        // Spells

        gameData.playerSkillLearningPoints = 0;
        for(int i=0; i<6; i++)
        {
            gameData.usingSpell[i] = 0;
        }

        for(int i = 0; i < 21; i++)
        {
            gameData.skillLevel[i] = 0;
        }

    }

}
