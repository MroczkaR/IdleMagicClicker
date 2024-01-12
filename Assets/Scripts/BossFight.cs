using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossFight : MonoBehaviour
{
    public GameData gameData;
    public Main main;
    public Monsters monsters;
    public PanelSystem panelSystem;
    public ErrorPanel errorPanel;
    
    public TMPro.TMP_Text bossName;
    public TMPro.TMP_Text bossHp;
    public TMPro.TMP_Text heroHp;
    public TMPro.TMP_Text heroInfoText;
    public TMPro.TMP_Text bossInfoText;
    public Slider heroBarHp;
    public Slider bossBarHp;

    public Button bossButton;
    private Sprite actualBossImage;
    private Animator heroInfoTextAnim;
    private Animator bossInfoTextAnim;

    public int bossActualHp;
    private int heroActualHp;

    private int dealDamage;
    private int bossDamage;

    private void Start()
    {
        GetBossStats();
        bossInfoAnimationUpdate();
    }

    public void bossInfoAnimationUpdate()
    {
        heroInfoTextAnim = heroInfoText.GetComponent<Animator>();
        bossInfoTextAnim = bossInfoText.GetComponent<Animator>();
        //heroInfoTextAnim.Update(0f);
        //bossInfoTextAnim.Update(0f);
        bossInfoTextAnim.enabled = false;
        heroInfoTextAnim.enabled = false;
        heroInfoText.enabled = false;
        bossInfoText.enabled = false;
    }

    private void BossDmgInfo(string infoText)
    {
        bossInfoText.enabled = true;
        bossInfoTextAnim.enabled = true;
        bossInfoText.text = infoText;
        StartCoroutine(BossInfoTextAnimation());
    }
    
    private void HeroDmgInfo(string infoText)
    {
        heroInfoText.enabled = true;
        heroInfoTextAnim.enabled = true;
        heroInfoText.text = infoText;
        StartCoroutine(HeroInfoTextAnimation());
    }
    
    public void UpdateBossHp(int bossActualHp, int bossMaxHp)
    {
        bossName.text = monsters.selectedBoss.name;
        bossHp.text = (bossActualHp + " / " + bossMaxHp).ToString();
        bossBarHp.value = (float)bossActualHp / bossMaxHp;
    }

    public void UpdateHeroHp()
    {   
        heroHp.text = (heroActualHp + " / " + gameData.playerHealth).ToString();
        heroBarHp.value = (float)heroActualHp / gameData.playerHealth;
    }

    
    public void GetBossStats()
    {
        actualBossImage = Resources.Load<Sprite>("boss_id_" + monsters.selectedBoss.id.ToString());
        bossButton.image.sprite = actualBossImage;
        bossActualHp = monsters.selectedBoss.maxHp;
        heroActualHp = gameData.playerHealth;
        UpdateBossHp(monsters.selectedBoss.maxHp, monsters.selectedBoss.maxHp);
        UpdateHeroHp();
        
    }

        public void SimpleAtack()
    {
        if(bossActualHp > 0)
        {
            dealDamage = Random.Range(gameData.playerMinDmg, gameData.playerMaxDmg + 1);
            bossActualHp -= dealDamage;
            bossInfoTextAnim.Play("ClickingInfoTextAnim", 0 , 0f);
            BossDmgInfo("- " + dealDamage.ToString());
            StartCoroutine(BossCounterAtack());

        }
        if(bossActualHp <= 0)
        {
            Debug.Log("You WIN with BOSS");
            //clickButton.enabled = false;
            //gameData.playerExp += monsters.selectedMonster.exp;
            //main.CheckExpierience();
            //CheckDrop();
            //StartCoroutine(RespMonster());
        }

        UpdateBossHp(bossActualHp, monsters.selectedBoss.maxHp);
    }

    private void BossAtack()
    {
        bossDamage = Random.Range(monsters.selectedBoss.minDmg, monsters.selectedBoss.maxDmg + 1);
        heroActualHp -= bossDamage;
        heroInfoTextAnim.Play("ClickingInfoTextAnim", 0, 0f);
        HeroDmgInfo("- " + bossDamage.ToString());
        UpdateHeroHp();
        if(heroActualHp <= 0)
        {
            panelSystem.OpenClickPanel();
            panelSystem.OpenSelectingPanel();
            errorPanel.ShowError("You lost fight with Boss \n Make up your Level or inventory and try again");
        }

    }


    IEnumerator HeroInfoTextAnimation()
    {
        yield return new WaitForSeconds(1);
        heroInfoTextAnim.Play("ClickingInfoTextAnim" , 0, 0f);
        heroInfoText.enabled = false;
        heroInfoTextAnim.enabled = false;
        //StopCoroutine(HeroInfoTextAnimation());
    }

    IEnumerator BossInfoTextAnimation()
    {
        yield return new WaitForSeconds(1);
        bossInfoTextAnim.Play("ClickingInfoTextAnim" , 0, 0f);
        bossInfoText.enabled = false;
        bossInfoTextAnim.enabled = false;
        //StopCoroutine(BossInfoTextAnimation());
    }

    IEnumerator BossCounterAtack()
    {
        yield return new WaitForSeconds(0.5f);
        BossAtack();
    }
}
