using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject GameOverPanel;
    public static GameManager instance = null;
    [SerializeField]
    public int number = 0;
    private GameObject StopPanel;
    private GameObject ScorePanelBox;
    private TMP_Text ScorePanel;
    private TMP_Text EndScore;
    private bool isGameOver = false;
    private bool GameStarted = false;
    public Text BestScoreText;
    private string KeyName = "BestScore";
    private int bestScore = 0;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        GameOverPanel = GameObject.Find("Canvas/GameOverPanel");
        ScorePanelBox = GameObject.Find("Canvas/ScorePanelBox");
        EndScore = GameObject.Find("Canvas/GameOverPanel/EndScore").GetComponent<TMP_Text>();
        ScorePanel = GameObject.Find("Canvas/ScorePanelBox/ScorePanel").GetComponent<TMP_Text>();
        StopPanel = GameObject.Find("Canvas/StopPanel");
        bestScore=PlayerPrefs.GetInt(KeyName, 0);
        //BestScoreText.text = $"Best Score: {bestScore.ToString()}";
    }
    public void Start()
    {
        if (!GameStarted)
        {
            StartCoroutine(IncreaseScoreCoroutine());
            ScorePanelBox.SetActive(true);
            GameOverPanel.SetActive(false);
            StopPanel.SetActive(false);
            Time.timeScale = 1f;
            Debug.Log("Game Started");
            GameStarted = true;
        }
        else
        {
            Debug.Log("Game Already Started.");
        }

    }
    private void Update()
    {
        
    }
    private IEnumerator IncreaseScoreCoroutine()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(0.1f); // 1초 대기

            if (!isGameOver)
            {
                number+=1;
                ScorePanel.SetText(number.ToString());// 10점씩 증가
                EndScore.SetText("Score:" + number.ToString());
            }
        }
    }

    public void SetGameOver()
    {
        Time.timeScale = 0f;
        isGameOver = true;
        StopCoroutine(IncreaseScoreCoroutine());
        Debug.Log("isGameover set true");
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null) 
        {
        
        Debug.Log("Game Over!");
        }
        GameOverPanel.SetActive(true);
        ScorePanelBox.SetActive(false);
        bool a = EndScore.IsActive();
        bool b=ScorePanel.IsActive();
        Debug.Log("Endscore:" + a);
        Debug.Log("ScorePaenl:" + b);
        Debug.Log("Score:" + number);
        if(number>bestScore)
        {
            PlayerPrefs.SetInt(KeyName, number);
            Debug.Log("BestScore!");
        }
    }
    public void RestartGame()
    {
        //isGameOver = false;
        Debug.Log("Game is restarted!");
        Time.timeScale = 1f;

        // 여기에 게임을 초기화하는 코드를 추가하세요.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void StartGame()
    {
        SceneManager.LoadScene("MainScene");
        
    }
    public void STOPGAME()
    {
        Time.timeScale = 0f;
        StopPanel.SetActive(true);
    }
    public void ResumeGame()
    {
        StopPanel.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Game Resumed");
    }
    public void ToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
