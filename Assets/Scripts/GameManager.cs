using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ballsText;
    public TextMeshProUGUI finalScore;
    public GameObject pegPrefab;
    public GameObject playerPrefab;
    private GameObject titleScreen;
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public Button playButton;
    public Button restartButton;
    public bool isGameRunning = false;
    public bool isBallDropped = false;
    private int pegs;
    private int score;
    private int balls;

    // Start is called before the first frame update
    void Start()
    {
        titleScreen = GameObject.Find("Title");
        playButton.onClick.AddListener(PlayClicked);
        restartButton.onClick.AddListener(RestartClicked);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartGame()
    {
        score = 0;
        balls = 3;
        pegs = 3;

        isGameRunning = true;
        inGameUI.SetActive(true);

        UpdateScore(0);
        ballsText.text = "Balls: " + balls;

        SpawnPeg(pegs);
    }

    public void BallLost()
    {
        if (balls > 0)
        {
            balls -= 1;
            ballsText.text = "Balls: " + balls;
            pegs += 1;
            SpawnPeg(pegs);
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameRunning = false;
        finalScore.text = "Score: " + score;
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
        DestroyPegs();
    }

    private void PlayClicked()
    {
        StartGame();
        titleScreen.SetActive(false);
    }

    private void RestartClicked()
    {
        StartGame();
        gameOverUI.gameObject.SetActive(false);
    }

    private void SpawnPeg(int numberOfPegs)
    {
        DestroyPegs();
        for (int i = 0; i < numberOfPegs; i++)
        {
            Instantiate(pegPrefab, RandomPoint(), pegPrefab.transform.rotation);
        }
    }

    private void DestroyPegs()
    {
        GameObject[] existingPegs = GameObject.FindGameObjectsWithTag("Pegs");
        if (existingPegs.Length != 0)
        {
            foreach (GameObject peg in existingPegs)
            {
                Destroy(peg.gameObject);
            }
        }
    }

    public void UpdateScore(int newScore)
    {
        score += newScore;
        scoreText.text = "Score: " + score;
    }

    private Vector3 RandomPoint()
    {
        int xRange = 4;
        int yMin = 5;
        int yMax = 16;

        Vector3 point = new Vector3(Random.Range(-xRange, xRange), Random.Range(yMin, yMax), 1);

        return point;
    }
}
