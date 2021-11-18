using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;
    [HideInInspector]
    public int score, coinScore, lifeScore;

    // Start is called before the first frame update
    void Awake()
    {
        MakeSingleton();
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }
    void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameplayScene")
        {
            if (gameRestartedAfterPlayerDied)
            {
                Debug.Log("game started after player died");
                GameplayConroller.instance.SetScore(score);
                GameplayConroller.instance.SetCoinScore(coinScore);
                GameplayConroller.instance.SetLifeScore(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;
            }
            else if (gameStartedFromMainMenu)
            {
                Debug.Log("game started from main menu");
                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;

                GameplayConroller.instance.SetScore(0);
                GameplayConroller.instance.SetCoinScore(0);
                GameplayConroller.instance.SetLifeScore(2);
            }
            else
            {
                Debug.Log("game started from other");
            }
        }
        else
        {
            Debug.Log("other scene");

        }
    }

    // Update is called once per frame
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if (lifeScore < 0)
        {
            gameRestartedAfterPlayerDied = false;
            gameStartedFromMainMenu = false;
            GameplayConroller.instance.GameOverShowPanel(score, coinScore);
        }
        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = true;

            GameplayConroller.instance.PlayerDiedRestartTheGame();
        }
    }
}
