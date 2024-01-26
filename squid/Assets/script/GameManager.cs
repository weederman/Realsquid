using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private int score = 0;
    [SerializeField]
    private TextMeshProUGUI text;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void Score()
    {
        score += 1;
        text.SetText(score.ToString());
        //Debug.Log(score);
    }

    public void SetGameOver()
    {
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if(enemySpawner != null)
        {
            Time.timeScale = 0f;
            Debug.Log("Game Over!");
        }
    }
}
