using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class AdminScript : MonoBehaviour
{
    public GameData gameData;
    public Main main;
    public TMPro.TMP_Text cheatCodeInput;
    private string cheatCode;
    private string cheatPrefix;
    private int cheatAmount;

    public void ExecuteCheatCode()
{
    cheatCode = cheatCodeInput.text;
    cheatAmount = ExtractNumber(cheatCode);
    if (cheatCode.StartsWith("coins"))
    {
        gameData.coinsBalance += cheatAmount;
    }
    else if(cheatCode.StartsWith("gems"))
    {
        gameData.gemsBalance += cheatAmount;
    }
    else if(cheatCode.StartsWith("level"))
    {
        gameData.playerLevel += cheatAmount;
    }
    else if(cheatCode.StartsWith("learnpoints"))
    {
        gameData.playerLearningPoints += cheatAmount;
    }
    else if(cheatCode.StartsWith("power"))
    {
        gameData.playerPower += cheatAmount;
    }
    else if(cheatCode.StartsWith("vitality"))
    {
        gameData.playerVitality += cheatAmount;
    }
    else if(cheatCode.StartsWith("lucky"))
    {
        gameData.playerLucky += cheatAmount;
    }
    else if(cheatCode.StartsWith("item"))
    {
        gameData.slotsEq[15] = cheatAmount;
    }
    else if(cheatCode.StartsWith("reset"))
    {
        main.ResetGame();
    }

    main.UpdateBalance();
}

private int ExtractNumber(string input)
{
    Match match = Regex.Match(input, @"\d+");
    if (match.Success)
    {
        if (int.TryParse(match.Value, out int result))
        {
            return result;
        }
    }
    return -1; 
}
}
