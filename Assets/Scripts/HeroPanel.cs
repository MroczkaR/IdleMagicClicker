using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroPanel : MonoBehaviour
{
    public GameData gameData;
    public Main main;
    public ErrorPanel errorPanel;
    public TMPro.TMP_Text levelText;
    public TMPro.TMP_Text expierienceText;
    public TMPro.TMP_Text learningPointsText;
    public TMPro.TMP_Text costsText;
    public TMPro.TMP_Text deffenceText;
    public TMPro.TMP_Text powerText;
    public TMPro.TMP_Text vitalityText;
    public TMPro.TMP_Text luckyText;
    public TMPro.TMP_Text damageText;
    public TMPro.TMP_Text hpText;
    public TMPro.TMP_Text critChanceText;


    // min = moc / 4, max moc+2 / 4 ?

    private void Start()
    {
        UpdateTextHeroPanel();
        //UpdateHeroStats();
    }

    public void UpdateTextHeroPanel()
    {
        levelText.text = "Level : " + gameData.playerLevel.ToString();
        expierienceText.text = "Experience : " + gameData.playerExp.ToString() + " / " + gameData.playerMaxExp.ToString();
        learningPointsText.text = "Learning points : " + gameData.playerLearningPoints.ToString();
        costsText.text = "Costs : " + gameData.playerCostsStats.ToString();
        deffenceText.text = "Deffence : " + gameData.playerDeffence.ToString();
        powerText.text = "Power : " + gameData.playerPower.ToString();
        vitalityText.text = "Health : " + gameData.playerVitality.ToString();
        luckyText.text = "Lucky : " + gameData.playerLucky.ToString();
        damageText.text = "Damage : " + gameData.playerMinDmg.ToString() + " - " + gameData.playerMaxDmg.ToString();
        hpText.text = "Health Points : " + gameData.playerHealth.ToString();
        critChanceText.text = "Critical Chance : " + gameData.playerCriticalChance.ToString() + " %";   
    }

    public void UpdateHeroStats()
    {
        //gameData.playerMinDmg = 1 + (gameData.playerPower / 4);
        //gameData.playerMaxDmg = 1 + ((gameData.playerPower + 2) / 4);
        //gameData.playerHealth = 10 + (gameData.playerVitality * 5);
    }

    public void PowerUp()
    {
        StatisticsUp(1);
    }

        public void VitalityUp()
    {
        StatisticsUp(2);
    }

        public void LuckyUp()
    {
       StatisticsUp(3);
    }

    private void StatisticsUp(int choosenStat)
    {
        if(gameData.playerLearningPoints > 0)
        {
            if(gameData.coinsBalance >= gameData.playerCostsStats)
            {
                if(choosenStat == 1)
                {
                    gameData.playerPrimaryPower ++;
                    gameData.playerPower ++;
                }
                else if(choosenStat == 2)
                {
                    gameData.playerPrimaryVitality ++;
                    gameData.playerVitality ++;
                }
                else
                {
                    gameData.playerPrimaryLucky ++;
                    gameData.playerLucky ++;
                }
                gameData.playerLearningPoints --;
                gameData.coinsBalance -= gameData.playerCostsStats;
                main.UpdateHeroStats();
                main.UpdateBalance();
                UpdateTextHeroPanel();
                
            }
            else
            {

                errorPanel.ShowError("You don't have enough coins !");
            }

        }
        else
        {
            errorPanel.ShowError("You don't have enough learning points !");
        }
    }

}
