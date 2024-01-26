using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDiver : MonoBehaviour
{
    public float moveSpeed = 10f;

    private float minX = -10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (transform.position.x < minX)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collide!");
            GameManager.instance.SetGameOver();
        }
    }
}
