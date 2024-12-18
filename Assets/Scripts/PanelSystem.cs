using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelSystem : MonoBehaviour
{
    public GameData gameData;
    public Equipment equipment;
    public Main main;
    public Story story;
    public HeroPanel heroPanelScript;
    public Clicker clicker;
    public Spells spells;
    public GameStatistics gameStats;
    public InfoMonsterPanel infoMonsterPanelScript;

    public TMPro.TMP_Text confirmationText;

    public GameObject GamePanel;
    public GameObject MenuPanel;
    public GameObject ClickPanel;
    public GameObject HeroPanel;
    public GameObject ActionPanel;
    public GameObject EquipmentPanel;
    public GameObject HeroStatsPanel;
    public GameObject ShopPanel;
    public GameObject InfoPanel;
    public GameObject ErrorPanel;
    public GameObject InfoMonsterPanel;
    public GameObject TutorialPanel;
    public GameObject ConfirmationPanel;
    public GameObject OptionsPanel;
    public GameObject AdminPanel;
    public GameObject AchievmentsPanel;
    public GameObject StatisticsPanel;
    public GameObject ElixirPanel;
    public GameObject SpellUpgradePanel;
    public GameObject SpellInfoPanel;
    public GameObject SelectingPanel;
    public GameObject BossFightPanel;

    private void CloseAllPanels()
    {
        MenuPanel.SetActive(false);
        HeroPanel.SetActive(false);
        ActionPanel.SetActive(false);
        EquipmentPanel.SetActive(false);
        HeroStatsPanel.SetActive(false);
        ShopPanel.SetActive(false);
        InfoPanel.SetActive(false);
        ErrorPanel.SetActive(false);
        ConfirmationPanel.SetActive(false);
        SelectingPanel.SetActive(false);
        BossFightPanel.SetActive(false);
        AchievmentsPanel.SetActive(false);
        StatisticsPanel.SetActive(false);
        SpellUpgradePanel.SetActive(false);
    }

    public void OpenGamePanel()
    {
        CloseAllPanels();
        GamePanel.SetActive(true);
        OpenClickPanel();
        
    }

    public void OpenClickPanel()
    {
        ClickPanel.SetActive(true);
        BossFightPanel.SetActive(false);
        clicker.isMonsterPanel = true;
    }

    public void OpenMenuPanel()
    {
        CloseAllPanels();
        GamePanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void OpenHeroPanel()
    {
        ActionPanel.SetActive(true);
        HeroPanel.SetActive(true);
        HeroStatsPanel.SetActive(true);
        heroPanelScript.UpdateTextHeroPanel();

    }

    public void CloseHeroPanel()
    {
        CloseAllPanels();

    }

    public void OpenEquipmentPanel()
    {
        EquipmentPanel.SetActive(true);
        equipment.Start();
        HeroStatsPanel.SetActive(false);
    }

    public void OpenHeroStatsPanel()
    {
        EquipmentPanel.SetActive(false);
        HeroStatsPanel.SetActive(true);
        heroPanelScript.UpdateTextHeroPanel();
    }

    public void OpenShopPanel()
    {
        CloseAllPanels();
        ActionPanel.SetActive(true);
        ShopPanel.SetActive(true);
        EquipmentPanel.SetActive(true);
    }

    public void CloseShopPanel()
    {
        CloseAllPanels();
    }

    public void OpenInfoPanel()
    {
        InfoPanel.SetActive(true);
    }

    public void CloseInfoPanel()
    {
        InfoPanel.SetActive(false);
    }

    public void OpenErrorPanel()
    {
        ErrorPanel.SetActive(true);
    }

    public void CloseErrorPanel()
    {
        ErrorPanel.SetActive(false);
    }

    public void OpenTutorialPanel()
    {
        TutorialPanel.SetActive(true);
    }

    public void CloseTutorialPanel()
    {
        TutorialPanel.SetActive(false);
        gameData.coinsBalance += story.coinsReward;
        main.UpdateBalance();
    }

    public void OpenConfirmationPanel(string askingText)
    {
        ConfirmationPanel.SetActive(true);
        confirmationText.text = askingText;
    }

    public void CloseConfirmationPanel()
    {
        ConfirmationPanel.SetActive(false);
    }

    public void OpenOptionsPanel()
    {
        OpenGamePanel();
        OptionsPanel.SetActive(true);
    }

    public void CloseOptionsPanel()
    {
        OptionsPanel.SetActive(false);
    }

    public void OpenAdminPanel()
    {
        OpenGamePanel();
        AdminPanel.SetActive(true);
    }

    public void CloseAdminPanel()
    {
        AdminPanel.SetActive(false);
    }

    public void OpenInfoMonsterPanel()
    {
        InfoMonsterPanel.SetActive(true);
        infoMonsterPanelScript.UpdateInfoMonsterTexts();
    }

    public void CloseInfoMonsterPanel()
    {
        InfoMonsterPanel.SetActive(false);
    }

    public void OpenSelectingPanel()
    {
        SelectingPanel.SetActive(true);
    }

    public void CloseSelectingPanel()
    {
        SelectingPanel.SetActive(false);
    }

    public void OpenBossFightPanel()
    {
        CloseAllPanels();
        ClickPanel.SetActive(false);
        BossFightPanel.SetActive(true);
        clicker.isMonsterPanel = false;
    }

    public void CloseBossFightPanel()
    {
        BossFightPanel.SetActive(false);
        ClickPanel.SetActive(true);
        clicker.isMonsterPanel = true;
    }

    public void OpenAchievmentsPanel()
    {
        OpenGamePanel();
        AchievmentsPanel.SetActive(true);
    }

    public void CloseAchievmetsPanel()
    {
        AchievmentsPanel.SetActive(false);
    }

    public void OpenStatisticsPanel()
    {
        OpenGamePanel();
        StatisticsPanel.SetActive(true);
        gameStats.UpdatingGameStatisticsTexts();
    }

    public void CloseStatisticsPanel()
    {
        StatisticsPanel.SetActive(false);
    }

    public void ShowHideElixirPanel()
    {
        if(ElixirPanel.activeSelf == false)
        {
            ElixirPanel.SetActive(true);
        }
        else
        {
            ElixirPanel.SetActive(false);
        }

    }

    public void OpenSpellUpgradePanel()
    {
        SpellUpgradePanel.SetActive(true);
        spells.RefreshSpellUpgradePanel();
    }

    public void CloseSpellUpgradePanel()
    {
        SpellUpgradePanel.SetActive(false);
    }

    public void OpenSpellInfoPanel()
    {
        SpellInfoPanel.SetActive(true);
    }

    public void CloseSpellInfoPanel()
    {
        SpellInfoPanel.SetActive(false);
    }
}
