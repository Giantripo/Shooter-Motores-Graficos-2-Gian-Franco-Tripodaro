public class Following : Controller_Enemy
{
    private void FixedUpdate()
    {
        FollowingBehaviour();
    }

    private void FollowingBehaviour()
    {
        //si player es true el agente setea su destino en la posicion que toma el player
        if (player != null )
        {
            agent.SetDestination(player.transform.position);
        }
    }
}
