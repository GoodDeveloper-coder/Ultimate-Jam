using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyMushroomScript : MonoBehaviour
{

    //public GameObject player;

    public Rigidbody2D Rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rb.AddForce(transform.up * 400);
        }
    }
}
