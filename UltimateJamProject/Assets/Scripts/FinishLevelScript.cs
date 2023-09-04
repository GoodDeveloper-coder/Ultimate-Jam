using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GlobalValues GV;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (GV.water)
            {
                Debug.Log("You win");
            }
            else
            {
                Debug.Log("You Lose");
            }
        }
    }
}
