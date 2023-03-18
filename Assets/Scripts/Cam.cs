using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Transform player;
    public float smooth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(nameof(Player)).transform;    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 following;
        following = new Vector3(player.position.x, transform.position.y, transform.position.z);
        if (transform.position.x >= 0)
        {
            //following = new Vector3(player.position.x, transform.position.y, player.position.z);
            //O Vector3.Lerp, é uma forma de seguir um ponto de forma menos brusca. Dessa forma, ele recebe 3 parametros, um da posição inicial do movimento, um da posical que ele deveria chegar e por ultimo o tempo que ele deveria levar pra acompanhar.
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime);
        }
        if (transform.position.x < 0)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0f,transform.position.y,transform.position.z), smooth);
        }


    }
}
