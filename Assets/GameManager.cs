using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameIsOver;

    public GameObject gameOverUI;
    public GameObject shopUI;
    public GameObject completeLevelUI;
    void Start()
    {
        gameIsOver = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (gameIsOver) { return; }
        if(PlayerStats.playerHealth < 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
        shopUI.SetActive(false);
    }

    public void WinLevel()
    {
        gameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
