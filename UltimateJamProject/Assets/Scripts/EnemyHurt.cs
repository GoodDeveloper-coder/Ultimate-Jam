using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    public int EnemyHP;

    public GameObject ParentEnemy;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHP == 0)
        {
            Destroy(ParentEnemy);
            Debug.Log("EnemyDestroy");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("EnemyDestroy21");

        if (collision.gameObject.tag == "Player")
        {
            if (EnemyHP == 0)
            {
                Destroy(gameObject);
                Debug.Log("EnemyDestroy");
            }
            else
            {
                EnemyHP--;
                Debug.Log("Enemy -1");
            }
            SoundManager.Instance.PlaySound(SoundManager.Sound.EnemyHurt, transform.position);
        }
    }
}