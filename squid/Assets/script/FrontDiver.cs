using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDiver : MonoBehaviour
{
    public float moveSpeed = 10f;

    private float minX = -8;
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
}
