using UnityEngine;

public class Controller_Shooting : MonoBehaviour
{
    
    public delegate void Shooting();
    public event Shooting OnShooting;
    public static Ammo ammo;
    public static int ammunition;
    public static Controller_Shooting _ShootingPlayer;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject cannonPrefab;
    public GameObject pBomb;
    public GameObject bumeranPrefab;
    public GameObject Ray;
    public float bulletForce = 20f;
    private bool started = false;
    public GameObject pFrozen;
 
    public float x=0.1f, y=2, z=0.1f;
    public Vector3 newSize;
    public static bool rayActive = false;

    //instancia el shooting en el awake haciendolo nulo, pero despues pasa a ser true sin entrar al else ya que lo hace despues
    private void Awake()
    {
        if (_ShootingPlayer == null)
        {
            _ShootingPlayer = this.gameObject.GetComponent<Controller_Shooting>();
            Debug.Log("Shooting es nulo");
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
       
        //vuelve a instanciar el shooting por el respawn 
        if (_ShootingPlayer == null)
            {
                _ShootingPlayer = this.gameObject.GetComponent<Controller_Shooting>();
            }

        Restart._Restart.OnRestart += Reset;
        started = true;
        ammo = Ammo.Bumeran;
        ammunition = 1;
    }

    private void OnEnable()
    {
        if (started)
            Restart._Restart.OnRestart += Reset;
    }

    private void Reset()
    {
       
        Ray.transform.localScale = new Vector3(0.3f, 0.2f,0.3f );
        ammo = Ammo.Bumeran;
        ammunition = 1;
    }

    void Update()
    {//entra a disparar y a check ammo cuando se hace click

    
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            CheckAmmo();
        }
    }

    private void CheckAmmo()
    {
        //cuando se acaba la municion de algun arma vuelve a tener el arma normal/pistola
        
            if (ammunition <= 0)
            {
              ammo = Ammo.Normal;
            }
    }

    private void Shoot()
    {    //si onshooting es true ejecuta onshooting
        if (OnShooting != null)
        {
            OnShooting();
        }
        //si se tiene el arma normal se instancia el prefab con su posicion y rotacion.
        if (ammo == Ammo.Normal)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            //se le añade una fuerza y un punto de seguimiento al rigid body
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }
        //si shotgun es true se entra a un for que repite una secuencia para que i valga mas de 0.2, el cual se instancia en -0.2, esto es para controlar la cantidad de las balas
        else if (ammo == Ammo.Shotgun)
        {
            Rigidbody rb;
            for (float i = -0.2f; i < 0.2f; i += 0.1f)
            {   //anula el rigid body
                rb = null;
                //instancia la bala 
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                //le instancia su rigid body
                rb = bullet.GetComponent<Rigidbody>();
                //se le añade la fuerza en cada direccion a cada bala, lo que hace que se generen mas de 1 bala
                rb.AddForce(new Vector3(firePoint.forward.x + i, firePoint.forward.y, firePoint.forward.z + i) * bulletForce, ForceMode.Impulse);
            }
            //la municion decrementa
            ammunition--;
        }
        //en caso de tener un cannon
        else if (ammo == Ammo.Cannon)
        {
            //se instancia la bala
            GameObject bullet = Instantiate(cannonPrefab, firePoint.position, firePoint.rotation);
            //instancia el rigid body
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            //se le añade una fuerza al rigidbody
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
            //se gasta la municion
            ammunition--;
        }
        //si se tiene el bumeran
        else if (ammo == Ammo.Bumeran)
        {
            //se instancia el bumeran
            GameObject bullet = Instantiate(bumeranPrefab, firePoint.position, firePoint.rotation);
            //instancia controller bumeran y lo carga en bm para despues igualar la posicion inicial con la direccion en la que fue disparado y la posicion
            Controller_Bumeran bm = bullet.GetComponent<Controller_Bumeran>();
            bm.startPos = firePoint.position;
            //instancia el rigidbody
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            //le añade una fuerza al bumeran 
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
            //decrementa la municion
            ammunition--;
        }
        if (ammo == Ammo.Bomb)
        {
            GameObject bullet = Instantiate(pBomb, firePoint.position, firePoint.rotation);
            //instancia el rigid body
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            //se le añade una fuerza al rigidbody
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
            //se gasta la municion
            Ray.transform.localScale = new Vector3(0.3f, 0.2f, 0.3f);
        }
        if (ammo == Ammo.ray)
        {
            Ray.transform.localScale = new Vector3(x, y, z);      
        }
        if(ammo == Ammo.Frozen)
        {
            GameObject bullet = Instantiate(pFrozen, firePoint.position, firePoint.rotation);
            //instancia el rigid body
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            //se le añade una fuerza al rigidbody
            //rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
            
            
        }
    }

    private void OnDisable()
    {
        Restart._Restart.OnRestart -= Reset;
    }
}
//estan cargados todos los tipos de armas, entra a este enum donde estan todas las clases para instanciar
public enum Ammo
{
    Normal,
    Shotgun,
    Cannon,
    Bumeran,
    Bomb,
    ray,
    Frozen

}
