using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeUI : MonoBehaviour
{
    public GameObject mainCanvas;
    [Header("Range")]
    public GameObject range;
    public Text rangeText;
    public Text rangePrice;
    [Header("Damage")]
    public GameObject dmg;
    public Text dmgText;
    public Text dmgPrice;
    [Header("Fire Rate")]
    public GameObject fireRate;
    public Text fireRateText;
    public Text fireRatePrice;
    [Header("Turn Speed")]
    public GameObject turretTurn;
    public Text turretTurnText;
    public Text turretTurnPrice;
    [Header("Explosion Radius")]
    public GameObject explosion;
    public Text explosionText;
    public Text explosionPrice;
    [Header("Slow Amount")]
    public GameObject slow;
    public Text slowText;
    public Text slowPrice;

    bool active = true;

    void Start()
    {
        for(int i = 1; i < 7; i++)
        {
            CheckLockedStatus(i);
        }
    }

    void Update()
    {
        for (int i = 1; i < 7; i++)
        {
            CheckLockedStatus(i);
        }
    }

    void CheckLockedStatus(int count)
    {
        if(LevelManager.Instance.currentLevel < TurretUpgrade.instance.GetRequiredLevel(count))
        {
            rangePrice.text = "LEVEL " + TurretUpgrade.instance.GetRequiredLevel(1) + " REQUIRED";
            dmgPrice.text = "LEVEL " + TurretUpgrade.instance.GetRequiredLevel(2) + " REQUIRED";
            fireRatePrice.text = "LEVEL " + TurretUpgrade.instance.GetRequiredLevel(3) + " REQUIRED";
            turretTurnPrice.text = "LEVEL " + TurretUpgrade.instance.GetRequiredLevel(4) + " REQUIRED";
            explosionPrice.text = "LEVEL " + TurretUpgrade.instance.GetRequiredLevel(5) + " REQUIRED";
            slowPrice.text = "LEVEL " + TurretUpgrade.instance.GetRequiredLevel(6) + " REQUIRED";

            rangeText.color = new Color(255f, 255f, 255f, .5f);
            dmgText.color = new Color(255f, 255f, 255f, .5f);
            fireRateText.color = new Color(255f, 255f, 255f, .5f);
            turretTurnText.color = new Color(255f, 255f, 255f, .5f);
            explosionText.color = new Color(255f, 255f, 255f, .5f);
            slowText.color = new Color(255f, 255f, 255f, .5f);
        }
        else
        {
            rangePrice.text = "€ " + TurretUpgrade.instance.GetCost(1);
            dmgPrice.text = "€ " + TurretUpgrade.instance.GetCost(2);
            fireRatePrice.text = "€ " + TurretUpgrade.instance.GetCost(3);
            turretTurnPrice.text = "€ " + TurretUpgrade.instance.GetCost(4);
            explosionPrice.text = "€ " + TurretUpgrade.instance.GetCost(5);
            slowPrice.text = "€ " + TurretUpgrade.instance.GetCost(6);

            rangeText.color = new Color(255f, 255f, 255f, 1f);
            dmgText.color = new Color(255f, 255f, 255f, 1f);
            fireRateText.color = new Color(255f, 255f, 255f, 1f);
            turretTurnText.color = new Color(255f, 255f, 255f, 1f);
            explosionText.color = new Color(255f, 255f, 255f, 1f);
            slowText.color = new Color(255f, 255f, 255f, 1f);
        }
    }

    public void ToggleUpgradeMenu()
    {        
        range.SetActive(active);
        dmg.SetActive(active);
        fireRate.SetActive(active);
        turretTurn.SetActive(active);
        explosion.SetActive(active);
        slow.SetActive(active);
        active = !active;
    }
    
}
