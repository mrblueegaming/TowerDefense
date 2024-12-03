using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public readonly float[] levelXp =
    {
        0f,
        108f,
        225f,
        351f,
        487f,
        634f,
        792f,
        964f,
        1149f,
        1349f,
        1565f,
        1798f,
        2050f,
        2321f,
        2615f,
        2932f,
        3275f,
        3645f,
        4045f,
        4476f,
        4942f,
        5446f,
        5989f,
        6576f,
        7211f,
        7895f,
        8635f,
        9434f,
        10297f,
        11228f,
        12235f,
        13321f,
        14495f,
        15763f,
        17132f,
        18610f,
        20207f,
        21932f,
        23794f,
        25806f,
        27978f,
        30324f,
        32858f,
        35595f,
        38551f,
        41743f,
        45190f,
        48913f,
        52934f,
        57277f,
        61967f,
        67033f,
        72503f,
        78411f,
        84792f,
        91684f,
        99126f,
        107165f,
        115846f,
        125221f,
        135347f,
        146283f,
        158093f,
        170849f,
        184625f,
        199503f,
        215571f,
        232925f,
        251667f,
        271908f,
        293769f,
        317378f,
        342876f,
        370415f,
        400156f,
        432276f,
        466966f,
        504432f,
        544894f,
        588594f,
        635789f,
        686760f,
        741809f,
        801262f,
        865471f,
        934816f,
        1009710f,
        1090594f,
        1177950f,
        1272294f,
        1374185f,
        1484228f,
        1603074f,
        1731428f,
        1870051f,
        2019763f,
        2181452f,
        2356076f,
        2544670f,
        2748352f
    };
    public int currentLevel = 1;
    public float currentExperience = 0;

    public float currentLevelExperience = 0;    

    public static LevelManager Instance;

    public delegate void ExperienceChangeHandler(int amount);
    public event ExperienceChangeHandler OnExperienceChange;

    void Start()
    {
        if(Debuger.Instance.debugMode)
        {
            currentExperience = 2740352f;
            CalcLevel();
            currentLevelExperience = 2740352f - levelXp[currentLevel - 1];
        }
        else
        {
            currentExperience = PlayerPrefs.GetFloat("playerXP", 0);
            CalcLevel();        
            currentLevelExperience = PlayerPrefs.GetFloat("playerXP", 0) - levelXp[currentLevel - 1];
        }   
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            Reset();
        }

        if(Input.GetKeyDown(KeyCode.F2))
        {
            AddXP();
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            RemoveXP();
        }
        
    }

    void OnEnable()
    {
        Instance.OnExperienceChange += HandleExperienceChange;
    }

    void OnDisable()
    {
        Instance.OnExperienceChange -= HandleExperienceChange;
    }

    public void AddExperience(int amount)
    {
        if(currentLevel != 100)
        {
            OnExperienceChange?.Invoke(amount);
        }        
    }

    void HandleExperienceChange(int newExperience)
    {
        currentExperience += newExperience;
        currentLevelExperience += newExperience;
        
        if (currentExperience >= levelXp[currentLevel])
        {
            LevelUp();
        }

        PlayerPrefs.SetInt("playerLvl", currentLevel);
        PlayerPrefs.SetFloat("playerXP", currentExperience);
    }

    void LevelUp()
    {
        currentLevel++;
        currentLevelExperience = currentExperience - levelXp[currentLevel - 1];
        PlayerStats.maxHealth += 10;
        PlayerStats.playerHealth = PlayerStats.maxHealth;
        PlayerPrefs.SetFloat("playerMaxHealth", PlayerStats.maxHealth);
    }

    void Reset()
    {
        if(Debuger.Instance.debugMode)
        {
            currentExperience = 0;
            currentLevelExperience = 0;
            currentLevel = 1;
            PlayerStats.Reset();
        }        
    }

    void AddXP()
    {
        if (Debuger.Instance.debugMode)
        {
            AddExperience(100);
        }
    }

    void RemoveXP()
    {
        if (Debuger.Instance.debugMode)
        {
            AddExperience(-100);
        }
    }

    public float GetLevelXP()
    {
        if(currentLevel == 100)
        {
            return levelXp[currentLevel - 1];
        }
        return levelXp[currentLevel] - levelXp[currentLevel - 1];
    }

    public void CalcLevel()
    {
        for (int i = 0; i < levelXp.Length; i++)
        {
            if (currentExperience >= levelXp[i] && currentExperience < levelXp[i + 1])
            {
                currentLevel = i + 1;
            }
        }
    }
}


