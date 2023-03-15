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

    private Rigidbody2D rigidbodyPlayer;
    private Animator animatorPlayer;
    // Start is called before the first frame update
    void Start()
    {
        unlockDoubleJump = false;
        rigidbodyPlayer= GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        
        rigidbodyPlayer.velocity = new Vector2(movement*speed, rigidbodyPlayer.velocity.y);

        if (movement< 0 )
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
        if (movement>0)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && canDoubleJump && unlockDoubleJump)
        {
            rigidbodyPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            canDoubleJump = false;
        }
        if (Input.GetButtonDown("Jump") && canJumping)
        {
            rigidbodyPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            canJumping= false;
            canDoubleJump= true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer==3)
        {
            canJumping= true;
            canDoubleJump= false;
        }
    }
}
