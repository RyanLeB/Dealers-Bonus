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
        foreach(Transform child in transform)
        {
            UiElements.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameState)
        {
            case GameState.MainMenu:
                for(int i = 0; i < UiElements.Count; i++)
                {
                    UiElements[i].SetActive(false);
                }
                UiElements[0].SetActive(true);
                break;
            case GameState.Game:
                for(int i = 0; i < UiElements.Count; i++)
                {
                    UiElements[i].SetActive(false);
                }
                break;
            case GameState.credits:
                UiElements[0].SetActive(false);
                for(int i = 0; i < UiElements.Count; i++)
                {
                    UiElements[i].SetActive(true);
                }
                break;
            case GameState.Pause:
                for(int i = 0; i < UiElements.Count; i++)
                {
                    UiElements[i].SetActive(false);
                }
                UiElements[2].SetActive(true);
                break;
            case GameState.GameOver:
                break;
        }
    }
}
