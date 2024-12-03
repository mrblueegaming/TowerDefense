using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    public float startSpeed = 10f;
    public float startHealth = 100;
    public int xp;

    [HideInInspector]
    public float health;

    public int worth = 50;
    public GameObject deathEffect;

    [Header("Unity Settings")]
    public Image healthBar;
    public LevelManager levelManager;

    bool isDead = false;
    
    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if(health <= 0 && !isDead)
        {            
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        PlayerStats.money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Wavespawner.enemysAlive--;

        LevelManager.Instance.AddExperience(xp);

        Destroy(gameObject);
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }
}
