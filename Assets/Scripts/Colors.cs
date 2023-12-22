using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    public int itemColor;
    public Color32 actualColor;
    private Color32 emptyGrey = new Color32(120, 120, 120, 255);
    private Color32 woodHelmet = new Color32(113, 61, 36, 255);
    private Color32 brownShoes = new Color32(239, 105, 42, 255);
    private Color32 black = new Color32(0, 0, 0, 255);
    private Color32 white = new Color32(255, 255, 255, 255);

    public void CheckColor(int index)
    {
        if(index == 0)
        {
            actualColor = emptyGrey;
        }
        else
        {
            actualColor = white;
        }
    }


}
