using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float motorForce;
    public float motorForce2;
    public float speed;



    
    private Rigidbody rb;
    private Renderer render;
    public static Controller_Player _Player;
    private Vector3 movement;
    private Vector3 mousePos;
    internal Vector3 shootAngle;
    private Vector3 startPos;
    private bool started = false;
    
    public static bool move = false;


    void Start()
    {
        
        startPos = this.transform.position;
        rb = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
        Restart._Restart.OnRestart += Reset;
        started = true;
    }

    private void OnEnable()
    {
        if (started)
            Restart._Restart.OnRestart += Reset;
    }

    private void Reset()
    {

        this.transform.position = new Vector3(-1.81f, 0.81f,0);
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    motorForce = 0.5f + speed * 2;
        //}
     
        //if (Input.GetKeyDown(KeyCode.G))
        //{
          
        //    motorForce =0.5f+ speed * -2;
        //}
        //if (Input.GetKeyDown(KeyCode.F))
        //{
           
        //    motorForce2 =0.5f+ speed * -2;
        //}
        //if (Input.GetKeyDown(KeyCode.H))
        //{
          
        //    motorForce2 =0.5f+ speed * 2;
        //}

        motorForce = Input.GetAxis("Vertical") * speed * 2;
        motorForce2 = Input.GetAxis("Horizontal") * speed * 2;

        GetComponent<Rigidbody>().AddForce(motorForce2, 0, motorForce);

    }

    public virtual void FixedUpdate()
    {
        //ejecuta movement 
        Movement();


    }

    private void Movement()
    {
        //hace el calculo para que el personaje se mueva
        // se necesita un movment, una posicion y una velocidad, por ahora son 0, por eso el player no se mueve hasta que se toca el input
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        //como es solo un transform de look at y funciona con el mouse solo hace falta aclarar los angulos en los que se va a mover, x y z, y la velociada con la que va a hacer el movimiento = 1
        transform.LookAt(new Vector3(mousePos.x, 1, mousePos.z));
    }
}
