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
    public int score = 0;
    
    private TMP_Text ScorePanel;
    private TMP_Text EndScore;
    private bool isGameOver = false;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        GameOverPanel= GameObject.Find("Canvas/GameOverPanel");
        EndScore = GameObject.Find("Canvas/GameOverPanel/EndScore").GetComponent<TMP_Text>();
        ScorePanel = GameObject.Find("Canvas/ScorePanelBox/ScorePanel").GetComponent<TMP_Text>();
        isGameOver = false;
    }
    public void Start()
    {
        GameOverPanel.SetActive(false);
        isGameOver = false;
    }
    private void Update()
    {
        Debug.Log(isGameOver);
        if (!isGameOver)
        {
            Score();
            ScorePanel.SetText(score.ToString());
        }
            //else Debug.Log("Game is already over!");
    }
    public void Score()
    {
        score += 1;
        
        //Debug.Log(score);
    }
    

    public void SetGameOver()
    {
        isGameOver = true;
        Debug.Log("isGameover set true");
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null) 
        {
        Time.timeScale = 0f;
        Debug.Log("Game Over!");
        }
        GameOverPanel.SetActive(true);
        bool a = EndScore.IsActive();
        bool b=ScorePanel.IsActive();
        Debug.Log("Endscore:" + a);
        Debug.Log("ScorePaenl:" + b);
        Debug.Log("Score:" + score);
        EndScore.SetText("Score:" + score.ToString());
    }
    public void RestartGame()
    {
        //isGameOver = false;
        Debug.Log("Game is restarted!");
        Time.timeScale = 1f;

        // 여기에 게임을 초기화하는 코드를 추가하세요.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
