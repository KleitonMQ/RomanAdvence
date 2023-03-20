using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furico : MonoBehaviour
{
    public float speed;
    public float walkTime;

    private float timer;
    private bool direction;

    private Rigidbody2D furicoRigid;
    private Animator furicoAnimator;


    // Start is called before the first frame update
    void Start()
    {
        furicoAnimator= GetComponent<Animator>();
        furicoRigid= GetComponent<Rigidbody2D>();
        direction = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > walkTime)
        {
            direction= !direction;
            timer= 0f;
        }

        if (direction)
        {
            transform.eulerAngles= new Vector2(0, 180);
            furicoRigid.velocity= Vector2.right * speed;
        }
        if (!direction)
        {
            transform.eulerAngles = new Vector2(0, 0);
            furicoRigid.velocity = Vector2.left * speed;
        }
    }

    void Move()
    {
        
    }
}
