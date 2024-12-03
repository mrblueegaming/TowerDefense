using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public Text textCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }

    public void ShowCost()
    {
        textCost.text = "€" + cost;
    }
}
