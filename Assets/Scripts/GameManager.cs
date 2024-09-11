using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public enum GameState { Game,Pause,MainMenu,Credits, GameOver};
    public UIManager uIManager;
    public LevelManager levelManager;
    public static GameManager instance;
    public bool IsPaused;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            instance = this;
        }

        uIManager = FindObjectOfType<UIManager>();
        levelManager = FindObjectOfType<LevelManager>();    
        if(uIManager == null)
        {
            Debug.LogError("UIManager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        KeyBinds();
        UISelection();
    }
    void KeyBinds()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && levelManager.currentLevel != "MainMenu" && IsPaused == false)
        {
            IsPaused = true;
            uIManager.gameState = UIManager.GameState.Pause;
            Debug.Log("Pause");
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && levelManager.currentLevel != "MainMenu" && IsPaused == true)
        {
            IsPaused = false;
            uIManager.gameState = UIManager.GameState.Game;
            Debug.Log("Game");
        }
    }
    void UISelection()
    {
        if(levelManager.currentLevel == "MainMenu")
        {
            uIManager.gameState = UIManager.GameState.MainMenu;
            IsPaused = false;
        }
        else if(levelManager.currentLevel == "GameScene")
        {
            if(IsPaused == true)
            {
                uIManager.gameState = UIManager.GameState.Pause;
            }
            else if(IsPaused == false)
            {
                uIManager.gameState = UIManager.GameState.Game;
            }
        }
        else if(levelManager.currentLevel == "Credits")
        {
            uIManager.gameState = UIManager.GameState.credits;
        }
        else if(levelManager.currentLevel == "GameOver")
        {
            uIManager.gameState = UIManager.GameState.GameOver;
            IsPaused = false;
        }

    }
}
