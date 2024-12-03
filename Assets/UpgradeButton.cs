using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public Bullet[] bullet;
    public Turret[] turret;

    public void UpgradeRange()
    {
        TurretUpgrade.instance.PurchaseTurretUpgrade(1, turret);
    }

    public void UpgradeDamage()
    {
        TurretUpgrade.instance.PurchaseBulletUpgrade(2, bullet);
    }

    public void UpgradeFireRate()
    {
        TurretUpgrade.instance.PurchaseTurretUpgrade(3, turret);
    }

    public void UpgradeTurnSpeed()
    {
        TurretUpgrade.instance.PurchaseTurretUpgrade(4, turret);
    }

    public void UpgradeExplosion()
    {
        TurretUpgrade.instance.PurchaseBulletUpgrade(5, bullet);
    }

    public void UpgradeSlowRate()
    {
        TurretUpgrade.instance.PurchaseTurretUpgrade(6, turret);
    }
}
