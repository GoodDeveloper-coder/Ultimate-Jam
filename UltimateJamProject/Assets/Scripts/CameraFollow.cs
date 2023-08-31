using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Speed;
    public GameObject Player;
    public GameObject Camera;

    void FixedUpdate()
    {
        Vector3 target = new Vector3()
        {
            x = Player.transform.position.x,
            y = Player.transform.position.y,
            z = Player.transform.position.z - 10,
        };
        Camera.transform.position = Vector3.Lerp(Camera.transform.position, target, Speed * Time.fixedDeltaTime);
    }
}
