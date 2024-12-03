using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public EnemyData[] enemies;
    public float rate;
    public int totalCount;

    public GameObject Randomizer()
    {
        int r = Random.Range(0, enemies.Length);
        while (enemies[r].maxCount == 0)
        {
            r = Random.Range(0, enemies.Length);
        }
        enemies[r].maxCount--;
        return enemies[r].enemyPrefab;
    }
}
