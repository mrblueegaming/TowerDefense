using UnityEngine;
using UnityEngine.Analytics;

public class PlayerStats : MonoBehaviour
{
    
    public static int money;
    public int startMoney = 400;

    public static float playerHealth;
    public static float maxHealth;
    public float startHealth;

    public static int rounds;    

    void Start()
    {
        money = startMoney;
        maxHealth = PlayerPrefs.GetFloat("playerMaxHealth", startHealth);
        playerHealth = maxHealth;
        rounds = 0;
    }

    void Update()
    {
        PlayerPrefs.SetFloat("playerMaxHealth", maxHealth);
        PlayerPrefs.SetInt("playerMoney", money);
    }

    public static void Reset()
    {
        money = 15000;
        maxHealth = 500;
        playerHealth = 500;
    }
    
}
