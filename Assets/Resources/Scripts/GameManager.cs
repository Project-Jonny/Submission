using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public Text scoreText;
    public static int score;

    string sceneName;

    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        gameOverText.SetActive(false);
        scoreText.text = "SCORE:" + score.ToString();
        sceneName = SceneManager.GetActiveScene().name;

        SoundManager.instance.PlayBGM("Battle");
    }

    void Update()
    {
        if (gameOverText.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                score = 0;
                FadeIOManager.instance.FadeOutToIn(() => Restart());
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                FadeIOManager.instance.FadeOutToIn(() => MoveToTitle());
            }
        }
    }

    public void AddScore()
    {
        score += 100;
        scoreText.text = "SCORE:" + score.ToString();
    }

    public void GameOver()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
        gameOverText.SetActive(true);
        SoundManager.instance.PlayBGM("GameOver");
    }

    void Restart()
    {
        SceneManager.LoadScene(sceneName);
    }

    void MoveToTitle()
    {
        SceneManager.LoadScene("title");
    }
}
