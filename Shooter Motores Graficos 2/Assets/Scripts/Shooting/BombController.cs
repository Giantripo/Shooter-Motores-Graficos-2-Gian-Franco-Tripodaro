using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public  GameObject exp;
    public float velDisparo;
    public Rigidbody balaPrefab;
    public Transform disparador;
    public Rigidbody balaImpulso;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
            Destroy(_exp, 3);
            balaImpulso = Instantiate(balaPrefab, disparador.position, Quaternion.identity);
            //le añade una fuerza al prefab para que sea disparado

        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
            Destroy(_exp, 3);
            Destroy(this.gameObject);
            balaImpulso = Instantiate(balaPrefab, disparador.position, Quaternion.identity);
        }

    }

}
