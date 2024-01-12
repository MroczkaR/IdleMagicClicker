using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clicker : MonoBehaviour
{
    public GameData gameData;
    public Main main;
    public PanelSystem panelSystem;
    public ErrorPanel errorPanel;
    public Monsters monsters;
    public Equipment equipment;
    public Items items;
    public Button clickButton;
    public TMPro.TMP_Text clickingInfoText;


    private Animator clickingInfoTextAnim;
    private Sprite actualMonsterImage;
    //private int maxPositionInfoText = 425;
    private int dealDamage;

    private int criticalAtack;
    public bool isMonsterPanel = true;
    public string monsterName;
    public int monsterActualHp;
    public int monsterMaxHp;
    //public int monsterMinDmg;
    //
    private void Start()
    {
        isMonsterPanel = true;
        if(isMonsterPanel == true)
        {
            GetMonsterStats();
            infoAnimationUpdate();
        }


    }

    private void infoAnimationUpdate()
    {
        clickingInfoTextAnim = clickingInfoText.GetComponent<Animator>();
        clickingInfoTextAnim.Update(0f);
        clickingInfoTextAnim.enabled = false;
        clickingInfoText.enabled = false;

    }

    public void Click()
    {
        if(monsterActualHp > 0)
        {
            dealDamage = Random.Range(gameData.playerMinDmg, gameData.playerMaxDmg + 1);
            monsterActualHp -= dealDamage;
            clickingInfoTextAnim.Play("ClickingInfoTextAnim" , 0, 0f);
            MonsterInfo(" - " + dealDamage.ToString());

        }
        if(monsterActualHp <= 0)
        {
            clickButton.enabled = false;
            gameData.playerExp += monsters.selectedMonster.exp;
            main.CheckExpierience();
            CheckDrop();
            StartCoroutine(RespMonster());
        }

        main.UpdateMonsterHp(monsterActualHp, monsters.selectedMonster.maxHp);
    }

    public void MonsterInfo(string infoText)
    {
        clickingInfoText.enabled = true;
        clickingInfoTextAnim.enabled = true;
        clickingInfoText.text = infoText;
        StartCoroutine(ClickingInfoTextAnimation());
    }

    public void GetMonsterStats()
    {
        actualMonsterImage = Resources.Load<Sprite>("monster_id_" + monsters.selectedMonster.id.ToString());
        clickButton.image.sprite = actualMonsterImage;
        monsterActualHp = monsters.selectedMonster.maxHp;
        main.UpdateMonsterHp(monsters.selectedMonster.maxHp, monsters.selectedMonster.maxHp);  
        
    }

    private void CheckDrop()
    {
        int drawnNumber = Random.Range(1, 101);
        if(drawnNumber <= monsters.selectedMonster.chanceForDrop)
        {
            items.ChangeSelectedItem(monsters.selectedMonster.droppingItem);
            AddDroppedItem(monsters.selectedMonster.droppingItem);
            MonsterInfo(" + " + items.selectedLoot.name.ToString());
        }
    }

    private void CheckCriticalAtack()
    {
        int drawnNumber = Random.Range(1, 101);
        if(drawnNumber <= gameData.playerCriticalChance)
        {

        }
    }


    IEnumerator RespMonster()
    {
        
        yield return new WaitForSeconds(1);
        monsterActualHp = monsters.selectedMonster.maxHp;
        main.UpdateMonsterHp(monsterActualHp, monsters.selectedMonster.maxHp);
        clickButton.enabled = true;
        
    }

    IEnumerator ClickingInfoTextAnimation()
    {
        yield return new WaitForSeconds(1);
        clickingInfoTextAnim.Play("ClickingInfoTextAnim" , 0, 0f);
        clickingInfoText.enabled = false;
        clickingInfoTextAnim.enabled = false;
        //StopCoroutine(ClickingInfoTextAnimation());
    }

        private void AddDroppedItem(int itemId)
    {
        if(equipment.takenSlots < 15)
        {
            for(int i = 1; i < equipment.maxSlotsEq; i++)
            {
                if(gameData.slotsEq[i] == 0)
                {
                    gameData.slotsEq[i] = itemId;
                    equipment.takenSlots ++;
                    i = equipment.maxSlotsEq;
                    if(equipment.takenSlots == 15)
                    {
                        errorPanel.ShowError("Your inventory is full");
                    }
                }
            }
        }
        else
        {
            errorPanel.ShowError("You don't have space in your inventory ! You Can't get loot from monsters.");
        }
    }



    /*void Update()
    {
        
        if(clickingInfoText.rectTransform.offsetMax.y > maxPositionInfoText && clickingInfoTextAnim.enabled)
        {
            clickingInfoTextAnim.enabled = false;
            clickingInfoText.rectTransform.offsetMax = new Vector2(0, 0);
            clickingInfoText.rectTransform.offsetMin = new Vector2(0, 0);
            clickingInfoText.enabled = false;   
        }
    }*/
}
