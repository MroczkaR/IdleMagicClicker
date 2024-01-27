using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public GameData gameData;
    public Items items;
    public Main main;
    public PanelSystem panelSystem;
    public InfoPanel infoPanel;
    public ErrorPanel errorPanel;
    //public ConfirmationPanel confirmationPanel;
    public Story story;
    public Colors colors;
    public int takenSlots = 0;
    public int maxSlotsEq = 16;
    private int slotIndex;
    private int choosenInv = 0;
    private int itemSellPrice;

    public Sprite empty;
    public Sprite emptyWand;
    public Sprite emptyRobe;
    private Sprite actualImage;
    private Image itemImage;
    public Image wandImage;
    public Image robeImage;
    private Button slot;

    
    public void Start()
    {
        UpdateEquipment();
        //UpdateEquipmentPublic();
    }

    //public void UpdateEquipmentPublic() => UpdateEquipment();


    private void UpdateEquipment()
    {
        takenSlots = 0;
        for(int index = 1; index < maxSlotsEq; index++)
        {
            itemImage = GameObject.Find("ImgSlotEq" + index.ToString()).GetComponent<Image>();
            if(gameData.slotsEq[index] != 0)
        {
            SetActualImage(gameData.slotsEq[index]);
            itemImage.sprite = actualImage;
            takenSlots ++;
            //Slot.GetComponent<Image>().color = Colors.ActualColor;
            //Colors.CheckColor(IndexObrazka);
            //slot.gameObject.SetActive(true);
        }
        else
        {
            gameData.slotsEq[index] = 0;
            itemImage.sprite = empty;
        }
        }

        if(gameData.equippedWand != 0)
        {
            SetActualImage(gameData.equippedWand);
            wandImage.sprite = actualImage;
            colors.CheckColor(gameData.equippedWand);
            wandImage.color = colors.actualColor;
        }
        else
        {
            wandImage.sprite = emptyWand;
            colors.CheckColor(0);
            wandImage.color = colors.actualColor;
        }

        if(gameData.equippedRobe != 0)
        {

            SetActualImage(gameData.equippedRobe);
            robeImage.sprite = actualImage;
            colors.CheckColor(gameData.equippedRobe);
            robeImage.color = colors.actualColor;
        }
        else
        {
            robeImage.sprite = emptyRobe;
            colors.CheckColor(0);
            robeImage.color = colors.actualColor;
        }

        

    }

    public void CheckBtn(Button btn)
    {
        if(btn.name == "WandButton")
        {
            if(gameData.equippedWand != 0)
            {   
                choosenInv = 1;
                items.ChangeSelectedItem(gameData.equippedWand);
                panelSystem.OpenInfoPanel();
                infoPanel.UpdateInfoPanelTexts(gameData.equippedWand, 2);
            }

        }
        else if(btn.name == "RobeButton")
        {
            if(gameData.equippedRobe != 0)
            {
                choosenInv = 2;
                items.ChangeSelectedItem(gameData.equippedRobe);
                panelSystem.OpenInfoPanel();
                infoPanel.UpdateInfoPanelTexts(gameData.equippedRobe, 2);
            }
        }
        else
        {
            choosenInv = 0;
        for(int i = 1; i < maxSlotsEq; i++)
        {
            if(btn.name == "SlotEq" + i.ToString())
            {
                slotIndex = i;
                if(gameData.slotsEq[slotIndex] != 0)
                {
                    items.ChangeSelectedItem(gameData.slotsEq[slotIndex]);
                    panelSystem.OpenInfoPanel();
                    infoPanel.UpdateInfoPanelTexts(gameData.slotsEq[slotIndex], 1);
                    SetActualImage(gameData.slotsEq[slotIndex]);
                }

                i = maxSlotsEq;
            }

        }
        }

    }

    private void SetActualImage(int imageIndex)
    {

        actualImage = Resources.Load<Sprite>("item_id_" + imageIndex.ToString());
    }

    public void EquipItem()
    {
        int saveId = 0;
        if(gameData.slotsEq[slotIndex] > 100 && gameData.slotsEq[slotIndex] < 201)
        {
            if(items.selectedRobe.requaredLevel <= gameData.playerLevel)
            {  
                robeImage.sprite = actualImage;
                saveId = gameData.equippedRobe;
                gameData.equippedRobe = gameData.slotsEq[slotIndex];
                colors.CheckColor(gameData.slotsEq[slotIndex]);
                robeImage.color = colors.actualColor;
                UpdatedEquippedItem(saveId);
            }
            else
            {
                errorPanel.ShowError("Your level is to low to equip this item !");
            }
        }
        else if(gameData.slotsEq[slotIndex] > 0 && gameData.slotsEq[slotIndex] < 101)
        {
            if(items.selectedWand.requaredLevel <= gameData.playerLevel)
            {
                wandImage.sprite = actualImage;
                saveId = gameData.equippedWand;
                gameData.equippedWand = gameData.slotsEq[slotIndex];
                colors.CheckColor(gameData.slotsEq[slotIndex]);
                wandImage.color = colors.actualColor;
                UpdatedEquippedItem(saveId);
            }
            else
            {
                errorPanel.ShowError("Your level is to low to equip this item !");
            }
        }
    }

    private void UpdatedEquippedItem(int savedId)
    {
            gameData.slotsEq[slotIndex] = savedId;
            panelSystem.CloseInfoPanel();
            panelSystem.CloseShopPanel();
            panelSystem.OpenHeroPanel();
            panelSystem.OpenEquipmentPanel(); 
            UpdateEquipment();
            main.UpdateHeroStats();
            story.CheckTutorialPanel();
    }

    public void RemoveItem()
    {
        if(takenSlots < 15)
        {
            if(choosenInv == 1)
        {
            for(int i = 1; i < maxSlotsEq; i++)
            {
                if(gameData.slotsEq[i] == 0)
                {
                    gameData.slotsEq[i] = gameData.equippedWand;
                    gameData.equippedWand = 0;
                    panelSystem.OpenEquipmentPanel();
                    panelSystem.CloseInfoPanel();
                    main.UpdateHeroStats();
                    i = maxSlotsEq;

                }
            }
        }
        else if(choosenInv == 2)
        {
            for(int i = 1; i < maxSlotsEq; i++)
            {
                if(gameData.slotsEq[i] == 0)
                {
                    gameData.slotsEq[i] = gameData.equippedRobe;
                    gameData.equippedRobe = 0;
                    panelSystem.OpenEquipmentPanel();
                    panelSystem.CloseInfoPanel();
                    main.UpdateHeroStats();
                    i = maxSlotsEq;

                }
            }
        }
        }
        else
        {
            errorPanel.ShowError("You don't have space in your inventory !");
        }
    }

    public void SellItem()
    {
        if(gameData.slotsEq[slotIndex] > 500)
        {
            itemSellPrice = items.selectedLoot.sellPrice;
        }
        else if(gameData.slotsEq[slotIndex] > 100)
        {
            itemSellPrice = items.selectedRobe.sellPrice;
        }
        else
        {
            itemSellPrice = items.selectedWand.sellPrice;           
        }

            gameData.coinsBalance += itemSellPrice;
            gameData.slotsEq[slotIndex] = 0;
            UpdateEquipment();
            main.UpdateBalance();
            panelSystem.CloseInfoPanel();

    }

}
