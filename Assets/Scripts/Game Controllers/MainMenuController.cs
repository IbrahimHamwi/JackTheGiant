using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }
    public void HighscoreMenu()
    {
        SceneManager.LoadScene("HighScoreScene");
    }
    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MusicButton()
    {

    }
} // MainMenu Controller
