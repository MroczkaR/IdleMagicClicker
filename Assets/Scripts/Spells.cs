using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spells : MonoBehaviour
{
    public GameData gameData;
    public PanelSystem panelSystem;
    public ErrorPanel errorPanel;
    public int takenSpellSlots = 0;
    private TMPro.TMP_Text spellName;
    private Image spellImage;

    public Sprite empty;
    public Button setToUse;
    public Button removeFromUse;
    private Sprite actualImage;

    public TMPro.TMP_Text spellNameText;
    public TMPro.TMP_Text elementarSpellText;
    public TMPro.TMP_Text skillLevelText;
    public TMPro.TMP_Text descriptionSpellText;
    public TMPro.TMP_Text atributesSpellText;
    public TMPro.TMP_Text requiredSpellLevelText;
    public TMPro.TMP_Text teachSpellCostText;

    public int[] atributesSpell = new int [21];

    private int whereIsSpell = 0;

    private List<Carmina> spellsList = new List<Carmina>();

    public class Carmina
    {
        public int id;
        public string elementar;
        public string nameSpell;
        public int requiredLevel;
        public string description;
        /*public int dmgSpell;
        public int deffenceSpell;
        public int healing;*/
        public int cooldownTime;
        public int teachCost;

        public Carmina(int id, string elementar, string nameSpell, int requiredLevel, string description, int cooldownTime, int teachCost)
        {
            this.id = id;
            this.elementar = elementar;
            this.nameSpell = nameSpell;
            this.requiredLevel = requiredLevel;
            this.description = description;
            this.cooldownTime = cooldownTime;
            this.teachCost = teachCost;
        }
    }

    public Carmina selectedSpell { get; private set; }

    private void Start()
    {
        spellsList.Add(new Carmina(0, "Firex", "Firex Bolt", 0, "Throwingx fire bolt to enemy, causing him fire dmg", 0, 0));
        spellsList.Add(new Carmina(1, "Fire", "Fire Bolt", 3, "Throwing fire bolt to enemy, causing him fire dmg", 1, 1));

        ChangeSelectedSpell(0);
        RefreshSpellPanel();
    }

    public void ChangeSelectedSpell(int index)
    {
        selectedSpell = spellsList[index];
    }   
    
    public void RefreshSpellPanel()
    {
        takenSpellSlots = 0;
        for(int i = 1; i < 6; i++)
        {
            spellImage = GameObject.Find("ImageSpell" + i.ToString()).GetComponent<Image>();
            spellName = GameObject.Find("NameSpell" + i.ToString()).GetComponent<TMPro.TMP_Text>();

            if(gameData.usingSpell[i] != 0)
            {
                SetActualImage(gameData.usingSpell[i]);
                ChangeSelectedSpell(gameData.usingSpell[i]);
                spellImage.sprite = actualImage;
                spellName.text = selectedSpell.nameSpell;
                takenSpellSlots ++;
            }
            else
            {
                spellImage.sprite = empty;
                spellName.text = " ";
            }
        }
    }

    public void RefreshSpellUpgradePanel()
    {
        for(int i = 1; i < 21; i++)
        {
            spellImage = GameObject.Find("ImageUpgrSpell" + i.ToString()).GetComponent<Image>();
            if(gameData.skillLevel[i] != 0)
            {
                SetActualImage(i);

            }
            else
            {
                SetLockedImage(i);
            }
            spellImage.sprite = actualImage;
        }

            
    }

    private void SetActualImage(int imageIndex)
    {

        actualImage = Resources.Load<Sprite>("spell_id_" + imageIndex.ToString());
    }

    private void SetLockedImage(int imageIndex)
    {
        actualImage = Resources.Load<Sprite>("locked_spell_id_" + imageIndex.ToString());
    }

    public void ClickToUpgradeSpell(Button btn)
    {
        int id = 0;
        for(int i = 1; i < 21; i++)
        {
            if(btn.name == "Spell" + i.ToString())
            {
                id = i;
                i = 21;
            }

        }
        ChangeSelectedSpell(id);
        UpdateSpellInfoPanel(id);
    }

    public void UpdateSpellInfoPanel(int spellId)
    {
        panelSystem.OpenSpellInfoPanel();
        for(int i = 1; i < 6; i++)
        {
            if(gameData.usingSpell[i] == spellId)
            {
                setToUse.gameObject.SetActive(false);
                removeFromUse.gameObject.SetActive(true);
                whereIsSpell = i;
                i = 6;
            }
            else
            {
                setToUse.gameObject.SetActive(true);
                removeFromUse.gameObject.SetActive(false);
            }
        }
        spellNameText.text = selectedSpell.nameSpell;
        elementarSpellText.text = "Element : " + selectedSpell.elementar;
        skillLevelText.text = "Skill Level : " + gameData.skillLevel[spellId];
        descriptionSpellText.text = "Description : " + selectedSpell.description;
        atributesSpellText.text = "Atributes : (2 + MaxDmg) * (1 + Power / 10)";
        requiredSpellLevelText.text = "Required Level : " + selectedSpell.requiredLevel.ToString();
        teachSpellCostText.text = "Teach cost : " + selectedSpell.teachCost.ToString();
    }

    public void UpgradeSpell()
    {
        if(gameData.playerSkillLearningPoints > -1)
        {
            gameData.skillLevel[selectedSpell.id] ++;
            gameData.playerSkillLearningPoints --;
            panelSystem.CloseSpellInfoPanel();
            RefreshSpellUpgradePanel();
        }
        else
        {
            errorPanel.ShowError("You don't have enough Skill Points !");
        }

    }

    public void SetSpellToUsing()
    {
        if(gameData.skillLevel[selectedSpell.id] > 0)
        {
            if(takenSpellSlots < 5)
            {
                for(int i = 1; i < 6; i++)
                {
                    if(gameData.usingSpell[i] == 0)
                    {
                        gameData.usingSpell[i] = selectedSpell.id;
                        RefreshSpellPanel();
                        panelSystem.CloseSpellInfoPanel();
                        i = 6;
                    }
                }
            }
            else
            {
                errorPanel.ShowError("All of you spell slots are using, firstly you have to remove some spell from using panel");
            }
        }
        else
        {
            errorPanel.ShowError("Firstly you have to learn this spell to use it");
        }
    }

    public void RemoveFromUsing()
    {
        gameData.usingSpell[whereIsSpell] = 0;
        RefreshSpellPanel();
        panelSystem.CloseSpellInfoPanel();
    }
}
