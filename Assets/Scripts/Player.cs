using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int hearth;
    public int life;

    private bool canJumping;
    private bool unlockDoubleJump;
    private bool canDoubleJump;
    private bool isFire;

    private Rigidbody2D rigidbodyPlayer;
    private Animator animatorPlayer;


    public GameObject arrow;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        unlockDoubleJump = false;
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        BowFire();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");


        rigidbodyPlayer.velocity = new Vector2(movement * speed, rigidbodyPlayer.velocity.y);

        if (movement < 0 && canJumping && !isFire)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            animatorPlayer.SetInteger("Transition", 1);
        }
        if (movement > 0 && canJumping && !isFire)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            animatorPlayer.SetInteger("Transition", 1);
        }
        if (movement == 0 && canJumping && !isFire)
        {
            animatorPlayer.SetInteger("Transition", 0);
        }
    }

    void Jump()
    {
        if (!canJumping && !isFire)
        {
            animatorPlayer.SetInteger("Transition", 2);
        }
        if (Input.GetButtonDown("Jump") && canDoubleJump && unlockDoubleJump)
        {
            rigidbodyPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            canDoubleJump = false;
        }
        if (Input.GetButtonDown("Jump") && canJumping)
        {
            rigidbodyPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            canJumping = false;
            canDoubleJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            canJumping = true;
            canDoubleJump = false;
        }
    }

    void BowFire()
    {
        StartCoroutine(nameof(Fire));
    }

    IEnumerator Fire()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isFire)
        {
            isFire = true;
            animatorPlayer.SetInteger("Transition", 3);
            yield return new WaitForSeconds(0.3f);
            GameObject Arrow = Instantiate(arrow, firePoint.position, firePoint.rotation);
            
                
            isFire = false;
        }
    }
}

