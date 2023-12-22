using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoMonsterPanel : MonoBehaviour
{
    public Monsters monsters;
    public Items items;
    public TMPro.TMP_Text infoPanelText;
    public TMPro.TMP_Text monsterNameText;
    public TMPro.TMP_Text monsterHpText;
    public TMPro.TMP_Text monsterExpierienceText;
    public TMPro.TMP_Text monsterRespawnTimeText;
    public TMPro.TMP_Text monsterDropText;
    public TMPro.TMP_Text monsterDropChanceText;
    public TMPro.TMP_Text playerBonusText;
    public TMPro.TMP_Text monstersKilledText;

    private void Start()
    {
        UpdateInfoMonsterTexts();
    }

    public void UpdateInfoMonsterTexts()
    {
        items.ChangeSelectedItem(monsters.selectedMonster.droppingItem);
        infoPanelText.text = "Monster Information";
        monsterNameText.text = "Name : " + monsters.selectedMonster.name;
        monsterHpText.text = "Health : " + monsters.selectedMonster.maxHp.ToString();
        monsterExpierienceText.text = "Expierience : " + monsters.selectedMonster.exp.ToString();
        monsterDropText.text = "Drop : " + items.selectedLoot.name;
        monsterDropChanceText.text = "Drop chance : " + monsters.selectedMonster.chanceForDrop.ToString() + "%";
        monsterRespawnTimeText.text = "Respawn time : " + monsters.selectedMonster.respawnTime.ToString() + "s";
        playerBonusText.text = "Bonus damage : "; // statistisc bonus dmg selected monster
        monstersKilledText.text = "Killed : "; // statistics killed selected monsters
    }

}
