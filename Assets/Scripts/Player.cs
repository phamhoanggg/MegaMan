using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator animator;
    public LayerMask groundLayer;

    public float speed;
    public float jumpForce;
    public float atkSpeed;
    public float dmg;
    public float hp;
    public float mana;

    private float atkCD;
    private bool isOnGround;
    void Start()
    {
        atkCD = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer))
        {
            isOnGround = true;
            Debug.Log("IsOnGround");
        }
        else
        {
            isOnGround = false;
        }

        Debug.DrawRay(transform.position, Vector2.down * 1.1f, Color.red);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb2d.AddForce(new Vector2(0, jumpForce));
        }

        if (atkCD <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Attack();
                atkCD = 1 / atkSpeed;
            }
        }
        else
        {
            atkCD -= Time.deltaTime;
        }


    }

    public void Attack()
    {
        animator.SetTrigger("punch");
    }

}
