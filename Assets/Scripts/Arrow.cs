using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D arrowRigdbody;
    public float speed;

    public int direction;
    // Start is called before the first frame update
    void Start()
    {
        arrowRigdbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
        direction= 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.y == 0)
        {
            arrowRigdbody.velocity = Vector2.right * speed;
        }
        if (transform.rotation.y != 0) 
        {
            arrowRigdbody.velocity = Vector2.left * speed;
        }
    }
}
