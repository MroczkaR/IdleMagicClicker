using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public GameData gameData;
    //public Main main;
    public PanelSystem panelSystem;
    public TMPro.TMP_Text tutorialText;

    public int coinsReward;

    private void Start()
    {
        CheckTutorialPanel();


     }

     public void CheckTutorialPanel()
     {
        if(gameData.playerLevel == 0 && gameData.storyTextNumber == 0)
        {

            panelSystem.OpenTutorialPanel();
            tutorialText.text = "Welcome \n in magic world young wizard. \n" 
             + "To start your journey you have to get your first wand."
             + "Here is 1 coin for you to buy it in Shop"
             + "Go to the shop, and buy Toplar Wand for 1 Coin.";
             gameData.storyTextNumber ++;
             coinsReward = 1;
        }

        if(gameData.storyTextNumber == 1 && gameData.equippedWand == 1)
        {
            panelSystem.OpenTutorialPanel();
            tutorialText.text = "Great, now you can use \n some spells !"
            + "Try it on \n your first enemy - Rat. \n Close this window and click on it to use spell on it";
            gameData.storyTextNumber ++;
        }
     }

     // test121

}
