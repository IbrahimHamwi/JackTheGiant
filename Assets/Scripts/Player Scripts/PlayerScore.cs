using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;
    private CameraScript cameraScript;
    private Vector3 previousPosition;
    private bool countScore;
    public static int scoreCount, lifeCount, coinCount;


    void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
        countScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();
    }
    void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < previousPosition.y)
            {
                scoreCount++;
            }
            previousPosition = transform.position;
            GameplayConroller.instance.SetScore(scoreCount);
        }
    }
    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200;
            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            target.gameObject.SetActive(false);
            GameplayConroller.instance.SetScore(scoreCount);
            GameplayConroller.instance.SetCoinScore(lifeCount);
        }
        if (target.tag == "Life")
        {
            lifeCount++;
            scoreCount += 300;
            GameplayConroller.instance.SetScore(scoreCount);
            GameplayConroller.instance.SetLifeScore(lifeCount);
            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);
        }
        if (target.tag == "Bounds")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            transform.position = new Vector3(500, 500, 0);
            lifeCount--;
            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
        }
        if (target.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            transform.position = new Vector3(500, 500, 0);
            lifeCount--;
            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
        }
    }
}//PlayerScore
