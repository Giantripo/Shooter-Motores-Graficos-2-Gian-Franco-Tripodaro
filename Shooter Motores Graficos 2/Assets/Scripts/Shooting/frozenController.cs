using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frozenController : MonoBehaviour
{
    public float velDisparo;
    public Rigidbody balaPrefab;
    public Transform disparador;
    public Rigidbody balaImpulso;
    public float cont;

    void Start()
    {
        cont = 1;
    }


    void Update()
    {
        cont -= Time.deltaTime;

        if (cont < 0)
        {
            //instancia el prefab en una posicion determinada
            balaImpulso = Instantiate(balaPrefab, disparador.position, Quaternion.identity);
            //le añade una fuerza al prefab para que sea disparado
            balaImpulso.AddForce(disparador.forward * 100 * velDisparo);
            cont = 3;
        }
    }
}
