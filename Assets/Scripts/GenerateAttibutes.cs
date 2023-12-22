using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAttibutes : MonoBehaviour
{

    public GameData gameData;

    public int GenerateMaxExpierience(int level)
    {
        switch(level)
        {
            case 0:
                return 1;
            case 1:
                return 1; // 9
            default:
                return 10;
        }
    }

    public int GeneratePowerRatio(int level)
    {
        return 1 + level/10;
        /*switch(level)
        {
            case < 10:
                return 1;
            case < 20:
                return 2;
            case < 30:
        }*/
    }

    public int GenerateVitalityRatio(int level)
    {
        return 5 * level/10;
    }
}
