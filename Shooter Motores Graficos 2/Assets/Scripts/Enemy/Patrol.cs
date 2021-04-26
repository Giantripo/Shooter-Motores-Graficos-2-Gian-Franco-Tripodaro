using UnityEngine;

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
            //si distancia es menor a patrol distance, la cual vale 5, el agente setea su destino en la posicion a la que cambia el player, si no, ejecuta patrolbehaviour 
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
        //comienza a restar
        destinationTime -= Time.deltaTime;
        //si destinationtime es menor a 0, destination pasa a valer un numero entre -10 y 20 en el eje X, 1 en el eje Y, y un numero random entre -12 y 9 en el eje Z
        if (destinationTime < 0)
        {
            destination = new Vector3(Random.Range(-10, 12), 1, Random.Range(-12, 9));
            //destination vuelve a valer 4
            destinationTime = 4;
        }
    }
}
