﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller_Enemy : MonoBehaviour
{
    
    public float expForce =50 , radius=20;
    public static int numPatroler;
    internal GameObject player;
    internal NavMeshAgent agent;
    internal Renderer render;
    internal Vector3 destination;
    public float patrolDistance = 5;
    public float destinationTime = 4;
    public float enemySpeed;

    void Start()
    {
        render = GetComponent<Renderer>();
        Restart._Restart.OnRestart += Reset;
        destination = new Vector3(UnityEngine.Random.Range(-10, 12), 1, UnityEngine.Random.Range(-12, 9));
        agent = GetComponent<NavMeshAgent>();
        //busca al Player
        player = GameObject.Find("Player");
    }

    public void Reset()
    {
        Destroy(this.gameObject);
    }

    internal virtual void OnCollisionEnter(Collision collision)
    {
        //si toca un projectile, destruye ambos gameobject y aumenta 1 punto 
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Controller_Hud.points++;
        }
        //si toca un cannonball, destruye solo al enemy y aumenta 1 punto 
        if (collision.gameObject.CompareTag("CannonBall"))
        {
            Destroy(this.gameObject);
            Controller_Hud.points++;
        }
        //si toca un cannonball, destruye solo al enemy y aumenta 1 punto 
        if (collision.gameObject.CompareTag("Bumeran"))
        {
            Destroy(this.gameObject);
            Controller_Hud.points++;
        }
        if (collision.gameObject.CompareTag("Bomb"))
        {
           
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider nearby in colliders)
            {
                Rigidbody rigg = nearby.GetComponent<Rigidbody>();
                if (rigg != null)
                {
                    rigg.AddExplosionForce(expForce, transform.position, radius);
                }
            }

            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ray"))
        {
            Destroy(this.gameObject);
            Controller_Hud.points++;
        }
    }



        private void OnDestroy()
    {
        Instantiator.enemies.Remove(this);
    }

    private void OnDisable()
    {
        Restart._Restart.OnRestart -= Reset;
    }
}
