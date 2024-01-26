using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squid : MonoBehaviour
{
    public Diver diver;
    public float speed;
    private Vector2 moveVelocity;
    public Transform shootTransform;
    Rigidbody2D rigid;
    public bool Ink = true;
    public ParticleSystem Weapon;
    private float cooldownDuration = 5f;
    private float cooldownTimer = 0f;
    void Start()
    {
        rigid=gameObject.GetComponent<Rigidbody2D>();
        diver = FindObjectOfType<Diver>();
    }
    void Update()
    {
        Vector2 moveInput = new Vector2(0, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        if (Input.GetKey(KeyCode.F) && Ink)
        {
            Shoot();
            StartCooldown();
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                Ink= true;
            }
        }
        
    }
    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + moveVelocity * Time.fixedDeltaTime);
    }
    void Shoot()
    {
        Weapon.Play();
        if (diver.state != 0)
        {
            diver.collide = true;
            diver.state-=1;
        }
    }
    void StartCooldown()
    {
        Ink = false;
        cooldownTimer = cooldownDuration;
    }
}
