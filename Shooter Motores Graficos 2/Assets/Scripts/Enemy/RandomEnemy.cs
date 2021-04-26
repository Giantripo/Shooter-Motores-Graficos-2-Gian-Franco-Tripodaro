using UnityEngine;

public class RandomEnemy : Controller_Enemy
{
    private void FixedUpdate()
    {
        PatrolBehaviour();
    }

    private void PatrolBehaviour()
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
}
