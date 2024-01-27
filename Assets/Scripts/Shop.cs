using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameData gameData;
    public Main main;
    public Equipment equipment;
    public PanelSystem panelSystem;
    public InfoPanel infoPanel;
    public ErrorPanel errorPanel;
    public Items items;
    public int maxShopSlots = 16;
    public int[] shopSlot = new int [16];
    private int slotIndex;
    private int itemBuyPrice;
    private Image itemImage;
    private Sprite actualImage;
    public Sprite empty;
    

    private void Start()
    {
        shopSlot[1] = 1;
        shopSlot[11] = 501;
        shopSlot[15] = 101;
        UpdateShop();
    }

    private void SetActualImage(int imageIndex)
    {

        actualImage = Resources.Load<Sprite>("item_id_" + imageIndex.ToString());
    }

    public void CheckShopBtn(Button btn)
    {
        for(int i = 1; i < maxShopSlots; i++)
        {
            if(btn.name == "ShopSlot" + i.ToString())
            {
                slotIndex = i;
                if(shopSlot[slotIndex] != 0)
                {
                    items.ChangeSelectedItem(shopSlot[slotIndex]);
                    panelSystem.OpenInfoPanel();
                    infoPanel.UpdateInfoPanelTexts(shopSlot[slotIndex], 3);
                }

                i = maxShopSlots;
            }
            
        }
    }

    private void UpdateShop()
    {
        for(int index = 1; index < maxShopSlots; index++)
        {
            itemImage = GameObject.Find("ImgShopSlot" + index.ToString()).GetComponent<Image>();
            if(shopSlot[index] != 0)
            {
                SetActualImage(shopSlot[index]);
                itemImage.sprite = actualImage;
            }
            else
            {
                shopSlot[index] = 0;
                itemImage.sprite = empty;
            }
        }
    }

    public void BuyItem()
    {
        if(shopSlot[slotIndex] > 500)
        {
            itemBuyPrice = items.selectedLoot.buyPrice;
        }
        else if(shopSlot[slotIndex] > 100)
        {
            itemBuyPrice = items.selectedRobe.buyPrice;
        }
        else
        {
            itemBuyPrice = items.selectedWand.buyPrice;           
        }
        
        if(gameData.coinsBalance >= itemBuyPrice)
        {
            
            if(equipment.takenSlots < 15)
            {
                gameData.coinsBalance -= itemBuyPrice;
                for(int i = 1; i < 16; i++)
                {
                    if(gameData.slotsEq[i] == 0)
                    {
                        gameData.slotsEq[i] = shopSlot[slotIndex];
                        equipment.Start();
                        main.UpdateBalance();
                        panelSystem.CloseInfoPanel();
                        i = 16;
                    }
                }
            }
            else
            {
                errorPanel.ShowError("You don't have space in your inventory !");
            }

        }
        else
        {
            errorPanel.ShowError("You don't have enough coins !");
        }
    }
}
