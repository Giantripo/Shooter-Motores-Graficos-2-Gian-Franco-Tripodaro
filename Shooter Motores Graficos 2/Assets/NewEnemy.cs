using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : Controller_Enemy
{
    public float velDisparo;
    public Rigidbody balaPrefab;
    public Transform disparador;
    public Rigidbody balaImpulso;
    public float cont;

    void Start()
    {
        cont = 1;
        PatrolBehaviour();
    }

    // Update is called once per frame
    public void PatrolBehaviour()
    {
        agent.SetDestination(destination);
        //comienza a restar
        destinationTime -= Time.deltaTime;
        //si destinationTime es menor a 0 destination comienza a ser un numero random entre -10 y 12 en X, 1 en Y y entre -12 y 9 en Z
        if (destinationTime < 0)
        {
            destination = new Vector3(Random.Range(-10, 12), 1, Random.Range(-12, 9));
            //destination = 4 para que despues de 4 segundos vuelva a valer < 0 y se vuelvan a mover 
            destinationTime = 4;
        }
    }

    private void Update()
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
