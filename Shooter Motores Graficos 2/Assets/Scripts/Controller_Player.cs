using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    public Camera cam;
    private Rigidbody rb;
    private Renderer render;
    public static Controller_Player _Player;
    private Vector3 movement;
    private Vector3 mousePos;
    internal Vector3 shootAngle;
    private Vector3 startPos;
    private bool started = false;
    public static float speed = 5;
    public static bool move = false;
    
    public TimeController timeController;
    
    private void Start()
    {
        //si el juego compienza sin player, es decir, se destruyo tras perder y tocar la R, lo que hace es que lo regenera en la posicion determinada y reinicia su disparo
        if (_Player == null)
        {
            _Player = this.gameObject.GetComponent<Controller_Player>();
        }
        startPos = this.transform.position;
        rb = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
        Restart._Restart.OnRestart += Reset;
        started = true;
        Controller_Shooting._ShootingPlayer.OnShooting += Shoot;
    }

    private void OnEnable()
    {
        if (started)
            Restart._Restart.OnRestart += Reset;
    }

    private void Reset()
    {
      
        this.transform.position = startPos;
    }

    private void Update()
    {
       
        //instancia el movimeinto en x y z
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        //hace que el player siga el mouse con la mirada. transforma la posiscion del mouse en una coordenada en el escenario
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Controller_Shooting.ammo = Ammo.Bomb;
          
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            
            Controller_Shooting.ammo = Ammo.ray;
           
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Controller_Shooting.ammo = Ammo.Frozen;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Controller_Shooting.ammo = Ammo.star;
        }

        if(movement.x !=0 || movement.y != 0)
        {
            move = true;
        }
        else
        {
            move = false;
        }
      
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

     //retorna el ultimo angulo al que se movio al personaje
    public Vector3 GetLastAngle()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            shootAngle = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            shootAngle = Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            shootAngle = Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            shootAngle = Vector3.right;
        }
        return shootAngle;
    }
    
    public virtual void OnCollisionEnter(Collision collision)
    {
        //si el jugador colisiona contra un enemy o enemy proyectile, se activa el texto de gameover y el player se desactiva
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyProjectile"))
        {
            gameObject.SetActive(false);
            Controller_Hud.gameOver = true;
        }
        //si el player colisiona contra un power up, se genera un numero aleatorio entre 1 y 3 que se carga en la variable rnd


        if (collision.gameObject.CompareTag("PowerUp"))
        {
            int rnd = UnityEngine.Random.Range(1, 3);
            //segun el numero que salio, consiguio un arma u otra
            if (rnd == 1)
            {
                Controller_Shooting.ammo = Ammo.Shotgun;
                Controller_Shooting.ammunition = 5;
            }
            else if (rnd == 2)
            {
                Controller_Shooting.ammo = Ammo.Cannon;
                Controller_Shooting.ammunition = 5;
            }
            else
            {
                Controller_Shooting.ammo = Ammo.Bumeran;
                Controller_Shooting.ammunition = 1;
            }
            //destruye el power up
            Destroy(collision.gameObject);
        }
        
        //if (collision.gameObject.CompareTag("Bumeran"))
        //{
        //    Controller_Shooting.ammo = Ammo.Bumeran;
        //    Controller_Shooting.ammunition = 1;
        //    Destroy(collision.gameObject);
        //}
    }
    // si el player colisiona con el bumeran, se recarga la municion de bumeran en 1 y lo destruye (ahora no empuja al player)
    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Bumeran"))
        {
            Controller_Shooting.ammo = Ammo.Bumeran;
            Controller_Shooting.ammunition = 1;
            Destroy(other.gameObject);
        }
    }
    


    void OnDisable()
    {
        Controller_Shooting._ShootingPlayer.OnShooting -= Shoot;
        Restart._Restart.OnRestart -= Reset;
    }

    private void Shoot()
    {
        if (Controller_Shooting.ammo == Ammo.Cannon)
        {
            rb.AddForce(this.transform.forward * -4f, ForceMode.Impulse);
        }
    }
}
