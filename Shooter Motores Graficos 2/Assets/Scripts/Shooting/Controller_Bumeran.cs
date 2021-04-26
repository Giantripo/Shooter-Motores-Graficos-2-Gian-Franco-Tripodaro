using UnityEngine;

public class Controller_Bumeran : MonoBehaviour
{
    private Controller_Player parent;
    private Rigidbody rb;
    private CapsuleCollider collider;
    private Vector3 direction;
    public Vector3 startPos;
    public float maxDistance;
    public float bumeranSpeed;
    private float travelDistance;
    private float colliderTimer = 0.07f;
    private bool going;
    public int aber;

    void Start()
    {
        //estalbece going como true, que es la variable que se se encarga de la posicion inicial y el cambio de posicion
        //tambien desactiva el colider hasta que lo necesita
        parent = Controller_Player._Player;
        rb = GetComponent<Rigidbody>();
        Restart._Restart.OnRestart += Reset;
        collider = GetComponent<CapsuleCollider>();
        collider.enabled = false;
        going = true;
    }

    private void Reset()
    {
        //si el juego se resetea destruye el boomeran
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        //si going es true, traveldistance pasa a ser igual a la posicion inicial, menos en la que termin
        Rotate();
        if (going)
        {
            travelDistance = (startPos - transform.position).magnitude;
              
            if (travelDistance > maxDistance)
            {
                CheckDirection(); //hace que no siga de largo
            }
        }
        //si going entra a returntoplayer
        else
        {
            ReturnToPlayer();
        }
    }

    void Update()
    {
        //activa el colider cuando colider es menor a 0 
        colliderTimer -= Time.deltaTime;

        if (colliderTimer < 0)
        {
            collider.enabled = true;
        }
        //si going es true traveldistance comienza a ser igual a la posicion inicial menos la posicion a la que fue
        if (going)
        {
            travelDistance = (startPos - transform.position).magnitude;
        }
    }

    private void CheckDirection()
    {
        //hace que going sea false, 
        going = false;
        rb.velocity = Vector3.zero;
        //si player es true entra a la siguiente linea, cheque ala direccion para que se quede quieto y no siga de largo
        if (Controller_Player._Player != null)
        {
            direction = -(this.transform.localPosition - parent.transform.localPosition).normalized;
        }
    }
    //hace que rote el boomeran
    private void Rotate()
    {
        transform.Rotate(new Vector3(10, 0, 0));
    }
    //le añade una direccion y velocidad al rigid body para que vuelva en la direccion en la que fue lanzado
    private void ReturnToPlayer()
    {
        rb.AddForce(direction * bumeranSpeed);
    }

    private void OnDisable()
    {
        Restart._Restart.OnRestart -= Reset;
    }
}
