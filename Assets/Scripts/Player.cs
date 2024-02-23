using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator animator;
    public LayerMask groundLayer;
    public Bullet bulletPrefab;
    public Transform firePosition;

    [Header("THUOC TINH")]
    public float speed;
    public float jumpForce;
    public float atkSpeed;
    public float fireCD;
    public float dmg;
    public float hp;
    public float mana;

    private float atkCD;
    private float currentFireCD;
    private bool isOnGround;
    private int direct;
    void Start()
    {
        atkCD = 0;
        direct = 1;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            direct = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
            direct = -1;
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


        if (currentFireCD <= 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fire();
                currentFireCD = fireCD;
            }
        }
        else
        {
            currentFireCD -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        animator.SetTrigger("punch");
    }

    public void Fire()
    {
        Bullet newBullet = Instantiate(bulletPrefab, firePosition.position, Quaternion.identity);
        newBullet.OnInit(direct);
    }

}
