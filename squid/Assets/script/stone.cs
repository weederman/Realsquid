using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Diver diver;
    private float minX = -10;
    // Start is called before the first frame update
    void Start()
    {
        diver = FindObjectOfType<Diver>();
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
        if (collision.gameObject.tag=="Player")
        {
            Debug.Log("STone!");
            if (diver.state <2)
            {
                diver.collide = true;
                diver.state++;
            }
            else
            {
                GameManager.instance.SetGameOver();
            }
        }
    }
}
