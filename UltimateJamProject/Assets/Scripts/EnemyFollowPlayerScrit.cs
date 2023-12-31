using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayerScrit : MonoBehaviour
{
    private Rigidbody2D physics;

    public Transform player;

    public float speed;
    public float agroDistance;

    public float scale = 0.5f;
    public float scale1 = -0.5f;

    /*
    private bool gg1 = true;
    private bool gg2;
    private bool gg3;
    private bool gg4;
    */


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        physics = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroDistance)
        {
            StartHunting();
            /*
            if (player.position.x == transform.position.x)
            {
                physics.velocity = new Vector2(0, 0);
            }
            else
            {
                StartHunting();
            }
            */
        }
        else
        {
            StopHunting();
        }
    }

    void StartHunting()
    {
        if (player.position.x < transform.position.x)
        {
            physics.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(scale, scale);
        }
        else if (player.position.x > transform.position.x)
        {
            physics.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(scale1, scale);
        }
    }

    void StopHunting()
    {
        physics.velocity = new Vector2(0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GlobalValues.Instance.PlayerLives--;
            GlobalValues.Instance.CameraShake();
            

            

            /*
            if (gg1)
            {
                HP1.SetActive(false);
                gg1 = false;
                gg2 = true;
                Debug.Log("2");
                PL.PlayerLives -= 1;
            }
            else if (gg2)
            {
                HP2.SetActive(false);
                gg2 = false;
                gg3 = true;
                Debug.Log("1");
                PL.PlayerLives -= 1;
            }
            else if (gg3)
            {
                HP3.SetActive(false);
                gg3 = false;
                gg4 = true;
                PL.PlayerLives -= 1;
            }
            else if (gg4)
            {
               // HP4.SetActive(false);
                gg4 = false;
                gg4 = false;
               // Debug.Log("You Lose");
            }
            */
        }
    }
}