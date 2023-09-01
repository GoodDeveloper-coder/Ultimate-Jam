using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValues : MonoBehaviour
{
    public int PlayerLives = 3;

    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;
    public GameObject HP4;

    public GameObject hho;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLives == 2)
        {
            HP1.SetActive(false);
        }

        if (PlayerLives == 1)
        {
            HP2.SetActive(false);
        }

        if (PlayerLives == 0)
        {
            HP3.SetActive(false);
            Debug.Log("You Lose");
            Time.timeScale = 0f;
            hho.SetActive(true);
        }
    }
}
