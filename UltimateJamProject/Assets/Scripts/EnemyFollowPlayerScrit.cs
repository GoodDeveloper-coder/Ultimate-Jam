using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayerScrit : MonoBehaviour
{
    private Rigidbody2D physics;

    public Transform player;

    public float speed;
    public float agroDistance;

    private float scale = 0.5f;
    private float scale1 = -0.5f;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroDistance)
        {
            if (player.position.x == transform.position.x)
            {
                physics.velocity = new Vector2(0, 0);
            }
            else
            {
                StartHunting();
            }
        }       
        else
        {
            StopHunting();
        }
    }

    void StartHunting()
    {
        if(player.position.x < transform.position.x)
        {
            physics.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
        else if(player.position.x > transform.position.x)
        {
            physics.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(-0.5f, 0.5f);
        }
    }

    void StopHunting()
    {
        physics.velocity = new Vector2(0, 0);
    }
}
