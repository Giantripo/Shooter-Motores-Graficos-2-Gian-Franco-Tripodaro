using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemy : MonoBehaviour
{
    [Header("Projectile Settings")]
    public int nBullets;
    public float bSpeed;
    public GameObject bullet;

    [Header("Private Variables")]
    private Vector3 startpoint;
    private const float radius =1;



    // Update is called once per frame
    void Update()
    {
        
    }

    internal virtual void OnCollisionEnter(Collision collision)
    {
        //si toca un projectile, destruye ambos gameobject y aumenta 1 punto 
        if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("CannonBall") || collision.gameObject.CompareTag("Bumeran") || collision.gameObject.CompareTag("Bomb"))
        {

            startpoint = transform.position;
            spawnBullets(nBullets);

        }

    }

    private void spawnBullets(int _nBullets)
    {
        float angleStep = 360f / _nBullets;
        float angle = 0f;

        for (int i =0; i < _nBullets -1;i++)
        {
            //direccion de disparo calculos
            float bulletXPosition = startpoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float bulletYPosition = startpoint.y + Mathf.Sin((angle * Mathf.PI) / 180) * radius;

            Vector3 bulletVector = new Vector3(bulletXPosition, bulletYPosition, 0);
            Vector3 bulletMoveDirection = (bulletVector - startpoint).normalized * bSpeed;

            GameObject tmpObj = Instantiate(bullet, startpoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(bulletMoveDirection.x, 0, bulletMoveDirection.y);

            angle += angleStep;
        }
    }
}
