using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketOfWaterScript : MonoBehaviour
{
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
            GV.water = true;
            SoundManager.Instance.PlaySound(SoundManager.Sound.PickUpWater, transform.position);
            Destroy(gameObject);
        }
    }
}
