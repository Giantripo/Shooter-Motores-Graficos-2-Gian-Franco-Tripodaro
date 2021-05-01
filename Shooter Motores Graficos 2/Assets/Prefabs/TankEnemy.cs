using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    public GameObject tank2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    internal virtual void OnCollisionEnter(Collision collision)
    {
        //si toca un projectile, destruye ambos gameobject y aumenta 1 punto 
        if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("CannonBall") || collision.gameObject.CompareTag("Bumeran") ||collision.gameObject.CompareTag("Bomb"))
        {

            Instantiate(tank2);

        }
       
    }
}
