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
    
    private TMP_Text ScorePanel;
    private TMP_Text EndScore;
    private bool isGameOver = false;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        GameOverPanel = GameObject.Find("Canvas/GameOverPanel");
        EndScore = GameObject.Find("Canvas/GameOverPanel/EndScore").GetComponent<TMP_Text>();
        ScorePanel = GameObject.Find("Canvas/ScorePanelBox/ScorePanel").GetComponent<TMP_Text>();
        
    }
    public void Start()
    {
        GameOverPanel.SetActive(false);
        StartCoroutine(IncreaseScoreCoroutine());
    }
    private void Update()
    {
        //Debug.Log(isGameOver);
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
        isGameOver = true;
        StopCoroutine(IncreaseScoreCoroutine());
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
        Debug.Log("Score:" + number);
        
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
