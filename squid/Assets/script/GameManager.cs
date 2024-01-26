using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private int score = 0;
    [SerializeField]
    private TextMeshProUGUI ScorePanel;
    private bool isGameOver = false;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        Debug.Log(isGameOver);
        if (isGameOver != true) Score();
    }
    public void Score()
    {
        score += 1;
        ScorePanel.text = score.ToString();
        //Debug.Log(score);
    }
    

    public void SetGameOver()
    {
        isGameOver = true;
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if(enemySpawner != null)
        {
            Time.timeScale = 0f;
            Debug.Log("Game Over!");
            
        }
        
    }
    public void RestartGame()
    {
        isGameOver = false;
        Time.timeScale = 1f;

        // 여기에 게임을 초기화하는 코드를 추가하세요.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
