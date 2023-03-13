using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int hearth;
    public int life;


    private Rigidbody2D rigidbodyPlayer;
    private Animator animatorPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyPlayer= GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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

    }
}
