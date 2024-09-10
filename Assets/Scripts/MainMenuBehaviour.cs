using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // StartButton() and QuitButton() are called when the respective buttons are clicked
    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void CreditsButton()
    {

    }
}
