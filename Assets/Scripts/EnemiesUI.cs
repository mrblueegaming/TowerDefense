using UnityEngine;
using UnityEngine.UI;

public class EnemiesUI : MonoBehaviour
{
    public Text enemiesText;

    void Update()
    {
        if (PlayerStats.playerHealth <= 0)
        {
            enemiesText.text = "0";
        }
        else
        {
            enemiesText.text = Wavespawner.enemysAlive.ToString();
        }
    }
}
