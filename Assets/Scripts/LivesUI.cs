using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;

    void Update()
    {
        if(PlayerStats.playerHealth <= 0)
        {
            livesText.text = "0 / " + PlayerStats.maxHealth;
        }
        else
        {
            livesText.text = (int)PlayerStats.playerHealth + " / " + (int)PlayerStats.maxHealth;
        }
    }
}
