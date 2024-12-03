using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public Text levelText;
    public Image xpBar;
    public Text percantage;


    void Update()
    {
        FillElements();
    }

    void FillElements()
    {
        levelText.text = "Level " + LevelManager.Instance.currentLevel;
        if(LevelManager.Instance.currentLevel != 100)
        {
            xpBar.fillAmount = LevelManager.Instance.currentLevelExperience / LevelManager.Instance.GetLevelXP();
            percantage.text = string.Format("{0:00.00}", 
                LevelManager.Instance.currentLevelExperience / LevelManager.Instance.GetLevelXP() * 100) + " %";
        }
        else
        {
            xpBar.fillAmount = 0f;
            percantage.text = "00,00 %";
        }
    }
}
