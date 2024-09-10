using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum GameState
    {
        MainMenu,
        Game,
        credits,
        Pause,
        GameOver
    }
     public GameState gameState;
     public List<GameObject> UiElements;
    // Start is called before the first frame update
    void Start()
    {
        UiElements = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameState)
        {
            case GameState.MainMenu:
                break;
            case GameState.Game:
                break;
            case GameState.credits:
                break;
            case GameState.Pause:
                break;
            case GameState.GameOver:
                break;
        }
    }
}
