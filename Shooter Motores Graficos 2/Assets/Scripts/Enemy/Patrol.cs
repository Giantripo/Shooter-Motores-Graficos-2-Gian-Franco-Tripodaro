﻿using UnityEngine;

public class Patrol : Controller_Enemy
{
    private void FixedUpdate()
    {
        Patroling();
    }

    private void Patroling()
    {
        if (player != null)
        {
            var heading = player.transform.position - this.transform.position;
            var distance = heading.magnitude;
            //si distancia es menor a patrol distance, la cual vale 5, el agente setea su destino en la posicion a la que cambia el player 
            if (distance < patrolDistance)
            {
                agent.SetDestination(player.transform.position);
            }
            else
            {
                PatrolBehaviour();
            }
        }
    }

    private void PatrolBehaviour()
    {
        agent.SetDestination(destination);
        destinationTime -= Time.deltaTime;
        if (destinationTime < 0)
        {
            destination = new Vector3(Random.Range(-10, 12), 1, Random.Range(-12, 9));
            destinationTime = 4;
        }
    }
}
