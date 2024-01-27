using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStatistics : MonoBehaviour
{
    
    public int totalTaps;
    public int totalExpGraunted;
    public int totalKilledMonsters;

    public TMPro.TMP_Text totalTapsText;

    private void Start()
    {
        UpdatingGameStatisticsTexts();
    }

    public void UpdatingGameStatisticsTexts()
    {
        totalTapsText.text = "Total Taps : " + totalTaps.ToString();
    }
}
