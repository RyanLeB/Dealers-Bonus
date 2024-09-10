using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uIManager;
    public LevelManager levelManager;
    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        levelManager = FindObjectOfType<LevelManager>();    
        if(uIManager == null)
        {
            Debug.LogError("UIManager is null");
        }
        if(instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(levelManager.currentLevel == "MainMenu")
        {
            uIManager.gameState = UIManager.GameState.MainMenu;
        }
        else if(levelManager.currentLevel == "GameScene")
        {
            uIManager.gameState = UIManager.GameState.Game;
        }
        else if(levelManager.currentLevel == "Credits")
        {
            uIManager.gameState = UIManager.GameState.credits;
        }
        else if(levelManager.currentLevel == "GameOver")
        {
            uIManager.gameState = UIManager.GameState.GameOver;
        }
    }
}
