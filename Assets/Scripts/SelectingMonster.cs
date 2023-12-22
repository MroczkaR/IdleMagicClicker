using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectingMonster : MonoBehaviour
{
    public Monsters monsters;
    public PanelSystem panelSystem;
    public Clicker clicker;
    public BossFight bossFight;
    public int [,] monstersArray = new int [20, 10];
    public int unlockedStage = 0;
    //private int actualPage = 0;
    private int monsterId = 0;
    private int bossId = 0;
    private Button actualMonster;
    private TMPro.TMP_Text actualMonsterText;
    private Button actualMonsterLocker;


    public void Start()
    {
        
        //actualImage = Resources.Load<Sprite>("item_id_" + imageIndex.ToString());
        SetScrollingMonsters();
    }

    public void CheckMonsterBtn(Button btn)
    {
        string monsterNumberString = btn.name.Substring("Monster".Length);
        if(int.TryParse(monsterNumberString, out monsterId))
        {
            monsters.SetSelectedMonster(monsterId);
            clicker.GetMonsterStats();
            panelSystem.CloseSelectingPanel();
        }
       
    }

    public void SetScrollingMonsters() // Nadpisanie całego Scrollingu tutaj bedzie
{
    for (int i = 0; i < 3; i++)
    {
        actualMonster = GameObject.Find("Monster" + i.ToString())?.GetComponent<Button>();
        actualMonsterText = GameObject.Find("Monster" + i.ToString() + "Text")?.GetComponent<TMP_Text>();
        actualMonsterLocker = GameObject.Find("LockMonster" + i.ToString())?.GetComponent<Button>();
        if(unlockedStage >= i)
        {
            actualMonsterLocker.gameObject.SetActive(false);
            actualMonster.enabled = true;
        }
        else
        {
            actualMonster.enabled = false;
        }
        monsters.SetSelectedMonster(i);
    }
}

    public void UnlockStage(Button btn)
    {
        string lockerNumberString = btn.name.Substring("LockMonster".Length);
        if(int.TryParse(lockerNumberString, out bossId))
        {
            //monsters.SetSelectedBoss(bossId);
            //Get Stats

        }
        string confirmationText = "Are you sure \n you wanna fight the boss ?";
        panelSystem.OpenConfirmationPanel(confirmationText);
    }

    public void ConfirmFightBoss()
    {
        panelSystem.OpenBossFightPanel();
        bossFight.GetBossStats();
        bossFight.bossInfoAnimationUpdate();
        bossId --;
    }
}
