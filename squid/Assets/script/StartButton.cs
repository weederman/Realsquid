using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public bool triggered = false;
    public MainManager main; 
    // Start is called before the first frame update
    private void Start()
    {
        //GameManager.instance.Awake();
        
    }   
    public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
