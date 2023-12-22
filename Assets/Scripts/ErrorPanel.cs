using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ErrorPanel : MonoBehaviour
{
    public PanelSystem panelSystem;

    public TMPro.TMP_Text infoErrorText;

    public void ShowError(string errorText)
    {
        panelSystem.OpenErrorPanel();
        infoErrorText.text = errorText;
    }
}
