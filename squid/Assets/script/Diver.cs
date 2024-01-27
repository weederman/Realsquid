using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Diver : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigid;
    private float[] diverPosX = { -8f, -4f, -3f };
    public bool collide = false;
    public int state = 0;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Vertical");

        // 키 입력에 따라 앞뒤로 힘을 주기
        rigid.AddForce(new Vector2(0, moveInput * speed));

        // DiverMove 실행 여부 확인
        if (collide&&Time.timeScale!=0f)
        {   
            DiverMove();
        }
    }

    void DiverMove()
    {
        float targetX = diverPosX[state]; // 원하는 X 좌표 설정

        // X 좌표 이동을 위한 방향 계산
        float moveDirection = Mathf.Sign(targetX - rigid.position.x);

        // 힘을 주어 움직이기
        rigid.AddForce(new Vector2(moveDirection * speed, 0));

        // 목표 위치에 도달하면 Collide를 false로 설정
        if ((moveDirection > 0 && rigid.position.x >= targetX) || (moveDirection < 0 && rigid.position.x <= targetX))
        {
            collide = false;
            //Debug.Log("DiverMove Completed");
        }
        else
        {
            //Debug.Log("DiverMove in Progress");
        }
    }
}

