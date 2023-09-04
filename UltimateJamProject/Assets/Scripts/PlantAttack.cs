using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlantAttack : MonoBehaviour
{
    public Animator anim;
    public GlobalValues GV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            GV.PlayerLives--;
            anim.Play("ObstaclePlantAnimAttack");
            GV.CameraShake();
        }
    }
}
