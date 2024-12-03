using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    Node target;
    public GameObject ui;
    public Text upgradeCost;
    public Button upgradeButton;
    public Text sellPrice;
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if(!target.isUpgraded)
        {
            upgradeCost.text = "€" + target.turretBlueprint.upgradeCost;
            sellPrice.text = "€" + target.turretBlueprint.GetSellAmount();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "MAX";
            sellPrice.text = "€" + target.turretBlueprint.GetSellAmount();
            upgradeButton.interactable = false;
        }

        ui.SetActive(true);
               
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
