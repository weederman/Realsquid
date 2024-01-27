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

        // Ű �Է¿� ���� �յڷ� ���� �ֱ�
        rigid.AddForce(new Vector2(0, moveInput * speed));

        // DiverMove ���� ���� Ȯ��
        if (collide&&Time.timeScale!=0f)
        {   
            DiverMove();
        }
    }

    void DiverMove()
    {
        float targetX = diverPosX[state]; // ���ϴ� X ��ǥ ����

        // X ��ǥ �̵��� ���� ���� ���
        float moveDirection = Mathf.Sign(targetX - rigid.position.x);

        // ���� �־� �����̱�
        rigid.AddForce(new Vector2(moveDirection * speed, 0));

        // ��ǥ ��ġ�� �����ϸ� Collide�� false�� ����
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

