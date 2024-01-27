using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    public GameData gameData;
    public Items items;
    public Button equipButton;
    public Button removeButton;
    public Button sellButton;
    public Button buyButton;
    public TMPro.TMP_Text nameText;
    public TMPro.TMP_Text text1InfoPanel;
    public TMPro.TMP_Text text2InfoPanel;
    public TMPro.TMP_Text text3InfoPanel;
    public TMPro.TMP_Text text4InfoPanel;
    public TMPro.TMP_Text text5InfoPanel;
    public TMPro.TMP_Text sellPriceText;

    private void Start()
    {
        //
    }

    public void UpdateInfoPanelTexts(int index, int inventory)
    {
        if(inventory == 1) //Inventory and Hero Panel
        {
            sellButton.gameObject.SetActive(true);
            equipButton.gameObject.SetActive(true);
            removeButton.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(false);
        }

        if(inventory == 2) // Equipped
        {
            removeButton.gameObject.SetActive(true);
            sellButton.gameObject.SetActive(false);
            equipButton.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(false);
        }

        if(inventory == 3)  // Buy From Shop
        {
            buyButton.gameObject.SetActive(true);
            removeButton.gameObject.SetActive(false);
            sellButton.gameObject.SetActive(false);
            equipButton.gameObject.SetActive(false);       
        }
        if(inventory == 4) // Inventory and Shop
        {
            sellButton.gameObject.SetActive(true);
            equipButton.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(false);
            removeButton.gameObject.SetActive(false);
        }

        MakeEmptyInfoTexts();

        if(index > 500)
        {
            nameText.text = items.selectedLoot.name;
            text1InfoPanel.text = items.selectedLoot.description.ToString();
            //text2InfoPanel.text = items.selectedLoot.
            if(inventory == 3)
            {
                sellPriceText.text = "Buy Price : " + items.selectedLoot.buyPrice.ToString();
            }
            else
            {
                sellPriceText.text = "Sell Price : " + items.selectedLoot.sellPrice.ToString();
            }

            equipButton.gameObject.SetActive(false);
        }
        else if(index > 100)
        {
            nameText.text = items.selectedRobe.name;
            text1InfoPanel.text = "Required Level : " + items.selectedRobe.requaredLevel.ToString();
            text2InfoPanel.text = "Deffence : " + items.selectedRobe.deffence.ToString();
            text3InfoPanel.text = "Vitality : " + items.selectedRobe.vitalityRobe.ToString();
            if(inventory == 3)
            {
                sellPriceText.text = "Buy Price : " + items.selectedRobe.buyPrice.ToString();
            }
            else
            {
                sellPriceText.text = "Sell Price : " + items.selectedRobe.sellPrice.ToString();
            }
        }
        else
        {
            nameText.text = items.selectedWand.name;
            text1InfoPanel.text = "Required Level : " + items.selectedWand.requaredLevel.ToString();
            text2InfoPanel.text = "Wand Damage : " + items.selectedWand.minDmgWand.ToString() + " - " + items.selectedWand.maxDmgWand.ToString();
            if(inventory == 3)
            {
                sellPriceText.text = "Buy Price : " + items.selectedWand.buyPrice.ToString();
            }
            else
            {
                sellPriceText.text = "Sell Price : " + items.selectedWand.sellPrice.ToString();
            }
        }

    
    }


    private void MakeEmptyInfoTexts()
    {
        text1InfoPanel.text = " ";
        text2InfoPanel.text = " ";
        text3InfoPanel.text = " ";
        text4InfoPanel.text = " ";
        text5InfoPanel.text = " ";
        sellPriceText.text = " ";
    }

}
