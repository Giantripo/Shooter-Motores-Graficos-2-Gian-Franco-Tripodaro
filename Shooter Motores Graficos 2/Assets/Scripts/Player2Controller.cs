using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float motorForce;
    public float motorForce2;
    public float speed;
    public bool move=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            move = true;
            motorForce = 0.5f + speed * 2;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            move = true;
            motorForce =0.5f+ speed * -2;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            move = true;
            motorForce2 =0.5f+ speed * -2;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            move = true;
            motorForce2 =0.5f+ speed * 2;
        }
        move = false;
     
        GetComponent<Rigidbody>().AddForce(motorForce2, 0, motorForce);

   


    }
}
