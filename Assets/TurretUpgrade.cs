using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUpgrade : MonoBehaviour    
{
    public int baseCost = 1000;

    public int rangeUpgradeLevel = 1;
    public int damagUpgradeLevel = 1;
    public int fireRateUpgradeLevel = 1;
    public int turretTurnSpeedUpgradeLevel = 1;
    public int explosionRadiusUpgradeLevel = 1;
    public int slowUpgradeLevel = 1;  
    
    public static TurretUpgrade instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        rangeUpgradeLevel = PlayerPrefs.GetInt("rangeUp", 1);
        damagUpgradeLevel = PlayerPrefs.GetInt("damageUp", 1);
        fireRateUpgradeLevel = PlayerPrefs.GetInt("fireRateUp", 1);
        turretTurnSpeedUpgradeLevel = PlayerPrefs.GetInt("turnSpeedUp", 1);
        explosionRadiusUpgradeLevel = PlayerPrefs.GetInt("explosionUp", 1);
        slowUpgradeLevel = PlayerPrefs.GetInt("slowUp", 1);
    }

    public void PurchaseTurretUpgrade(int type, Turret[] turret)
    {
        bool charge = false; 
        if(GetTypeLevel(type) > 5)
        {
            return;
        }

        if (LevelManager.Instance.currentLevel >= GetRequiredLevel(type) && PlayerStats.money >= GetCost(type))
        {
            for(int i = 0;  i < turret.Length; i++)
            {
                ApplyUpgrade(type, null, turret[i]);
                charge = true;
            }
            IncreaseType(type);
        }
        else if (LevelManager.Instance.currentLevel < GetRequiredLevel(type))
        {
            Debug.Log("Player Level insufficient!");
        }
        else
        {
            Debug.Log("Not enough money");
        }

        if (charge)
        {
            PlayerStats.money -= GetCost(type);
        }
    }

    public void PurchaseBulletUpgrade(int type, Bullet[] bullet)
    {
        bool charge = false;
        if (GetTypeLevel(type) > 5)
        {
            return;
        }

        if (LevelManager.Instance.currentLevel >= GetRequiredLevel(type) && PlayerStats.money >= GetCost(type))
        {
            for (int i = 0; i < bullet.Length; i++)
            {
                ApplyUpgrade(type, bullet[i], null);
                charge = true;
            }
            IncreaseType(type);
        }
        else if (LevelManager.Instance.currentLevel < GetRequiredLevel(type))
        {
            Debug.Log("Player Level insufficient!");
        }
        else
        {
            Debug.Log("Not enough money");
        } 
        
        if (charge)
        {
            PlayerStats.money -= GetCost(type);
        }             
    }

    void ApplyUpgrade(int type, Bullet bullet, Turret turret)
    {
        switch (type)
        {
            case 1:
                turret.range *= GetUpgradeMultiplier(type);
                break;
            case 2:
                bullet.damage *= GetUpgradeMultiplier(type);
                break;
            case 3:
                turret.fireRate *= GetUpgradeMultiplier(type);
                break;
            case 4:
                turret.turnSpeed *= GetUpgradeMultiplier(type);
                break;
            case 5:
                bullet.explosionRadius *= GetUpgradeMultiplier(type);
                break;
            case 6:
                turret.slowAmount *= GetUpgradeMultiplier(type);
                break;
        }
    }

    float GetUpgradeMultiplier(int type)
    {
        float multiplier = 0;
        float mult = .15f;
        switch(type)
        {
            case 1:
                multiplier = 1f + (rangeUpgradeLevel > 5 ? 1 : rangeUpgradeLevel * mult);
                break;
            case 2:
                multiplier = 1f + (damagUpgradeLevel > 5 ? 1 : damagUpgradeLevel * mult);
                break;
            case 3:
                multiplier = 1f + (fireRateUpgradeLevel > 5 ? 1 : fireRateUpgradeLevel * mult);
                break;
            case 4:
                multiplier = 1f + (turretTurnSpeedUpgradeLevel > 5 ? 1 : turretTurnSpeedUpgradeLevel * mult);
                break;
            case 5:
                multiplier = 1f + (explosionRadiusUpgradeLevel > 5 ? 1 : explosionRadiusUpgradeLevel * mult);
                break;
            case 6:
                multiplier = 1f + (slowUpgradeLevel > 5 ? 1 : slowUpgradeLevel * mult);
                break;
        }
        return multiplier;
    }

    public int GetCost(int type)
    {
        int cost = 0;
        float mult = .3f;
        switch (type)
        {
            case 1:
                cost = (int)(baseCost * (1.5f + (rangeUpgradeLevel > 5 ? 2 : rangeUpgradeLevel * mult)));
                break;
            case 2:
                cost = (int)(baseCost * (1.5f + (damagUpgradeLevel > 5 ? 2 : damagUpgradeLevel * mult)));
                break;
            case 3:
                cost = (int)(baseCost * (1.5f + (fireRateUpgradeLevel > 5 ? 2 : fireRateUpgradeLevel * mult)));
                break;
            case 4:
                cost = (int)(baseCost * (1.5f + (turretTurnSpeedUpgradeLevel > 5 ? 2 : turretTurnSpeedUpgradeLevel * mult)));
                break;
            case 5:
                cost = (int)(baseCost * (1.5f + (explosionRadiusUpgradeLevel > 5 ? 2 : explosionRadiusUpgradeLevel * mult)));
                break;
            case 6:
                cost = (int)(baseCost * (1.5f + (slowUpgradeLevel > 5 ? 1 : slowUpgradeLevel * mult)));
                break;
        }
        return cost;
    }

    public int GetRequiredLevel(int type)
    {
        int level = 0;
        int mult = 15;
        switch (type)
        {
            case 1:
                level = rangeUpgradeLevel * mult;
                break;  
            case 2:     
                level = damagUpgradeLevel * mult;
                break;  
            case 3:     
                level = fireRateUpgradeLevel * mult;
                break;  
            case 4:     
                level = turretTurnSpeedUpgradeLevel * mult;
                break;  
            case 5:     
                level = explosionRadiusUpgradeLevel * mult;
                break;  
            case 6:     
                level = slowUpgradeLevel * mult ;
                break;
        }
        return level;
    }

    void IncreaseType(int type)
    {
        switch(type)
        {
            case 1:
                rangeUpgradeLevel++;
                PlayerPrefs.SetInt("rangeUp", rangeUpgradeLevel);
                break;
            case 2: 
                damagUpgradeLevel++;
                PlayerPrefs.SetInt("damageUp", damagUpgradeLevel);
                break;
            case 3:
                fireRateUpgradeLevel++;
                PlayerPrefs.SetInt("fireRateUp", fireRateUpgradeLevel);
                break;
            case 4:
                turretTurnSpeedUpgradeLevel++;
                PlayerPrefs.SetInt("turnSpeedUp", turretTurnSpeedUpgradeLevel);
                break;
            case 5:
                explosionRadiusUpgradeLevel++;
                PlayerPrefs.SetInt("explosionUp", explosionRadiusUpgradeLevel);
                break;
            case 6:
                slowUpgradeLevel++;
                PlayerPrefs.SetInt("slowUp", slowUpgradeLevel);
                break;
        }
    }

    int GetTypeLevel(int type)
    {
        int level = 0;
        switch (type)
        {
            case 1:
                level = rangeUpgradeLevel;
                break;
            case 2:
                level = damagUpgradeLevel;
                break;
            case 3:
                level = fireRateUpgradeLevel;
                break;
            case 4:
                level = turretTurnSpeedUpgradeLevel;
                break;
            case 5:
                level = explosionRadiusUpgradeLevel;
                break;
            case 6:
                level = slowUpgradeLevel;
                break;
        }
        return level;
    }
}
