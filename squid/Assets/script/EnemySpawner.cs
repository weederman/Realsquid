using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float SpawnInterval = 3f;
    private float[] arrPosy = { 4f,2f,0f,-2f,-4f };
    public float MaxInterval = 1f;
    void Start()
    {
        StartEnemyRoutin();
    }
    public void StopEnemyRoutine()
    {
        StopCoroutine("EnemyRoutine");
    }
    void StartEnemyRoutin()
    {
        StartCoroutine("EnemyRoutine");
    }
    // Update is called once per frame
    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            foreach(float posy in arrPosy)
            {
                int index=Random.Range(0, 11);
                SpawnEnemy(posy,index);
            }
            yield return new WaitForSeconds(SpawnInterval);
        }
    }
    void SpawnEnemy(float posy,int index)
    {
        Vector3 spawnPos = new Vector3(transform.position.x, posy, transform.position.z);
        Instantiate(enemies[index],spawnPos,Quaternion.identity );
        if(SpawnInterval>MaxInterval)
        {
            SpawnInterval -= 0.001f;
        }
    }
}
